using GestorProductosApi.DTOs;

namespace GestorProductosApi.Services;

// Contrato de la capa de negocio.
// Trabaja exclusivamente con DTOs hacia afuera (hacia el controlador).
public interface IProductoService
{
    // Obtiene todos los productos ya transformados a ProductoDto
    List<ProductoDto> ObtenerTodos();

    // Obtiene un producto por Id transformado a ProductoDto (o null si no existe)
    ProductoDto? ObtenerPorId(int id);

    // Recibe el DTO con los datos de creación, lo guarda y devuelve el ProductoDto resultante
    ProductoDto Crear(CreateProductoDto dto);

    // Actualiza un producto existente recibiendo su Id y el DTO con nuevos datos
    bool Actualizar(int id, CreateProductoDto dto);

    // Elimina un producto por su Id
    bool Eliminar(int id);
}