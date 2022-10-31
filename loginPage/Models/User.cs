namespace loginPage.Models
{
    public class User
    {
        public int id { get; set; }
        public String username { get; set; }
        public String password { get; set; }
        public String email { get; set; }
        public int IsActive { get; set; }
    }
}
