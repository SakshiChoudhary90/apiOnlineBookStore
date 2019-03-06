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
    public class BookCategoryController : ControllerBase
    {
        OnlineBookStoreAPIDbContext context = new OnlineBookStoreAPIDbContext();
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookCategory>>> Get()
        {
            return await context.BookCategorys.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<BookCategory>> Get(int id)
        {
            var bkc = await context.BookCategorys.FindAsync(id);
            if (bkc == null)
            {
                return NotFound();
            }
            return bkc;
        }

        [HttpPost]
        public async Task<ActionResult<BookCategory>> Post([FromBody] BookCategory bkc)
        {
            context.BookCategorys.Add(bkc);
            await context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = bkc.BookCategoryId, bkc });
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<BookCategory>> Delete(int id)
        {
            var bkc = await context.BookCategorys.FindAsync(id);
            if (bkc == null)
            {
                return NotFound();
            }
            context.BookCategorys.Remove(bkc);
            await context.SaveChangesAsync();
            return NoContent();
        }



        [HttpPut("{id}")]

        public async Task<ActionResult<BookCategory>> Put(int id, [FromBody]BookCategory newpublication)
        {

            if (id != newpublication.BookCategoryId)
            {
                return BadRequest();
            }
            context.Entry(newpublication).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}