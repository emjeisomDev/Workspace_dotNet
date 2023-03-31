using Blog.Data;
using Blog.Models;
using Blog.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blog.Controllers
{
    [ApiController]
    [Route("v1/categories")]
    public class CategoryController : ControllerBase
    {
        [HttpGet("")]
        public async Task<IActionResult> GetAsync([FromServices] BlogDataContext context)
        {
            try
            {
                var categories = await context.Categories.ToListAsync();
                return Ok(categories);
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, "05XE01 - It wasn't possible get the categories!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "05XE06 - Internal fail on server!");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByIdAsync(
            [FromRoute] int id,
            [FromServices] BlogDataContext context
        )
        {
            try
            {
                var category = await context.Categories.FirstOrDefaultAsync(x => x.Id == id);

                if (category == null)
                {
                    return NotFound();
                }
                return Ok(category);
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, "05XE02 - It wasn't possible get the category!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "05XE06 - Internal fail on server!");
            }
        }

        [HttpPost("")]
        public async Task<IActionResult> PostAsync(
            [FromBody] EditorCategoryViewModel model,
            [FromServices] BlogDataContext context
        )
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                var category = new Category
                {
                    Id = 0,
                    Name = model.Name,
                    Slug = model.Slug.ToLower()
                };
                await context.Categories.AddAsync(category);
                await context.SaveChangesAsync();
                return Created($"/{category.Id}", category);
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, "05XE03 - It wasn't possible include the category!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "05XE06 - Internal fail on server!");
            }

        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutAsync(
            [FromRoute] int id,
            [FromBody] EditorCategoryViewModel model,
            [FromServices] BlogDataContext context
        )
        {

            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                var category = await context.Categories.FirstOrDefaultAsync(x => x.Id == id);

                if (category == null)
                    return NotFound();

                category.Name = model.Name;
                category.Slug = model.Slug;

                context.Categories.Update(category);
                await context.SaveChangesAsync();

                return Ok();
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, "05XE04 - It wasn't possible update the category!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "05XE06 - Internal fail on server!");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(
            [FromRoute] int id,
            [FromServices] BlogDataContext context
        )
        {
            try
            {
                var category = await context.Categories.FirstOrDefaultAsync(x => x.Id == id);

                if (category == null)
                    return NotFound();

                context.Categories.Remove(category);
                await context.SaveChangesAsync();

                return Ok(category);
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, "05XE05 - It wasn't possible delete the category!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "05XE06 - Internal fail on server!");
            }
        }


    }
}
