using GameStore.Api.Data;
using GameStore.Api.Data.Migrations;
using GameStore.Api.Dtos;
using GameStore.Api.endpoints;
using GameStore.Api.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddValidation();

builder.AddGameStoreDb();

var app = builder.Build();

app.MapGameEndpoints();

app.MigrateDb();

app.Run();