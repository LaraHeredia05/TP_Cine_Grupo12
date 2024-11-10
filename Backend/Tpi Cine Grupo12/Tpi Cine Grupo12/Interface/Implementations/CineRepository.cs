using Microsoft.EntityFrameworkCore;
using Tpi_Cine_Grupo12.Interface.Contracts;
using Tpi_Cine_Grupo12.Models;
namespace Tpi_Cine_Grupo12.Interface.Implementations
{
    public class CineRepository : ICineRepository
    {
        private readonly CineDbContext _context;

        public CineRepository(CineDbContext context)
        { _context = context; }

        public bool ButacaReservada(int funcionButaca, int funcion, int sala, int num, int fila, int ticket)
        {
            throw new NotImplementedException();
        }
    

        public async Task<bool> CancelarCompra(int comprobante)
        {
            Comprobantes c = await _context.Comprobantes
                .FirstOrDefaultAsync(x => x.id_comprobante == comprobante && x.estado == "En Curso");

            if (c != null)
            {
                c.estado = "Cancelada";

                return await _context.SaveChangesAsync() > 0;
            }
            return false;
        }

        public async Task<List<Butacas>> GetButacasDisponibles(int ticket)
        {
            var butacasDisponibles = await _context.Butacas
                   .Where(b => b.estado == "Disponible" && b.Tickets.Any(t => t.id_ticket == ticket))
                   .ToListAsync();

            return butacasDisponibles;
        }

        public async Task<List<Clientes>> GetClientes(string usuario, string contraseña)
        {
            return await _context.Clientes
            .Where(x => x.usuario == usuario && x.contraseña == contraseña)
            .ToListAsync();
        }

        public List<Funciones> GetFunciones(int pelicula, int sala, DateOnly dia, TimeOnly horario, string varchar, string tipo_funcion)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Generos>> GetGeneros()
        {
            return await _context.Generos.ToListAsync();
        }

        public List<Peliculas> GetPeliculas(string titulo, string duracion, int genero, int direc, DateOnly anioLanzamiento, DateOnly fecEstreno, string clasificacion)
        {
            throw new NotImplementedException();
        }

        public List<Peliculas_actores> GetPeliculasActores(int pelicula, int actores)
        {
            throw new NotImplementedException();
        }

        public List<Promociones> GetPromociones(string nombre, DateOnly dia, TimeOnly finalizacion, TimeOnly inicio, int descuento)
        {
            throw new NotImplementedException();
        }

        public List<Sucursales> GetSucursales(string nombre, string direccion, int provincia, int localidad, int barrio, string telefono)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> PostCliente(string nombre, string apellido, string email, string telefono, string usuario, string contraseña)
        {
            var Cliente = new Clientes
            {
                nombre_cliente = nombre,
                apellido_cliente = apellido,
                email = email,
                telefono = telefono,
                usuario = usuario,
                contraseña = contraseña
            };

            _context.Clientes.Add(Cliente);
            return await _context.SaveChangesAsync() > 0;
        }

        public bool PostComprobante()
        {
            throw new NotImplementedException();
        }
    }
}
