using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Service.Interfaces;
using TestTask.Domain.Models;
using TestTask.Service.Response;
using TestTask.DAL.Interfaces;
using System.Collections;
using TestTask.Domain.ViewModels;

namespace TestTask.Service.Implementations
{
    public class StaffService : IStaffService
    {
        private readonly IStaffRepository _staffRepository;

        public StaffService(IStaffRepository staffRepository)
        {
            _staffRepository = staffRepository;
        }

        /*public async Task<IBaseResponse<Staff>> GetPersonById(int  id)
        { 
            var baseResponse = new BaseResponse<Staff>();
            try
            {
                var person = await _staffRepository.Get(id);
                if (person == null)
                {
                    baseResponse.Description = "person not found";
                    baseResponse.StatusCode = StatusCode.NotFound;

                    return baseResponse;
                }

                baseResponse.Data = person;

                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<Staff>()
                {
                    Description = $"[GetPerson] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }*/

        public async Task<IBaseResponse<StaffViewModel>> AddPerson(StaffViewModel staffViewModel)
        {
            var baseResponse = new BaseResponse<StaffViewModel>();
            try
            {
                var person = new Staff()
                {
                    Name = staffViewModel.Name,
                    Email = staffViewModel.Email
                };

                await _staffRepository.Create(person);

                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<StaffViewModel>()
                {
                    Description = $"[AddPerson] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<bool>> DeletePerson(int id)
        {
            var baseResponse = new BaseResponse<bool>();
            try
            {
                var person = await _staffRepository.Get(id);
                if (person == null)
                {
                    baseResponse.Description = "person not found";
                    baseResponse.StatusCode = StatusCode.NotFound;

                    return baseResponse;
                }

                await  _staffRepository.Delete(person);

                return baseResponse;
            }
            catch(Exception ex)
            {
                return new BaseResponse<bool>()
                {
                    Description = $"[DeletePerson] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<IEnumerable<Staff>>> GetStaff()
        {
            var baseResponse = new BaseResponse<IEnumerable<Staff>>();
            try
            {
                var staff = await _staffRepository.Select();
                if (staff.Count == 0)
                { 
                    baseResponse.Description = "empty";
                    baseResponse.StatusCode = StatusCode.Success;

                    return baseResponse;
                }

                baseResponse.Data = staff;
                baseResponse.StatusCode = StatusCode.Success;

                return baseResponse;
            } 
            catch(Exception ex)
            {
                return new BaseResponse<IEnumerable<Staff>>()
                { 
                    Description = $"[GetStaff] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
    }
}