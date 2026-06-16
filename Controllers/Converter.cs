using Microsoft.AspNetCore.Mvc;
using System.Runtime;
using UnitConverter.Models;
using UnitConverter.Services;

namespace UnitConverter.Controllers
{
    [ApiController]
    public class ConverterController : ControllerBase
    {
        private readonly IConverterService _converterService;
        public ConverterController(IConverterService converterService)
        {
            _converterService = converterService;
        }

        [HttpPost("convert")]
        public IActionResult Convert([FromBody] ConverterRequest request)
        {
            var result = _converterService.Convert(request.FromUnit,request.ToUnit,request.Value);
            return Ok(result);
        }

        [HttpGet("units")]
        public IActionResult GetCategories()
        {
            var categories = _converterService.GetCategories();
            return Ok(categories);
        }

        [HttpGet("units/{category}")]
        public IActionResult GetUnitsByCategory(string category)
        {
            var units = _converterService.GetUnitsByCategory(category);
            return Ok(units);
        }
    }

    public class ErrorResponse
    {
        public string Error { get; set; } = string.Empty;
    }
}
