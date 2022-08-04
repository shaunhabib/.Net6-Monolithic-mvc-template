using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Monolithic_mvc_temp.ViewModels;

namespace Monolithic_mvc_temp.Services.Interfaces
{
    public interface IEmpService
    {
        Task<int> CreateEmpAsync(EmployeeVm empVm);
        Task<int> UpdateEmpAsync(EmployeeVm empVm);
        Task<List<EmployeeVm>> GetAllEmpAsync();
        Task<EmployeeVm> GetEmpByIdAsync(int id);
        Task<bool> DeleteEmpAsync(int id);
    }
}