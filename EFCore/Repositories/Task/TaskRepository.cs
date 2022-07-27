using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using EFCore.Context;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Repositories.Task
{
    public class TaskRepository : ITaskRepository
    {
        private readonly DataContext _context;

        public TaskRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<PVSystem> CreatePvSystem(PVSystem pvSystem)
        {
            await _context.Tasks.AddAsync(pvSystem);
            _context.SaveChangesAsync();
            return await _context.Tasks.FirstOrDefaultAsync(t => t.PvSystemId == pvSystem.PvSystemId);
        }

        public async Task<List<PVSystem>> GetPvSystem()
        {
            return await _context.Tasks.OrderBy(t => t.Id).ToListAsync();
        }
    }
}