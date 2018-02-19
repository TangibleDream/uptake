using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UptakeTechTest.pages
{
    class ResultsPage
    {
        public string getFeetToPaint(int rooms)
        {
            return $"//tr[{rooms + 1}]/td[2]";
        }
        public string lblTotalGallons = ".//h5[contains(text(),\"Total Gallons Required:\")]";        
    }
}
