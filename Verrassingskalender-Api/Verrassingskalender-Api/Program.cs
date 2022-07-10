using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Verrassingskalender_Api.Database;
using Verrassingskalender_Api.Services;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          // Not secure, but for test app this is not an issue.
                          policy.WithOrigins("*")
                          .AllowAnyOrigin()
                         .AllowAnyMethod()
                         .AllowAnyHeader();
                      });
});

var folder = Environment.SpecialFolder.LocalApplicationData;
var path = Environment.GetFolderPath(folder);
var DbPath = System.IO.Path.Join(path, "VerrassingsKalender.db");

builder.Services.AddDbContext<VerrassingsKalenderContext>(
        options => options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=VerrassingsKalender"));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IGridFactory, GridFactory>();
builder.Services.AddScoped<IVerrassingsKalenderRepository, VerrassingsKalenderRepository>();
builder.Services.AddScoped<IGridService, GridService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

// Converts exceptions to consumable error message.
app.UseExceptionHandler(c => c.Run(async context =>
{
    var exception = context.Features
        .Get<IExceptionHandlerPathFeature>()
        .Error;
    var response = new { message = exception.Message };
    await context.Response.WriteAsJsonAsync(response);
}));
app.MapControllers();

app.Run();
