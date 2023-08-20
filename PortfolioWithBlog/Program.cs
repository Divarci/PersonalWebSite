using RepositoryLayer.Extensions;
using ServiceLayer.Exceptions.Middleware;
using ServiceLayer.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.LoadRepositoryLayerExtensions(builder.Configuration);
builder.Services.LoadServiceLayerExtensions(builder.Configuration);



var app = builder.Build();

//using( var scope = app.Services.CreateScope())
//{
//    var rolemanager  = scope.ServiceProvider.GetRequiredService<RoleManager<AppRole>>();
//    await RoleSeed.RoleAdd(rolemanager);
//}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseMiddleware<ExceptionHandlerWithLogging>();


    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/Home/PageNotFound");
//app.UseExceptionHandler("/Home/GeneralException");

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseMiddleware<SecurityStampCheck>();
app.UseMiddleware<RefreshCookie>();


app.UseNToastNotify();
app.UseEndpoints(endpoints =>
{
    endpoints.MapAreaControllerRoute(
        name: "Admin",
        areaName: "Admin",
        pattern: "Admin/{controller=Dashboard}/{action=Index}/{id?}"
        );
    endpoints.MapAreaControllerRoute(
       name: "User",
       areaName: "User",
       pattern: "User/{controller=Dashboard}/{action=Index}/{id?}"
       );
     endpoints.MapAreaControllerRoute(
       name: "GuildWarsTwo",
       areaName: "GuildWarsTwo",
       pattern: "GuildWarsTwo/{controller=Dashboard}/{action=Index}/{id?}"
       );
    endpoints.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
});


app.Run();
