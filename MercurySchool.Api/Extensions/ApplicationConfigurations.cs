using MercurySchool.DataAccess.Repositories;
using MercurySchool.Models.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Data;

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