﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.Dto
{
    public class GetMoskowWeatherResultDto
    {
        public double Value { get; set; }
        public bool IsError { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
