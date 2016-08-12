using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Beertap.Model;

namespace Beertap.ApiServices
{
    public static class Common
    {
        public static BeerState GetBeerState(int ml)
        {
            if (ml > 2800)
            {
                return BeerState.New;
            }
            if (ml > 1200)
            {
                return BeerState.GoingDown;
            }
            if (ml > 1)
            {
                return BeerState.AlmostEmpty;
            }
            return BeerState.Dry;
        }
    }
}
