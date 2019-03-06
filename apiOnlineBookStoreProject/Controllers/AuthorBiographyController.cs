using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiOnlineBookStoreProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace apiOnlineBookStoreProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorBiographyController : ControllerBase
    {
    
    OnlineBookStoreAPIDbContext context = new OnlineBookStoreAPIDbContext();
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorBiography>>> Get()
        {
            return await context.AuthorBiographies.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorBiography>> Get(int id)
        {
            var pub = await context.AuthorBiographies.FindAsync(id);
            if (pub == null)
            {
                return NotFound();
            }
            return pub;
        }

        [HttpPost]
        public async Task<ActionResult<AuthorBiography>> Post([FromBody] AuthorBiography aut)
        {
            context.AuthorBiographies.Add(aut);
            await context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = aut.AuthorBiographyId, aut });
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<AuthorBiography>> Delete(int id)
        {
            var aut = await context.AuthorBiographies.FindAsync(id);
            if (aut == null)
            {
                return NotFound();
            }
            context.AuthorBiographies.Remove(aut);
            await context.SaveChangesAsync();
            return NoContent();
        }



        [HttpPut("{id}")]

        public async Task<ActionResult<AuthorBiography>> Put(int id, [FromBody]AuthorBiography newAuthor)
        {

            if (id != newAuthor.AuthorBiographyId)
            {
                return BadRequest();
            }
            context.Entry(newAuthor).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}