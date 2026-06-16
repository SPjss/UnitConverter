using System.Runtime;
using UnitConverter.Models;

namespace UnitConverter.Services.Converters
{
    public class WeightConverter : IUnitConverter
    {
        public string Category => "weight";

        private static readonly Dictionary<string, double> ToBaseUnit = new(StringComparer.OrdinalIgnoreCase)
        {
            ["kilogram"] = 1.0,
            ["gram"] = 0.001,
            ["milligram"] = 0.000001,
            ["pound"] = 0.453592,
            ["ounce"] = 0.0283495,
            ["ton"] = 1000.0
        };

        private static readonly Dictionary<string, string> Abbreviations = new(StringComparer.OrdinalIgnoreCase)
        {
            ["kilogram"] = "kg",
            ["gram"] = "g",
            ["milligram"] = "mg",
            ["pound"] = "lb",
            ["ounce"] = "oz",
            ["ton"] = "t"
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
