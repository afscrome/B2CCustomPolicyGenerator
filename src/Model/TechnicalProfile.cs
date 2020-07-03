using System.Collections.Generic;

namespace B2CCustomPolicyGenerator.Model
{
    public class TechnicalProfile
    {
        public TechnicalProfile(string id)
        {
            Id = id;
        }

        public string Id { get; }
        public string DisplayName { get; set; }
        public Protocol Protocol { get; set; }

        public IDictionary<string, string> Metadata { get; } = new Dictionary<string, string>();
    }
}
