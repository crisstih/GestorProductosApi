using GestorProductosApi.Models;

namespace GestorProductosApi.Repositories;

// Implementación en memoria del repositorio.
public class ProductoRepositoryInMemory : IProductoRepository
{
    // "static" permite que la lista persista en la memoria del servidor entre peticiones HTTP,
    // incluso cuando el servicio se registra con ciclo de vida Scoped.
    private static readonly List<Producto> _productos = new List<Producto>
    {
        // Seed data inicial
        new Producto { Id = 1, Nombre = "Notebook Lenovo", Precio = 750000, Categoria = "Computacion", Activo = true },
        new Producto { Id = 2, Nombre = "Mouse Inalambrico", Precio = 22000, Categoria = "Accesorios", Activo = true },
        new Producto { Id = 3, Nombre = "Teclado Mecanico", Precio = 55000, Categoria = "Accesorios", Activo = true },
        new Producto { Id = 4, Nombre = "Monitor 24 pulgadas", Precio = 190000, Categoria = "Monitores", Activo = false }
    };

    // Contador estático para simular la generación de IDs autoincrementales
    private static int _proximoId = 5;

    public List<Producto> ObtenerTodos()
    {
        return _productos.ToList();
    }

    public Producto? ObtenerPorId(int id)
    {
        return _productos.FirstOrDefault(p => p.Id == id);
    }

    public Producto Agregar(Producto producto)
    {
        // Asignamos el nuevo Id autoincremental
        producto.Id = _proximoId++;
        _productos.Add(producto);
        return producto;
    }

    public bool Actualizar(Producto producto)
    {
        var existente = ObtenerPorId(producto.Id);
        if (existente == null)
            return false;

        // Actualizamos los campos
        existente.Nombre = producto.Nombre;
        existente.Precio = producto.Precio;
        existente.Categoria = producto.Categoria;
        existente.Activo = producto.Activo;

        return true;
    }

    public bool Eliminar(int id)
    {
        var existente = ObtenerPorId(id);
        if (existente == null)
            return false;

        _productos.Remove(existente);
        return true;
    }
}