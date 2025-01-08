using Sample.Datahub.Models.Domain;

namespace Sample.Datahub.Repository
{
    public interface IEmployeeData
    {
        List<Employee> Get();
        Employee? GetById(Guid id);
        Employee Create(Employee employee);
        Employee Update(Employee employee);
        void Delete(Employee employee);
    }
}
