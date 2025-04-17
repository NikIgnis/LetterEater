using LetterEater.Core.Models;
using LetterEater.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetterEater.Application.Services
{
    public class AdminsService : IAdminsService
    {
        private readonly IAdminRepository _adminRepository;

        public AdminsService(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public async Task<Guid> CreateAdmin(Admin admin)
        {
            return await _adminRepository.Create(admin);
        }

        public async Task<List<Admin>> GetAllAdmins()
        {
            return await _adminRepository.Get();
        }

        public async Task<Guid> UpdateAdmin(Guid adminId, string name, string surename, string contactNumber, string email, string password)
        {
            return await _adminRepository.Update(adminId, name, surename, contactNumber, email, password);
        }

        public async Task<Guid> DeleteAdmin(Guid adminId)
        {
            return await _adminRepository.Delete(adminId);
        }
    }
}