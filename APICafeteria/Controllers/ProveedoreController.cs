using APICafeteria.Models;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http.Cors;

namespace APICafeteria.Controllers
{
    [Route("proveedores")]
    [ApiController]
    // [EnableCors(origins: "http://localhost:8000/proveedores", headers: "*", methods: "*")]
    public class ProveedoreController : ControllerBase
    {

        [Route("all")]
        [HttpGet]
        public IEnumerable<Models.Proveedore> GetAllProveedores()
        {
            using (var db = new Models.Cheques_ProveedoresContext())
            {
                var results = db.Proveedores.ToList();
                return results;
            }

        }


        [Route("byid")]
        [HttpGet]
        public IEnumerable<Models.Proveedore> GetProveedorById(int id_proveedor)
        {
            using (var db = new Models.Cheques_ProveedoresContext())
            {
 
                var results = db.Proveedores.Where(e => e.ProveedorId == id_proveedor).ToList().FirstOrDefault();
                yield return results;
#pragma warning restore CS8600 // Se va a convertir un literal nulo o un posible valor nulo en un tipo que no acepta valores NULL

            }

        }


        [Route("bycedula")]
        [HttpGet]
        public IEnumerable<Models.Proveedore> GetProveedorByCedula(string cedula)
        {
            using (var db = new Models.Cheques_ProveedoresContext())
            {

                var results = db.Proveedores.Where(e => e.Cedula == cedula).ToList().FirstOrDefault();
                yield return results;
#pragma warning restore CS8600 // Se va a convertir un literal nulo o un posible valor nulo en un tipo que no acepta valores NULL

            }





        }

        [HttpPost]
        [Route("nuevo")]
        public async Task SetProveedor(string nombre, string tipo, string cedula, int balance,
             int cuentaContable, string estado)
        {

            var db = new Models.Cheques_ProveedoresContext();
            var entity = new Proveedore()
            {
                Nombre = nombre,
                Tipo = tipo,
                Cedula = cedula,
                Balance = balance,
                CuentaContable = cuentaContable,
                Estado = estado
            };

            db.Proveedores.Add(entity);
            await db.SaveChangesAsync();


        }


        [HttpPost]
        [Route("delete")]
        public async Task DeleteProveedor(int id_proveedor)
        {

            var db = new Models.Cheques_ProveedoresContext();

            var rmProveedor = db.Proveedores.Where(e => e.ProveedorId == id_proveedor).FirstOrDefault();

            db.Proveedores.RemoveRange(rmProveedor);
            db.SaveChanges();


        }




        [HttpPost]
        [Route("update")]
        public async Task UpdateProveedor(int id_proveedor, string nombre, string tipo, string cedula, int balance,
              int cuentaContable, string estado)
        {

            using (var db = new Models.Cheques_ProveedoresContext())
            {
                var addprov = db.Proveedores.Where(e => e.ProveedorId == id_proveedor).FirstOrDefault();

#pragma warning disable CS8602 // Desreferencia de una referencia posiblemente NULL.

                addprov.Nombre = nombre;
                addprov.Tipo = tipo;
                addprov.Cedula = cedula;
                addprov.Balance = balance;
                addprov.CuentaContable = cuentaContable;
                addprov.Estado = estado;
#pragma warning restore CS8602 // Desreferencia de una referencia posiblemente NULL.

                db.SaveChanges();
            }

        

        }







        /*[HttpPost]
     [Route("new")]
     public async Task SetFacturation(  )
     {

         var db = new Models.();
         var entity = new Facturacion()
         {
             NombreCliente = name,
             NombreProducto = productname,
             Cantidad = cantidad,
             Subtotal = subtotal,
             Total = total,
             Estado = estado
         };

         db.Facturacions.Add(entity);
         await db.SaveChangesAsync();


     }
     */
    }
}
