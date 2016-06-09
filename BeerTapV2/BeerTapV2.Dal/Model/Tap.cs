using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerTapV2.Dal.Model
{
    public class Tap
    {
        public int Id { get; set; }
        public virtual Office  Office { get; set; }
        public virtual Keg Keg { get; set; }
    }
}
