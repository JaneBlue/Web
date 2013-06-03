using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LNCDCDSS.Models
{
    public class DataFromReporter
    {
        public DataFromReporter()
        {
            this.archetypesFromReporter = new List<ArchetypeFromReporter>();
        }
        public List<ArchetypeFromReporter> archetypesFromReporter { get; set; }
        public class ArchetypeFromReporter
        {
            public ArchetypeFromReporter()
            {
                this.valuesFromReporter = new List<ValueFromReporter>();
            }
            public string ArchetypeID { get; set; }
            public List<ValueFromReporter> valuesFromReporter { get; set; }
        }
        public class ValueFromReporter
        {
            public string Path { get; set; }
            public string Value { get; set; }
        }
    }
}