using Microsoft.EntityFrameworkCore;
using ResumeStorage.Core.Services;
using ResumeStorage.Data;
using ResumeStorage.Services;

namespace ResumeStorage
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var mapper = AutoMapperConfig.CreateMapper();

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<ResumeDbContext>(options => {
                options.UseSqlServer(builder.Configuration.GetConnectionString("ResumeConnectionString"));
            });

            builder.Services.AddSingleton(mapper);

            builder.Services.AddTransient<IResumeDbContext, ResumeDbContext>();

            builder.Services.AddTransient<IBasicProfileService, BasicProfileService>();

            builder.Services.AddTransient<IExperienceService, ExperienceService>();

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
                pattern: "{controller=Resume}/{action=Index}");

            app.Run();
        }
    }
}