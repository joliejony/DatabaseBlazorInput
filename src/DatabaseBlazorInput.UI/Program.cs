using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using DatabaseBlazorInput.UI;
using System.Net.Http;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Point HttpClient at the API (adjust port if your API listens elsewhere)
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5133") });

await builder.Build().RunAsync();
