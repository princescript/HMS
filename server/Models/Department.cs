using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace server.Models;


[Table("Department")]
public partial class Department
{
    [Key]
    public int DepartId { get; set; }


    [Required]
    [StringLength(100)]

    public string DepartName { get; set; } = null!;

    [StringLength(250)]
    public string? DepartDescription { get; set; } 
}
