using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pr45.Models;

namespace pr45.Controllers
{
    [Route("api/TaskController")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class TaskController : Controller
    {
        Context _context;
        public TaskController(Context context)
        {
            _context = context;
        }

        [Route("ListTask")]
        [HttpGet]
        public async Task<IActionResult> ListTask()
        {
            var tasks = _context.Tasks.ToList();
            return Ok(tasks);
        }

        [Route("ItemTask")]
        [HttpGet]
        public async Task<IActionResult> ItemTask(int id)
        {
            var task = _context.Tasks.FirstOrDefault(x => x.Id == id);
            return Ok(task);
        }

        [Route("ListUser")]
        [HttpGet]
        public async Task<IActionResult> ListUser()
        {
            var user = _context.Users.ToList();
            return Ok(user);
        }

        [Route("ItemUser")]
        [HttpGet]
        public async Task<IActionResult> ItemUser(int id)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == id);
            return Ok(user);
        }
    }
}
