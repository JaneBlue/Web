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
        string PatID;
        public ActionResult Index(string ID)
        {
            PatID = ID;
            return View();
        }
        [HttpPost]
        public JsonResult Save()
        {
            VisitRecordOperation vr = new VisitRecordOperation();
            string jsonStr = Request.Params["postjson"];
            PatID = "1bbfd6ec79c34ff185525179e39766df";
            try{
                VisitData obj = JsonHelper.JsonDeserialize<VisitData>(jsonStr);//jsonStr.FromJsonTo<VisitData>();
                if (obj.pal.Total != "0")
                {
                    vr.InsertPatADL(obj.pal, PatID);
                }
           
              //  vr.InsertPatDisease(obj.pds, PatID);
                vr.InsertPatLabExam(obj.ple, PatID);
                vr.InsertPatMMSE(obj.pme, PatID);
                vr.InsertPatMoca(obj.pma, PatID);
                vr.InsertPatotherTest(obj.pot, PatID);
                vr.InsertPatPhysicaExam(obj.ppe, PatID);
                vr.InsertPatRecentDrug(obj.prd, PatID);

                //
                localhost.InputData InputDataValue = new localhost.InputData();
                InputDataValue.timeorientation = 5; //double.Parse(TextBox1.Text);
                InputDataValue.placeorientation = 5; //double.Parse(TextBox2.Text);
                InputDataValue.Languageimmediaterecall = 3; //double.Parse(TextBox3.Text);
                InputDataValue.Attentionandcalculation = 5; //double.Parse(TextBox4.Text);
                InputDataValue.shortmemory = 2;// double.Parse(TextBox5.Text);
                InputDataValue.namingobjects = 2;// double.Parse(TextBox6.Text);
                InputDataValue.languageretell = 1;// double.Parse(TextBox7.Text);
                InputDataValue.readingcomprehension = 3;// double.Parse(TextBox8.Text);
                InputDataValue.languageunderstanding = 1;// double.Parse(TextBox9.Text);
                InputDataValue.languageexpression = 1;// double.Parse(TextBox10.Text);
                InputDataValue.drawgraph = 1;// double.Parse(TextBox11.Text);
                InputDataValue.Visualspaceandexecutiveability = 5;// double.Parse(TextBox12.Text);
                InputDataValue.naming = 3;// double.Parse(TextBox13.Text);
                InputDataValue.memory = 0;// double.Parse(TextBox14.Text);
                InputDataValue.attention = 6;// double.Parse(TextBox15.Text);
                InputDataValue.language = 3;// double.Parse(TextBox16.Text);
                InputDataValue.animalnumber = 16;// double.Parse(TextBox17.Text);
                InputDataValue.abstractability = 2;// double.Parse(TextBox18.Text);
                InputDataValue.MoCadelayrecall = 3;// double.Parse(TextBox19.Text);
                InputDataValue.orientaion = 4;//double.Parse(TextBox20.Text);
                InputDataValue.PhysicalSelfmaintenance = 6;// double.Parse(TextBox21.Text);
                InputDataValue.grippingability = 10;// double.Parse(TextBox22.Text);
                InputDataValue.word1 = 11;// double.Parse(TextBox23.Text);
                InputDataValue.word2 = 5;// double.Parse(TextBox24.Text);
                InputDataValue.word3 = 7;// double.Parse(TextBox25.Text);
                InputDataValue.wordaverage = 5;// double.Parse(TextBox26.Text);
                InputDataValue.worddelayrecall = 5;// double.Parse(TextBox27.Text);
                InputDataValue.originalwordrecognition = 9;// double.Parse(TextBox28.Text);
                InputDataValue.Newwordrecognize = 10;// double.Parse(TextBox29.Text);
                InputDataValue.graphcopy = 16;// double.Parse(TextBox30.Text);
                InputDataValue.graphimmediaterecall = 16;// double.Parse(TextBox31.Text);
                InputDataValue.graphdelayrecall = 16;// double.Parse(TextBox32.Text);
                InputDataValue.lineA = 49;// double.Parse(TextBox33.Text);
                InputDataValue.lineB = 112;// double.Parse(TextBox34.Text);
                InputDataValue.GDS = 10;// double.Parse(TextBox35.Text);
                InputDataValue.CDR = 0;// double.Parse(TextBox36.Text);

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
