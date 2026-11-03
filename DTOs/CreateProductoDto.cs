// Importamos este paquete para poder usar Data Annotations (validaciones automáticas)
using System.ComponentModel.DataAnnotations;

namespace GestorProductosApi.DTOs;

// DTO para recibir datos de creación o edición de un producto.
//no incluye "Id" porque el Id lo genera el sistema.
public class CreateProductoDto
{
    // [Required]:el campo es obligatorio.
    // [StringLength]:exige un mínimo de 3 y un máximo de 100 caracteres.
    [Required(ErrorMessage = "El nombre es obligatorio.")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "El nombre debe tener entre 3 y 100 caracteres.")]
    public string Nombre { get; set; } = string.Empty;

    // [Range]:exige que el precio sea mayor a 0 (desde 0.01 en adelante).
    [Required(ErrorMessage = "El precio es obligatorio.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor a 0.")]
    public decimal Precio { get; set; }

    // [Required]: La categoría también es obligatoria.
    [Required(ErrorMessage = "La categoría es obligatoria.")]
    public string Categoria { get; set; } = string.Empty;

    // Opcionalmente podemos indicar si está activo (por defecto true al crearlo)
    public bool Activo { get; set; } = true;
}