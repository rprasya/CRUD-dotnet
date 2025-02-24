using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RESTfulAPI.Data;
using RESTfulAPI.Model;

namespace RESTfulAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly TutorialDbContext _context;
        public ProductController(TutorialDbContext context)
        {
            _context = context;
        }

        [HttpGet("list")]
        public IResult Get()
        {
            var list = _context.Products.ToList();
            return TypedResults.Ok(list);
        }

        [HttpGet("detail")]
        public IResult Get(int id)
        {
            var detail = _context.Products.FirstOrDefault(x => x.Id == id);
            if(detail == null)
            {
                return TypedResults.NotFound($"Product dengan id: {id} tidak di temukan");
            }

            return TypedResults.Ok(detail);
        }

        [HttpPost("create")]
        public IResult Post([FromBody] Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return TypedResults.Ok($"Product dengan nama: {product.Name} berhasil dibuat");
        }

        [HttpPut("update")]
        public IResult Put([FromForm] Product product)
        {
            var detail = _context.Products.FirstOrDefault(x => x.Id == product.Id);
            if (detail == null)
            {
                return TypedResults.NotFound($"Product dengan id: {product.Id} tidak di temukan");
            }
            detail.Name = product.Name;
            detail.Description = product.Description;
            detail.Price = product.Price;
            _context.SaveChanges();
            return TypedResults.Ok($"Product dengan Id: {product.Id} berhasil diubah");
        }

        [HttpDelete("delete")]
        public IResult Delete(int id)
        {
            var detail = _context.Products.FirstOrDefault(x => x.Id == id);
            if (detail == null)
            {
                return TypedResults.NotFound($"Product dengan id: {id} tidak di temukan");
            }

            _context.Products.Remove(detail);
            _context.SaveChanges();
            return TypedResults.Ok($"Menghapus data dengan id: {id}");
        }
    }
}
