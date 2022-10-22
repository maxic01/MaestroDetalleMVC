using MaestroDetalleMVC.Models;
using MaestroDetalleMVC.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MaestroDetalleMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly MVCDBContext _context;

        public HomeController(MVCDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index([FromBody] FacturaViewModel oFacturaViewModel)
        {
            Factura oFactura = oFacturaViewModel.oFactura;
            using (var _contexTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    oFactura.DetalleFacturas = oFacturaViewModel.oDetalle;

                    _context.Facturas.Add(oFactura);

                    _context.SaveChanges();

                    _contexTransaction.Commit();
                }
                catch (Exception)
                {
                    _contexTransaction.Rollback();
                }
            }                   
            return Json(new{ respuesta = true});
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}