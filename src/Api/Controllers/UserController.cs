using Application.Database.User.Commands.CreateUser;
using Application.Database.User.Commands.DeleteUser;
using Application.Database.User.Commands.UpdateUser;
using Application.Database.User.Querys.GetAllUser;
using Application.Database.User.Querys.GetUserByCodeDocumentNumber;
using Application.Database.User.Querys.GetUserById;
using Application.Excepctions;
using Application.External.GetTokenJwt;
using Application.Features;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;

namespace Api.Controllers
{
    [Authorize]
    [Route("api/v1/user")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class UserController : ControllerBase
    {
        public UserController()
        {
            
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create(
            [FromBody] CreateUserModel model,
            [FromServices] ICreateUserCommand createUserCommand,
            [FromServices] IValidator<CreateUserModel> validator )
        {
            var validation = await validator.ValidateAsync( model );
            if ( !validation.IsValid )
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest,validation.Errors));

            var data = await createUserCommand.Execute(model);

            return StatusCode(StatusCodes.Status201Created, ResponseApiService.Response(StatusCodes.Status201Created, data, "Ejecucion correcta"));
        }
        [HttpPut("update")]
        public async Task<IActionResult> Update(
          [FromBody] UpdateUserModel model,
          [FromServices] IUpdateUserCommand updateUserCommand,
          [FromServices] IValidator<UpdateUserModel> validator)
        {
            var validation = await validator.ValidateAsync(model);
            if (!validation.IsValid)
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest, validation.Errors));

            var data = await updateUserCommand.Execute(model);

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data, "Ejecucion correcta"));
        }

        [HttpDelete("delete/{userId}")]
        public async Task<IActionResult> Delete(        
         [FromServices] IDeleteUserCommand deleteUserCommand,
         [FromServices] IValidator<int> validator,
         int userId)
        {
            var validation = await validator.ValidateAsync(userId);
            if (!validation.IsValid)
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest, validation.Errors));

          


            var data = await deleteUserCommand.Execute(userId);
            if (!data)
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound));
            

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data, "Ejecucion correcta"));
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll(
         [FromServices] IGetAllUserQuery getAllUserQuery)
        {
          
            var data = await getAllUserQuery.Execute();
            if (data?.Count==0)
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound));


            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data, "Ejecucion correcta"));
        }
        [HttpGet("get-by-id/{userId}")]
        public async Task<IActionResult> GetById(
         [FromServices] IGetUserByIdQuery getUserByIdQuery,
         [FromServices] IValidator<int> validator, int userId)
        {
            var validation = await validator.ValidateAsync(userId);
            if (!validation.IsValid)
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest, validation.Errors));
    

            var data = await getUserByIdQuery.Execute(userId);
            if (data == null)
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound));


            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data, "Ejecucion correcta"));
        }

        [AllowAnonymous]
        [HttpGet("get-login-password-docummentnumber/{password}/{userDocumentNumber}")]
        public async Task<IActionResult> GetLoginPasswordDocumentNumber(
         [FromServices] IGetUserByCodeDocumentNumberQuery getUserByCodeDocumentNumberQuery,
         [FromServices] IValidator<(string,string)> validator,
         [FromServices] IGetTokenJwtService getTokenJwtService, string password, string userDocumentNumber)
        {
            var validation = await validator.ValidateAsync((password, userDocumentNumber));
            if (!validation.IsValid)
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest, validation.Errors));


            var data = await getUserByCodeDocumentNumberQuery.Execute(password, userDocumentNumber);
            if (data == null)
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound));

            data.Token = getTokenJwtService.Execute(data.UserId.ToString());
            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data, "Ejecucion correcta"));
        }

        [HttpPost]
        public async Task<IActionResult> test()
        {
            var number = int.Parse("OK");
            return StatusCode(StatusCodes.Status200OK,ResponseApiService.Response(StatusCodes.Status200OK,"{}","Ejecucion correcta"));
        } 
        
    }
}
