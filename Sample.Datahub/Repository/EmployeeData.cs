﻿using Sample.Datahub.Models.Domain;

namespace Sample.Datahub.Repository
{
    public class EmployeeData : IEmployeeData
    {
        private readonly SampleDbContext _context;
        public EmployeeData(SampleDbContext context)
        {
            _context = context;
        }
        public List<Employee> Get()
        {
            var employees = _context.Employees.ToList();
            return employees;
        }
        public Employee? GetById(Guid id)
        {
            var employee = _context.Employees.FirstOrDefault(x => x.Id == id);
            //var employee = _context.Employees.Find(id);
           // var employee = _context.Employees.Where(x => x.Id == id);
           return employee;
        }
       

    }
}