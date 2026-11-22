using FridgeTrack.Controllers;
using FridgeTrack.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FridgeTrack.Tests
{
    [TestClass]
    public class AlimentosControllerTests
    {
        private FridgeContext CrearContexto()
        {
            var opciones = new DbContextOptionsBuilder<FridgeContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new FridgeContext(opciones);
            context.Database.EnsureCreated();
            return context;
        }

        [TestMethod]
        public void Index_MuestraLosAlimentosDeLaBaseDeDatos()
        {
            var controller = new AlimentosController(CrearContexto());

            var resultado = controller.Index() as ViewResult;
            var alimentos = resultado!.Model as List<Alimento>;

            Assert.HasCount(6, alimentos!);
        }

        [TestMethod]
        public void Crear_AgregaUnAlimentoNuevo()
        {
            var context = CrearContexto();
            var controller = new AlimentosController(context);
            var nuevo = new Alimento { Nombre = "Yogurt", Categoria = "Lacteos", Cantidad = 4, FechaVencimiento = new DateTime(2026, 12, 1) };

            var resultado = controller.Crear(nuevo);

            Assert.IsInstanceOfType(resultado, typeof(RedirectToActionResult));
            Assert.AreEqual(7, context.Alimentos.Count());
            Assert.IsTrue(context.Alimentos.Any(a => a.Nombre == "Yogurt"));
        }

        [TestMethod]
        public void Editar_CambiaLosDatosDelAlimento()
        {
            var context = CrearContexto();
            var controller = new AlimentosController(context);
            var leche = context.Alimentos.Find(1)!;
            leche.Nombre = "Leche descremada";
            leche.Cantidad = 5;

            controller.Editar(leche);

            var editado = context.Alimentos.Find(1)!;
            Assert.AreEqual("Leche descremada", editado.Nombre);
            Assert.AreEqual(5, editado.Cantidad);
        }

        [TestMethod]
        public void ConfirmarEliminar_BorraElAlimento()
        {
            var context = CrearContexto();
            var controller = new AlimentosController(context);

            controller.ConfirmarEliminar(2);

            Assert.AreEqual(5, context.Alimentos.Count());
            Assert.IsNull(context.Alimentos.Find(2));
        }
    }
}
