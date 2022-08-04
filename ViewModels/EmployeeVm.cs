using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Monolithic_mvc_temp.ViewModels
{
    public class EmployeeVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
    }
}