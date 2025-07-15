using Microsoft.EntityFrameworkCore; 
using Ramon_Gonzalez_AP1_P2.Context;
using Ramon_Gonzalez_AP1_P2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions; 
using System.Threading.Tasks;

namespace Ramon_Gonzalez_AP1_P2.Services
{
    public class EntradasService
    {
        private readonly Contexto _context;

        public EntradasService(Contexto context)
        {
            _context = context;
        }

        public async Task<bool> Guardar(Entrada entrada)
        {
            if (entrada.EntradaId == 0)
            {
                _context.Entradas.Add(entrada);
            }
            else
            {
                _context.Entradas.Update(entrada);
            }
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Entrada?> Buscar(int id)
        {
            return await _context.Entradas
                                 .Include(e => e.Detalle)
                                 .ThenInclude(d => d.Producto)
                                 .FirstOrDefaultAsync(e => e.EntradaId == id);
        }

        public async Task<bool> Eliminar(int id)
        {
            var entradaAEliminar = await _context.Entradas.FindAsync(id);
            if (entradaAEliminar == null)
            {
                return false;
            }

            _context.Entradas.Remove(entradaAEliminar);
            return await _context.SaveChangesAsync() > 0;
        }

        // Método 'Listar' con la firma corregida
        // Ahora acepta una Expression<Func<Entrada, bool>> para que la consulta sea traducida a SQL
        public async Task<List<Entrada>> Listar(Expression<Func<Entrada, bool>> criterio)
        {
            return await _context.Entradas
                                 .Include(e => e.Detalle)
                                 .ThenInclude(d => d.Producto)
                                 .Where(criterio)
                                 .ToListAsync();
        }
    }
}