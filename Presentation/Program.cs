using BusinessLayer;
using DataAccess;
using Microsoft.EntityFrameworkCore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddDependencyInjection();

//Add DB
string connString = builder.Configuration.GetConnectionString("DatabaseConnection");
builder.Services.AddDbContext<PRN_BookStoreContext>(options => {
    options.UseSqlServer(connString).EnableSensitiveDataLogging();
});

builder.Services.AddSession();

// Add services to the container.
builder.Services.AddRazorPages();

//ADD SESSION
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

WebApplication app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();
app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();
app.UseEndpoints(endpoints =>
{
    endpoints.MapRazorPages();
    endpoints.MapGet("/", c =>
    {
        c.Response.Redirect("/LoginPage");
        return Task.CompletedTask;
    });
});
app.Run();