using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using todolist_blazor_app;
using todolist_blazor_app.Data;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Her tilføjes din service, så den kan bruges fra views
builder.Services.AddSingleton<ToDoListService>();

// Sørge for at HttpClient også at tilgængelig rundt omkring
// Vi har brug for den inde i vores service
builder.Services.AddSingleton(sp => new HttpClient
{
    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
});

await builder.Build().RunAsync();
