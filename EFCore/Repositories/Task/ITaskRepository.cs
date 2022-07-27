using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace EFCore.Repositories.Task
{
    public interface ITaskRepository
    {
        Task<PVSystem> CreatePvSystem(PVSystem pvSystem);
        Task<List<PVSystem>> GetPvSystem();
    }
}