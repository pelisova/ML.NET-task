using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.ML.OnnxRuntime.Tensors;

namespace Core.DTOs
{
    public class CreatePvSystemDto
    {
        [Required]
        public string? PvSystemId { get; set; }
        public string? Description { get; set; }
        [Required]
        public int StatusCode { get; set; }
        [Required]
        public int Connected { get; set; }
        [Required]
        public int Riso { get; set; }
        [Required]
        public float PerformanceRatio { get; set; }
        [Required]
        public int Temp { get; set; }

        public int? IsHealthy { get; set; }

        public float? Probability { get; set; }
    }

    public class Data
    {
        public float StatusCode { get; set; }
        public float Connected { get; set; }
        public float Riso { get; set; }
        public float PerformanceRatio { get; set; }
        public float Temp { get; set; }

        public Tensor<float> AsTensor()
        {
            float[] data = new float[]
            {
                StatusCode, Connected, Riso, PerformanceRatio, Temp
            };
            int[] dimensions = new int[] { 1, 5 };
            return new DenseTensor<float>(data, dimensions);
        }
    }
}