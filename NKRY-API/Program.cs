using Microsoft.EntityFrameworkCore;
using NKRY_API.DataAccess.EFCore;
using NKRY_API.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ApplicationContext>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("NKRY-APIContext") ??
throw new InvalidOperationException("Connections string: NKRY-APIContext was not found")));


// Add services to the container.
builder.Services.AddControllers();
// Add this service to the container to get run on runtime
builder.Services.ConfigureUnitOfWork();

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

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");

// set up our api to use attribute based routing
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
}
);

app.Run();
