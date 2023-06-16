using BLayer.DTOS.Categories;
using BLayer.Managers.Categories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryManager categoryManager;
        public CategoriesController(ICategoryManager _categoryManager)
        {
            categoryManager = _categoryManager;
        }

        [HttpGet]
        public ActionResult<List<CategoryReadDto>> getAll()
        {
            return categoryManager.getAll();
        }
    }
}
