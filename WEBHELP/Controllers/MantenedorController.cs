using Microsoft.AspNetCore.Mvc;

using WEBHELP.Datos;
using WEBHELP.Models;

namespace WEBHELP.Controllers
{
    public class MantenedorController : Controller
    {
        EmpleadoDatos _EmpleadoDatos = new EmpleadoDatos();
        public IActionResult Listar()
        {
            //Vista para mostrar la lista de empleados
            var oLista = _EmpleadoDatos.Listar();

            return View(oLista);
        }

        public IActionResult Guardar()
        {
            //Solo devuelve la vista html
            return View();
        }


        [HttpPost]

        public IActionResult Guardar(EmpleadoModel oEmpleado){
            //Recibe un objeto y lo guarda en la base de datos

            if(!ModelState.IsValid)
                return View();


            var respuesta = _EmpleadoDatos.Guardar(oEmpleado);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Editar(int IdEmpleado)
        {
            //Solo devuelve la vista html
            var oempleado = _EmpleadoDatos.Obtener(IdEmpleado);
            return View(oempleado);
        }

        [HttpPost]
        public IActionResult Editar(EmpleadoModel oEmpleado)
        {
 
            if (!ModelState.IsValid)
                return View();


            var respuesta = _EmpleadoDatos.Editar(oEmpleado);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Eliminar(int IdEmpleado)
        {
            //METODO SOLO DEVUELVE LA VISTA
            var oempleado = _EmpleadoDatos.Obtener(IdEmpleado);
            return View(oempleado);
        }

        [HttpPost]
        public IActionResult Eliminar(EmpleadoModel oEmpleado)
        {

            var respuesta = _EmpleadoDatos.Eliminar(oEmpleado.IdEmpleado);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

    }
}
