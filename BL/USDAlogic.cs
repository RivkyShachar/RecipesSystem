using DP;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL
{
    public class USDAlogic
    {
        public string GetFoodValus(string data)
        {
            DAL.USDAadapter dal = new DAL.USDAadapter();
            Root myUSDA = null;
            string myJson = dal.GetUSDA(data);
            if (myJson != null)
            {
                myUSDA = JsonConvert.DeserializeObject<Root>(myJson);
            }
            return myJson;

        }
    }
}
