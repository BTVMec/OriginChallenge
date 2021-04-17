using System.Collections.Generic;

namespace OriginFinancial.CodingChallenge.Infra.Data.Context
{
    public class EnvironmentContextConfiguration
    {
        public string EnvironmentName { get; set; }
        public Contexts Contexts { get; set; }
    }

    public class Contexts
    {
        public string ConnStringsName { get; set; }
        public List<string> DatabaseNames { get; set; }
    }
}
