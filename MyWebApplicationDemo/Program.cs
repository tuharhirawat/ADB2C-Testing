//using Microsoft.EntityFrameworkCore;
//using MyWebApplicationDemo.Models;

//var builder = WebApplication.CreateBuilder(args);

//// Add CORS policy
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowReactApp", policy =>
//    {
//        policy.WithOrigins("http://localhost:5173") // React app URL
//              .AllowAnyHeader()
//              .AllowAnyMethod()
//              .AllowCredentials();
//    });
//});

//builder.Services.AddDbContext<MyWebAppDbContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//builder.Services.AddControllers();
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//var app = builder.Build();

//// ✅ Use the correct CORS policy name
//app.UseCors("AllowReactApp");

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();
//app.UseAuthorization();
//app.MapControllers();
//app.Run();

















//using Microsoft.AspNetCore.Authentication.JwtBearer;
//using Microsoft.IdentityModel.Tokens;
//using Microsoft.EntityFrameworkCore;
//using MyWebApplicationDemo.Models;
//using System.Text;

//var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowReactApp", policy =>
//    {
//        policy.WithOrigins("http://localhost:5173") // React app URL
//              .AllowAnyHeader()
//              .AllowAnyMethod()
//              .AllowCredentials();
//    });
//});

//builder.Services.AddDbContext<MyWebAppDbContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//var azureAdB2COptions = builder.Configuration.GetSection("AzureAdB2C");

//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//    .AddJwtBearer(options =>
//    {
//        options.Authority = $"{azureAdB2COptions["Instance"]}{azureAdB2COptions["Domain"]}/v2.0/{azureAdB2COptions["SignUpSignInPolicyId"]}/";
//        options.Audience = azureAdB2COptions["ClientId"];

//        options.TokenValidationParameters = new TokenValidationParameters
//        {
//            ValidateIssuer = true,
//            ValidIssuer = $"{azureAdB2COptions["Instance"]}{azureAdB2COptions["Domain"]}/v2.0/",

//            ValidateAudience = true,
//            ValidAudience = azureAdB2COptions["Audience"],

//            ValidateLifetime = true,
//            ValidateIssuerSigningKey = true,

//            IssuerSigningKey = new SymmetricSecurityKey(
//                Convert.FromBase64String(builder.Configuration["JwtSettings:Key"])
//            )
//        };
//    });

//builder.Services.AddControllers();
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//var app = builder.Build();

//app.UseAuthentication();
//app.UseAuthorization();

//app.UseCors("AllowReactApp");

//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();
//app.MapControllers();
//app.Run();


















using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using MyWebApplicationDemo.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp", policy =>
    {
        policy.WithOrigins("http://localhost:5173") // React app URL
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
    });
});

builder.Services.AddDbContext<MyWebAppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var azureAdB2COptions = builder.Configuration.GetSection("AzureAdB2C");

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = $"{azureAdB2COptions["Instance"]}{azureAdB2COptions["Domain"]}/v2.0/{azureAdB2COptions["SignUpSignInPolicyId"]}/";
        options.Audience = azureAdB2COptions["ClientId"];

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = $"{azureAdB2COptions["Instance"]}{azureAdB2COptions["Domain"]}/v2.0/{azureAdB2COptions["SignUpSignInPolicyId"]}/",

            ValidateAudience = true,
            ValidAudience = azureAdB2COptions["Audience"],

            ValidateLifetime = true,
            ValidateIssuerSigningKey = true
        };
    });

builder.Services.AddControllers();

// 🔹 Add Swagger Authentication Support
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });

    var securityScheme = new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Description = "Enter 'Bearer {token}'",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT"
    };

    var securityRequirement = new OpenApiSecurityRequirement
    {
        { securityScheme, new string[] {} }
    };

    c.AddSecurityDefinition("Bearer", securityScheme);
    c.AddSecurityRequirement(securityRequirement);
});

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.UseCors("AllowReactApp");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();

















//using Microsoft.EntityFrameworkCore;
//using MyWebApplicationDemo.Models;

//var builder = WebApplication.CreateBuilder(args);

//// Add database context
//builder.Services.AddDbContext<MyWebAppDbContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//builder.Services.AddControllers();
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//var app = builder.Build();

//app.UseHttpsRedirection();
//app.UseAuthorization();
//app.MapControllers();
//app.Run();
