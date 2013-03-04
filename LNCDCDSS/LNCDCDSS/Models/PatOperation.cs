using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LNCDCDSS.Models
{
    public class PatOperation
    {
        LNCDDataModelContainer context = new LNCDDataModelContainer();
        public IEnumerable<PatBasicInfor> GetPats()
        {
            return context.PatBasicInforSet.ToList();
        }
        public void InsertPat(PatBasicInfor pat)
        {
            context.PatBasicInforSet.Add(pat);
        }
    }
}