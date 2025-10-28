using TesteTecnico.API.EndPoints;
using TesteTecnico.API.Infraestrutura;

var builder = WebApplication.CreateBuilder(args);
builder.AdicionarContext();
builder.AdicionarSerializadorConfig();
builder.AdicionarSwagger();
builder.AdicionarAngularCors();

var app = builder.Build();
app.AddEndPointsEmpresas();
app.UseSwagger();   
app.UseSwaggerUI();
app.UseCors("AllowAngularApp");

app.Run();