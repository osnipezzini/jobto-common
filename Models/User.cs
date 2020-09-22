namespace JobTo.Common.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public long EmployeeId { get; set; }
        public Person Employee { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }
    }
}
