using System.Runtime;
using UnitConverter.Models;

namespace UnitConverter.Services.Converters
{
    public class TempConverter : IUnitConverter
    {
          public string Category => "temperature";

        private static readonly HashSet<string> Units = new(StringComparer.OrdinalIgnoreCase)
        {
            "celsius", "fahrenheit", "kelvin"
        };

        private static readonly Dictionary<string, string> Abbreviations = new(StringComparer.OrdinalIgnoreCase)
        {
          ["celsius"] = "°C",
          ["fahrenheit"] = "°F",
          ["kelvin"] = "K"
        };
        public IReadOnlyList<UnitData> SupportedUnits =>
                    Units.Select(u => new UnitData
                    {
                        Name = u,
                        Abbreviation = Abbreviations[u],
                        Category = Category
                    }).ToList();

        public bool CanConvert(string fromUnit, string toUnit) =>
                    Units.Contains(fromUnit) && Units.Contains(toUnit);

        public double Convert(string fromUnit, string toUnit, double value)
        {
          var from = fromUnit.ToLowerInvariant();
          var to = toUnit.ToLowerInvariant();
          if (from == to) return value;
      
          double celsius = from switch
          {
            "celsius" => value,
            "fahrenheit" => (value - 32) * 5.0 / 9.0,
            "kelvin" => value - 273.15,
            _=> throw new ArgumentException($"Unsupported unit: {fromUnit}")
          };

          double result = to switch
          {
            "celsius" => celsius,
            "fahrenheit" => celsius * 9.0 / 5.0 + 32,
            "kelvin" => celsius + 273.15,
            _ => throw new ArgumentException($"Unsupported unit: {toUnit}")
          };
          return Math.Round(result, 4);
        }
    }
}
