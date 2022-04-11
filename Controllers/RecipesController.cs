using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _11_04_2022_1750.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {

        private static List<Recipe> recipes = new List<Recipe>
        {
            new Recipe{
                Id = 1,
                Name = "Cake1",
                NumberOfLikes = 10
            },
            new Recipe
            {
                Id = 2,
                Name = "Cake2",
                NumberOfLikes = 2
            }
        };

        [HttpGet]
        public async Task<ActionResult<List<Recipe>>> Get()
        {
            return Ok(recipes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Recipe>> Get(int id)
        {
            var recipe = recipes.Find(r => r.Id == id);
            if (recipe == null) {
                return BadRequest("Recipe not found");
            }
            return Ok(recipe);

        }


        [HttpPost]
        public async Task<ActionResult<List<Recipe>>> AddRecipe(Recipe recipe)
        {
            recipes.Add(recipe);
            return Ok(recipes);
        }

        [HttpPut]
        public async Task<ActionResult<List<Recipe>>> UpdateRecipe(Recipe request)
        {
            var recipe = recipes.Find(r => r.Id == request.Id);
            if (recipe == null)
            {
                return BadRequest("Recipe not found");
            }
            recipe.NumberOfLikes = request.NumberOfLikes;
            recipe.Name = request.Name;
            return Ok(recipes);

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Recipe>>> Delete(int id)
        {
            var recipe = recipes.Find(r => r.Id == id);
            if (recipe == null)
            {
                return BadRequest("Recipe not found");
            }
            recipes.Remove(recipe);
            return Ok(recipes);

        }


    }
}
