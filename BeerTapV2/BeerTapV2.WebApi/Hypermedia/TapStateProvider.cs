using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BeerTapV2.Model;
using IQ.Platform.Framework.Common;
using IQ.Platform.Framework.WebApi.Hypermedia;
using IQ.Platform.Framework.WebApi.Model.Hypermedia;

namespace BeerTapV2.WebApi.Hypermedia
{

    public abstract class TapStateProvider<TTapResource>: 
        ResourceStateProviderBase<TTapResource, TapState>
        where TTapResource : IStatefulResource<TapState>, IStatefulTap
    {
        public override TapState GetFor(TTapResource resource)
        {
            return resource.TapState;
        }

        protected override IDictionary<TapState, IEnumerable<TapState>> GetTransitions()
        {
            return new Dictionary<TapState, IEnumerable<TapState>>
            {
                {
                    TapState.New, new[]
                    {
                        TapState.GoinDown,
                        TapState.AlmostDry,
                        TapState.ShesDryMate
                    }
                },
                {
                    TapState.GoinDown,
                    new []
                    {
                        TapState.AlmostDry,
                        TapState.ShesDryMate
                    }
                },
                {
                    TapState.AlmostDry,
                    new []
                    {
                        TapState.ShesDryMate
                    }
                }
            };
        }

        public override IEnumerable<TapState> All => EnumEx.GetValuesFor<TapState>();
    }

    public class TapStateProvider: TapStateProvider<Tap>
    {
    }
}