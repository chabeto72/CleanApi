using Application.Database.User.Querys.GetAllTask;
using Application.Database.User.Querys.GetAllUser;
using Application.Excepctions;
using Application.Features;
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
       

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll(
         [FromServices] IGetAllTaskQuery getAllTaskQuery)
        {

            var data = await getAllTaskQuery.Execute();
            if (data == null)
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound));


            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data, "Ejecucion correcta"));
        }
        
    }
}
