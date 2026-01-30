namespace StaffManager
{
    class Staff
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }

        public Staff(int id, string name, string role)
        {
            Id = id;
            Name = name;
            Role = role;
        }
    }
}
