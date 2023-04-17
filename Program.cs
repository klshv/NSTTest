using System.Text.Json.Serialization;
using Test_App;
using Test_App.App.Interfaces.DataServices;
using Test_App.App.Interfaces.Services;
using Test_App.App.Services;
using Test_App.Data;
using Test_App.Data.Services;
//using Test_App.App.Interfaces.Services;
//using Test_App.App.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(options =>
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));


builder.Services.AddDbContext<TestAppDbContext>();
builder.Services.AddAutoMapper(typeof(TestAppAutoMapperProfile));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => { });

builder.Services.AddTransient<IPersonService, PersonService>();
builder.Services.AddTransient<IPersonDataService, PersonDataService>();


builder.Services.AddCors(options => options.AddDefaultPolicy(p => p
    .AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Test App API");
        c.InjectStylesheet("/swagger/custom.css");
        c.RoutePrefix = String.Empty;
    });
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();