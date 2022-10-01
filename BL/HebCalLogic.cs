using DP;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading;

namespace BL
{
 //HebCalLogic is checking if there is a holiday in the next week
    public class HebCalLogic
    {
        string[] theHolidays = {"ראש השנה", "פורים", "שבועות", "פסח", "חנוכה", "סוכות" };
        public List<string> IsHolidyWeek(string today,string SevenDaysFromNow)
        {
            DAL.HebCalAdapter dal = new DAL.HebCalAdapter();
            Root myHolyday = null;
            string myJson = dal.GetComingWeek(today, SevenDaysFromNow);
            if (myJson != null)
            {
                myHolyday = JsonConvert.DeserializeObject<Root>(myJson);
            }
            List<string> holidays = new List<string>();
            foreach (var item in myHolyday.items)
            {
                if (item.category == "holiday")
                {
                    if (item.hebrew!=null)
                        foreach(string holiday in theHolidays)
                        {
                            if (item.hebrew.Contains(holiday) && !holidays.Contains(holiday)&& item.hebrew != "פסח שני")
                            {
                                holidays.Add(holiday);
                                break;
                            }
                        }
                }
            }
            return holidays;


        }
    }
}
/*
 * Rosh Hashana
 * Sukkot
 * Chanukah
 * Pesach
 * Shavuot
 * Purim
 */

