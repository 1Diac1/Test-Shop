﻿using Microsoft.Extensions.DependencyInjection;
using Test_Shop.Application.Common.Behaviours;
using System.Reflection;
using FluentValidation;
using MediatR;

namespace Test_Shop.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            return services;
        }
    }
}
