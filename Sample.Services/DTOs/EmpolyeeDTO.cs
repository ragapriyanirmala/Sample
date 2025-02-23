﻿namespace Sample.Services.DTOs
{
    public class EmpolyeeDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string? EmployeeImageUrl { get; set; }
        public BranchDTO Branch { get; set; }
        public TeamDTO Team { get; set; }   
    }
}
