﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace CineApi.Models;

public partial class Pelicula
{
    public int IdPelicula { get; set; }

    public string Titulo { get; set; }

    public int Duracion { get; set; }

    public int? IdGenero { get; set; }

    public int? IdDirector { get; set; }

    public int? AnioLanzamiento { get; set; }

    public DateTime? FechaEstreno { get; set; }

    public string Clasificacion { get; set; }

    public virtual ICollection<Funcione> Funciones { get; set; } = new List<Funcione>();

    public virtual Directore IdDirectorNavigation { get; set; }

    public virtual Genero IdGeneroNavigation { get; set; }

    public virtual ICollection<Actore> IdActors { get; set; } = new List<Actore>();

    public virtual ICollection<Premio> IdPremios { get; set; } = new List<Premio>();
}