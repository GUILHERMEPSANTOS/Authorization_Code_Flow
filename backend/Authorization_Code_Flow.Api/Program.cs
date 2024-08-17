using Authorization_Code_Flow.Api.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddIdpService(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddCors(config =>
 config.AddPolicy("All", policy => policy
    .AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod())
);

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("All");
app.UseRouting();
app.MapControllers();

app.Run();
