using GestorProductosApi.Models;

namespace GestorProductosApi.Repositories;

//contrato de la capa de acceso a datos.
//define qué operaciones se pueden realizar directamente sobre los datos de tipo Producto.
public interface IProductoRepository
{
    // Obtiene todos los productos almacenados
    List<Producto> ObtenerTodos();

    // Obtiene un producto por su identificador único (o null si no existe)
    Producto? ObtenerPorId(int id);

    // Guarda un nuevo producto y devuelve el producto con su nuevo Id asignado
    Producto Agregar(Producto producto);

    // Actualiza los datos de un producto existente (devuelve true si se actualizó, false si no existía)
    bool Actualizar(Producto producto);

    // Elimina un producto por su Id (devuelve true si se borró, false si no se encontró)
    bool Eliminar(int id);
}