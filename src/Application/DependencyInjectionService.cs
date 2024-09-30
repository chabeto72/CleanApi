using Application.Configuration;
using Application.Database.User.Commands.CreateUser;
using Application.Database.User.Commands.DeleteUser;
using Application.Database.User.Commands.UpdateUser;
using Application.Database.User.Querys.GetAllTask;
using Application.Database.User.Querys.GetAllUser;
using Application.Database.User.Querys.GetUserByCodeDocumentNumber;
using Application.Database.User.Querys.GetUserById;
using Application.Validators.task;
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

            #region task
            //inyeccion de dependencias Commands           
            services.AddTransient<ICreateTaskCommand, CreateTaskCommand>();
            services.AddTransient<IUpdateTaskCommand, UpdateTaskCommand>();
            services.AddTransient<IDeleteTaskCommand, DeleteTaskCommand>();
            //inyeccion de dependencias Querys
            services.AddTransient<IGetAllTaskQuery, GetAllTaskQuery>();
            //services.AddTransient<IGetUserByIdQuery, GetUserByIdQuery>();
            //services.AddTransient<IGetUserByCodeDocumentNumberQuery, GetUserByCodeDocumentNumberQuery>();
            #endregion

            #region Validator
            services.AddScoped<IValidator<CreateUserModel>, CreateUserValidator>();
            services.AddScoped<IValidator<UpdateUserModel>, UpdateUserValidator>();
            services.AddScoped<IValidator<int>, GetByIdUserValidator>();
            services.AddScoped<IValidator<(string, string)>, GetUserByCodeDocumentNumberValidator>();
            services.AddScoped<IValidator<CreateTaskModel>, CreateTaskValidator>();
            services.AddScoped<IValidator<UpdateTaskModel>, UpdateTaskValidator>();
            services.AddScoped<IValidator<Guid>, DeleteTaskValidator>();
            #endregion


            return services;
        }
    }
}
