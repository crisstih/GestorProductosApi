using GestorProductosApi.DTOs;
using GestorProductosApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace GestorProductosApi.Controllers;

// [ApiController]: Habilita características para Web APIs (validaciones automáticas de DataAnnotations, etc.)
// [Route("api/[controller]")]: Define la ruta base en base al nombre del controlador: "/api/productos"
[ApiController]
[Route("api/[controller]")]
public class ProductosController : ControllerBase
{
    // Inyectamos la interfaz del servicio
    private readonly IProductoService _service;

    public ProductosController(IProductoService service)
    {
        _service = service;
    }

    // ------------------------------------------------------------------------
    // 1. GET: /api/productos -> Retorna 200 OK con la lista de ProductoDto
    // ------------------------------------------------------------------------
    [HttpGet]
    public IActionResult ObtenerTodos()
    {
        var productos = _service.ObtenerTodos();
        return Ok(productos);
    }

    // ------------------------------------------------------------------------
    // 2. GET: /api/productos/{id} -> Retorna 200 OK o 404 Not Found si no existe
    // ------------------------------------------------------------------------
    [HttpGet("{id}")]
    public IActionResult ObtenerPorId(int id)
    {
        var producto = _service.ObtenerPorId(id);

        if (producto == null)
            return NotFound(new { mensaje = $"No se encontró el producto con Id {id}." });

        return Ok(producto);
    }

    // ------------------------------------------------------------------------
    // 3. POST: /api/productos -> Recibe CreateProductoDto por Body, valida y crea
    // Retorna 201 Created con CreatedAtAction apuntando al GET /api/productos/{id}
    // ------------------------------------------------------------------------
    [HttpPost]
    public IActionResult Crear([FromBody] CreateProductoDto dto)
    {
        // Valida si los DataAnnotations del DTO se cumplieron ([Required], [Range], etc.)
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var nuevo = _service.Crear(dto);

        // CreatedAtAction devuelve status 201 y coloca en el header Location la URL para consultar este nuevo recurso
        return CreatedAtAction(nameof(ObtenerPorId), new { id = nuevo.Id }, nuevo);
    }

    // ------------------------------------------------------------------------
    // 4. PUT: /api/productos/{id} -> Actualiza producto existente o retorna 404 / 400
    // ------------------------------------------------------------------------
    [HttpPut("{id}")]
    public IActionResult Actualizar(int id, [FromBody] CreateProductoDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var actualizado = _service.Actualizar(id, dto);

        if (!actualizado)
            return NotFound(new { mensaje = $"No se encontró el producto con Id {id} para actualizar." });

        // Retornamos 204 No Content indicando que se actualizó con éxito sin contenido para devolver
        return NoContent();
    }

    // ------------------------------------------------------------------------
    // 5. DELETE: /api/productos/{id} -> Elimina producto y retorna 204 o 404
    // ------------------------------------------------------------------------
    [HttpDelete("{id}")]
    public IActionResult Eliminar(int id)
    {
        var eliminado = _service.Eliminar(id);

        if (!eliminado)
            return NotFound(new { mensaje = $"No se encontró el producto con Id {id} para eliminar." });

        // Retornamos 204 No Content confirmando la eliminación
        return NoContent();
    }
}