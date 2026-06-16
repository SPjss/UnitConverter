using System.Runtime;
using UnitConverter.Models;

namespace UnitConverter.Services.Converters
{
    public class LengthConverter : IUnitConverter
    {
            public string Category => "length";

            // Conversion factors to base unit (meter)
            private static readonly Dictionary<string, double> ToBaseUnit = new(StringComparer.OrdinalIgnoreCase)
            {
                ["meter"] = 1.0,
                ["kilometer"] = 1000.0,
                ["centimeter"] = 0.01,
                ["millimeter"] = 0.001,
                ["mile"] = 1609.344,
                ["yard"] = 0.9144,
                ["foot"] = 0.3048,
                ["inch"] = 0.0254
            };

            private static readonly Dictionary<string, string> Abbreviations = new(StringComparer.OrdinalIgnoreCase)
            {
                ["meter"] = "m",
                ["kilometer"] = "km",
                ["centimeter"] = "cm",
                ["millimeter"] = "mm",
                ["mile"] = "mi",
                ["yard"] = "yd",
                ["foot"] = "ft",
                ["inch"] = "in"
            };

            public IReadOnlyList<UnitData> SupportedUnits =>
                ToBaseUnit.Keys.Select(u => new UnitData
                {
                    Name = u,
                    Abbreviation = Abbreviations[u],
                    Category = Category
                }).ToList();

            public bool CanConvert(string fromUnit, string toUnit) =>
                ToBaseUnit.ContainsKey(fromUnit) && ToBaseUnit.ContainsKey(toUnit);

            public double Convert(string fromUnit, string toUnit, double value)
            {
                var baseValue = value * ToBaseUnit[fromUnit.ToLowerInvariant()];
                return Math.Round(baseValue / ToBaseUnit[toUnit.ToLowerInvariant()], 4);
            }
        }
}
