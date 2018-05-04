using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeveloperEvaluation.Util
{
    /// <summary>
    /// helper class to perform all calculations.
    /// </summary>
    public class CalculationHelper
    {
        private string[] inputs;
        private CalculationDTO dto;
        public CalculationHelper(IncomingDataDTO _inputs)
        {
            inputs = _inputs.input.Split(',');
            dto = new CalculationDTO();
        }
        /// <summary>
        /// Invokes internal calculation functions.
        /// </summary>
        /// <returns> A Calculation DTO which gets serialized</returns>
        public CalculationDTO Calculate()
        {
            CalculateMean(ref dto);
            CalculateMedian(ref dto);
            CalculateMode(ref dto);
            return dto;
        }
        /// <summary>
        /// Calculates the mean of a user provided value collection
        /// </summary>
        /// <param name="dto">reference to DTO object we will return to our angular client</param>
        internal void CalculateMean(ref CalculationDTO dto)
        {
            double result = 0;
            foreach(string s in inputs)
            {
                bool parsed = false;
                double temp = 0.0;
                parsed = Double.TryParse(s, out temp);
                if (parsed)
                {
                    result += temp;
                }
            }
            dto.mean = (result / inputs.Length);
        }
        /// <summary>
        /// Calculates the median of a user provided value collection
        /// </summary>
        /// <param name="dto">reference to DTO object we will return to our angular client</param>
        internal void CalculateMedian(ref CalculationDTO dto)
        {
            double[] convertedArray = Array.ConvertAll(inputs, Double.Parse);
            Array.Sort(convertedArray);
            if(convertedArray.Length % 2 != 0)
            {
                dto.median = convertedArray[(int)Math.Floor((Double)convertedArray.Length / 2)];
            }
            else
            {
                int lower = (convertedArray.Length / 2) - 1;
                int upper = convertedArray.Length / 2;
                dto.median = (convertedArray[lower] + convertedArray[upper]) / 2;
            }
        }
        /// <summary>
        /// Calculates the mode(s) of a user provided value collection
        /// </summary>
        /// <param name="dto">reference to DTO object we will return to our angular client</param>
        internal void CalculateMode(ref CalculationDTO dto)
        {
            Dictionary<double, int> instanceCount = new Dictionary<double, int>();
            foreach(string s in inputs)
            {
                bool parsed = false;
                double tempKey = 0.0;
                parsed = Double.TryParse(s, out tempKey);
                if (parsed)
                {
                    if (instanceCount.ContainsKey(tempKey))
                    {
                        instanceCount[tempKey]++;
                    }
                    else
                    {
                        instanceCount.Add(tempKey, 1);
                    }
                }
            }
            dto.mode = new List<double>();
            int highestInstanceCount = 0;
            foreach(double key in instanceCount.Keys)
            {
                if(instanceCount[key] > highestInstanceCount)
                {
                    highestInstanceCount = instanceCount[key];
                }
            }
            dto.mode = instanceCount.Keys.Where(k => instanceCount[k] == highestInstanceCount).ToList();
        }

    }
}