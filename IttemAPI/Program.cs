using IttemAPI.Configurations;

var builder = WebApplication.CreateBuilder(args);

#region Configuration

builder.Services.ConfigureController();
builder.Services.ConfigureServices(builder.Configuration);
builder.Services.AddHealthChecks();

#endregion

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

app.UseCors("CorsPolicy");
app.UseHttpsRedirection();
app.UseAuthorization();
app.ConfigureEndpoints(builder.Configuration.GetSection("EndPointsConfig"));

app.Run();