using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;
using TestAPIWithSwagger.Models;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddMvc(c =>
       c.Conventions.Add(new SwaggerVersion.ApiExplorerGroupPerVersionConvention())//ورزن بندی سواگر
   );

//builder.Services.AddApiVersioning(o =>
//{
//    o.ReportApiVersions = true;
//    o.AssumeDefaultVersionWhenUnspecified = true;
//    o.DefaultApiVersion = new ApiVersion(1, 0);
//});

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API - V1", Version = "v1" });
    c.SwaggerDoc("v2", new OpenApiInfo { Title = "My API - V2", Version = "v2" });
    c.DocInclusionPredicate((_, api) => !string.IsNullOrWhiteSpace(api.GroupName));

    //داکیومنت های کد ها هم داخل این فایل برای نمایش درون سواگر ریخته شود
    // Set the comments path for the Swagger JSON and UI.
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath, includeControllerXmlComments: true);

    //توضیحات اضافه از HTML
    c.DocumentFilter<SwaggerVersion.TestDocumentFilter>();

});

//روش بدون ورژن تست شده اوکی بود
//// Register the Swagger generator, defining 1 or more Swagger documents
//builder.Services.AddSwaggerGen(c =>
//{
//    c.SwaggerDoc("v1", new OpenApiInfo
//    {
//        Version = "v1",
//        Title = "ToDo API",
//        Description = "A simple example ASP.NET Core Web API",
//        TermsOfService = new Uri("https://example.com/terms"),
//        Contact = new OpenApiContact
//        {
//            Name = "Shayne Boyer",
//            Email = string.Empty,
//            Url = new Uri("https://twitter.com/spboyer"),
//        },
//        License = new OpenApiLicense
//        {
//            Name = "Use under LICX",
//            Url = new Uri("https://example.com/license"),
//        }
//    });

///   //داکیومنت های کد ها هم داخل این فایل برای نمایش درون سواگر ریخته شود
//    // Set the comments path for the Swagger JSON and UI.
//    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
//    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
//    c.IncludeXmlComments(xmlPath, includeControllerXmlComments: true);
//});

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


// Enable middleware to serve generated Swagger as a JSON endpoint.
app.UseSwagger();

// Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.)


app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API - V1");
    c.SwaggerEndpoint("/swagger/v2/swagger.json", "My API - V2");
   
});

//نسخه بدون ورژن درست بود
//app.UseSwaggerUI(c =>
//{
//    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
//    //c.RoutePrefix = string.Empty; //اینو غیر فعال کنیم از ادرس بیس استفاده میشه
//    c.InjectStylesheet("/swagger-ui/custom.css");
//});

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
