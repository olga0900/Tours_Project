using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToursProject.Order
{
    public static class StaticOrder
    {
        public class ToursWithCount
        {
            public TourPanel tour;
            public int count;
        }
        public static List<ToursWithCount> TourPanels = new List<ToursWithCount>();

    }
}
