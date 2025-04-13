﻿using LetterEater.Core.Models;
using LetterEater.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetterEater.DataAccess.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private readonly LetterEaterDbContext _context;

        public AdminRepository(LetterEaterDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Create(Admin admin)
        {
            bool adminExist = await _context.Admins.AnyAsync(u => u.AdminId == admin.AdminId);

            if (!adminExist)
            {
                throw new Exception("User doesn't exist");
            }

            var adminEntity = new AdminEntity()
            {
                AdminId = admin.AdminId,
                Name = admin.Name,
                Surename = admin.Surename,
                ContactNumber = admin.ContactNumber,
                Email = admin.Email,
                Password = admin.Password
            };

            await _context.Admins.AddAsync(adminEntity);
            await _context.SaveChangesAsync();

            return admin.AdminId;
        }

        public async Task<List<Admin>> Get()
        {
            bool adminExist = await _context.Admins.AnyAsync();

            if (!adminExist)
            {
                throw new Exception("Admins don't exist");
            }

            var adminEntity = await _context.Admins
                .AsNoTracking()
                .ToListAsync();

            var admins = adminEntity
                .Select(a => Admin.Create(a.AdminId, a.Name, a.Surename, a.ContactNumber, a.Email, a.Password))
                .ToList();

            return admins;
        }

        public async Task<Guid> Update(Guid adminId, string name, string surename, string contactNumber, string email, string password)
        {
            bool adminExist = await _context.Admins.AnyAsync(u => u.AdminId == adminId);

            if (!adminExist)
            {
                throw new Exception("User doesn't exist");
            }

            await _context.Admins
                .Where(b => b.AdminId == adminId)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(b => b.Name, b => name)
                    .SetProperty(b => b.Surename, b => surename)
                    .SetProperty(b => b.ContactNumber, b => contactNumber)
                    .SetProperty(b => b.Email, b => email)
                    .SetProperty(b => b.Password, b => password));

            return adminId;
        }

        public async Task<Guid> Delete(Guid adminId)
        {
            bool adminExist = await _context.Admins.AnyAsync(u => u.AdminId == adminId);

            if (!adminExist)
            {
                throw new Exception("User doesn't exist");
            }

            await _context.Admins
                .Where(b => b.AdminId == adminId)
                .ExecuteDeleteAsync();

            return adminId;
        }
    }
}