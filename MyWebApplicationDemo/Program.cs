
//// update #1 on  2/12/2024

//using Microsoft.AspNetCore.Authentication.JwtBearer;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.IdentityModel.Tokens;
//using Microsoft.OpenApi.Models;
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
//            ValidIssuer = $"{azureAdB2COptions["Instance"]}{azureAdB2COptions["Domain"]}/v2.0/{azureAdB2COptions["SignUpSignInPolicyId"]}/",

//            ValidateAudience = true,
//            ValidAudience = azureAdB2COptions["Audience"],

//            ValidateLifetime = true,
//            ValidateIssuerSigningKey = true
//        };
//    });

//builder.Services.AddControllers();

//// 🔹 Add Swagger Authentication Support
//builder.Services.AddSwaggerGen(c =>
//{
//    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });

//    var securityScheme = new OpenApiSecurityScheme
//    {
//        Name = "Authorization",
//        Description = "Enter 'Bearer {token}'",
//        In = ParameterLocation.Header,
//        Type = SecuritySchemeType.Http,
//        Scheme = "Bearer",
//        BearerFormat = "JWT"
//    };

//    var securityRequirement = new OpenApiSecurityRequirement
//    {
//        { securityScheme, new string[] {} }
//    };

//    c.AddSecurityDefinition("Bearer", securityScheme);
//    c.AddSecurityRequirement(securityRequirement);
//});

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


// update #2 on  2/12/2024
//using Microsoft.AspNetCore.Authentication.JwtBearer;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.IdentityModel.Tokens;
//using Microsoft.OpenApi.Models;
//using MyWebApplicationDemo.Models;
//using System.Text;

//var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowReactApp", policy =>
//    {
//        policy.WithOrigins("http://localhost:5173") // React frontend URL
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
//        options.Authority = $"{azureAdB2COptions["Instance"]}{azureAdB2COptions["Domain"]}/v2.0/";
//        options.Audience = azureAdB2COptions["ClientId"];
//        options.TokenValidationParameters = new TokenValidationParameters
//        {
//            ValidateIssuer = true,
//            ValidIssuer = $"{azureAdB2COptions["Instance"]}{azureAdB2COptions["Domain"]}/v2.0/",

//            ValidateAudience = true,
//            ValidAudience = azureAdB2COptions["Audience"],

//            ValidateLifetime = true,
//            ValidateIssuerSigningKey = true
//        };
//    });

//builder.Services.AddControllers();

//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen(c =>
//{
//    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });

//    var securityScheme = new OpenApiSecurityScheme
//    {
//        Name = "Authorization",
//        Type = SecuritySchemeType.Http,
//        Scheme = "bearer",
//        BearerFormat = "JWT",
//        In = ParameterLocation.Header,
//        Description = "Enter the token from Azure AD B2C",
//        Reference = new OpenApiReference
//        {
//            Type = ReferenceType.SecurityScheme,
//            Id = "Bearer"
//        }
//    };
//    c.AddSecurityDefinition("Bearer", securityScheme);
//    c.AddSecurityRequirement(new OpenApiSecurityRequirement
//    {
//        { securityScheme, new string[] {} }
//    });
//});

//var app = builder.Build();

//app.UseCors("AllowReactApp");

//app.UseAuthentication();
//app.UseAuthorization();

//app.UseSwagger();
//app.UseSwaggerUI();

//app.MapControllers();

//app.Run();










// #1 update on 2/13/2025
//using Microsoft.AspNetCore.Authentication.JwtBearer;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.IdentityModel.Tokens;
//using Microsoft.OpenApi.Models;
//using MyWebApplicationDemo.Models;

//var builder = WebApplication.CreateBuilder(args);

//// CORS setup to allow React frontend
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowReactApp", policy =>
//    {
//        policy.WithOrigins("http://localhost:5173")
//              .AllowAnyHeader()
//              .AllowAnyMethod()
//              .AllowCredentials();
//    });
//});

//// Database context
//builder.Services.AddDbContext<MyWebAppDbContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//// Azure AD B2C Configuration
//var azureAdB2COptions = builder.Configuration.GetSection("AzureAdB2C");
//string instance = azureAdB2COptions["Instance"];
//string domain = azureAdB2COptions["Domain"];
//string clientId = azureAdB2COptions["ClientId"];
//string audience = azureAdB2COptions["Audience"];

//// JWT Authentication Setup
//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//    .AddJwtBearer(options =>
//    {
//        options.Authority = $"{instance}/{domain}/v2.0/";
//        options.Audience = clientId; // API Client ID
//        options.TokenValidationParameters = new TokenValidationParameters
//        {
//            ValidateIssuer = true,
//            ValidIssuer = $"{instance}/{domain}/v2.0/",

//            ValidateAudience = true,
//            ValidAudience = audience,

//            ValidateLifetime = true,
//            ValidateIssuerSigningKey = true
//        };
//    });

//builder.Services.AddControllers();
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen(c =>
//{
//    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });

//    var securityScheme = new OpenApiSecurityScheme
//    {
//        Name = "Authorization",
//        Type = SecuritySchemeType.Http,
//        Scheme = "bearer",
//        BearerFormat = "JWT",
//        In = ParameterLocation.Header,
//        Description = "Enter JWT token from Azure AD B2C",
//        Reference = new OpenApiReference
//        {
//            Type = ReferenceType.SecurityScheme,
//            Id = "Bearer"
//        }
//    };
//    c.AddSecurityDefinition("Bearer", securityScheme);
//    c.AddSecurityRequirement(new OpenApiSecurityRequirement
//    {
//        { securityScheme, new string[] {} }
//    });
//});

//var app = builder.Build();

//// Middleware
//app.UseCors("AllowReactApp");
//app.UseAuthentication();
//app.UseAuthorization();
//app.UseSwagger();
//app.UseSwaggerUI();
//app.MapControllers();
//app.Run();











using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MyWebApplicationDemo.Models;

var builder = WebApplication.CreateBuilder(args);

// Enable CORS for React frontend
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp", policy =>
    {
        policy.WithOrigins("http://localhost:5173") // React frontend URL
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
    });
});

// Configure database connection
builder.Services.AddDbContext<MyWebAppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var azureAdB2COptions = builder.Configuration.GetSection("AzureAdB2C");

// Configure JWT authentication for Azure AD B2C
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = $"{azureAdB2COptions["Instance"]}{azureAdB2COptions["Domain"]}/v2.0/";
        options.Audience = azureAdB2COptions["ClientId"];
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = $"{azureAdB2COptions["Instance"]}{azureAdB2COptions["Domain"]}/v2.0/",

            ValidateAudience = true,
            ValidAudience = azureAdB2COptions["ClientId"],  // Fix: Ensure correct Audience validation

            ValidateLifetime = true,
            ValidateIssuerSigningKey = true
        };
    });

builder.Services.AddControllers();

// Enable Swagger with JWT authentication support
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });

    var securityScheme = new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter the token from Azure AD B2C",
        Reference = new OpenApiReference
        {
            Type = ReferenceType.SecurityScheme,
            Id = "Bearer"
        }
    };
    c.AddSecurityDefinition("Bearer", securityScheme);
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        { securityScheme, new string[] {} }
    });
});

var app = builder.Build();

app.UseCors("AllowReactApp");

app.UseAuthentication();
app.UseAuthorization();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();
