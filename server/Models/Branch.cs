using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace server.Models;

[Table("Branch")]
public  class Branch
{
    [Key]
    public int BranchId { get; set; }

    public string BranchName { get; set; } = null!;

    public string? BranchAddress { get; set; }

    public string BranchCity { get; set; } = null!;
}

