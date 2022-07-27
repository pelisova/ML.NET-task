using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Services.Task;
using Core.DTOs;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class TaskController : BaseApiController
    {
        private readonly ITaskService _taskService;
        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpPost]
        public async Task<ActionResult<PVSystem>> CheckIsHealthy([FromBody] CreatePvSystemDto createPVSystemDto)
        {
            PVSystem task = null;
            try
            {
                task = await _taskService.CreatePvSystem(createPVSystemDto);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            string message = "";
            if (task != null)
            {
                if (task.IsHealthy == 1)
                {
                    message = "PV System is Healthy with the probability: " + @task.Probability;
                }
                else
                {
                    message = "PV System is Unhealthy with the probability: " + @task.Probability;
                }
                return Ok(message);
            }

            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpGet]
        public async Task<ActionResult<List<PVSystem>>> GetPvSystem()
        {
            var tasks = await _taskService.GetPvSystem();
            return (!tasks.Any()) ? NotFound() : Ok(tasks);
        }
    }
}