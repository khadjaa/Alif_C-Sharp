using Erm.BusinessLayer;
using Erm.BusinessLayer.Validators;
using Erm.DataAccess;

using FluentValidation;

using Microsoft.EntityFrameworkCore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(options =>
{
    options.AddProfile<RiskProfileInfoProfile>();
});

builder.Services.AddDbContext<ErmDbContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection")));

builder.Services.AddStackExchangeRedisCache(options 
    => options.Configuration = builder.Configuration.GetConnectionString("RedisConnection"));

builder.Services.AddScoped<RiskProfileRepository>();
builder.Services.AddScoped<RiskProfileRepositoryProxy>();
builder.Services.AddScoped<IRiskProfileService, RiskProfileService>();

builder.Services.AddScoped<IValidator<RiskProfileInfo>, RiskProfileInfoValidator>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.UseMiddleware<ApiKeyMiddleware>();

app.MapControllers();
app.UseHttpsRedirection();
app.Run();