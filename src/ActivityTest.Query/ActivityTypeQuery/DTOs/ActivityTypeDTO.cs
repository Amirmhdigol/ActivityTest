using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityTest.Query.ActivityTypeQuery.DTOs;
public class ActivityTypeDTO 
{
    public int Id { get; set; }
    public DateTime CreationDate { get; set; }

    public int Code { get; set; }
    public bool IsActive { get; set; }
    public string Name { get; set; }
}