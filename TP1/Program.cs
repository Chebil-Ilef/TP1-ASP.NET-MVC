using NuGet.Protocol.Plugins;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

/*Methode  custom routes*/
app.MapControllerRoute(
    name: "Release details",
    pattern: "{controller=Movie}/{Release}/{year}/{month}",
    defaults: new { controller = "Movie" ,action = "ByRelease"});



/* les differents systèmes de routage:
 
    - Default Route:

     app.UseEndpoints(endpoints =>{
        endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
     });

    - Custom Routes:

     app.MapControllerRoute(
    name: "Release details",
    pattern: "{controller=Movie}/{Release}/{year}/{month}",
    defaults: new { controller = "Movie" ,action = "ByRelease"});

    - Attribute Routing:

    [Route("api/[controller]")]
    public class MovieController : Controller
    {
    [HttpGet("Release/{year}/{month}")]
    public IActionResult ByRelease(int year, int month)
    {
        // Action logic
    }
    }


*/

//app.MapGet("/", () => "Hello World!");

app.Run();
