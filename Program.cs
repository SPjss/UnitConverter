using UnitConverter.Middleware;
using UnitConverter.Services;
using UnitConverter.Services.Converters;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IUnitConverter, LengthConverter>();
builder.Services.AddSingleton<IUnitConverter, TempConverter>();
builder.Services.AddSingleton<IUnitConverter, WeightConverter>();
builder.Services.AddSingleton<IUnitConverter, VolumeConverter>();


builder.Services.AddSingleton<IConverterService, ConverterService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Unit Converter API",
        Version = "v1",
        Description = "An API for converting values between different units of measurement."
    });
});

var app = builder.Build();

app.UseMiddleware<ExceptionhandlerMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();