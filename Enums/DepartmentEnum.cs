using System.Text.Json.Serialization;

namespace EmployeeManagement.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum DepartmentEnum
    {
        HR,
        Financial,
        Shopping,
        Janitorial
    }
}
