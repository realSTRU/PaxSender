global using PaxSender.Models;

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

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
