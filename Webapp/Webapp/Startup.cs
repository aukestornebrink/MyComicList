using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace Webapp;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<MyDbContext>(options => options.useMySQL(Configuration.GetConnectionString("default")));
        services.AddControllersWithViews();
    }

    private IConfiguration Configuration { get; }

    public void Configureservices(IServiceCollection services)
    {
        services.AddIdentity<IdentityUser, IdentityUser>();
    }
}