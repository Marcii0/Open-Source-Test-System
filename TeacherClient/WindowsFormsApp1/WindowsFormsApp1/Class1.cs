using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSONREQS
{
    internal class JSONREQS
    {

        public static string ReadJSON(string json, string mainKey = "")
        {

            string trimmedjson = json.Remove(json.IndexOf('}'), json.Length);
            return trimmedjson;
        }


    }
}
