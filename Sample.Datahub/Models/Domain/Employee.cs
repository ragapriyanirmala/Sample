namespace Sample.Datahub.Models.Domain
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string? EmployeeImageUrl { get; set; }
        public Guid BranchId { get; set; }
        public Guid TeamId { get; set; }

        // Navigation Properties
        public Branch Branch { get; set; }
        public Team Team { get; set;  }

    }       
}
