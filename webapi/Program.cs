using CandleShop.DataAccess;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// ���������� �������� � ���������.
builder.Services.AddControllers();

builder.Services.AddDbContext<IDatabaseContext, DatabaseContext>(options =>
{
    string? connection = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseSqlServer(connection);
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// ��������� ��������� HTTP-�������.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();