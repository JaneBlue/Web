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
                    vr.InsertPatLabExam(obj.ple, PatID);
                    vr.InsertPatMMSE(obj.pme, PatID);
                    vr.InsertPatMoca(obj.pma, PatID);
                    vr.InsertPatotherTest(obj.pot, PatID);
           
                // vr.InsertPatPhysicaExam(obj.ppe, PatID);
                //vr.InsertPatRecentDrug(obj.prd, PatID);

                //
               
            }
            catch(Exception  e){
                return this.Json(new { OK = false, Message = "保存失败" });  
            }
            
          return  this.Json(new { OK = true, Message = "保存成功" });  
        }
        [HttpPost]
        public JsonResult CDSSdiagnosis()
        {
            string strResult = null;
            try
            {
                string jsonStr = Request.Params["postjson"];
                VisitData obj = JsonHelper.JsonDeserialize<VisitData>(jsonStr);//jsonStr.FromJsonTo<VisitData>();
                localhost.InputData InputDataValue = new localhost.InputData();
                if (obj.pme.M1 != "")
                {
                    InputDataValue.timeorientation = System.Convert.ToDouble(obj.pme.M1); //M1
                }
                if (obj.pme.M2 != "")
                {
                    InputDataValue.placeorientation = System.Convert.ToDouble(obj.pme.M2); //M2
                }
                if (obj.pme.M3 != "")
                {
                    InputDataValue.Languageimmediaterecall = System.Convert.ToDouble(obj.pme.M3); //M3
                }
                if (obj.pme.M4 != "")
                {
                    InputDataValue.Attentionandcalculation = System.Convert.ToDouble(obj.pme.M4); //M4
                }
                if (obj.pme.M5 != "")
                {
                    InputDataValue.shortmemory = System.Convert.ToDouble(obj.pme.M5);//M5
                }
                if (obj.pme.M6 != "")
                {
                    InputDataValue.namingobjects = System.Convert.ToDouble(obj.pme.M6);//M6
                }
                if (obj.pme.M7 != "")
                {
                    InputDataValue.languageretell = System.Convert.ToDouble(obj.pme.M7);//M7
                }
                if (obj.pme.M8 != "")
                {
                    InputDataValue.readingcomprehension = System.Convert.ToDouble(obj.pme.M8);//M8
                }
                if (obj.pme.M9 != "")
                {
                    InputDataValue.languageunderstanding = System.Convert.ToDouble(obj.pme.M9);//M9
                }
                if (obj.pme.M10 != "")
                {
                    InputDataValue.languageexpression = System.Convert.ToDouble(obj.pme.M10);//M10
                }
                if (obj.pme.M11 != "")
                {
                    InputDataValue.drawgraph = System.Convert.ToDouble(obj.pme.M11);//M11
                }
                if (obj.pma.MC1 != "")
                {
                    InputDataValue.Visualspaceandexecutiveability = System.Convert.ToDouble(obj.pma.MC1);//MC1
                }
                if (obj.pma.MC2 != "")
                {
                    InputDataValue.naming = System.Convert.ToDouble(obj.pma.MC2);//MC2
                }
                if (obj.pma.MC3 != "")
                {
                    InputDataValue.memory = System.Convert.ToDouble(obj.pma.MC3);//MC3
                }
                if (obj.pma.MC4 != "")
                {
                    InputDataValue.attention = System.Convert.ToDouble(obj.pma.MC4);//MC4
                }
                if (obj.pma.MC5 != "")
                {
                    InputDataValue.language = System.Convert.ToDouble(obj.pma.MC5);//MC5
                }
                if (obj.pma.MC6 != "")
                {
                    InputDataValue.animalnumber = System.Convert.ToDouble(obj.pma.MC6);//MC6
                }
                if (obj.pma.MC7 != "")
                {
                    InputDataValue.abstractability = System.Convert.ToDouble(obj.pma.MC7);//MC7
                }
                if (obj.pma.MC8 != "")
                {
                    InputDataValue.MoCadelayrecall = System.Convert.ToDouble(obj.pma.MC8);//MC8
                }
                if (obj.pma.MC9 != "")
                {
                    InputDataValue.orientaion = System.Convert.ToDouble(obj.pma.MC9);//MC9
                }
                string[] strName = { "A1" };
                PatADL pal = new PatADL();
                ObjectMapper.CopyFrontProperties(obj.pal, pal);

                InputDataValue.PhysicalSelfmaintenance = System.Convert.ToDouble(pal.A1) + System.Convert.ToDouble(pal.A2) + System.Convert.ToDouble(pal.A3) + System.Convert.ToDouble(pal.A4)
                                                        + System.Convert.ToDouble(pal.A5) + System.Convert.ToDouble(pal.A6) + System.Convert.ToDouble(pal.A7) + System.Convert.ToDouble(pal.A8)
                                                    + System.Convert.ToDouble(pal.A9) + System.Convert.ToDouble(pal.A10);//A1+...+A10
                InputDataValue.grippingability = System.Convert.ToDouble(pal.A11) + System.Convert.ToDouble(pal.A12) + System.Convert.ToDouble(pal.A13) + System.Convert.ToDouble(pal.A14)
                                                        + System.Convert.ToDouble(pal.A15) + System.Convert.ToDouble(pal.A16) + System.Convert.ToDouble(pal.A17) + System.Convert.ToDouble(pal.A18)
                                                        + System.Convert.ToDouble(pal.A19) + System.Convert.ToDouble(pal.A20);//A11+...+A20
                if (obj.pot.Vocabulary1 != "")
                {
                    InputDataValue.word1 = System.Convert.ToDouble(obj.pot.Vocabulary1);//Vocabulary1
                }
                if (obj.pot.Vocabulary2 != "")
                {
                    InputDataValue.word2 = System.Convert.ToDouble(obj.pot.Vocabulary2);
                }
                if (obj.pot.Vocabulary3 != "")
                {
                    InputDataValue.word3 = System.Convert.ToDouble(obj.pot.Vocabulary3);
                }
                InputDataValue.wordaverage = (InputDataValue.word1 + InputDataValue.word2 + InputDataValue.word3) / 3;
                if (obj.pot.Vocabulary4 != "")
                {
                    InputDataValue.worddelayrecall = System.Convert.ToDouble(obj.pot.Vocabulary4);
                }
                if (obj.pot.VocabularyAnalyse1 != "")
                {
                    InputDataValue.originalwordrecognition = System.Convert.ToDouble(obj.pot.VocabularyAnalyse1);
                }
                if (obj.pot.VocabularyAnalyse2 != "")
                {
                    InputDataValue.Newwordrecognize = System.Convert.ToDouble(obj.pot.VocabularyAnalyse2);
                }
                if (obj.pot.Picture1 != "")
                {
                    InputDataValue.graphcopy = System.Convert.ToDouble(obj.pot.Picture1);
                }
                if (obj.pot.Picture2 != "")
                {
                    InputDataValue.graphimmediaterecall = System.Convert.ToDouble(obj.pot.Picture2);
                }
                if (obj.pot.Picture3 != "")
                {
                    InputDataValue.graphdelayrecall = System.Convert.ToDouble(obj.pot.Picture3);
                }
                if (obj.pot.ConnectNumber1 != "")
                {
                    InputDataValue.lineA = System.Convert.ToDouble(obj.pot.ConnectNumber1);
                }
                if (obj.pot.ConnectNumber2 != "")
                {
                    InputDataValue.lineB = System.Convert.ToDouble(obj.pot.ConnectNumber2);
                }
                if (obj.pot.PatGDS != "")
                {
                    InputDataValue.GDS = System.Convert.ToDouble(obj.pot.PatGDS);
                }
                if (obj.pot.PatCDR != "")
                {
                    InputDataValue.CDR = System.Convert.ToDouble(obj.pot.PatCDR);
                }

             localhost.Service1 b = new localhost.Service1();

            

                b.DoInference(InputDataValue, ref strResult);
            }
            catch (Exception e)
            {
                return this.Json(new { OK = false, Message = "推理出错" });
            }

            return this.Json(new { OK = true, Message = strResult });
        }
    }
}
