﻿using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Prueba_Yokaira.DAL;
using Prueba_Yokaira.Models;

public class IngresosBLL
{
    public Context _context { get; set; }
    public IngresosBLL(Context context)
    {
        _context = context;
    }

    public bool Existe(int ingresoId)
    {
        return _context.ingreso.Any(i => i.IngresoId == ingresoId);
    }

    public bool Insertar(Ingresos ingresos)
    {
        _context.ingreso.Add(ingresos);
        return _context.SaveChanges() > 0;
    }

    public bool Guardar(Ingresos ingresos)
    {
        if (!Existe(ingresos.IngresoId))
            return Insertar(ingresos);
        else
            return Modificar(ingresos);
    }

    public bool Modificar(Ingresos ingresos)
    {
        _context.ingreso.Entry(ingresos).State = EntityState.Modified;
        return _context.SaveChanges() > 0;
    }

    public bool Eliminar(Ingresos ingresos)
    {
        _context.ingreso.Remove(ingresos);
        int eliminado = _context.SaveChanges();
        return eliminado > 0;
    }

    public Ingresos? Buscar(int ingresoId)
    {
        return _context.ingreso.Where(i => i.IngresoId == ingresoId)
            .AsNoTracking()
            .SingleOrDefault();
    }
    public List<Ingresos> Listar(Expression<Func<Ingresos, bool>> Criterio)
    {
        return _context.ingreso
            .Where(Criterio)
            .AsNoTracking().ToList();
    }
}