namespace GestorProductosApi.Models;

//representa la entidad de dominio de nuestra aplicación.
//esta clase contiene toda la estructura de datos que se almacena en memoria o base de datos.
public class Producto
{
    //identificador único del producto en el sistema
    public int Id { get; set; }

    //nombre del producto
    public string Nombre { get; set; } = string.Empty;

    //precio monetario (usamos decimal para precisión financiera)
    public decimal Precio { get; set; }

    //categoria a la que pertenece
    public string Categoria { get; set; } = string.Empty;

    // estado del producto (true = activo para venta, false = dado de baja)
    public bool Activo { get; set; }
}