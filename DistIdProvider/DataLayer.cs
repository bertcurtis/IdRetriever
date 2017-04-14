using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistIdProvider
{
    public class DataLayer
    {
        public DataLayer()
        {
            CountryName = new List<string>();
            DistIds = new List<string>();
        }
        public List<string> CountryName { get; set; }
        public List<string> DistIds { get; set; }
        public bool WindowStay { get; set; }
        public int Index { get; set; }
    }
}
