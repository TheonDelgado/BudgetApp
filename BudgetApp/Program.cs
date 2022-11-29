using BudgetApp.Data;
using BudgetApp.Models;
using BudgetApp.Models.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    // .AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("BudgetAppConnectionString")));
    .AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("CoolInMemoryDatabase")); // use in memory db because i dont have a mssql setup :P

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();
builder.Services.AddHttpContextAccessor();

builder.Services.AddControllersWithViews();

var app = builder.Build();

SeedDatabase(app);

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.Run();





void SeedDatabase(WebApplication app)
{
    using var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetService<AppDbContext>();

    db.Categories.AddRange(new Category { Id = 1, CategoryName = "Business" },
        new Category { Id = 2, CategoryName = "Food" },
        new Category { Id = 3, CategoryName = "Personal" },
        new Category { Id = 4, CategoryName = "Other" });

    db.Transactions.Add(new Transaction
    {
        Id = Guid.NewGuid(),
        Amount = 1,
        CategoryId = 1,
        Date = DateTimeOffset.Now,
        Name = "test"
    });

    db.SaveChanges();
}