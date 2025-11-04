namespace Observer_Pattern.User
{
    internal class User
    {
        private Account _userAccount { get; set; }

        public User(Account userAccount)
        {
            _userAccount = userAccount;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"\n✅ Account created successfully!");
            Console.WriteLine($"🆔 ID: {_userAccount.Id}");
            Console.WriteLine($"👤 Name: {_userAccount.Name}");
        }
    }
}
