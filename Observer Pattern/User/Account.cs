namespace Observer_Pattern.User
{
    internal class Account
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Password { get; set; }

        public Account(int id, string? name, string? password)
        {
            Id = id;
            Name = name;
            Password = password;
        }
    }
}
