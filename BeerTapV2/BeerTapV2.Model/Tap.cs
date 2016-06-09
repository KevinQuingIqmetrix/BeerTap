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
    /// <summary>
    /// tap resource
    /// </summary>
    public class Tap: IIdentifiable<int>, IStatefulTap, IStatefulResource<TapState>
    {
        /// <summary>
        /// tap resource identity
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// tap state depending on keg milliliters / capacity percentage
        /// </summary>
        public TapState TapState { get; set; }
        /// <summary>
        /// Keg on Tap
        /// </summary>
        public Keg Keg { get; set; }
    }

    /// <summary>
    /// tap states
    /// </summary>
    public enum TapState
    {
        /// <summary>
        /// newly created keg on tap
        /// </summary>
        New,
        /// <summary>
        /// not so new keg
        /// </summary>
        GoinDown,
        /// <summary>
        /// keg fill is below keg threshold
        /// </summary>
        AlmostDry,
        /// <summary>
        /// keg milliliters is 0
        /// </summary>
        ShesDryMate
    }
    /// <summary>
    /// interface that make taps stateful
    /// </summary>
    public interface IStatefulTap
    {
        /// <summary>
        /// state of tap
        /// </summary>
        TapState TapState { get; set; }
    }
}
