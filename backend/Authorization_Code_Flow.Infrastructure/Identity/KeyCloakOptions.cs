using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authorization_Code_Flow.Infrastructure.Identity
{
    public class KeyCloakOptions
    {
        public string ConfidentialClientId { get; set; }
        public string ConfidentialClientSecret { get; set; }
        public string TokenUrl { get; set; }
        public string RealmUrl { get; set; }
        public string AdminUrl { get; set; }
        public string WellKnown { get; set; }
    }
}
