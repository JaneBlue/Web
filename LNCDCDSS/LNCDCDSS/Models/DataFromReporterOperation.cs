﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;

namespace LNCDCDSS.Models
{
    public class DataFromReporterOperation
    {
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
                        //set the value into loc
                        setArchetypeValue(archetype, loc, it_key);
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

        public String getArchetypeNodePath(org.openehr.am.archetype.Archetype archetype, String name)
        {
            java.util.Map patheNodeMap = archetype.getPathNodeMap();
            java.util.Set pathSet = patheNodeMap.keySet();
            String nodePath = "";
            for (java.util.Iterator it_key = pathSet.iterator(); it_key.hasNext(); )
            {
                String path = it_key.next() as String;
                if (name.StartsWith(path))
                {
                    if (path.Length > nodePath.Length)
                    {
                        nodePath = path;
                    }
                }
            }

            return nodePath;
        }

        public void setArchetypeValue(
            org.openehr.am.archetype.Archetype archetype,
            org.openehr.rm.common.archetyped.Locatable loc,
            Dictionary<string, object> values)
        {
            java.util.Map map_values = new java.util.HashMap();
            map_values.put(org.openehr.build.SystemValue.LANGUAGE, new org.openehr.rm.datatypes.text.CodePhrase("ISO_639-1", "en"));
            map_values.put(org.openehr.build.SystemValue.CHARSET, new org.openehr.rm.datatypes.text.CodePhrase("IANA_character-sets",
            "UTF-8"));
            map_values.put(org.openehr.build.SystemValue.ENCODING, new org.openehr.rm.datatypes.text.CodePhrase("IANA_character-sets",
            "UTF-8"));
            map_values.put(org.openehr.build.SystemValue.TERMINOLOGY_SERVICE, org.openehr.terminology.SimpleTerminologyService.getInstance());
            map_values.put(org.openehr.build.SystemValue.MEASUREMENT_SERVICE, org.openehr.rm.support.measurement.SimpleMeasurementService.getInstance());
            org.openehr.build.RMObjectBuilder rmBuilder = new org.openehr.build.RMObjectBuilder(map_values);

            foreach (string strPath in values.Keys)
            {
                java.util.Map pathNodeMap = archetype.getPathNodeMap();
                String nodePath = getArchetypeNodePath(archetype, strPath);
                org.openehr.am.archetype.constraintmodel.CObject node = pathNodeMap.get(nodePath) as org.openehr.am.archetype.constraintmodel.CObject;
                Object target = loc.itemAtPath(nodePath);
                if (target == null)
                {
                    java.lang.Class klass = rmBuilder.retrieveRMType(node.getRmTypeName());
                    target = klass.newInstance();
                }

                String attributePath = strPath.Substring(nodePath.Length);
                String[] attributePathSegments = attributePath.Split('/');
                Object tempTarget = target;
                foreach (String pathSegment in attributePathSegments)
                {
                    if ("" != pathSegment)
                    {
                        Type tObjectType = tempTarget.GetType();
                        PropertyInfo iPropertyInfo = tObjectType.GetProperty(pathSegment);
                        Type tPropertyType = iPropertyInfo.GetType();

                        //Class klass = ReflectHelper.getter(tempTarget.getClass(), pathSegment).getReturnType();
                        //PropertyAccessor propertyAccessor = new ChainedPropertyAccessor(
                        //        new PropertyAccessor[] {
                        //                PropertyAccessorFactory.getPropertyAccessor(tempTarget.getClass(), null),
                        //                PropertyAccessorFactory.getPropertyAccessor("field")
                        //        }
                        //);
                        //Setter setter = propertyAccessor.getSetter(tempTarget.getClass(), pathSegment);
                        if (tPropertyType.IsPrimitive || tPropertyType == typeof(String))
                        {
                            //setter.set(tempTarget, values.get(path), null);
                            tempTarget.GetType().GetProperty(pathSegment).SetValue(tempTarget, values[strPath], null);
                        }
                        else
                        {
                            Object value = Activator.CreateInstance(tPropertyType);
                            //setter.set(tempTarget, value, null);
                            tempTarget.GetType().GetProperty(pathSegment).SetValue(tempTarget, value, null);
                            tempTarget = value;
                        }
                    }
                }		
            }
        }
    }
}