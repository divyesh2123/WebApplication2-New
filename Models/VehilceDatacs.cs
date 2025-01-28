using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication2.Models
{
    public class VehilceDatacs
    {
        public int Id { get; set; }

        public string? PlateNumber { get; set; }

        public string? Model { get; set; }

        public string? Make { get; set; }

        public bool IsActive { get; set; }

        public string? Type { get; set; }

        public int? PassingYear { get; set; }

        public List<SelectListItem> Items { get; set; }
    }
}
