using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.ML.OnnxRuntime.Tensors;

namespace Core.Entities
{
    public class PVSystem
    {
        public int Id { get; set; }
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

        // Add IsHealhy property and dynamically fill it
        [Required]
        public int IsHealthy { get; set; }
        [Required]
        public float Probability { get; set; }

    }
}