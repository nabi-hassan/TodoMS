using NToastNotify;
using Serilog;
using WebApi.Middlewares;
using WebApp.ServiceInterfaces;
using WebApp.Services;

var builder = WebApplication.CreateBuilder(args);

//Create Logger from settings from appsettings.json
var logger = new LoggerConfiguration()
.ReadFrom.Configuration(builder.Configuration)
.CreateLogger();
//Add Logger
Log.Logger = logger;
builder.Host.UseSerilog(logger);


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

builder.Services.AddRazorPages().AddNToastNotifyToastr(new ToastrOptions()
{
    ProgressBar = true,
    PositionClass = ToastPositions.TopRight
});

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

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseStatusCodePagesWithReExecute("/Errors/Exception/{0}");

//Use Serilog
app.UseSerilogRequestLogging();

app.UseStaticFiles();
//Use NToastNotify
app.UseNToastNotify();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
