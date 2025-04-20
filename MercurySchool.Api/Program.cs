var builder = WebApplication.CreateBuilder(args);

builder.RegisterServices();

var app = builder.Build();

app.AddMiddleware();
app.AddSchoolEndpoints();

app.Run();

public partial class Program
{ }