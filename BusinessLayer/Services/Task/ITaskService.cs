using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DTOs;
using Core.Entities;

namespace BusinessLayer.Services.Task
{
    public interface ITaskService
    {
        Task<PVSystem> CreatePvSystem(CreatePvSystemDto createPVSystemDto);
        Task<List<PVSystem>> GetPvSystem();
    }
}