using ActivityTest.Domain.Common.Bases;
using ActivityTest.Domain.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityTest.Domain.ActivityTypeAgg;
public class ActivityTypeLog : BaseEntity
{
    private ActivityTypeLog()
    {

    }
  
    public ActivityTypeLog(string information)
    {
        Guard(information);
        Information = information;
    } 

    public string Information { get; set; }
    
    public void Edit(string information)
    {
        Information = information;
    }
    private static void Guard(string information)
    {
        NullOrEmptyDomainDataException.CheckString(information, nameof(information));
    }

}
