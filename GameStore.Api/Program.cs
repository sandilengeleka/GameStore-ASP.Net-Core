using GameStore.Api.Dtos;
using GameStore.Api.endpoints;
using Microsoft.AspNetCore.Http.HttpResults;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddValidation();

var app = builder.Build();

app.MapGameEndpoint();

app.Run();