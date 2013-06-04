using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace LNCDCDSS
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected static java.util.Map archetypes = new java.util.HashMap();
        protected static java.util.Map arms = new java.util.HashMap();

        public static void ReadArchetypes()
        {
            archetypes.put("openEHR-EHR-OBSERVATION.mmse.v1"
                , System.IO.File.ReadAllText(@"C:\Users\hudi\Documents\GitHub\Web\LNCDCDSS\LNCDCDSS\Archetypes\openEHR-EHR-OBSERVATION.mmse.v1.adl"));
            archetypes.put("openEHR-EHR-OBSERVATION.other_cognitions_scale_exams.v1"
                , System.IO.File.ReadAllText(@"C:\Users\hudi\Documents\GitHub\Web\LNCDCDSS\LNCDCDSS\Archetypes\openEHR-EHR-OBSERVATION.other_cognitions_scale_exams.v1.adl"));
            archetypes.put("openEHR-EHR-OBSERVATION.related_disease_and_drug.v1"
                , System.IO.File.ReadAllText(@"C:\Users\hudi\Documents\GitHub\Web\LNCDCDSS\LNCDCDSS\Archetypes\openEHR-EHR-OBSERVATION.related_disease_and_drug.v1.adl"));
            archetypes.put("openEHR-EHR-OBSERVATION.adl.v1"
                , System.IO.File.ReadAllText(@"C:\Users\hudi\Documents\GitHub\Web\LNCDCDSS\LNCDCDSS\Archetypes\openEHR-EHR-OBSERVATION.adl.v1.adl"));
            archetypes.put("openEHR-EHR-OBSERVATION.body_check.v1"
                , System.IO.File.ReadAllText(@"C:\Users\hudi\Documents\GitHub\Web\LNCDCDSS\LNCDCDSS\Archetypes\openEHR-EHR-OBSERVATION.body_check.v1.adl"));
            archetypes.put("openEHR-EHR-OBSERVATION.cdr.v1"
                , System.IO.File.ReadAllText(@"C:\Users\hudi\Documents\GitHub\Web\LNCDCDSS\LNCDCDSS\Archetypes\openEHR-EHR-OBSERVATION.cdr.v1.adl"));
            archetypes.put("openEHR-EHR-OBSERVATION.gds.v1"
                , System.IO.File.ReadAllText(@"C:\Users\hudi\Documents\GitHub\Web\LNCDCDSS\LNCDCDSS\Archetypes\openEHR-EHR-OBSERVATION.gds.v1.adl"));
            archetypes.put("openEHR-EHR-OBSERVATION.moca.v1"
                , System.IO.File.ReadAllText(@"C:\Users\hudi\Documents\GitHub\Web\LNCDCDSS\LNCDCDSS\Archetypes\openEHR-EHR-OBSERVATION.moca.v1.adl"));
        }

        public static void ReadARMs()
        {
            arms.put("openEHR-EHR-OBSERVATION.body_check.v1"
                , System.IO.File.ReadAllText(@"C:\Users\hudi\Documents\GitHub\Web\LNCDCDSS\LNCDCDSS\ARMs\openEHR-EHR-OBSERVATION.body_check.v1.arm.xml"));
            arms.put("openEHR-EHR-OBSERVATION.related_disease_and_drug.v1"
                , System.IO.File.ReadAllText(@"C:\Users\hudi\Documents\GitHub\Web\LNCDCDSS\LNCDCDSS\ARMs\openEHR-EHR-OBSERVATION.related_disease_and_drug.v1.arm.xml"));
            arms.put("openEHR-EHR-OBSERVATION.other_cognitions_scale_exams.v1"
                , System.IO.File.ReadAllText(@"C:\Users\hudi\Documents\GitHub\Web\LNCDCDSS\LNCDCDSS\ARMs\openEHR-EHR-OBSERVATION.other_cognitions_scale_exams.v1.arm.xml"));
            arms.put("openEHR-EHR-OBSERVATION.moca.v1"
                , System.IO.File.ReadAllText(@"C:\Users\hudi\Documents\GitHub\Web\LNCDCDSS\LNCDCDSS\ARMs\openEHR-EHR-OBSERVATION.moca.v1.arm.xml"));
            arms.put("openEHR-EHR-OBSERVATION.mmse.v1"
                , System.IO.File.ReadAllText(@"C:\Users\hudi\Documents\GitHub\Web\LNCDCDSS\LNCDCDSS\ARMs\openEHR-EHR-OBSERVATION.mmse.v1.arm.xml"));
            arms.put("openEHR-EHR-OBSERVATION.gds.v1"
                , System.IO.File.ReadAllText(@"C:\Users\hudi\Documents\GitHub\Web\LNCDCDSS\LNCDCDSS\ARMs\openEHR-EHR-OBSERVATION.gds.v1.arm.xml"));
            arms.put("openEHR-EHR-OBSERVATION.cdr.v1"
                , System.IO.File.ReadAllText(@"C:\Users\hudi\Documents\GitHub\Web\LNCDCDSS\LNCDCDSS\ARMs\openEHR-EHR-OBSERVATION.cdr.v1.arm.xml"));
            arms.put("openEHR-EHR-OBSERVATION.adl.v1"
                , System.IO.File.ReadAllText(@"C:\Users\hudi\Documents\GitHub\Web\LNCDCDSS\LNCDCDSS\ARMs\openEHR-EHR-OBSERVATION.adl.v1.arm.xml"));
        }

        public static void RegisterCDR()
        {
            ReadArchetypes();
            ReadARMs();

            AQLExecute.AQLExecuteImplService aqlImpl = new AQLExecute.AQLExecuteImplService();

            java.util.Set list_key_Archetypes = archetypes.keySet();
            for (java.util.Iterator it_key = list_key_Archetypes.iterator(); it_key.hasNext();) 
            {
                String str = it_key.next() as String;
			    aqlImpl.registerArchetype(str, archetypes.get(str) as String);
		    }
		
            java.util.Set list_key_ARMs = arms.keySet();
            for (java.util.Iterator it_key = list_key_ARMs.iterator(); it_key.hasNext(); )
            {
                String str = it_key.next() as String;
                aqlImpl.registerArchetype(str, arms.get(str) as String);
            }

            bool bReturn = false;
            bool bReturnSpecified = false;
            aqlImpl.reconfigure(out bReturn, out bReturnSpecified);
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            RegisterCDR();
        }
    }
}