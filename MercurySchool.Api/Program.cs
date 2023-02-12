var builder = WebApplication.CreateBuilder(args);


builder.Configuration.AddEnvironmentVariables();

if (builder.Environment.IsEnvironment("Development"))
{
    builder.Configuration.AddUserSecrets("267b1952-4e37-4074-9ed7-62676de16dfc");
}

var vaultUri = $"https://{builder.Configuration["KeyVaultName"]}.vault.azure.net/";
;
var connectionString = builder.Configuration["cosmos-connection-string"];

builder.Services.AddSingleton((s) =>
{
    var serializationOptions = CosmosUtilities.CreateCosmosSerializationOptions();

    CosmosClientBuilder configurationBuilder = new CosmosClientBuilder(connectionString)
    .WithSerializerOptions(cosmosSerializerOptions: serializationOptions);

    return configurationBuilder.Build();
});


// Add factories
builder.Services.AddScoped<IDataAccessFactory, DataAccessFactory>();

// Add services to the container.
builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<IReferenceDataRepository, ReferenceDataRepository>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();

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

app.UseAuthorization();

app.MapControllers();

app.Run();
