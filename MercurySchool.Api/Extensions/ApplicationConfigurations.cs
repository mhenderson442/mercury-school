namespace MercurySchool.Api.Extensions;

public static class ApplicationConfigurations
{
    public static void AddMiddleware(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger()
               .UseSwaggerUI();
        }

        app.UseHttpsRedirection();
    }
}