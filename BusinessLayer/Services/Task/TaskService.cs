using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.DTOs;
using Core.Entities;
using EFCore.Repositories.Task;
using Microsoft.ML;
using Microsoft.ML.OnnxRuntime;
using Microsoft.ML.OnnxRuntime.Tensors;

namespace BusinessLayer.Services.Task
{
    public class TaskService : ITaskService
    {
        private readonly IMapper _mapper;
        private readonly ITaskRepository _taskRepository;
        private InferenceSession _session;
        public TaskService(IMapper mapper, ITaskRepository taskRepository, InferenceSession session)
        {
            _mapper = mapper;
            _taskRepository = taskRepository;
            _session = session;
        }

        public async Task<PVSystem> CreatePvSystem(CreatePvSystemDto createPVSystemDto)
        {
            //Here will be logic to call model, predict value and add that isHelathy value to existing dto.
            var data = new Data()
            {
                StatusCode = NormalizeData(createPVSystemDto.StatusCode),
                Connected = createPVSystemDto.Connected,
                Riso = createPVSystemDto.Riso,
                PerformanceRatio = createPVSystemDto.PerformanceRatio,
                Temp = NormalizeData(createPVSystemDto.Temp)
            };

            try
            {
                createPVSystemDto = checkIsHealthy(data, createPVSystemDto);
            }
            catch (System.Exception er)
            {
                throw er;
            }

            return await _taskRepository.CreatePvSystem(_mapper.Map<PVSystem>(createPVSystemDto));
        }

        public async Task<List<PVSystem>> GetPvSystem()
        {
            return await _taskRepository.GetPvSystem();
        }



        private CreatePvSystemDto checkIsHealthy(Data data, CreatePvSystemDto createPVSystemDto)
        {
            var modelInputLayerName = _session.InputMetadata.Keys.Single();
            var tensor = data.AsTensor();
            var input = new List<NamedOnnxValue>
            {
                NamedOnnxValue.CreateFromTensor<float>(modelInputLayerName, tensor)
            };

            var output = _session.Run(input);
            var result = output.Last().AsEnumerable<NamedOnnxValue>().First().AsDictionary<Int64, float>();
            var probability1 = output.Last().AsEnumerable<NamedOnnxValue>().First().AsDictionary<Int64, float>()[0];
            var probability2 = output.Last().AsEnumerable<NamedOnnxValue>().First().AsDictionary<Int64, float>()[1];
            var predicition1 = output.Last().AsEnumerable<NamedOnnxValue>().First().AsDictionary<Int64, float>().Keys.AsEnumerable().First();
            var predicition2 = output.Last().AsEnumerable<NamedOnnxValue>().First().AsDictionary<Int64, float>().Keys.AsEnumerable().Last();
            output.Dispose();

            if (probability1 < probability2)
            {
                createPVSystemDto.IsHealthy = (int)predicition2;
                createPVSystemDto.Probability = probability2;
            }
            else
            {
                createPVSystemDto.IsHealthy = (int)predicition1;
                createPVSystemDto.Probability = probability1;
            }

            return createPVSystemDto;
        }

        private float NormalizeData(int num)
        {
            float number = (float)(num);
            if (number == 1) return number;
            while (number > 1)
            {
                number = number / 10;
            }
            return number;
        }

    }


}