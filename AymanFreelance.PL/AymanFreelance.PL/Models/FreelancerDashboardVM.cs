namespace AymanFreelance.PL.Models
{
    public class FreelancerDashboardVM
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string? Photo { get; set; }
        public List<ProjectTBL_VM> ProjectTBL_VM { get; set; } = new List<ProjectTBL_VM>();
    }
}
