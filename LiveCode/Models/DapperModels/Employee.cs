using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LiveCode.Models.DapperModels
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Department { get; set; }
        public int CompanyId { get; set; }
        [ForeignKey(nameof(CompanyId))]
        public Company? Company { get; set; }
    }

    public class Company
    {
        [Key]
        public int Id { get; set; }
        public string? CompanyName { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
