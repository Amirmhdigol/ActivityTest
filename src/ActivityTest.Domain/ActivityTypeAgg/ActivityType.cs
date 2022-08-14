using ActivityTest.Domain.Common;
using ActivityTest.Domain.Common.Bases;
using ActivityTest.Domain.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityTest.Domain.ActivityTypeAgg;
public class ActivityType : BaseEntity
{
    private ActivityType()
    {

    }
    public ActivityType(int code, bool isActive, string name)
    {
        Guard(name, code);
        Code = code;
        IsActive = isActive;
        Name = name;
    }

    public int Code { get; set; }
    public bool IsActive { get; set; }
    public string Name { get; set; }

    public void Edit(string name, bool isActive, int code)
    {
        Code = code;
        IsActive = isActive;
        Name = name;
    }

    public void Guard(string name, int code)
    {
        NullOrEmptyDomainDataException.CheckString(name, nameof(name));

        if (code == 0)
            throw new NullOrEmptyDomainDataException(code.ToString());
    }
}
