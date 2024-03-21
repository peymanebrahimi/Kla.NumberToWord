using Kla.NumberToWord.Api;
using Kla.NumberToWord.Application;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplication();
//builder.Services.AddExceptionHandler<ExceptionHandlerMiddleware>();

builder.Services.AddCors(o => o.AddPolicy("MyCorePolicy", b =>
{
    b.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
}));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.ConfigureExceptionHandler();

app.UseCors("MyCorePolicy");
app.UseHttpsRedirection();

app.UseAuthorization();

//app.UseExceptionHandler();

app.MapControllers();

app.Run();