using Microsoft.AspNetCore.Mvc;
using ToDo.Data;
using ToDo.Models;

namespace ToDo.Controllers
{
    [ApiController]

    public class HomeController : ControllerBase
    {
        [HttpGet("/")]
        public IActionResult Get([FromServices] AppDbContext context)

          => Ok(context.ToDoModels.ToList());



        [HttpGet("/{id:int}")]
        public IActionResult GetById([FromServices] AppDbContext context, [FromRoute] int id)
        {
            var todo = context.ToDoModels.FirstOrDefault(x => x.Id == id);
            if (todo == null)
                return NotFound();

            return Ok(todo);
        }


        [HttpPost("/")]
        public IActionResult Post([FromBody] ToDoModel toDoModel, [FromServices] AppDbContext context)
        {
            context.ToDoModels.Add(toDoModel);
            context.SaveChanges();
            return Created($"/{toDoModel.Id}", toDoModel);
        }

        [HttpPut("/{id:int}")]
        public IActionResult Put([FromBody] ToDoModel toDoModel, [FromServices] AppDbContext context, [FromRoute] int id)
        {
            var model = context.ToDoModels.FirstOrDefault(x => x.Id == id);
            if (model == null)
            {
                return NotFound(toDoModel);
            }
            else
            {
                model.Title = toDoModel.Title;
                model.Done = toDoModel.Done;

                context.ToDoModels.Update(model);
                context.SaveChanges();
                
                return Ok(model);
            }
        }
        [HttpDelete("/{id:int}")]
        public IActionResult Delete([FromServices] AppDbContext context, [FromRoute] int id)
        {
            var model = context.ToDoModels.FirstOrDefault(x => x.Id == id);
            if (model == null)
            {
                return NotFound();
            }
            context.ToDoModels.Remove(model);
            context.SaveChanges();
            
            return Ok(model);

        }
    }
}