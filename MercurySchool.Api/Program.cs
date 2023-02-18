var builder = WebApplication.CreateBuilder(args);


builder.Configuration.AddEnvironmentVariables();

builder.Configuration.AddAzureKeyVault(
        new Uri($"https://{builder.Configuration["KeyVaultName"]}.vault.azure.net/"),
        new DefaultAzureCredential());

var appSettings = builder.Configuration.GetSection("AppSettings").Get<AppSettings>();

builder.Services.AddSingleton((s) =>
{
    var serializationOptions = CosmosUtilities.CreateCosmosSerializationOptions();
    var configurationBuilder = new CosmosClientBuilder(appSettings?.CosmosConnectionString)
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
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
