using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Monolithic_mvc_temp.Models;
using Monolithic_mvc_temp.Services.Interfaces;
using Monolithic_mvc_temp.UnitOfWork;
using Monolithic_mvc_temp.ViewModels;

namespace Monolithic_mvc_temp.Services.Implementations
{
    public class EmpService : IEmpService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmpService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<int> CreateEmpAsync(EmployeeVm empVm)
        {
            try
            {
                if (Validate(empVm))
                {
                    var Emp = new Employee
                    {
                        Name = empVm.Name,
                        Designation = empVm.Designation,
                        Email = empVm.Email,
                        PhoneNumber = empVm.PhoneNumber
                    };
                    await _unitOfWork.Employee.CreateAsync(Emp);
                    await _unitOfWork.SaveChangesAsync();
                    return Emp.Id;
                }
            }
            catch (System.Exception)
            {
                throw;
            }
            return 0;
        }

        public async Task<int> UpdateEmpAsync(EmployeeVm empVm)
        {
            try
            {
                var Emp = await _unitOfWork.Employee.GetByIdAsync(empVm.Id);
                if (Emp is null)
                {
                    return 0;
                }
                if (Validate(empVm))
                {
                    empVm.Name = Emp.Name;
                    empVm.Designation = Emp.Designation;
                    empVm.Email = Emp.Email;
                    empVm.PhoneNumber = Emp.PhoneNumber;
                    await _unitOfWork.Employee.UpdateAsync(Emp);
                    await _unitOfWork.SaveChangesAsync();
                    return Emp.Id;
                }
            }
            catch (System.Exception)
            {
                throw;
            }
            return 0;
        }
        public async Task<List<EmployeeVm>> GetAllEmpAsync()
        {
            try
            {
                var models = _unitOfWork.Employee.AsNoTracking();
                if (models != null)
                {
                    var modelVmlist = models.Select(s => new EmployeeVm
                    {
                        Id = s.Id,
                        Name = s.Name,
                        Designation = s.Designation,
                        Email = s.Email,
                        PhoneNumber = s.PhoneNumber
                    }) .ToList();

                    return modelVmlist;
                }
            }
            catch (System.Exception)
            {
                throw;
            }
            return null;
        }

        public async Task<EmployeeVm> GetEmpByIdAsync(int id)
        {
            try
            {
                var Emp = _unitOfWork.Employee.AsNoTracking().FirstOrDefault(x => x.Id == id);
                if (Emp != null)
                {
                    var empVm = new EmployeeVm
                    {
                        Id = Emp.Id,
                        Name = Emp.Name,
                        Designation = Emp.Designation,
                        PhoneNumber = Emp.PhoneNumber,
                        Email = Emp.Email
                    };
                    return empVm;
                }
            }
            catch (System.Exception e)
            {
                throw;
            }

            return null;
        }

        public async Task<bool> DeleteEmpAsync(int id)
        {
            try
            {
                var Emp = _unitOfWork.Employee.AsNoTracking().FirstOrDefault(x => x.Id == id);
                if (Emp != null)
                {
                    await _unitOfWork.Employee.DeleteAsync(Emp);
                    await _unitOfWork.SaveChangesAsync();
                    return true;
                }
            }
            catch (System.Exception e)
            {
                throw;
            }

            return false;
        }
        private bool Validate(EmployeeVm empVm)
        {
            bool valid = true;
            if (String.IsNullOrEmpty(empVm.Name))
            {
                valid = false;
            }
            if (String.IsNullOrEmpty(empVm.Designation))
            {
                valid = false;
            }
            return valid;
        }
    }
}