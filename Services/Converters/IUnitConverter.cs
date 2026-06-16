using System.Runtime;
using UnitConverter.Models;

namespace UnitConverter.Services.Converters
{
    public interface IUnitConverter
    {
        public string Category { get; }
        public IReadOnlyList<UnitData> SupportedUnits { get; }
        public bool CanConvert(string fromUnit, string toUnit);
        public double Convert(string fromUnit, string toUnit, double value);
    }
}
