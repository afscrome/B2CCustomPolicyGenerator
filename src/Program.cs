using B2CCustomPolicyGenerator.Model;
using System;

namespace B2CCustomPolicyGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var policy = new TrustFrameworkPolicy("MyPolicyId");

            var mandatoryClaimsProvider = new ClaimsProvider
            {
                DisplayName = "Trustframework Policy Engine TechnicalProfiles",
                TechnicalProfiles =
                {
                    new TechnicalProfile("TpEngine_c3bd4fe2-1775-4013-b91d-35f16d377d13")
                    {
                        DisplayName = "Trustframework Policy Engine Default Technical Profile",
                        Metadata =
                        {
                            ["url"] = "${service:te}"
                        }
                    }
                }
            };

            Console.WriteLine("Hello World!");
        }
    }
}
