using Chms.Infrastructure;
using Chms.Application;

var builder = WebApplication.CreateBuilder(args);

// Configure appsettings.json
builder.Host.ConfigureAppConfiguration((hostingContext, config) =>
{
    config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
          .AddJsonFile($"appsettings.{hostingContext.HostingEnvironment.EnvironmentName}.json", optional: true, reloadOnChange: true);
    config.AddEnvironmentVariables();
});

builder.Services.AddCors(options =>
            {
                options.AddPolicy("ChmsCorsPolicy", builder =>
                 builder.WithOrigins(new string[] { "*" })
                 .AllowAnyHeader()
                 .AllowAnyMethod());
            });

// Add services to the container.
builder.Services.AddChMSDapper(builder.Configuration);
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddDbContextAndIdentity(builder.Configuration);
builder.Services.AddJwtAuthentication(builder.Configuration);
builder.Services.AddApplicationLogic(builder.Configuration);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseCors("ChmsCorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
