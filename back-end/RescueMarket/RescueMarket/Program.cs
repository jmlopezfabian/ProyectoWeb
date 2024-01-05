using RescueMarket.Context;
var builder = WebApplication.CreateBuilder(args);
RMContext database = new RMContext();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
database.Database.EnsureCreated();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
