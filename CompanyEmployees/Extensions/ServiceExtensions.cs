using Contracts;
using FluentValidation;
using LoggerService;
using Microsoft.EntityFrameworkCore;
using Repository;

namespace CompanyEmployees.Extensions;

public static class ServiceExtensions
{
	public static void ConfigureCors(this IServiceCollection services) =>
		services.AddCors(options =>
		{
			options.AddPolicy("CorsPolicy", builder =>
			builder.AllowAnyOrigin()
			.AllowAnyMethod()
			.AllowAnyHeader());
		});

	public static void ConfigureIISIntegration(this IServiceCollection services) =>
		services.Configure<IISOptions>(options =>
		{
		});

	public static void ConfigureLoggerService(this IServiceCollection services) =>
		services.AddSingleton<ILoggerManager, LoggerManager>();

	public static void ConfigureRepositoryManager(this IServiceCollection services) =>
		services.AddScoped<IRepositoryManager, RepositoryManager>();

	public static void ConfigureMediatR(this IServiceCollection services)=>
	 services.AddMediatR(cfg=> cfg.RegisterServicesFromAssembly(typeof(Application.AssemblyReference).Assembly));

	public static void ConfigureAutoMapper(this IServiceCollection services)
	=> services.AddAutoMapper(typeof(Program));

	public static void ConfigureFluentValidation(this IServiceCollection services)
	=> services.AddValidatorsFromAssembly(typeof(Application.AssemblyReference).Assembly);

	public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) =>
		services.AddDbContext<RepositoryContext>(opts =>
			opts.UseSqlServer(configuration.GetConnectionString("sqlConnection")));
}
