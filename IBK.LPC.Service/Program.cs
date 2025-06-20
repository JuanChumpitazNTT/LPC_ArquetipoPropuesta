using IBK.LPC.Application.IoC;
using IBK.LPC.Service.Extensions;
var builder = WebApplication.CreateBuilder(args);

//Registrar Inyeccion de Dependencias
builder.Services.AddDependencyInjectionInterfaces();

//Register los services 
builder.Services.AddServicesApi(builder.Configuration);

var app = builder.Build();
app.UseHttpsRedirection();
app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI();


app.Run();