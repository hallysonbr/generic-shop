using GenericShop.Services.Orders.Application;
using GenericShop.Services.Orders.Infra;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplicationServices();
builder.Services.AddMongo();
builder.Services.AddRepositories();
builder.Services.AddMessageBus();
builder.Services.AddSubscribers();
builder.Services.AddConsulConfig(builder.Configuration);
builder.Services.AddRedisCache();

builder.Services.AddHttpClient();
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

app.UseHttpsRedirection();

app.UseRouting();

//app.UseAuthorization();

app.UseConsul();

app.MapControllers();

app.Run();