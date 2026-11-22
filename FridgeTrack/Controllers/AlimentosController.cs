using FridgeTrack.Models;
using Microsoft.AspNetCore.Mvc;

namespace FridgeTrack.Controllers
{
    public class AlimentosController : Controller
    {
        private readonly FridgeContext _context;

        public AlimentosController(FridgeContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var alimentos = _context.Alimentos.OrderBy(a => a.FechaVencimiento).ToList();
            return View(alimentos);
        }

        public IActionResult Detalle(int id)
        {
            var alimento = _context.Alimentos.Find(id);
            if (alimento == null)
            {
                return NotFound();
            }
            return View(alimento);
        }

        public IActionResult Crear()
        {
            var alimento = new Alimento { Cantidad = 1, FechaVencimiento = DateTime.Today.AddDays(7) };
            return View(alimento);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(Alimento alimento)
        {
            if (!ModelState.IsValid)
            {
                return View(alimento);
            }
            _context.Alimentos.Add(alimento);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Editar(int id)
        {
            var alimento = _context.Alimentos.Find(id);
            if (alimento == null)
            {
                return NotFound();
            }
            return View(alimento);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(Alimento alimento)
        {
            if (!ModelState.IsValid)
            {
                return View(alimento);
            }
            _context.Alimentos.Update(alimento);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Eliminar(int id)
        {
            var alimento = _context.Alimentos.Find(id);
            if (alimento == null)
            {
                return NotFound();
            }
            return View(alimento);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ConfirmarEliminar(int id)
        {
            var alimento = _context.Alimentos.Find(id);
            if (alimento != null)
            {
                _context.Alimentos.Remove(alimento);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
