using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeerTapV2.Model;
using IQ.Platform.Framework.Common;
using IQ.Platform.Framework.WebApi.Model.Hypermedia;

namespace BeerTapV2.Model
{
    public class Tap: IIdentifiable<int>, IStatefulTap, IStatefulResource<TapState>
    {
        public int Id { get; }

        public TapState TapState { get; set; }
    }

    public enum TapState
    {
        New,
        GoinDown,
        AlmostDry,
        ShesDryMate
    }

    public interface IStatefulTap
    {
        TapState TapState { get; set; }
    }
}
