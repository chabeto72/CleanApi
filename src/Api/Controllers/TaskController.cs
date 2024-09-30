using Application.Database.User.Commands.CreateUser;
using Application.Database.User.Commands.UpdateUser;
using Application.Database.User.Querys.GetAllTask;
using Application.Database.User.Querys.GetAllUser;
using Application.Excepctions;
using Application.Features;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Authorize]
    [Route("api/v1/task")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class TaskController : ControllerBase
    {
        public TaskController()
        {
                
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create(
           [FromBody] CreateTaskModel model,
           [FromServices] ICreateTaskCommand createTaskCommand,
           [FromServices] IValidator<CreateTaskModel> validator)
        {
            var validation = await validator.ValidateAsync(model);
            if (!validation.IsValid)
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest, validation.Errors));

            var data = await createTaskCommand.Execute(model);

            return StatusCode(StatusCodes.Status201Created, ResponseApiService.Response(StatusCodes.Status201Created, data, "Ejecucion correcta"));
        }


        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll(
         [FromServices] IGetAllTaskQuery getAllTaskQuery)
        {

            var data = await getAllTaskQuery.Execute();
            if (data == null)
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound));


            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data, "Ejecucion correcta"));
        }
        [HttpPut("update")]
        public async Task<IActionResult> Update(
         [FromBody] UpdateTaskModel model,
         [FromServices] IUpdateTaskCommand updateTaskCommand,
         [FromServices] IValidator<UpdateTaskModel> validator)
        {
            var validation = await validator.ValidateAsync(model);
            if (!validation.IsValid)
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest, validation.Errors));

            var data = await updateTaskCommand.Execute(model);

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data, "Ejecucion correcta"));
        }

    }
}
