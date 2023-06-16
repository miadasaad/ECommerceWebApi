using BLayer.DTOS.Products;
using BLayer.Managers.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace E_Commerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductManager productManager;
        public ProductsController(IProductManager _productManager)
        {
            productManager = _productManager;
        }

        [HttpGet]
        public ActionResult<List<ProductReadDto>> getAll()
        {
            return productManager.getAll();
        }
        [HttpGet]
        [Route("{id}")]
        
        public ActionResult<ProductReadDto> getById(int id)
        {
            var product = productManager.getById(id);
            if (product == null)
            {
                return NotFound();
            }
            var customHeaderValue = "";
            //IEnumerable<string> headerValues;
            if (Request.Headers.TryGetValue("x-api-key", out var headerValues))
            {
                 customHeaderValue = headerValues.First();
                // use the customHeaderValue in your code
            }
            return Ok(customHeaderValue);

        }

        [HttpGet]
        [Route("category/{id}")]

        public ActionResult<List<ProductReadDto>> getPrdsByCatId(int id)
        {
            return productManager.getPrdsByCatId(id);
            
        }

        [HttpGet]
        [Route("categories/{id}")]

        public ActionResult<ProductWithCategory> getPrdsByCatObject(int id)
        {
            return productManager.getPrdWithCat(id);

        }

        [HttpPost]
        public ActionResult add(ProductAddDto productAddDto)
        {
            var newId = productManager.add(productAddDto);
            // return CreatedAtAction("getById", new { id = newId }, new { m = "product added successfully" });
            var customHeaderValue = "";
            //IEnumerable<string> headerValues;
            if (Request.Headers.TryGetValue("x-api-key", out var headerValues))
            {
                customHeaderValue = headerValues.First();
                // use the customHeaderValue in your code
            }
            return Ok(productAddDto.name+"  :::  "+ customHeaderValue);
        }

        [HttpPut]
        public ActionResult update(ProductUpdateDto productUpdateDto)
        {
            var res = productManager.update(productUpdateDto);
            if (res == false)
            {
                return NotFound();
            }
            return NoContent();
        }
        [HttpDelete]
        [Route("{id}")]
        public ActionResult delete(int id)
        {
            productManager.deleteById(id);
            return NoContent();
        }

    }
}








