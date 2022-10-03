using System;
using System.Collections.Generic;
using System.Text;

namespace DP
{
    public class BigMLmodel
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class Meta
        {
            public int limit { get; set; }
            public object next { get; set; }
            public int offset { get; set; }
            public object previous { get; set; }
            public int total_count { get; set; }
        }

        public class Root
        {
            public Meta meta { get; set; }
            public List<object> objects { get; set; }
        }
    }
}
