using System;
using System.Collections.Generic;
using System.Text;

namespace DP
{
    public class USDAparamsDTO
    {
        public class Nutrient
        {
            public string Name { get; set; }
            public string UnitName { get; set; }
            public double Value { get; set; }
        }
        public class RecipeTitle
        {
            public string Title;
            public string Tag;
        }
    }
}
