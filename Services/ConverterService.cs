using System.Runtime;
using UnitConverter.Models;
using UnitConverter.Services.Converters;

namespace UnitConverter.Services
{
    public class ConverterService : IConverterService
    {
        private readonly IReadOnlyList<IUnitConverter> _converters;

        public ConverterService(IEnumerable<IUnitConverter> converters)
        {
            _converters = converters.ToList();
        }

        public async Task<ConverterResponse> Convert(string fromUnit, string toUnit, double value)
        {
            var converter = _converters.FirstOrDefault(c =>
                c.CanConvert(fromUnit, toUnit));

            if (converter is null)
            {
                throw new ArgumentException(
                    $"Cannot convert from '{fromUnit}' to '{toUnit}'. " +
                    "Unit not supported or belong to different categories.");
            }

            var result = converter.Convert(fromUnit, toUnit, value);

            return new ConverterResponse
            {
                FromUnit = fromUnit.ToLowerInvariant(),
                ToUnit = toUnit.ToLowerInvariant(),
                OriginalValue = value,
                ConvertedValue = result,
                Category = converter.Category
            };
        }

        public IReadOnlyList<string> GetCategories() =>
        _converters.Select(c => c.Category).Distinct().ToList();

        public IReadOnlyList<UnitData> GetUnitsByCategory(string category)
        {
            var converter = _converters.FirstOrDefault(c =>
                c.Category.Equals(category, StringComparison.OrdinalIgnoreCase));

            if (converter is null)
            {
                throw new ArgumentException($"Category '{category}' is not supported.");
            }

            return converter.SupportedUnits;
        }
    }
}
