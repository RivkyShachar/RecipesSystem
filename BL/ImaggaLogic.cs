using Newtonsoft.Json;
using DP;
using static DP.ImaggaModel;
using System;
using System.Collections.Generic;
using System.Text;
using Root = DP.ImaggaModel.Root;

namespace BL
{
    public class ImaggaLogic
    {
        public bool IsGoodPic(ImaggaParamsDTO data)
        {
            string result = "false";
            DAL.ImaggaAdapter dal = new DAL.ImaggaAdapter();
            Root myPicture = null;
            if (data.ImageUrl == null)
                return false;
            string myJson = dal.GetImageInformation(data.ImageUrl);
            if (myJson != null)
            {
                myPicture = JsonConvert.DeserializeObject<Root>(myJson);
            }
            if (myPicture != null && myPicture.status.type == "success")
                foreach (var tag in myPicture.result.tags)
                    if (tag.tag.en == "food" && tag.confidence > 85)
                    {
                        result = "food";
                        break;
                    }
            if(result=="food")
                foreach (var tag in myPicture.result.tags)
                    if (data.Title.Contains(tag.tag.en) && tag.confidence > 80)
                    {
                        result = "title";
                        break;
                    }
            //need to check if it's kosher
            if (result == "title")
                return true;
            return false;



            
        }

    }
}
