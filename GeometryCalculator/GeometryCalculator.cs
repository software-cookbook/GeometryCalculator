using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NCalc;

namespace GeometryCalculator
{
    public class GeometryCalculator
    {
        private readonly GeometryInfoConfig _config;

        public GeometryCalculator(GeometryInfoConfig config)
        {
            _config = config;
        }


        public double Calculate(string shapeName, Dictionary<string, double> parameterValues)
        {
            var shape = _config.shapes.FirstOrDefault(s => s.name.ToLower() == shapeName.ToLower());
            if (shape == null)
            {
                throw new ArgumentException($"Shape {shapeName} not found in configuration");
            }

            var expression = new Expression(shape.areaFormula);

            foreach (var parameter in shape.parameters)
            {
                if (!parameterValues.ContainsKey(parameter))
                {
                    throw new ArgumentException($"Parameter {parameter} not found in parameter values");
                }

                expression.Parameters[parameter] = parameterValues[parameter];
            }
            
            return (double)expression.Evaluate();
        }
    }
}
