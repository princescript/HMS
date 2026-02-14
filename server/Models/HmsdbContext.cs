
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace server.Models;

public partial class HmsdbContext : DbContext
{

    public HmsdbContext(DbContextOptions<HmsdbContext> options): base(options)
    {
    }

    public virtual DbSet<Branch> DbBranch { get; set; }

   public virtual DbSet<Department> DbDepartment { get; set; }

    //public virtual DbSet<Doctor> Doctors { get; set; }


    

    
}
