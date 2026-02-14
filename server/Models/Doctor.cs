using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace server.Models;

[Table("Doctor")]
public partial class Doctor 
{
    [Key]
    public int DocId { get; set; }

    public string DocName { get; set; } = null!;

    public string DocSpecialization { get; set; } = null!;

    public string? DocPhone { get; set; }
}
