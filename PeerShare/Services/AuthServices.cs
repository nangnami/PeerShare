
using System;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using PeerShare.Data;

namespace PeerShare.Services
{
    public static class AuthService
    {
        private const string ConnectionString =
            @"Data Source=.\SQLEXPRESS;" +
            "Initial Catalog=PeerShareDB;" +
            "Integrated Security=True;" +
            "TrustServerCertificate=True;";

        public static string Register(
            string username,
            string email,
            string password,
            string confirmPassword)
        {
            username = (username ?? "").Trim();
            email = (email ?? "").Trim();

            if (username.Length < 3 || username.Length > 50)
                return "Username must contain 3 to 50 characters.";

            if (username.Contains("@"))
                return "Username cannot contain @.";

            if (email.Length == 0 || email.Length > 100)
                return "Enter a valid email address.";

            try
            {
                var address = new MailAddress(email);

                if (!string.Equals(address.Address, email,
                    StringComparison.OrdinalIgnoreCase))
                    return "Enter a valid email address.";
            }
            catch (FormatException)
            {
                return "Enter a valid email address.";
            }

            if (string.IsNullOrEmpty(password) ||
                password.Length < 12)
                return "Password must contain at least 12 characters.";

            if (password.Length > 128)
                return "Password must not exceed 128 characters.";

            if (password != confirmPassword)
                return "Passwords do not match.";

            using (var db = new PeerShareDataContext(ConnectionString))
            {
                bool usernameExists = db.Users.Any(
                    u => u.Username == username);

                if (usernameExists)
                    return "Username is already taken.";

                bool emailExists = db.Users.Any(
                    u => u.Email == email);

                if (emailExists)
                    return "Email is already registered.";

                var newUser = new User
                {
                    Username = username,
                    Email = email,
                    PasswordHash =
                        PasswordHasher.HashPassword(password),
                    CreatedAt = DateTime.Now
                };

                db.Users.InsertOnSubmit(newUser);

                try
                {
                    db.SubmitChanges();
                    return "SUCCESS";
                }
                catch (SqlException ex)
                {
                    // SQL Server unique constraint violation.
                    if (ex.Number == 2601 || ex.Number == 2627)
                        return "Username or email is already registered.";

                    throw;
                }
            }
        }

        public static User Login(
            string usernameOrEmail,
            string password)
        {
            string identifier = (usernameOrEmail ?? "").Trim();

            if (identifier.Length == 0 ||
                string.IsNullOrEmpty(password))
                return null;

            using (var db = new PeerShareDataContext(ConnectionString))
            {
                var user = db.Users.FirstOrDefault(
                    u => u.Username == identifier ||
                         u.Email == identifier);

                if (user == null)
                    return null;

                if (!PasswordHasher.VerifyPassword(
                    password, user.PasswordHash))
                    return null;

                // Return a detached copy of the account details.
                return new User
                {
                    UserId = user.UserId,
                    Username = user.Username,
                    Email = user.Email,
                    CreatedAt = user.CreatedAt
                };
            }
        }

        public static bool TestConnection()
        {
            using (var db = new PeerShareDataContext(ConnectionString))
            {
                db.Connection.Open();
                return true;
            }
        }
    }
}
