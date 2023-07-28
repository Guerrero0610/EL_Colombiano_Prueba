using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_El_Colombiano.Models;

public partial class PersonasInteresada
{
    public int Id { get; set; }

    [Display(Name = "Nombre")]
    [Required]
    [StringLength(20)]
    public string Nombre { get; set; } = null!;

    [Display(Name = "Apellido")]
    [Required]
    [StringLength(25)]
    public string Apellido { get; set; } = null!;

    [Display(Name = "Correo Electronico")]
    [Required]
    [EmailAddress]
    public string CorreoElectronico { get; set; } = null!;

    [Required(ErrorMessage = "El campo Numero de Telefono es obligatorio.")]
    [RegularExpression(@"^\d+$", ErrorMessage = "El campo Numero de Telefono solo debe contener números.")]
    public string NumeroTelefono { get; set; } = null!;

    [Required(ErrorMessage = "El campo Proyecto de Interes es obligatorio.")]
    public int? ProyectoDeInteres { get; set; }

    [Required(ErrorMessage = "El campo Fecha de Registro es obligatorio.")]
    public DateTime FechaRegistro { get; set; }

    public virtual Proyecto? ProyectoDeInteresNavigation { get; set; }

}
