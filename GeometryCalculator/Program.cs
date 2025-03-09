using System.Text.Json;

namespace GeometryCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var configStr = File.ReadAllText("GeometryInfo.json");

            var config = JsonSerializer.Deserialize<GeometryInfoConfig>(configStr);

            var calculator = new GeometryCalculator(config);

            Console.WriteLine("Available shapes :");
            foreach (var shape in config.shapes)
            {
                Console.WriteLine($"{shape.name}");
            }

            Console.WriteLine("\nSelect a shape :");
            var shapeName = Console.ReadLine();

            var paramValues = new Dictionary<string, double>();
            var shapeConfig = config.shapes.FirstOrDefault(s => s.name.ToLower() == shapeName.ToLower());
            foreach (var shapeParam in shapeConfig.parameters)
            {
                Console.Write($"{shapeParam} : ");
                var paramValue = Console.ReadLine();
                paramValues[shapeParam] = double.Parse(paramValue);
            }

            var area = calculator.Calculate(shapeName, paramValues);
            Console.WriteLine($"Area of {shapeName} is {area}");
        }



    }
}
