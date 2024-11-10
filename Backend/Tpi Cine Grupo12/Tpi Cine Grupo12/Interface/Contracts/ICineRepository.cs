using Tpi_Cine_Grupo12.Models;

namespace Tpi_Cine_Grupo12.Interface.Contracts
{
    public interface ICineRepository
    {
       //Metodos GET
        List<Funciones> GetFunciones(int pelicula, int sala, DateOnly dia, TimeOnly horario, string varchar, string tipo_funcion);
        List<Sucursales> GetSucursales(string nombre, string direccion, int provincia, int localidad, int barrio, string telefono);
        Task<List<Clientes>> GetClientes(string usuario, string contraseña);
        List<Peliculas> GetPeliculas(string titulo, string duracion, int genero, int direc, DateOnly anioLanzamiento, DateOnly fecEstreno, string clasificacion );
        List<Promociones> GetPromociones(string nombre, DateOnly dia, TimeOnly finalizacion, TimeOnly inicio, int descuento);
        Task<List<Generos>> GetGeneros();
        Task<List<Butacas>> GetButacasDisponibles(int ticket);
        List <Peliculas_actores> GetPeliculasActores(int pelicula, int actores);

        // Metodos POST
        bool PostComprobante();
        Task<bool> PostCliente(string nombre, string apellido, string email, string telefono, string usuario, string contraseña);

        // Metodos PUT
        bool ButacaReservada(int funcionButaca, int funcion, int sala, int num, int fila, int ticket);
        Task<bool> CancelarCompra(int comprobante);
    }
}
