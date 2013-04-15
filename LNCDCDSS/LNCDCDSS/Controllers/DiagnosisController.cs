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
            this.TempData["PatID"] = ID;
            return View();
        }
        [HttpPost]
        public JsonResult Save()
        {
            VisitRecordOperation vr = new VisitRecordOperation();
            string jsonStr = Request.Params["postjson"];
            string PatID = this.TempData["PatID"].ToString();
            try
            {
                VisitData obj = JsonHelper.JsonDeserialize<VisitData>(jsonStr);//jsonStr.FromJsonTo<VisitData>();

                vr.InsertPatADL(obj.pal, PatID);
                vr.InsertPatDisease(obj.pds, PatID);
                vr.InsertPatLabExam(obj.ple, PatID);
                vr.InsertPatMMSE(obj.pme, PatID);
                vr.InsertPatMoca(obj.pma, PatID);
                vr.InsertPatotherTest(obj.pot, PatID);
                vr.UpdateVisitRecord(obj.vsr, PatID);
                vr.InsertPatPhysicaExam(obj.ppe, PatID);
                vr.InsertPatRecentDrug(obj.prd, PatID);

                //

            }
            catch (Exception e)
            {
                return this.Json(new { OK = false, Message = "保存失败" });
            }

            return this.Json(new { OK = true, Message = "保存成功" });
        }
        [HttpPost]
        public JsonResult CDSSdiagnosis()
        {
            string strResult = null;
            double dProbalily = 0.0f;
            try
            {
                string jsonStr = Request.Params["postjson"];
                VisitData obj = JsonHelper.JsonDeserialize<VisitData>(jsonStr);//jsonStr.FromJsonTo<VisitData>();
                WebReference.InputData InputDataValue = new WebReference.InputData();
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
                Double dA1,dA2,dA3,dA4,dA5,dA6,dA7,dA8,dA9,dA10,dA11,dA12,dA13,dA14,dA15,dA16,dA17,dA18,dA19,dA20;
                if ("独立完成" == pal.A1)
                {
                    dA1 = 1;
                }
                else if ("有些困难" == pal.A1)
                {
                    dA1 = 2;
                }
                else if ("需要帮助" == pal.A1)
                {
                    dA1 = 3;
                }
                else if ("无法完成" == pal.A1)
                {
                    dA1 = 4;
                }
                else
                {
                    dA1 = 0;
                }

                if ("独立完成" == pal.A2)
                {
                    dA2 = 1;
                }
                else if ("有些困难" == pal.A2)
                {
                    dA2 = 2;
                }
                else if ("需要帮助" == pal.A2)
                {
                    dA2 = 3;
                }
                else if ("无法完成" == pal.A2)
                {
                    dA2 = 4;
                }
                else
                {
                    dA2 = 0;
                }

                if ("独立完成" == pal.A3)
                {
                    dA3 = 1;
                }
                else if ("有些困难" == pal.A3)
                {
                    dA3 = 2;
                }
                else if ("需要帮助" == pal.A3)
                {
                    dA3 = 3;
                }
                else if ("无法完成" == pal.A3)
                {
                    dA3 = 4;
                }
                else
                {
                    dA3 = 0;
                }

                if ("独立完成" == pal.A4)
                {
                    dA4 = 1;
                }
                else if ("有些困难" == pal.A4)
                {
                    dA4 = 2;
                }
                else if ("需要帮助" == pal.A4)
                {
                    dA4 = 3;
                }
                else if ("无法完成" == pal.A4)
                {
                    dA4 = 4;
                }
                else
                {
                    dA4 = 0;
                }

                if ("独立完成" == pal.A5)
                {
                    dA5 = 1;
                }
                else if ("有些困难" == pal.A5)
                {
                    dA5 = 2;
                }
                else if ("需要帮助" == pal.A5)
                {
                    dA5 = 3;
                }
                else if ("无法完成" == pal.A5)
                {
                    dA5 = 4;
                }
                else
                {
                    dA5 = 0;
                }

                if ("独立完成" == pal.A6)
                {
                    dA6 = 1;
                }
                else if ("有些困难" == pal.A6)
                {
                    dA6 = 2;
                }
                else if ("需要帮助" == pal.A6)
                {
                    dA6 = 3;
                }
                else if ("无法完成" == pal.A6)
                {
                    dA6 = 4;
                }
                else
                {
                    dA6 = 0;
                }

                if ("独立完成" == pal.A7)
                {
                    dA7 = 1;
                }
                else if ("有些困难" == pal.A7)
                {
                    dA7 = 2;
                }
                else if ("需要帮助" == pal.A7)
                {
                    dA7 = 3;
                }
                else if ("无法完成" == pal.A7)
                {
                    dA7 = 4;
                }
                else
                {
                    dA7 = 0;
                }

                if ("独立完成" == pal.A8)
                {
                    dA8 = 1;
                }
                else if ("有些困难" == pal.A8)
                {
                    dA8 = 2;
                }
                else if ("需要帮助" == pal.A8)
                {
                    dA8 = 3;
                }
                else if ("无法完成" == pal.A8)
                {
                    dA8 = 4;
                }
                else
                {
                    dA8 = 0;
                }

                if ("独立完成" == pal.A9)
                {
                    dA9 = 1;
                }
                else if ("有些困难" == pal.A9)
                {
                    dA9 = 2;
                }
                else if ("需要帮助" == pal.A9)
                {
                    dA9 = 3;
                }
                else if ("无法完成" == pal.A9)
                {
                    dA9 = 4;
                }
                else
                {
                    dA9 = 0;
                }

                if ("独立完成" == pal.A10)
                {
                    dA10 = 1;
                }
                else if ("有些困难" == pal.A10)
                {
                    dA10 = 2;
                }
                else if ("需要帮助" == pal.A10)
                {
                    dA10 = 3;
                }
                else if ("无法完成" == pal.A10)
                {
                    dA10 = 4;
                }
                else
                {
                    dA10 = 0;
                }

                if ("独立完成" == pal.A11)
                {
                    dA11 = 1;
                }
                else if ("有些困难" == pal.A11)
                {
                    dA11 = 2;
                }
                else if ("需要帮助" == pal.A11)
                {
                    dA11 = 3;
                }
                else if ("无法完成" == pal.A11)
                {
                    dA11 = 4;
                }
                else
                {
                    dA11 = 0;
                }

                if ("独立完成" == pal.A12)
                {
                    dA12 = 1;
                }
                else if ("有些困难" == pal.A12)
                {
                    dA12 = 2;
                }
                else if ("需要帮助" == pal.A12)
                {
                    dA12 = 3;
                }
                else if ("无法完成" == pal.A12)
                {
                    dA12 = 4;
                }
                else
                {
                    dA12 = 0;
                }

                if ("独立完成" == pal.A13)
                {
                    dA13 = 1;
                }
                else if ("有些困难" == pal.A13)
                {
                    dA13 = 2;
                }
                else if ("需要帮助" == pal.A13)
                {
                    dA13 = 3;
                }
                else if ("无法完成" == pal.A13)
                {
                    dA13 = 4;
                }
                else
                {
                    dA13 = 0;
                }

                if ("独立完成" == pal.A14)
                {
                    dA14 = 1;
                }
                else if ("有些困难" == pal.A14)
                {
                    dA14 = 2;
                }
                else if ("需要帮助" == pal.A14)
                {
                    dA14 = 3;
                }
                else if ("无法完成" == pal.A14)
                {
                    dA14 = 4;
                }
                else
                {
                    dA14 = 0;
                }

                if ("独立完成" == pal.A15)
                {
                    dA15 = 1;
                }
                else if ("有些困难" == pal.A15)
                {
                    dA15 = 2;
                }
                else if ("需要帮助" == pal.A15)
                {
                    dA15 = 3;
                }
                else if ("无法完成" == pal.A15)
                {
                    dA15 = 4;
                }
                else
                {
                    dA15 = 0;
                }

                if ("独立完成" == pal.A16)
                {
                    dA16 = 1;
                }
                else if ("有些困难" == pal.A16)
                {
                    dA16 = 2;
                }
                else if ("需要帮助" == pal.A16)
                {
                    dA16 = 3;
                }
                else if ("无法完成" == pal.A16)
                {
                    dA16 = 4;
                }
                else
                {
                    dA16 = 0;
                }

                if ("独立完成" == pal.A17)
                {
                    dA17 = 1;
                }
                else if ("有些困难" == pal.A17)
                {
                    dA17 = 2;
                }
                else if ("需要帮助" == pal.A17)
                {
                    dA17 = 3;
                }
                else if ("无法完成" == pal.A17)
                {
                    dA17 = 4;
                }
                else
                {
                    dA17 = 0;
                }

                if ("独立完成" == pal.A18)
                {
                    dA18 = 1;
                }
                else if ("有些困难" == pal.A18)
                {
                    dA18 = 2;
                }
                else if ("需要帮助" == pal.A18)
                {
                    dA18 = 3;
                }
                else if ("无法完成" == pal.A18)
                {
                    dA18 = 4;
                }
                else
                {
                    dA18 = 0;
                }

                if ("独立完成" == pal.A19)
                {
                    dA19 = 1;
                }
                else if ("有些困难" == pal.A19)
                {
                    dA19 = 2;
                }
                else if ("需要帮助" == pal.A19)
                {
                    dA19 = 3;
                }
                else if ("无法完成" == pal.A19)
                {
                    dA19 = 4;
                }
                else
                {
                    dA19 = 0;
                }

                if ("独立完成" == pal.A20)
                {
                    dA20 = 1;
                }
                else if ("有些困难" == pal.A20)
                {
                    dA20 = 2;
                }
                else if ("需要帮助" == pal.A20)
                {
                    dA20 = 3;
                }
                else if ("无法完成" == pal.A20)
                {
                    dA20 = 4;
                }
                else
                {
                    dA20 = 0;
                }

                InputDataValue.PhysicalSelfmaintenance = dA1+dA2+dA3+dA4+dA5+dA6+dA7+dA8+dA9+dA10;//A1+...+A10
                InputDataValue.grippingability = dA11 + dA12 + dA13 + dA14 + dA15 + dA16 + dA17 + dA18 + dA19 + dA20;//A11+...+A20
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

                WebReference.InferenceService b = new WebReference.InferenceService();



                b.DoInference(InputDataValue, ref strResult, ref dProbalily);

                if ("AD" == strResult)
                    strResult = "阿尔兹海默症";
                else if("MCI" == strResult)
                    strResult = "轻度认知障碍";
                else if("Normal" == strResult)
                    strResult = "正常";
            }
            catch (Exception e)
            {
                return this.Json(new { OK = false, Message =e.Message + "推理出错" });
            }

            return this.Json(new { OK = true, Message = strResult + "              相似度:" + (dProbalily * 100).ToString() + "%" });
        }
    }
}
