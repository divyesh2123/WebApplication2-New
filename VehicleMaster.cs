using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace WebApplication2;

public partial class VehicleMaster
{
    

    public int Id { get; set; }

    public string? PlateNumber { get; set; }

    public string? Model { get; set; }

    public string? Make { get; set; }

    public bool? IsActive { get; set; }

    public string? Type { get; set; }

    public int? PassingYear { get; set; }



}
