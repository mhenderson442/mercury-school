using MercurySchool.Api.Extensions;
using MercurySchool.DataAccess.Repositories;
using MercurySchool.Models.Entities;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.RegisterServices();

var app = builder.Build();

app.AddMiddleware();
app.AddSchoolEndpoints();

app.Run();

public partial class Program
{ }