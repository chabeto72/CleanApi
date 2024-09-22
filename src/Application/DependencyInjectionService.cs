﻿using Application.Configuration;
using Application.Database.User.Commands.CreateUser;
using Application.Database.User.Commands.DeleteUser;
using Application.Database.User.Commands.UpdateUser;
using Application.Database.User.Querys.GetAllUser;
using Application.Database.User.Querys.GetUserByCodeDocumentNumber;
using Application.Database.User.Querys.GetUserById;
using Application.Validators.User;
using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependencyInjectionService
    {
        public static IServiceCollection addApplication(this IServiceCollection services)
        {
            var mapper = new MapperConfiguration(config => config.AddProfile(new MapperProfile()));
            services.AddSingleton(mapper.CreateMapper());
            #region User
            //inyeccion de dependencias Commands           
            services.AddTransient<ICreateUserCommand, CreateUserCommand>();
            services.AddTransient<IUpdateUserCommand, UpdateUserCommand>();
            services.AddTransient<IDeleteUserCommand, DeleteUserCommand>();
            //inyeccion de dependencias Querys
            services.AddTransient<IGetAllUserQuery, GetAllUserQuery>();
            services.AddTransient<IGetUserByIdQuery, GetUserByIdQuery>();
            services.AddTransient<IGetUserByCodeDocumentNumberQuery, GetUserByCodeDocumentNumberQuery>();
            #endregion

            #region Validator
            services.AddScoped<IValidator<CreateUserModel>, CreateUserValidator>();
            services.AddScoped<IValidator<UpdateUserModel>, UpdateUserValidator>();
            services.AddScoped<IValidator<int>, GetByIdUserValidator>();
            services.AddScoped<IValidator<(string, string)>, GetUserByCodeDocumentNumberValidator>();
            #endregion


            return services;
        }
    }
}
