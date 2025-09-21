using Backend.Database;

namespace Backend;

public class Program
{
    public static void Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
        
        builder.Services.AddControllers();
        builder.Services.AddDbContext<AppDbContext>();

        builder.Services.AddLogging();
        
        WebApplication app = builder.Build();

        app.UseHttpsRedirection();
                
        app.UseAuthentication();
        app.UseAuthorization();
        
        app.MapDefaultControllerRoute();

        app.Run();
    }
}