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

        public static void setArchetypeValue(org.openehr.am.archetype.Archetype archetype, org.openehr.rm.common.archetyped.Locatable loc
            , java.util.Map values) 
		{
		    java.util.Set list_key = values.keySet();
            for (java.util.Iterator it_key = list_key.iterator(); it_key.hasNext();) 
            {
                String strPath = it_key.next() as String;
			    java.util.Map pathNodeMap = archetype.getPathNodeMap();
                String nodePath = CreatedADLHelper.getArchetypeNodePath(archetype, strPath);
			    org.openehr.am.archetype.constraintmodel.CObject node = pathNodeMap.get(nodePath) as org.openehr.am.archetype.constraintmodel.CObject;
			    Object target = loc.itemAtPath(nodePath);
                //if (target == null) 
                //{
                //    java.lang.Class klass = ArchetypeRepository.getRMBuilder().retrieveRMType(node.getRmTypeName());
                //    target = klass.newInstance();
                //}

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
                            tempTarget.GetType().GetProperty(pathSegment).SetValue(tempTarget, values.get(strPath), null);
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