using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using pr45.Models;

namespace pr45.Controllers
{
    [Route("api/delete")]
    [ApiExplorerSettings(GroupName = "v4")]
    public class Delete : Controller
    {
        Context context;
        public Delete(Context context)
        {
            this.context = context;
        }

        [HttpDelete]
        [Route("TaskDelete")]
        public async Task<IActionResult> DeleteTask(int? id = null)
        {
            if(Request.Cookies.TryGetValue("AuthToken", out var token))
            {
                if(id is not null && await context.Tasks.FirstOrDefaultAsync(x=> x.Id == id) is Models.Task task)
                {
                    context.Tasks.Remove(task);
                    context.SaveChanges();
                    return Ok($"Task with id = {id} deleted");
                }
                return BadRequest("Null id or not exist");
            }
            return Unauthorized("No token");
        }
        [HttpGet]//получение
        [HttpPost]//добавление
        [HttpPut]//Изменение
        [HttpDelete]
        [Route("UserDelete")]
        public async Task<IActionResult> DeleteUser(int? id = null)
        {
            if (Request.Cookies.TryGetValue("AuthToken", out var token))
            {
                if (id is not null && await context.Users.FirstOrDefaultAsync(x => x.Id == id) is Models.Users task)
                {
                    context.Users.Remove(task);
                    context.SaveChanges();
                    return Ok($"User with id = {id} deleted");
                }
                return BadRequest("Null id or not exist");
            }
            return Unauthorized("No token");
        }

        [HttpDelete]
        [Route("LibDelete")]
        public async Task<IActionResult> DeleteLib(int? id = null)
        {
            if (Request.Cookies.TryGetValue("AuthToken", out var token))
            {
                if (id is not null && await context.Library.FirstOrDefaultAsync(x => x.Id == id) is Library task)
                {
                    context.Library.Remove(task);
                    context.SaveChanges();
                    return Ok($"Library with id = {id} deleted");
                }
                return BadRequest("Null id or not exist");
            }
            return Unauthorized("No token");
        }

        [HttpDelete]
        [Route("LitDelete")]
        public async Task<IActionResult> DeleteLit(int? id = null)
        {
            if (Request.Cookies.TryGetValue("AuthToken", out var token))
            {
                if (id is not null && await context.Literature.FirstOrDefaultAsync(x => x.Id == id) is Models.Literature task)
                {
                    context.Literature.Remove(task);
                    context.SaveChanges();
                    return Ok($"Literature with id = {id} deleted");
                }
                return BadRequest("Null id or not exist");
            }
            return Unauthorized("No token");

            Ok();//200
            NotFound();//404
            BadRequest();//400
            Unauthorized();//401
        }
    }
}
