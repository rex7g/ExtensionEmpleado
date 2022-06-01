using Microsoft.AspNetCore.Mvc;
using ExtensionEmpleado.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ExtensionEmpleado.Controllers
{
    public class ExtensionController : Controller
    {
        private readonly DataContext _db;

        public ExtensionController(DataContext db)
        {
             _db = db;
        }




        public  async Task<IActionResult> Crear( int? id)
        {
            Empleado empleado = new Empleado();
            {
                if(id==null)
                {
                    return View(empleado);
                }
                else
                {
                    empleado = await _db.Empleado.FindAsync(id);
                    return View(empleado);
                }
            }
        }


        [HttpPost]

        public async Task< IActionResult> Crear(Empleado empleado)
        { 
            if(ModelState.IsValid)
            {

                if (empleado.EmpleadoId == 0)
                {
                    await _db.Empleado.AddAsync(empleado);
                    await _db.SaveChangesAsync();
                    return RedirectToAction(nameof(Crear));
                }
                else
                {
                    _db.Empleado.Update(empleado);
                    await _db.SaveChangesAsync();
                    return RedirectToAction(nameof(Crear), new { id = 0 });
                }

            }

            return View(empleado);
        }
        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            var todos = await _db.Empleado.ToListAsync();
            return Json(new { data = todos });
        }


        [HttpDelete]
        public async Task<IActionResult> Delete(int? id)
        {
            var empleado = await _db.Empleado.FindAsync(id);
            if (empleado == null)
            {
                return Json(new { success = false, message = "Error al Borrar" });
            }
            _db.Empleado.Remove(empleado);
            await _db.SaveChangesAsync();
            return Json(new { success = true, message = "Empleado Eliminado Exitosamente!" });
        }

    }
}
