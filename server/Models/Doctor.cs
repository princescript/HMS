using System;
using System.Collections.Generic;

namespace server.Models;

public partial class Doctor 
{
    public int DocId { get; set; }

    public string DocName { get; set; } = null!;

    public string DocSpecialization { get; set; } = null!;

    public string? DocPhone { get; set; }
}
