using Microsoft.EntityFrameworkCore;
using Ramon_Gonzalez_AP1_P2.Context;
using Ramon_Gonzalez_AP1_P2.Models;
using System.Linq.Expressions;


namespace Ramon_Gonzalez_AP1_P2.Services
{
    public class ProductosService
    {
        private readonly Contexto _context;

        public ProductosService(Contexto context)
        {
            _context = context;
        }

        public async Task<bool> Guardar(Producto producto)
        {
            if (producto.ProductoId == 0)
            {
                _context.Productos.Add(producto);
            }
            else
            {
                _context.Productos.Update(producto);
            }
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Producto?> Buscar(int id)
        {
            return await _context.Productos.FindAsync(id);
        }

        public async Task<bool> Eliminar(int id)
        {
            var productoAEliminar = await _context.Productos.FindAsync(id);
            if (productoAEliminar == null)
            {
                return false;
            }

            _context.Productos.Remove(productoAEliminar);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<Producto>> Listar(Expression<Func<Producto, bool>> criterio)
        {
            return await _context.Productos.Where(criterio).ToListAsync();
        }
    }
}