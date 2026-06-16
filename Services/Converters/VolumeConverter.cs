using System.Runtime;
using UnitConverter.Models;

namespace UnitConverter.Services.Converters
{
    public class VolumeConverter : IUnitConverter
    {
        public string Category => "volume";

        private static readonly Dictionary<string, double> ToBaseUnit = new(StringComparer.OrdinalIgnoreCase)
        {
            ["liter"] = 1.0,
            ["milliliter"] = 0.001,
            ["gallon"] = 3.78541,
            ["quart"] = 0.946353,
            ["pint"] = 0.473176,
            ["cup"] = 0.236588
        };

        private static readonly Dictionary<string, string> Abbreviations = new(StringComparer.OrdinalIgnoreCase)
        {
            ["liter"] = "L",
            ["milliliter"] = "mL",
            ["gallon"] = "gal",
            ["quart"] = "qt",
            ["pint"] = "pt",
            ["cup"] = "cup"
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
