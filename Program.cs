global using PaxSender.Models;
global using PaxSender;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
//using PaxSender.DAL;
using PaxSender.BLL;
using PaxSender.Data;
using Radzen.Blazor;
using Radzen;
var builder = WebApplication.CreateBuilder(args);

var ConStr = builder.Configuration.GetConnectionString("ConStr");//conexion string

builder.Services.AddDbContext<Contexto>(con =>
  con.UseSqlite(ConStr)  // contexto
);
builder.Services.AddDbContext<PaxSenderContext>(con =>
  con.UseSqlite(ConStr)  // contexto
);

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<PaxSenderContext>();



builder.Services.AddTransient<SuplidorBLL>();// bll
builder.Services.AddTransient<CategoriaBLL>();// bll
builder.Services.AddTransient<ClienteBLL>();//bll
builder.Services.AddTransient<ArticuloBLL>();//bll
builder.Services.AddScoped<NotificationService>();//ServicioDeNotificaciones
builder.Services.AddScoped<DialogService>();//DialogService
builder.Services.AddScoped<SucursalBLL>();//bll
builder.Services.AddScoped<EntradaBLL>();//bll
builder.Services.AddScoped<SalidaBLL>();//bll
builder.Services.AddScoped<PedidoBLL>();//bll
builder.Services.AddScoped<AlmacenBLL>();//bll
builder.Services.AddScoped<EnvioBLL>();//bll
builder.Services.AddScoped<VentaBLL>();//bll
builder.Services.AddScoped<AppStateService>();//Service



// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();


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




app.UseAuthentication();
app.UseRouting();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});





app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
