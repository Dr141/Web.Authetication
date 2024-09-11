using Web.Api.Extension;
using Web.Api.IoC;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.ConfigSwagger();
builder.Services.ConfigAuthentication(builder.Configuration);
builder.Services.RegistraServices(builder.Configuration);
var app = builder.Build();
app.Services.Migrations();
// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Web api de autenticação V1");
});
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseCors(builder => builder
    .SetIsOriginAllowed(orign => true)
    .AllowAnyMethod()
    .AllowAnyHeader()
    .AllowCredentials());

app.MapControllers();
app.Run();
