using Marriage.Infrastructure.Data;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// Add Controllers
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular", policy =>
    {
        policy.WithOrigins("http://localhost:4200", "https://bondhonmideacenter.com")
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
    });
});

// JWT Authentication
builder.Services.AddAuthentication("Bearer")
.AddJwtBearer("Bearer", options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});
// ✅ Register your LocationSeederService
builder.Services.AddHttpClient<LocationSeederService>();
var app = builder.Build();
//using (var scope = app.Services.CreateScope())
//{
//    var seeder = scope.ServiceProvider.GetRequiredService<LocationSeederService>();
//    await seeder.SeedAllLocationsAsync();
//}
app.Use(async (context, next) =>
{
    context.Response.Headers["Cross-Origin-Opener-Policy"] = "unsafe-none";
    context.Response.Headers["Cross-Origin-Embedder-Policy"] = "unsafe-none";
    await next();
});
// Serve wwwroot
app.UseStaticFiles();

// Ensure selfies folder exists and is served
var selfiesPath = Path.Combine(builder.Environment.WebRootPath, "selfies");
if (!Directory.Exists(selfiesPath))
    Directory.CreateDirectory(selfiesPath);

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(selfiesPath),
    RequestPath = "/selfies"
});



// 2️⃣ HTTPS redirection
app.UseHttpsRedirection();

// 3️⃣ CORS
app.UseCors("AllowAngular");

// 4️⃣ Authentication & Authorization
app.UseAuthentication();
app.UseAuthorization();

// 5️⃣ Swagger
app.UseSwagger();
app.UseSwaggerUI();

// 6️⃣ Map controllers
app.MapControllers();

app.Run();