# Unit Converter API

A lightweight RESTful API built with ASP.NET Core 8 for converting numerical values between different units of measurement.
 Supported Categories

| Category    | Units                                                        |
|-------------|--------------------------------------------------------------|
| Length      | meter, kilometer, centimeter, millimeter, mile, yard, foot, inch |
| Temperature | celsius, fahrenheit, kelvin                                  |
| Weight      | kilogram, gram, milligram, pound, ounce, ton                 |
| Volume      | liter, milliliter, gallon, quart, pint, cup                  |

Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)

Project Structure
UnitConverter/
├── Controllers/
│   └── ConverterController.cs     # API endpoints
├── Middleware/
│   └── ExceptionHandlerMiddleware.cs  # Global error handling
├── Models/
│   ├── ConverterRequest.cs        # Request model
│   ├── ConverterResponse.cs       # Response model
│   └── UnitData.cs                # Unit info model
├── Services/
│   ├── IConverterService.cs       # Service interface
│   ├── ConverterService.cs        # Conversion orchestration
│   └── Converters/
│       ├── IUnitConverter.cs      # Converter interface
│       ├── LengthConverter.cs
│       ├── TempConverter.cs
│       ├── WeightConverter.cs
│       └── VolumeConverter.cs
└── Program.cs




