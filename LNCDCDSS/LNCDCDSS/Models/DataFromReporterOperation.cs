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
            archetypes.put("openEHR-EHR-OBSERVATION.mmse.v1"
                , readLines("C:\\Users\\hudi\\Documents\\GitHub\\CDRDocument\\knowledge\\archetype\\ZJU\\CDSS\\openEHR-EHR-OBSERVATION.mmse.v1.adl"));
            archetypes.put("openEHR-EHR-OBSERVATION.other_cognitions_scale_exams.v1"
                , readLines("C:\\Users\\hudi\\Documents\\GitHub\\CDRDocument\\knowledge\\archetype\\ZJU\\CDSS\\openEHR-EHR-OBSERVATION.other_cognitions_scale_exams.v1.adl"));
            archetypes.put("openEHR-EHR-OBSERVATION.related_disease_and_drug.v1"
                , readLines("C:\\Users\\hudi\\Documents\\GitHub\\CDRDocument\\knowledge\\archetype\\ZJU\\CDSS\\openEHR-EHR-OBSERVATION.related_disease_and_drug.v1.adl"));
            archetypes.put("openEHR-EHR-OBSERVATION.adl.v1"
                , readLines("C:\\Users\\hudi\\Documents\\GitHub\\CDRDocument\\knowledge\\archetype\\ZJU\\CDSS\\openEHR-EHR-OBSERVATION.adl.v1.adl"));
            archetypes.put("openEHR-EHR-OBSERVATION.body_check.v1"
                , readLines("C:\\Users\\hudi\\Documents\\GitHub\\CDRDocument\\knowledge\\archetype\\ZJU\\CDSS\\openEHR-EHR-OBSERVATION.body_check.v1.adl"));
            archetypes.put("openEHR-EHR-OBSERVATION.cdr.v1"
                , readLines("C:\\Users\\hudi\\Documents\\GitHub\\CDRDocument\\knowledge\\archetype\\ZJU\\CDSS\\openEHR-EHR-OBSERVATION.cdr.v1.adl"));
            archetypes.put("openEHR-EHR-OBSERVATION.gds.v1"
                , readLines("C:\\Users\\hudi\\Documents\\GitHub\\CDRDocument\\knowledge\\archetype\\ZJU\\CDSS\\openEHR-EHR-OBSERVATION.gds.v1.adl"));
            archetypes.put("openEHR-EHR-OBSERVATION.moca.v1"
                , readLines("C:\\Users\\hudi\\Documents\\GitHub\\CDRDocument\\knowledge\\archetype\\ZJU\\CDSS\\openEHR-EHR-OBSERVATION.moca.v1.adl"));
        }

        public String[] CreatedADL(java.util.Map results)
        {
            //create the list of dADLs
            String[] list_dADLs;
            //get the results' count
            int nCountResults = results.size();
            //initial list_dADLs
            list_dADLs = new String[nCountResults];
            
            //get results' key set
            int nIndexResults = 0;
            java.util.Set list_key = results.keySet();
            for (java.util.Iterator it_key = list_key.iterator(); it_key.hasNext();) 
            {
                //get one key in results
                java.util.HashMap values = it_key.next() as java.util.HashMap;
                //get the value by the key
                String strArchetypeId = results.get(values) as String;

                //temp escape "openEHR-EHR-OBSERVATION.body_check.v1"
                if ("openEHR-EHR-OBSERVATION.body_check.v1" == strArchetypeId)
                    continue;

                //get SkeletonGenerator
                org.openehr.rm.util.SkeletonGenerator generator = org.openehr.rm.util.SkeletonGenerator.getInstance();
                //get the archetype instance
                String strArchetypeString = archetypes.get(strArchetypeId) as String;
                se.acode.openehr.parser.ADLParser parser = new se.acode.openehr.parser.ADLParser(strArchetypeString);
                org.openehr.am.archetype.Archetype archetype = parser.parse();
                //create the dADL object
                Object result = generator.create(archetype, org.openehr.rm.util.GenerationStrategy.MAXIMUM_EMPTY);
                if (result is org.openehr.rm.common.archetyped.Locatable) 
                {
                    org.openehr.rm.common.archetyped.Locatable loc = result as org.openehr.rm.common.archetyped.Locatable;
                    if (null != loc)
                    {
                        //set the value into loc
                        CreatedADLHelper.setArchetypeValue(archetype, loc, values);
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

        protected static String dADLtoString(java.util.List results)
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

        protected java.util.Map archetypes = new java.util.HashMap();
    }
}