﻿using ECommerceAPI.Application.Repositories.CustomerRepos;
using ECommerceAPI.Application.Repositories.OrderRepos;
using ECommerceAPI.Application.Repositories.ProductRepos;
using ECommerceAPI.Persistence.Contexts;
using ECommerceAPI.Persistence.Repositories.CustomerRepos;
using ECommerceAPI.Persistence.Repositories.OrderRepos;
using ECommerceAPI.Persistence.Repositories.ProductRepos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Persistence
{
	public static class ServiceRegistration
	{
		public static void AddPersistenceServices(this IServiceCollection services)
		{
			services.AddDbContext<ECommerceAPIDbContext>(options => options.UseNpgsql(Configuration.ConnectionString), ServiceLifetime.Singleton);
			services.AddSingleton<IProductReadRepository, ProductReadRepository>();
			services.AddSingleton<IProductWriteRepository, ProductWriteRepository>();
			services.AddSingleton<ICustomerReadRepository, CustomerReadRepository>();
			services.AddSingleton<ICustomerWriteRepository, CustomerWriteRepository>();
			services.AddSingleton<IOrderReadRepository, OrderReadRepository>();
			services.AddSingleton<IOrderWriteRepository, OrderWriteRepository>();
		}
	}
}
