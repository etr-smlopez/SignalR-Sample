
var builder = WebApplication.CreateBuilder(args);


// Set the environment to Development
builder.Environment.EnvironmentName = "Development";

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSignalR(); // Add SignalR to the services

builder.Services.AddHostedService<MyBackgroundService>(); // Register the background service
//builder.Services.AddHostedService<Worker>();

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

app.MapHub<UpdateHub>("/updateHub"); // Map the SignalR hub
//app.MapHub<UpdateHub>("updateHub"); // Map the SignalR hub

app.Run();