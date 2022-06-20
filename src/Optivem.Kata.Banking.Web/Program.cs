using Optivem.Kata.Banking.Web.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Register(builder.Configuration);

builder.Configuration
    .AddEnvironmentVariables();

var app = builder.Build();

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
public partial class Program { }