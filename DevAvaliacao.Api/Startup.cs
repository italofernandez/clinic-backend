using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DevAvaliacao.Infra.DataContext;
using DevAvaliacao.Infra.Transactions.UnityOfWork;
using DevAvaliacao.Domain.DataContext.Services;
using DevAvaliacao.Application.DataContext.Services;

namespace DevAvaliacao.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(x => x.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyHeader()
                       .AllowCredentials()
                       .AllowAnyMethod()
                       .AllowAnyOrigin();
            }));

            services.AddEntityFrameworkNpgsql()
               .AddDbContext<DevAvaliacaoDataContext>()
               .BuildServiceProvider();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddScoped<DevAvaliacaoDataContext, DevAvaliacaoDataContext>();
            services.AddTransient<IUnityOfWork, UnityOfWork>();
            services.AddTransient<IConsultationService, ConsultationService>();
            services.AddTransient<IDoctorScheduleService, DoctorScheduleService>();
            services.AddTransient<IDoctorService, DoctorService>();
            services.AddTransient<IPatientService, PatientService>();
            services.AddTransient<ISpecialtyService, SpecialtyService>();
            services.AddTransient<IUserService, UserService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            // app.UseHttpsRedirection();
            app.UseCors("MyPolicy");
            app.UseMvc();
        }
    }
}
