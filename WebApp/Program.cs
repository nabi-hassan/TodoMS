using WebApp.ServiceInterfaces;
using WebApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var mvcBuilder = builder.Services.AddRazorPages();

builder.Services.AddHttpClient("WebApiClient", (HttpClient) =>
{
    HttpClient.BaseAddress = new Uri(builder.Configuration["ApiBaseUrl"]);
}
);

// Add HttpClientService
builder.Services.AddScoped<IHttpClientService, HttpClientService>();

// Add DataService
builder.Services.AddScoped<IDataService, DataService>();

#if DEBUG
mvcBuilder.AddRazorRuntimeCompilation();
#endif

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
