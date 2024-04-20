using ContosoPizza.Models;
using ContosoPizza.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContosoPizza.Controllers;

[ApiController]
[Route("[controller]")]
public class PizzaController : ControllerBase
{
    public PizzaController()
    {
    }

    [HttpGet]
    public ActionResult<List<Pizza>> GetAll() =>
        PizzaService.GetAll();

    // Get the Pizza details through the use of the GET grabber
    // GET ACTION
    [HttpGet("{id}")]
    public ActionResult<Pizza> Get(int id){
        var pizza = PizzaService.Get(id);
        if(pizza == null)
            return NotFound();
        
        return pizza;
    }

    //Add in more pizza through the use of the PUT creater
    // POST ACTION
    [HttpPost]
    public IActionResult Create(Pizza pizza){
        PizzaService.Add(pizza);
        return CreatedAtAction(nameof(Get), new { id = pizza.Id, pizza});
    }


    // PUT action

    // DELETE action
}