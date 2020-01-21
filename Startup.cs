using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StudyTogether.API.Data;
using StudyTogether.API.Services;

namespace StudyTogether.API
{
    //Api programos pradzia
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
            //nustatymai reikalingi prisijungti prie duomenu bazes
            // prisijungimo duomenys nurodomi appsettings.json faile
            services.AddDbContext<StudyTogetherDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
           // sukuriamos interface ir klasiu instance 
            services.AddTransient<StudyTogetherDbContext>();
            services.AddTransient<IQuestionsServices, QuestionsServices>();
            services.AddTransient<IStudentsServices, StudentsServices>();
            services.AddTransient<IQuizesServices, QuizesServices>();
            services.AddTransient<IAnswersServices, AnswersServices>();
            services.AddTransient<IGradeServices, GradeServices>();
            // Kontroleriai komunikacijai su klient programa
            services.AddControllers();
                
            services.AddSwaggerDocument();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            // reikalinga, kad butu galima gauti http uzklausas
            app.UseOpenApi();
            // swager irankui naudoti
            app.UseSwaggerUi3();
           

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
