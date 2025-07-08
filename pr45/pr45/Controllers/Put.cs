using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pr45.Models;

namespace pr45.Controllers
{
    [Route("api/Put")]
    [ApiExplorerSettings(GroupName = "v3")]
    public class Put : Controller
    {
        Context _context;
        public Put(Context context)
        {
            _context = context;
        }

        [Route("TaskPut")]
        [HttpPut]
        public async Task<IActionResult> AddTask(Models.Task task)
        {
            if (Request.Cookies.TryGetValue("AuthToken", out var token))
            {
                string msg = "";
                if (await _context.Tasks.AnyAsync(x => x.Id == task.Id))
                {
                    task.Id = null;
                    msg = "Message: Id replaced";
                }
                _context.Tasks.Add(task);
                _context.SaveChanges();
                return Ok($"Access granted with token: {token}\n{msg}");
            }
            return Unauthorized("Token cookie missing");
        }
        [Route("TaskEditPut")]
        [HttpPut]
        public async Task<IActionResult> EditTask(Models.Task task)
        {
            if (Request.Cookies.TryGetValue("AuthToken", out var token))
            {
                string msg = "";
                if (await _context.Tasks.FirstOrDefaultAsync(x => x.Id == task.Id) is Models.Task Task)
                {
                    Task.Name = task.Name;
                    Task.Priority = task.Priority;
                    Task.Comment = task.Comment;
                    Task.DateExecute = task.DateExecute;
                    Task.Done = task.Done;
                    _context.Tasks.Update(Task);
                    _context.SaveChanges();
                    return Ok($"Access granted with token: {token}\n{msg}");
                }
                return NotFound($"Task with id = {task.Id} not found");
                
            }
            return Unauthorized("Token cookie missing");
        }

        [Route("UserPut")]
        [HttpPut]
        public async Task<IActionResult> AddUser(Models.Users user)
        {
            if (Request.Cookies.TryGetValue("AuthToken", out var token))
            {
                string msg = "";
                if (await _context.Users.AnyAsync(x => x.Id == user.Id))
                {
                    user.Id = null;
                    msg = "Message: Id replaced";
                }
                _context.Users.Add(user);
                _context.SaveChanges();
                return Ok($"Access granted with token: {token}\n{msg}");
            }
            return Unauthorized("Token cookie missing");
        }
        [Route("UserEditPut")]
        [HttpPut]
        public async Task<IActionResult> EditUser(Models.Users user)
        {
            if (Request.Cookies.TryGetValue("AuthToken", out var token))
            {
                string msg = "";
                if (await _context.Users.FirstOrDefaultAsync(x => x.Id == user.Id) is Models.Users User)
                {
                    User.Login = user.Login;
                    User.Password = user.Password;
                    _context.Users.Update(User);
                    _context.SaveChanges();
                    return Ok($"Access granted with token: {token}\n{msg}");
                }
                return NotFound($"Task with id = {user.Id} not found");

            }
            return Unauthorized("Token cookie missing");
        }

        [Route("LibraryPut")]
        [HttpPut]
        public async Task<IActionResult> AddLibrary(Library lib)
        {
            if (Request.Cookies.TryGetValue("AuthToken", out var token))
            {
                string msg = "";
                if (await _context.Library.AnyAsync(x => x.Id == lib.Id))
                {
                    lib.Id = null;
                    msg = "Message: Id replaced";
                }
                _context.Library.Add(lib);
                _context.SaveChanges();
                return Ok($"Access granted with token: {token}\n{msg}");
            }
            return Unauthorized("Token cookie missing");
        }
        [Route("LibraryEditPut")]
        [HttpPut]
        public async Task<IActionResult> EditLibarary(Library lib)
        {
            if (Request.Cookies.TryGetValue("AuthToken", out var token))
            {
                if (await _context.Library.FirstOrDefaultAsync(x => x.Id == lib.Id) is Library Lib)
                {
                    Lib.Name = lib.Name;
                    Lib.Address = lib.Address;
                    Lib.Phone = lib.Phone;
                    Lib.Mail = lib.Mail;
                    _context.Library.Update(Lib);
                    _context.SaveChanges();
                    return Ok($"Access granted with token: {token}");
                }
                return NotFound($"Task with id = {lib.Id} not found");

            }
            return Unauthorized("Token cookie missing");
        }

        [Route("LiteraturePut")]
        [HttpPut]
        public async Task<IActionResult> AddLiterature(Literature lit)
        {
            if (Request.Cookies.TryGetValue("AuthToken", out var token))
            {
                string msg = "";
                if (await _context.Literature.AnyAsync(x => x.Id == lit.Id))
                {
                    lit.Id = null;
                    msg = "Message: Id replaced";
                }
                _context.Literature.Add(lit);
                _context.SaveChanges();
                return Ok($"Access granted with token: {token}\n{msg}");
            }
            return Unauthorized("Token cookie missing");
        }
        [Route("LiteratureEditPut")]
        [HttpPut]
        public async Task<IActionResult> EditLiterature(Literature lit)
        {
            if (Request.Cookies.TryGetValue("AuthToken", out var token))
            {
                if (await _context.Literature.FirstOrDefaultAsync(x => x.Id == lit.Id) is Literature Lit)
                {
                    Lit.Name = lit.Name;
                    Lit.Author = lit.Author;
                    Lit.Publisher = lit.Publisher;
                    Lit.Price = lit.Price;
                    Lit.Description = lit.Description;
                    Lit.ReleaseDate = lit.ReleaseDate;
                    _context.Literature.Update(Lit);
                    _context.SaveChanges();
                    return Ok($"Access granted with token: {token}");
                }
                return NotFound($"Task with id = {lit.Id} not found");

            }
            return Unauthorized("Token cookie missing");
        }
    }
}
