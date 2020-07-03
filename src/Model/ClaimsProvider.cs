using System.Collections.Generic;

namespace B2CCustomPolicyGenerator.Model
{
    public class ClaimsProvider
    {
        public string DisplayName { get; set; }
        public IList<TechnicalProfile> TechnicalProfiles { get; } = new List<TechnicalProfile>();
    }
}
