using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace API.Extensions;

public static class IdentityServiceExtensions
{
    public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
       .AddJwtBearer(options =>
       {
           var tokenKey = config["TokenKey"] ?? throw new Exception("TokenKey not found");
           var issuer = config["TokenIssuer"] ?? throw new Exception("TokenIssuer not found");
           var audience = config["TokenAudience"] ?? throw new Exception("TokenAudience not found");
           options.TokenValidationParameters = new TokenValidationParameters
           {
               ValidateIssuerSigningKey = true,
               IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey)),

               ValidateIssuer = true, // ✅ เปิดการตรวจสอบ issuer
               ValidIssuer = issuer,  // ✅ ตั้งค่าให้ตรงกับใน token

               ValidateAudience = true, // ถ้าไม่ใช้ก็ปิดไว้ได้
               ValidAudience = audience
           };
       });
        return services;
    }
}
