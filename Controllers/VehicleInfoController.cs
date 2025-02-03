using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class VehicleInfoController : Controller
    {

        public ActionResult ListInfo()
        {
           using VmsContext vmsContext = new ();   
            List<VehicleMaster> d = new List<VehicleMaster>();
            d = vmsContext.VehicleMasters.ToList(); 
            return View(d);
        }


        public IActionResult Index(int? id)
        {
            VehilceDatacs vehicleMaster = new VehilceDatacs();

            if(id.HasValue)
            {
                VmsContext vmsContext = new VmsContext();
                var p = vmsContext.VehicleMasters.Find(id);
                vehicleMaster.PlateNumber = p.PlateNumber;
                vehicleMaster.PassingYear= p.PassingYear;   
                vehicleMaster.Make = p.Make;
                vehicleMaster.IsActive = p.IsActive.Value;
                vehicleMaster.Type = p.Type;    


            }

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

            if (av.Id == 0)
            {
                VehicleMaster d = new VehicleMaster();
                d.IsActive = av.IsActive;
                d.PlateNumber = av.PlateNumber;
                d.Model = av.Model;
                d.Make = av.Make;
                d.Type = av.Type;
                d.PassingYear = av.PassingYear;
                vmsContext.VehicleMasters.Add(d);
            }
            else
            {
                var vehicle = vmsContext.VehicleMasters.Find(av.Id);
                vehicle.PlateNumber = av.PlateNumber;
                vehicle.Model = av.Model;
                vehicle.Make = av.Make; 
                vehicle.Type = av.Type;
                vehicle.IsActive = av.IsActive; 

            }

            vmsContext.SaveChanges();

            return RedirectToAction("ListInfo");
        }

        public ActionResult DeleteInfo(int id)
        {
            using VmsContext vmsContext = new();

            var d = vmsContext.VehicleMasters.Find(id);

            vmsContext.VehicleMasters.Remove(d);

            vmsContext.SaveChanges();

            return RedirectToAction("ListInfo");   
        }

       
    }
}
