using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.Mappings;
using BusinessLayer.Services.Task;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.ML.OnnxRuntime;

namespace BusinessLayer
{
    public static class BusinessLayerExtensions
    {
        public static IServiceCollection AddBusinessLayer(this IServiceCollection services)
        {
            var mapperList = new List<Profile>();

            mapperList.Add(new MappingTasks());

            services.AddScoped<ITaskService, TaskService>();
            services.AddSingleton<InferenceSession>(new InferenceSession("../BusinessLayer/Model/model.onnx"));

            services.AddAutoMapper(c => c.AddProfiles(mapperList), typeof(List<Profile>));


            return services;
        }
    }
}