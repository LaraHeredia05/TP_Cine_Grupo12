﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace CineApi.Models;

public partial class Barrio
{
    public int IdBarrio { get; set; }

    public string NombreBarrio { get; set; }

    public int? IdLocalidad { get; set; }

    public virtual Localidade IdLocalidadNavigation { get; set; }

    public virtual ICollection<Sucursale> Sucursales { get; set; } = new List<Sucursale>();
}