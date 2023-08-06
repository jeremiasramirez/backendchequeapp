using APICafeteria.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APICafeteria.Controllers
{
    [Route("solicitudes")]
    [ApiController]
    public class SolicitudRegistroChequeController : ControllerBase
    {
        // GET:  solicitudes 
        [Route("all")]
        [HttpGet]
        public IEnumerable<Models.SolicitudRegistroCheque> GetAllSolicitud()
        {
            using (var db = new Models.Cheques_ProveedoresContext())
            {
                var results = db.SolicitudRegistroCheques.ToList();
                return results;
            }

        }


        [HttpPost]
        [Route("nuevo")]
        public async Task SetSolicitud(int numeroSolicitud, string fechaRegistro, 
            string estado, int proveedorId,
            string cContableProveedor, int monto, string nombreProveedor)
        {

            var db = new Models.Cheques_ProveedoresContext();
            var entity = new SolicitudRegistroCheque()
            {
                NumeroSolicitud = numeroSolicitud,
                FechaRegistro = fechaRegistro,
                Estado = estado,
                ProveedorId = proveedorId,
                CContableProveedor = cContableProveedor,
                Monto = monto,
                ProveedorNombre = nombreProveedor


            };

            db.SolicitudRegistroCheques.Add(entity);
            await db.SaveChangesAsync();


        }
    }
}
 
