using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Reflection;

namespace LNCDCDSS.Models
{
    public class CreatedADLHelper
    {
        public static String getArchetypeNodePath(org.openehr.am.archetype.Archetype archetype, String name) 
        {
		    java.util.Map patheNodeMap = archetype.getPathNodeMap();
		    java.util.Set pathSet = patheNodeMap.keySet();
		    String nodePath = "";
		    for (java.util.Iterator it_key = pathSet.iterator(); it_key.hasNext();) 
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

        public static void setArchetypeValue(
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
                String nodePath = CreatedADLHelper.getArchetypeNodePath(archetype, strPath);
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
                        Type tPropertyType = tempTarget.GetType().GetProperty(pathSegment).GetType();

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
			
    //			loc.set(nodePath, target);			
		    }
	    }
    }
}