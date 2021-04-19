using System.Collections.Generic;

namespace OriginFinancial.CodingChallenge.Infra.Data.Environment
{
    public class EnvironmentConfiguration
    {
        public List<EnvironmentVariables> EnvironmentVariables { get; set; }
    }

    public class EnvironmentVariables
    {
        public string EnvironmentName { get; set; }
        public Contexts Contexts { get; set; }
        public Security Security { get; set; }
    }

    public class Contexts
    {
        public string ConnStringsName { get; set; }
        public List<string> DatabaseNames { get; set; }
    }

    public class Security
    {
        public string SecurityName { get; set; }
        public string SecurityValue { get; set; }
    }
}
