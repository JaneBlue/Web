using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LNCDCDSS.Models
{
    public class DataFromReporterOperation
    {
        public DataFromReporterOperation()
        {
            //String path = @"C:\Users\hudi\Documents\GitHub\";
            //archetypes.put("openEHR-EHR-OBSERVATION.mmse.v1"
            //    , System.IO.File.ReadAllText(path + @"Web\LNCDCDSS\LNCDCDSS\Archetypes\openEHR-EHR-OBSERVATION.mmse.v1.adl"));
            //archetypes.put("openEHR-EHR-OBSERVATION.other_cognitions_scale_exams.v1"
            //    , System.IO.File.ReadAllText(path + @"Web\LNCDCDSS\LNCDCDSS\Archetypes\openEHR-EHR-OBSERVATION.other_cognitions_scale_exams.v1.adl"));
            //archetypes.put("openEHR-EHR-OBSERVATION.related_disease_and_drug.v1"
            //    , System.IO.File.ReadAllText(path + @"Web\LNCDCDSS\LNCDCDSS\Archetypes\openEHR-EHR-OBSERVATION.related_disease_and_drug.v1.adl"));
            //archetypes.put("openEHR-EHR-OBSERVATION.adl.v1"
            //    , System.IO.File.ReadAllText(path + @"Web\LNCDCDSS\LNCDCDSS\Archetypes\openEHR-EHR-OBSERVATION.adl.v1.adl"));
            //archetypes.put("openEHR-EHR-OBSERVATION.body_check.v1"
            //    , System.IO.File.ReadAllText(path + @"Web\LNCDCDSS\LNCDCDSS\Archetypes\openEHR-EHR-OBSERVATION.body_check.v1.adl"));
            //archetypes.put("openEHR-EHR-OBSERVATION.cdr.v1"
            //    , System.IO.File.ReadAllText(path + @"Web\LNCDCDSS\LNCDCDSS\Archetypes\openEHR-EHR-OBSERVATION.cdr.v1.adl"));
            //archetypes.put("openEHR-EHR-OBSERVATION.gds.v1"
            //    , System.IO.File.ReadAllText(path + @"Web\LNCDCDSS\LNCDCDSS\Archetypes\openEHR-EHR-OBSERVATION.gds.v1.adl"));
            //archetypes.put("openEHR-EHR-OBSERVATION.moca.v1"
            //    , System.IO.File.ReadAllText(path + @"Web\LNCDCDSS\LNCDCDSS\Archetypes\openEHR-EHR-OBSERVATION.moca.v1.adl"));
        }

        public String[] CreatedADL(Dictionary<Dictionary<string, object>, string> results)
        {
            //create the list of dADLs
            String[] list_dADLs;
            //get the results' count
            int nCountResults = results.Count;
            //initial list_dADLs
            list_dADLs = new String[nCountResults];
            
            //get results' key set
            int nIndexResults = 0;
            foreach (Dictionary<string, object> it_key in results.Keys)
            {
                //get the value by the key
                String strArchetypeId = results[it_key];

                //temp escape "openEHR-EHR-OBSERVATION.body_check.v1"
                if ("openEHR-EHR-OBSERVATION.body_check.v1" == strArchetypeId)
                    continue;

                //get SkeletonGenerator
                org.openehr.rm.util.SkeletonGenerator generator = org.openehr.rm.util.SkeletonGenerator.getInstance();
                //get the archetype instance
                String strArchetypeString = LNCDCDSS.MvcApplication.archetypes.get(strArchetypeId) as String;
                se.acode.openehr.parser.ADLParser parser = new se.acode.openehr.parser.ADLParser(strArchetypeString);
                org.openehr.am.archetype.Archetype archetype = parser.parse();
                //create the dADL object
                Object result = generator.create(archetype, org.openehr.rm.util.GenerationStrategy.MAXIMUM_EMPTY);
                if (result is org.openehr.rm.common.archetyped.Locatable) 
                {
                    org.openehr.rm.common.archetyped.Locatable loc = result as org.openehr.rm.common.archetyped.Locatable;
                    if (null != loc)
                    {
                        CreatedADLHelper oCreatedADLHelper = new CreatedADLHelper();

                        //set the value into loc
                        oCreatedADLHelper.setArchetypeValue(archetype, loc, it_key);
                        //Generate uid for archetype
                        org.openehr.rm.support.identification.HierObjectID uid =
                            new org.openehr.rm.support.identification.HierObjectID(System.Guid.NewGuid().ToString());
                        loc.setUid(uid);
                        //change the loc into dADL
                        org.openehr.rm.binding.DADLBinding binding = new org.openehr.rm.binding.DADLBinding();
                        String strdADL = dADLtoString(binding.toDADL(loc));
                        //add the dADL string into list of dADLs
                        list_dADLs[nIndexResults] = strdADL;
                        ++nIndexResults;
                    }
			    }
            }

            return list_dADLs;
        }

        protected String dADLtoString(java.util.List results)
        {
            java.lang.StringBuilder sb = new java.lang.StringBuilder();
            int nCount = results.size();
            for (int nIndex = 0; nIndex < nCount; ++nIndex)
            {
                String str = results.get(nIndex) as String;
                sb.append(str);
			    sb.append("\n");
            }
		    
		    return sb.toString();
        }

        protected static String readLines(String name)
        {
            //java.lang.StringBuilder result = new java.lang.StringBuilder();
            //java.io.BufferedReader reader = new java.io.BufferedReader(new java.io.InputStreamReader(
            //        java.lang.Thread.currentThread().getContextClassLoader().getResourceAsStream(name)));

            //String line = reader.readLine();
            //while (line != null)
            //{
            //    result.append(line);
            //    result.append("\n");
            //    line = reader.readLine();
            //}
            //return result.toString();
            String strtemp = System.IO.File.ReadAllText(name);
            return strtemp;
        }

        //protected java.util.Map archetypes = new java.util.HashMap();
    }
}