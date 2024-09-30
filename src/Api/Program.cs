using Api;
using Common;
using Application;
using External;
using Persistence;

using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Persistence.DataBase;
using Azure.Identity;
using Azure.Core;

var builder = WebApplication.CreateBuilder(args);


var keyVaultUrl = builder.Configuration["keyVaultUrl"]?? string.Empty;
//if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "local")
//{
//    string tenantId = Environment.GetEnvironmentVariable("tenantId") ??string.Empty;
//    string clientId = Environment.GetEnvironmentVariable("clientId") ?? string.Empty;
//    string clientSecret = Environment.GetEnvironmentVariable("clientSecret") ?? string.Empty;

//    var tokenCredentials = new ClientSecretCredential(tenantId, clientId, clientSecret);
//    builder.Configuration.AddAzureKeyVault(new Uri(keyVaultUrl), tokenCredentials);
//}
//else
//{
//    builder.Configuration.AddAzureKeyVault(new Uri(keyVaultUrl), new DefaultAzureCredential());
//}

builder.Services.addWebApi()
    .addCommon()
    .addApplication()
    .addExternal(builder.Configuration)
    .addPersistence(builder.Configuration);

builder.Services.AddControllers();


//var sql = builder.Configuration["SQLConnectionString"];
//var sendGrid = builder.Configuration["SendGridApiKey"];

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI(c => {
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    c.RoutePrefix = string.Empty;
});
app.MapControllers();
app.UseCors("AllowAll");

//app.MapPost("/CreateUser", async(IDataBaseService _dataBaseService)=>{

//    var entity = new Domain.Entities.User.UserEntity { FirtsName = "Ariel", LastName = "Bejarano", Code = "Ari123" };
//    await _dataBaseService.User.AddAsync(entity);
//    await _dataBaseService.SaveAsync();
//    return "Ok creado";
//});


app.Run();


