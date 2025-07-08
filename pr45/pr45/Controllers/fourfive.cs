using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pr45.Models;
using System.Linq.Dynamic.Core;

namespace pr45.Controllers
{
    [Route("api/fourfive")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class fourfive : Controller
    {
        Context _context;
        public fourfive(Context context)
        {
            _context = context;
        }

        [Route("LiteratureList")]
        [HttpGet]
        public async Task<IActionResult> LiteratureList()
        {
            var tasks =await _context.Literature.ToListAsync();
            return Ok(tasks);
        }

        [Route("LibraryList")]
        [HttpGet]
        public async Task<IActionResult> LibraryList()
        {
            var tasks =await _context.Library.ToListAsync();
            return Ok(tasks);
        }

        [Route("LiteratureListBy")]
        [HttpGet]
        public async Task<IActionResult> LiteratureListBy(string sortProperty = "Name")
        {
            try
            {
                var tasks =await _context.Literature.OrderBy($"{sortProperty}").ToListAsync();
                return Ok(tasks);
            }
            catch (Exception e)
            {
                return NotFound(e);
            }
        }

        [Route("LibraryListBy")]
        [HttpGet]
        public async Task<IActionResult> LibraryListBy(string sortProperty = "Name")
        {
            try
            {
                var tasks = await _context.Library.OrderBy($"{sortProperty}").ToListAsync();
                return Ok(tasks);
            }
            catch (Exception e)
            {
                return NotFound(e);
            }
        }
    }
}

