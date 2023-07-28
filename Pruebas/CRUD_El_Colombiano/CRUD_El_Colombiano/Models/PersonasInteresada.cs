using System;
using System.Collections.Generic;

namespace CRUD_El_Colombiano.Models;

public partial class PersonasInteresada
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string CorreoElectronico { get; set; } = null!;

    public string NumeroTelefono { get; set; } = null!;

    public int? ProyectoDeInteres { get; set; }

    public DateTime FechaRegistro { get; set; }

    public virtual Proyecto? ProyectoDeInteresNavigation { get; set; }
}
