﻿

//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------


namespace Geograf.Model
{

using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;


public partial class dbGeografEntities : DbContext
{
    public dbGeografEntities()
        : base("name=dbGeografEntities")
    {

    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        throw new UnintentionalCodeFirstException();
    }


    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Ethnic> Ethnics { get; set; }

    public virtual DbSet<Language> Languages { get; set; }

    public virtual DbSet<Natinolity> Natinolities { get; set; }

    public virtual DbSet<Population> Populations { get; set; }

    public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

}

}

