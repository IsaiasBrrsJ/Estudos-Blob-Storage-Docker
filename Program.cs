
using EstudiesDocker.Data;
using EstudiesDocker.Strategi;
using Microsoft.AspNetCore;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddTransient<IPaymentStrategyContext, PaymentStrategyContext>();

var config = builder.Configuration;
builder
    .Services.AddDbContext<DataContext>(options =>
    {
        var connetion = config.GetConnectionString("SqlServer");
        
        options.UseSqlServer(connetion);

        
    });


// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


using(var appMigration = app.Services.CreateScope())
{
    var service = appMigration.ServiceProvider.GetService<DataContext>();

    await service!.Database.MigrateAsync();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

}







app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.Run();

