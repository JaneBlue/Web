using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LNCDCDSS.Models;
namespace LNCDCDSS.Controllers
{
    public class DiagnosisController : Controller
    {
       // string PatID;
        public ActionResult Index(string ID)
        {
         this.TempData["PatID"]=ID;
            return View();
        }
        [HttpPost]
        public JsonResult Save()
        {
            VisitRecordOperation vr = new VisitRecordOperation();
            string jsonStr = Request.Params["postjson"];
            string  PatID =this.TempData["PatID"].ToString();
            try{
                VisitData obj = JsonHelper.JsonDeserialize<VisitData>(jsonStr);//jsonStr.FromJsonTo<VisitData>();
              
                    vr.InsertPatADL(obj.pal, PatID);


                    vr.InsertPatDisease(obj.pds, PatID);
              //  vr.InsertPatLabExam(obj.ple, PatID);
              //  vr.InsertPatMMSE(obj.pme, PatID);
             //   vr.InsertPatMoca(obj.pma, PatID);
             //   vr.InsertPatotherTest(obj.pot, PatID);
             vr.InsertPatPhysicaExam(obj.ppe, PatID);
                vr.InsertPatRecentDrug(obj.prd, PatID);

                //
                localhost.InputData InputDataValue = new localhost.InputData();
                InputDataValue.timeorientation = System.Convert.ToDouble(obj.pme.M1); //M1
                InputDataValue.placeorientation = System.Convert.ToDouble(obj.pme.M2); //M2
                InputDataValue.Languageimmediaterecall = System.Convert.ToDouble(obj.pme.M3); //M3
                InputDataValue.Attentionandcalculation = System.Convert.ToDouble(obj.pme.M4); //M4
                InputDataValue.shortmemory = System.Convert.ToDouble(obj.pme.M5);//M5
                InputDataValue.namingobjects = System.Convert.ToDouble(obj.pme.M6);//M6
                InputDataValue.languageretell = System.Convert.ToDouble(obj.pme.M7);//M7
                InputDataValue.readingcomprehension = System.Convert.ToDouble(obj.pme.M8);//M8
                InputDataValue.languageunderstanding = System.Convert.ToDouble(obj.pme.M9);//M9
                InputDataValue.languageexpression = System.Convert.ToDouble(obj.pme.M10);//M10
                InputDataValue.drawgraph = System.Convert.ToDouble(obj.pme.M11);//M11
                InputDataValue.Visualspaceandexecutiveability = System.Convert.ToDouble(obj.pma.MC1);//MC1
                InputDataValue.naming = System.Convert.ToDouble(obj.pma.MC2);//MC2
                InputDataValue.memory = System.Convert.ToDouble(obj.pma.MC3);//MC3
                InputDataValue.attention = System.Convert.ToDouble(obj.pma.MC4);//MC4
                InputDataValue.language = System.Convert.ToDouble(obj.pma.MC5);//MC5
                InputDataValue.animalnumber = System.Convert.ToDouble(obj.pma.MC6);//MC6
                InputDataValue.abstractability = System.Convert.ToDouble(obj.pma.MC7);//MC7
                InputDataValue.MoCadelayrecall = System.Convert.ToDouble(obj.pma.MC8);//MC8
                InputDataValue.orientaion = System.Convert.ToDouble(obj.pma.MC9);//MC9
                InputDataValue.PhysicalSelfmaintenance = System.Convert.ToDouble(obj.pal.A1) + System.Convert.ToDouble(obj.pal.A2) + System.Convert.ToDouble(obj.pal.A3) + System.Convert.ToDouble(obj.pal.A4)
                                                        + System.Convert.ToDouble(obj.pal.A5) + System.Convert.ToDouble(obj.pal.A6) + System.Convert.ToDouble(obj.pal.A7) + System.Convert.ToDouble(obj.pal.A8)
                                                        + System.Convert.ToDouble(obj.pal.A9) + System.Convert.ToDouble(obj.pal.A10);//A1+...+A10
                InputDataValue.grippingability = System.Convert.ToDouble(obj.pal.A11) + System.Convert.ToDouble(obj.pal.A12) + System.Convert.ToDouble(obj.pal.A13) + System.Convert.ToDouble(obj.pal.A14)
                                                        + System.Convert.ToDouble(obj.pal.A15) + System.Convert.ToDouble(obj.pal.A16) + System.Convert.ToDouble(obj.pal.A17) + System.Convert.ToDouble(obj.pal.A18)
                                                        + System.Convert.ToDouble(obj.pal.A19) + System.Convert.ToDouble(obj.pal.A20);//A11+...+A20
                InputDataValue.word1 = System.Convert.ToDouble(obj.pot.Vocabulary1);//Vocabulary1
                InputDataValue.word2 = System.Convert.ToDouble(obj.pot.Vocabulary2);
                InputDataValue.word3 = System.Convert.ToDouble(obj.pot.Vocabulary3);
                InputDataValue.wordaverage = (InputDataValue.word1 + InputDataValue.word2 + InputDataValue.word3) / 3;
                InputDataValue.worddelayrecall = System.Convert.ToDouble(obj.pot.Vocabulary4);
                InputDataValue.originalwordrecognition = System.Convert.ToDouble(obj.pot.VocabularyAnalyse1);
                InputDataValue.Newwordrecognize = System.Convert.ToDouble(obj.pot.VocabularyAnalyse2);
                InputDataValue.graphcopy = System.Convert.ToDouble(obj.pot.Picture1);
                InputDataValue.graphimmediaterecall = System.Convert.ToDouble(obj.pot.Picture2);
                InputDataValue.graphdelayrecall = System.Convert.ToDouble(obj.pot.Picture3);
                InputDataValue.lineA = System.Convert.ToDouble(obj.pot.ConnectNumber1);
                InputDataValue.lineB = System.Convert.ToDouble(obj.pot.ConnectNumber2);
                InputDataValue.GDS = System.Convert.ToDouble(obj.pot.PatGDS);
                InputDataValue.CDR = System.Convert.ToDouble(obj.pot.PatCDR);

                localhost.Service1 b = new localhost.Service1();
                string strResult = null;
                b.DoInference(InputDataValue, ref strResult);
            }
            catch(Exception  e){
                return this.Json(new { OK = false, Message = "保存失败" });  
            }
            
          return  this.Json(new { OK = true, Message = "保存成功" });  
        }

    }
}
