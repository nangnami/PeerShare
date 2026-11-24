namespace PeerShare.Services
{
    public static class SessionService
    {
        public static int UserId { get; private set; }
        public static string Username { get; private set; }
        public static string Email { get; private set; }

        public static bool IsLoggedIn
        {
            get { return UserId > 0; }
        }

        public static void StartSession(
            int userId, string username, string email)
        {
            UserId = userId;
            Username = username;
            Email = email;
        }

        public static void UpdateProfile(
            string username, string email)
        {
            Username = username;
            Email = email;
        }

        public static void EndSession()
        {
            UserId = 0;
            Username = null;
            Email = null;
        }
    }
}