namespace GestorProductosApi.DTOs;

// DTO de respuesta: esto es lo que la api devuelve al exterior (por ejemplo, en un GET).
//asi protegemos la entidad interna y controlamos que datos ve el cliente
public class ProductoDto
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public decimal Precio { get; set; }
    public string Categoria { get; set; } = string.Empty;
    public bool Activo { get; set; }
}