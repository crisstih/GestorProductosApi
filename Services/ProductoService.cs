using GestorProductosApi.DTOs;
using GestorProductosApi.Models;
using GestorProductosApi.Repositories;

namespace GestorProductosApi.Services;

public class ProductoService : IProductoService
{
    // Referencia privada al repositorio (se recibe por Inyección de Dependencias)
    private readonly IProductoRepository _repository;

    // Constructor: .NET inyecta automáticamente la implementación de IProductoRepository
    public ProductoService(IProductoRepository repository)
    {
        _repository = repository;
    }

    public List<ProductoDto> ObtenerTodos()
    {
        // 1. Obtenemos las entidades desde el repositorio
        var entidades = _repository.ObtenerTodos();

        // 2. Transformamos (mapeamos) cada Producto en un ProductoDto usando LINQ (.Select)
        return entidades.Select(p => new ProductoDto
        {
            Id = p.Id,
            Nombre = p.Nombre,
            Precio = p.Precio,
            Categoria = p.Categoria,
            Activo = p.Activo
        }).ToList();
    }

    public ProductoDto? ObtenerPorId(int id)
    {
        var entidad = _repository.ObtenerPorId(id);
        if (entidad == null)
            return null;

        // Transformamos la entidad encontrada a DTO
        return new ProductoDto
        {
            Id = entidad.Id,
            Nombre = entidad.Nombre,
            Precio = entidad.Precio,
            Categoria = entidad.Categoria,
            Activo = entidad.Activo
        };
    }

    public ProductoDto Crear(CreateProductoDto dto)
    {
        // 1. Convertimos el CreateProductoDto recibido en la Entidad interna Producto
        var nuevaEntidad = new Producto
        {
            Nombre = dto.Nombre,
            Precio = dto.Precio,
            Categoria = dto.Categoria,
            Activo = dto.Activo
        };

        // 2. Le pedimos al repositorio que la guarde
        var guardado = _repository.Agregar(nuevaEntidad);

        // 3. Devolvemos el ProductoDto con el nuevo Id asignado
        return new ProductoDto
        {
            Id = guardado.Id,
            Nombre = guardado.Nombre,
            Precio = guardado.Precio,
            Categoria = guardado.Categoria,
            Activo = guardado.Activo
        };
    }

    public bool Actualizar(int id, CreateProductoDto dto)
    {
        // Mapeamos los datos del DTO a la entidad con el Id correspondiente
        var entidadAActualizar = new Producto
        {
            Id = id,
            Nombre = dto.Nombre,
            Precio = dto.Precio,
            Categoria = dto.Categoria,
            Activo = dto.Activo
        };

        return _repository.Actualizar(entidadAActualizar);
    }

    public bool Eliminar(int id)
    {
        return _repository.Eliminar(id);
    }
}