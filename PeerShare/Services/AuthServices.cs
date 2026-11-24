using System;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using PeerShare.Data;

namespace PeerShare.Services
{
    public static class AuthService
    {
        // ==========================================
        // REGISTER ACCOUNT
        // ==========================================

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

            // Hash password before saving to SQL Server.
            string passwordHash =
                PasswordHasher.HashPassword(password);

            using (var db = new PeerShareDataContext())
            {
                try
                {
                    db.usp_User_Register(
                        username,
                        email,
                        passwordHash
                    );

                    return "SUCCESS";
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 50001)
                        return "Username is already taken.";

                    if (ex.Number == 50002)
                        return "Email is already registered.";

                    if (ex.Number == 2601 ||
                        ex.Number == 2627)
                        return "Username or email is already registered.";

                    throw;
                }
            }
        }

        // ==========================================
        // LOGIN ACCOUNT
        // ==========================================

        public static User Login(
            string usernameOrEmail,
            string password)
        {
            string identifier =
                (usernameOrEmail ?? "").Trim();

            if (identifier.Length == 0 ||
                identifier.Length > 100 ||
                string.IsNullOrEmpty(password) ||
                password.Length > 128)
                return null;

            using (var db = new PeerShareDataContext())
            {
                var user = db.usp_User_GetByLogin(identifier)
                    .FirstOrDefault();

                if (user == null)
                    return null;

                if (!PasswordHasher.VerifyPassword(
                    password, user.PasswordHash))
                    return null;

                // Convert stored procedure result
                // into our existing User entity.
                return new User
                {
                    UserId = user.UserId,
                    Username = user.Username,
                    Email = user.Email,
                    CreatedAt = user.CreatedAt
                };
            }
        }

        // ==========================================
        // TEST DATABASE CONNECTION
        // ==========================================

        public static bool TestConnection()
        {
            using (var db = new PeerShareDataContext())
            {
                db.Connection.Open();
                return true;
            }
        }
    }
}