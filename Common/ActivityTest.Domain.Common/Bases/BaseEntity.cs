using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityTest.Domain.Common.Bases
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            CreationDate = DateTime.Now;
        }

        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
