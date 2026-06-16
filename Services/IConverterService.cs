using System.Runtime;
using UnitConverter.Models;

namespace UnitConverter.Services
{
    public interface IConverterService
    {
        public Task<ConverterResponse> Convert(string fromUnit, string toUnit, double value);
        public IReadOnlyList<string> GetCategories();
        public IReadOnlyList<UnitData> GetUnitsByCategory(string category);
    }
}
