namespace CrossStitchWebApp.ViewModel
{
    public class EditUserDashboardViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? ProfileImageurl { get; set; }
        public IFormFile Image { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }
}
