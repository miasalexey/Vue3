using System.Configuration;
using Data;
using Data.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.SpaServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using VueCliMiddleware;

var builder = WebApplication.CreateBuilder(args);
var connString = builder.Configuration.GetConnectionString("MyDB");



// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<Context>(o =>
{
    o.UseSqlServer(connString);
});

builder.Services.AddScoped<CriminalCaseService>();
builder.Services.AddScoped<PersonService>();
builder.Services.AddScoped<PersonsInCriminalCasesService>();
builder.Services.AddSpaStaticFiles(opt => opt.RootPath = "ClientApp/dist");

const string myAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: myAllowSpecificOrigins,
        policy  =>
        {
            policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
        });
});


var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSpaStaticFiles();
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.MapControllers();
app.UseCors(myAllowSpecificOrigins);



app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();

    // NOTE: VueCliProxy is meant for developement and hot module reload
    // NOTE: SSR has not been tested
    // Production systems should only need the UseSpaStaticFiles() (above)
    // You could wrap this proxy in either
    // if (System.Diagnostics.Debugger.IsAttached)
    // or a preprocessor such as #if DEBUG
    endpoints.MapToVueCliProxy(
        "{*path}",
        new SpaOptions { SourcePath = "ClientApp" },
        npmScript: (System.Diagnostics.Debugger.IsAttached) ? "serve" : null,
        regex: "Compiled successfully",
        forceKill: true
    );
});

app.Run();