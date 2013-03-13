using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Text;
namespace LNCDCDSS.Models
{
    public static class JSTransfer
    {
        public static T FromJsonTo<T>(this string jsonString)
        {

            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));

            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonString));

            T jsonObject = (T)ser.ReadObject(ms);

            ms.Close();

            return jsonObject;

        }
    }
}
