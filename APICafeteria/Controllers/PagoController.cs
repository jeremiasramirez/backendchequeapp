using APICafeteria.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APICafeteria.Controllers
{
    [Route("pago")]
    [ApiController]
    public class PagoController : ControllerBase
    {

        // GET:  pay 
        [Route("all")]
        [HttpGet]
        public IEnumerable<Models.Pago> GetAllPay()
        {
            using (var db = new Models.Cheques_ProveedoresContext())
            {
                var results = db.Pagos.ToList();
                return results;
            }

        }


        [HttpPost]
        [Route("nuevo")]
        public async Task setPago( string nombreProv, string cc, string fecha, int monto)
        {

            var db = new Models.Cheques_ProveedoresContext();
            var entity = new Pago()
            {
          
                NombreProveedor = nombreProv,
                CuentaContable = cc,
                Fecha = fecha,
                Monto=monto
                
            };

            db.Pagos.Add(entity);
            await db.SaveChangesAsync();


        }


    }
}
