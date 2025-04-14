﻿using LetterEater.Core.Models;

namespace LetterEater.Application.Services
{
    public interface IAdminsService
    {
        Task<Guid> CreateAdmin(Admin admin);
        Task<Guid> DeleteAdmin(Guid adminId);
        Task<List<Admin>> GetAllAdmins();
    }
}