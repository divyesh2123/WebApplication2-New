using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class VehicleInfoController : Controller
    {
        public IActionResult Index()
        {
            VehilceDatacs vehicleMaster = new VehilceDatacs();

            vehicleMaster.Items = new List<SelectListItem>();

            for(int yea=DateTime.Now.Year;yea> DateTime.Now.Year-10;yea--)
            {
                vehicleMaster.Items.Add(new SelectListItem
                {
                    Text = yea.ToString(),
                    Value = yea.ToString()
                });
            }


            return View(vehicleMaster);
        }

        [HttpPost]
        public IActionResult Index(VehicleMaster av)
        {
            using VmsContext vmsContext = new();

            VehicleMaster d = new VehicleMaster();
            d.IsActive = av.IsActive;
            d.PlateNumber = av.PlateNumber;
            d.Model = av.Model;
            d.Make = av.Make;
            d.Type = av.Type;
            d.PassingYear = av.PassingYear; 

            vmsContext.VehicleMasters.Add(d);

            vmsContext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
