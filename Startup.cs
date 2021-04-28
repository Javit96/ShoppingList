using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Logging;
using ShoppingList.Extensions;
using ShoppingList.Models;
using ShoppingList.Models.Auth;
using ShoppingList.Settings;


namespace ShoppingList
{
    public class Startup
    {
        public Startup()
        {
            var configurationBuilder = new ConfigurationBuilder()
              .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
              .AddEnvironmentVariables();

            Configuration = configurationBuilder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<JWTSettings>(Configuration.GetSection("JWTSettings"));
            var jwtSection = Configuration.GetSection("JWTSettings").Get<JWTSettings>();

            services.AddControllers();


            services.AddDbContext<ShoppingListContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("App_conection")));

            var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;

            services.AddIdentity<User, Role>(options =>
            {
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;

                options.User.RequireUniqueEmail = true;
                options.SignIn.RequireConfirmedEmail = true;


            })
                .AddEntityFrameworkStores<ShoppingListContext>()
            .AddDefaultTokenProviders();

            IdentityModelEventSource.ShowPII = true;

            services.AddAutoMapper(typeof(Startup));

            services.AddAuth(jwtSection);

            //to validate the token which has been sent by clients
            /* var appSettings = jwtSection.Get<JWTSettings>();
             var key = Encoding.ASCII.GetBytes(appSettings.SecretKey);

             services.AddAuthentication(x =>
             {
                 x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                 x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
             })
             .AddJwtBearer(x =>
             {
                 x.RequireHttpsMetadata = true;
                 x.SaveToken = true;
                 x.TokenValidationParameters = new TokenValidationParameters
                 {
                     ValidateIssuerSigningKey = true,
                     IssuerSigningKey = new SymmetricSecurityKey(key),
                     ValidateIssuer = false,
                     ValidateAudience = false,
                     ClockSkew = TimeSpan.Zero
                 };
             });

             services.AddMvc();*/
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuth();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
