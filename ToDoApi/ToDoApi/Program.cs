using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using ToDoApi;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<ToDoDBContext>();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors(builder =>
    builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader()
);

// if (app.Environment.IsDevelopment())
// {
app.UseSwagger();
app.UseSwaggerUI();
// }

// get all items records
app.MapGet("/items", async (ToDoDBContext context) => await context.Items.ToListAsync());

// get a task of specific id
app.MapGet("/items/{id}", async (ToDoDBContext context, int id) =>
{
    var item = await context.Items.FindAsync(id);
    if (item != null)
    {
        return Results.Ok(item);
    }
    else return Results.NotFound();
});

// create a new item
app.MapPost("/items", async (ToDoDBContext context, Item _item) =>
{
    context.Add(_item);
    await context.SaveChangesAsync();
    return Results.Created("/items", _item);
});

// update an item
app.MapPut("items/{id}", async (ToDoDBContext context, Item _item) =>
{
    var item = context.Items.Find(_item.Id);
    if (item != null)
    {
        item.IsComplete = _item.IsComplete;
        context.Items.Update(item);
        await context.SaveChangesAsync();
        return Results.NoContent();
    }
    else return Results.NotFound();
});

// delete an item
app.MapDelete("items/{id}", async (ToDoDBContext context, int id) =>
{
    var _item = context.Find<Item>(id);
    if (_item != null)
    {
        context.Remove(_item);
        await context.SaveChangesAsync();
        return Results.NoContent();
    }
    else return Results.NotFound();
});

app.MapGet("/", () => "ToDoList Server is RUNNING 🏃🏃‍♀️🏃‍♂️");
app.Run();