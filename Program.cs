using AppMvc.ExtendMethods;
using AppMvc.Models;
using AppMvc.Services;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.Configure<RazorViewEngineOptions>(options =>
{
    // /View/Controller/Action.cshtml
    // /MyView/Controller/Action.cshtml

    // {0} -> ten Action
    // {1} -> ten Controller
    // {2} -> ten Area
    options.ViewLocationFormats.Add("/MyView/{1}/{0}" + RazorViewEngine.ViewExtension);
});

// services.AddSingleton<ProductService>();
// services.AddSingleton<ProductService, ProductService>();
// services.AddSingleton(typeof(ProductService));
builder.Services.AddSingleton(typeof(ProductService), typeof(ProductService));
builder.Services.AddSingleton<PlanetService>();
//register DB Context
builder.Services.AddDbContext<AppDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("AppMvcConnectionString"));
});



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
app.AddStatusCodePage();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

// app.MapControllerRoute(
//     name: "default",
//     pattern: "{controller=Home}/{action=Index}/{id?}");

// app.MapRazorPages();

// /sayhi
app.MapGet("/sayhi", async (context) =>
{
    await context.Response.WriteAsync($"Hello ASP.NET MVC {DateTime.Now}");
});

// endpoints.MapControllers
// endpoints.MapControllerRoute
// endpoints.MapDefaultControllerRoute
// endpoints.MapAreaControllerRoute

// [AcceptVerbs]

// [Route]

// [HttpGet]
// [HttpPost]
// [HttpPut]
// [HttpDelete]
// [HttpHead]
// [HttpPatch]

// Area

app.MapControllers();

app.MapControllerRoute(
    name: "first",
    pattern: "{url:regex(^((xemsanpham)|(viewproduct))$)}/{id:range(2,4)}",
    defaults: new
    {
        controller = "First",
        action = "ViewProduct"
    }

);

app.MapAreaControllerRoute(
    name: "product",
    pattern: "/{controller}/{action=Index}/{id?}",
    areaName: "ProductManage"
);

// Controller khong co Area
app.MapControllerRoute(
    name: "default",
    pattern: "/{controller=Home}/{action=Index}/{id?}"
);

app.MapRazorPages();

app.Run();
