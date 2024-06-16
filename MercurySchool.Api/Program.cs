var builder = WebApplication.CreateBuilder(args);

var credential = new DefaultAzureCredential();
builder.Configuration.AddAppConfigurations(credential);

var settings = builder.Configuration.GetSection("Settings").Get<Settings>();
builder.Services.AddAppServices(credential, settings!);

// Add services to the container.
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

app.MapSchools();
app.MapPersons();

app.Run();

public partial class Program
{ }