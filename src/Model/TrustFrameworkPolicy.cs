using System;

namespace B2CCustomPolicyGenerator.Model
{
    public class TrustFrameworkPolicy
    {
        public TrustFrameworkPolicy(string policyId)
        {
            if (string.IsNullOrWhiteSpace(policyId))
                throw new ArgumentOutOfRangeException(nameof(policyId));

            PolicyId = policyId;
        }

        public string PolicyId { get; }
    }
}
