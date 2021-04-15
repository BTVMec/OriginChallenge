using System;
using System.Collections.Generic;
using System.Text;

namespace OriginFinancial.CodingChallenge.AppService.ViewModel
{
    public class DomainViewModel
    {
        public string Property { get; set; }
        public KeyValuePairs Definition { get; set; }
    }

    public class KeyValuePairs
    {
        public int Key { get; set; }
        public string Value { get; set; }
    }
}
