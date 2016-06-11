using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace BeerTapV2.Common
{
    public interface IAutoMap
    {
        TClassTo Map< TClassFrom, TClassTo>(TClassFrom src);
    }

    public class AutoMap: IAutoMap
    {
        public TClassTo Map<TClassFrom, TClassTo>(TClassFrom src)
        {
            return AutoMapper.Mapper.Map<TClassFrom, TClassTo>(src);
        }
    }

    
}
