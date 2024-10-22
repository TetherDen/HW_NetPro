var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello WebServer!");


app.MapPost("/auth", async (HttpContext httpContext) =>
{
    var form = httpContext.Request.Form;

    string? name = form["name"];
    string? email = form["email"];
    string? password = form["password"];

    // ......  Тут логика проверки и добавления пользователя в БД

    // Возращаем данные
    await httpContext.Response.WriteAsync($"Name: {name}   Email:{email}    Password: {password}");
});



app.Run();