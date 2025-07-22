using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using RepositoryPattern.Models;
using RepositoryPattern.Repositories.Abstractions;

namespace RepositoryPattern.Controllers
{
    [ApiController]
    [Route("api/product")]
    public class ProductController : ControllerBase
    {
        public readonly IProductRepository _repository;
        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int skip = 0, int take = 25, CancellationToken cancellationToken = default)
        {
            var products = await _repository.GetAll(cancellationToken, skip, take);

            return Ok(products);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetProductById([FromRoute] int id, CancellationToken cancellationToken)
        {
            var product = await _repository.GetById(id, cancellationToken);
            if(product == null)
            {
                return NotFound($"Produto com id {id} não encontrado.");
            }

            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] Product product, CancellationToken cancellationToken)
        {
            if (product == null)
            {
                return BadRequest("Produto não pode ser nulo.");
            }

            var result = await _repository.Create(product, cancellationToken);
            return CreatedAtAction(nameof(GetProductById), new { id = result.Id }, result);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateProduct([FromRoute] int id, [FromBody] Product product, CancellationToken cancellationToken)
        {
            if (id != product.Id)
                return BadRequest("O ID da URL difere do ID do corpo.");

            var exists = await _repository.GetById(id, cancellationToken);
            if (exists == null)
                return NotFound($"Produto com id {id} não encontrado.");

            await _repository.Update(product, cancellationToken);
            return NoContent();
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> RemoveProduct([FromRoute] int id, CancellationToken cancellationToken)
        {
            var product = await _repository.GetById(id, cancellationToken);
            if(product == null)
            {
                return NotFound($"Produto com id {id} não encontrado.");
            }

            var result = await _repository.Delete(product, cancellationToken);

            return NoContent();
        }
    }
}
