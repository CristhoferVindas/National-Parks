namespace NationalParks.Models.ViewModels
{
    public class UserWithRolesViewModel
    {
        public User User { get; set; }
        public List<string> Roles { get; set; }
    }
}
