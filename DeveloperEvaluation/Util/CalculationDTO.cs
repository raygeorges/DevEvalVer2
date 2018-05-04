using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeveloperEvaluation.Util
{
    /// <summary>
    /// Simple dto to store our calculated values.
    /// </summary>
    public class CalculationDTO
    {
        public double mean { get; set; }
        public double median { get; set; }
        public List<double> mode { get; set; }
    }
}