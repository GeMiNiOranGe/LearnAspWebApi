using Presentation;

using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPresentation();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUi(options =>
    {
        options.DocumentPath = "/openapi/v1.json";
    });
    app.MapScalarApiReference(options =>
    {
        Random random = new();
        ScalarTheme[] themes = Enum.GetValues<ScalarTheme>();
        ScalarTheme randomTheme = themes[random.Next(themes.Length)];
        options.WithTitle($"{options.Title} | {{documentName}} | {randomTheme} theme");
        options.WithTheme(randomTheme);
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
