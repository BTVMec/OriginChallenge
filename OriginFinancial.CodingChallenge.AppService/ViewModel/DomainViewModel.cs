using System;
using System.Collections.Generic;
using System.Text;

namespace OriginFinancial.CodingChallenge.AppService.ViewModel
{
    public class DomainViewModel
    {
        public string Property { get; set; }
        public List<DomainKeyValuesPair> Definitions { get; set; }
    }

    public class DomainKeyValuesPair
    {
        public int Key { get; set; }
        public string Value { get; set; }
    }
}
