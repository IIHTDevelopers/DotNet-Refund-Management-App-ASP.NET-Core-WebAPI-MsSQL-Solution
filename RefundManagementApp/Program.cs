using RefundManagementApp.BusinessLayer.Interfaces;
using RefundManagementApp.BusinessLayer.Services.Repository;
using RefundManagementApp.BusinessLayer.Services;
using RefundManagementApp.DataLayer;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<RefundManagementAppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration
        .GetConnectionString("ConnStr")); // for example if you're holding the connection string in the appsettings.json
});
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<IRefundManagementRepository, RefundManagementRepository>();
builder.Services.AddScoped<IRefundManagementService, RefundManagementService>();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
         .AllowAnyHeader()
         .AllowAnyMethod();
    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseStaticFiles();
app.UseCors();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();