using EmployeeManagement.Enums;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Models
{
    public class EmployeeModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DepartmentEnum Department { get; set; }
        public bool Active { get; set; }
        public ShiftEnum Shift { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.UtcNow.ToLocalTime();
        public DateTime ChangeDate { get; set; } = DateTime.UtcNow.ToLocalTime();
    }
}
