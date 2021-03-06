using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;
using WhiskyMan.BusinessLogic.Authentication;
using WhiskyMan.BusinessLogic.Interfaces.Policy;
using WhiskyMan.BusinessLogic.Interfaces.Transactions;
using WhiskyMan.BusinessLogic.Policy;
using WhiskyMan.BusinessLogic.Policy.Transactions;
using WhiskyMan.BusinessLogic.Policy.Users;
using WhiskyMan.BusinessLogic.Transactions;
using WhiskyMan.BusinessLogic.Transactions.Operations;
using WhiskyMan.Entities.Auth;
using WhiskyMan.Repositories;
using WhiskyMan.Repositories.DatabaseStartup;
using WhiskyMan.Repositories.Interfaces;
using WhiskyMan.Repositories.Interfaces.Wrappers;
using WhiskyMan.Repositories.Mapping;
using WhiskyMan.Repositories.Wrappers;

namespace WhiskyMan
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
            services.AddIdentityCore<User>(opt =>
            {
                opt.Password.RequireNonAlphanumeric = false;
            })
                .AddRoles<Role>()
                .AddRoleManager<RoleManager<Role>>()
                .AddSignInManager<SignInManager<User>>()
                .AddRoleValidator<RoleValidator<Role>>()
                .AddEntityFrameworkStores<DataContext>();

            services.AddControllers();
            services.AddMvc()
                .AddFluentValidation(config => config.RegisterValidatorsFromAssemblyContaining<Models.User.UserModel>());

            //Sqlite database
            services.AddDbContext<DataContext>(
                optBuilder => optBuilder.UseSqlite(
                    Configuration.GetConnectionString("SqliteConnection"),
                    b => b.MigrationsAssembly("WhiskyMan.API"))
            );

            services.AddSingleton(MapperProvider.GetMapper());
            services.AddScoped<AuthService>();
            services.AddScoped<DataContext>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IBottleRepository, BottleRepository>();
            services.AddScoped<IDataContextWrapper, DataContextWrapper>();
            services.AddScoped<IBottleDescriptionRepository, BottleDescriptionRepository>();
            services.AddScoped<IUserManagerWrapper, UserManagerWrapper>();
            services.AddScoped<ISignInManagerWrapper, SignInManagerWrapper>();
            services.AddScoped<IRoleManagerWrapper, RoleManagerWrapper>();
            services.AddScoped<UpdateRolesOperation>();
            services.AddHttpContextAccessor();
            services.AddScoped<IRequestBodyAccessor, RequestBodyAccessor>();
            services.AddScoped<GetTransactionPriceOperation>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();
            services.AddScoped<ITransactionFacade, TransactionFacade>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).
                AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(Configuration.GetSection("AppSettings:Token").Value)),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });


            // policies
            services.AddScoped<IAuthorizationHandler, AddOwnTransactionHandler>();
            services.AddScoped<IAuthorizationHandler, ViewOwnUserInfoHandler>();

            services.AddAuthorization(opt =>
            {
                opt.AddPolicy(TransactionPolicies.AddOwnTransaction, policy =>
                    policy.Requirements.Add(new AddOwnTransactionRequirement()));
                opt.AddPolicy(UserPolicies.ViewOwnUserInfo, policy =>
                    policy.Requirements.Add(new ViewOwnUserInfoRequirement()));
            });
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

            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
