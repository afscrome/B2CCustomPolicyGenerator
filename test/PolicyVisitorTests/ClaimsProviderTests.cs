using B2CCustomPolicyGenerator;
using B2CCustomPolicyGenerator.Model;
using NUnit.Framework;
using System.Xml.Linq;

namespace B2CCustomPolicyGenerator.Tests.PolicyVisitorTests
{
    public class ClaimsProviderTests : PolicyVisitorTestBase<ClaimsProvider>
    {
        protected override XNode Visit(PolicyVisitor visitor, ClaimsProvider input)
            => visitor.Visit(input);

        [Test]
        public void ClaimsProvider()
        {
            var input = new ClaimsProvider
            {
                DisplayName = "Local Account SignIn",
                TechnicalProfiles =
                {
                    new TechnicalProfile("login-NonInteractive")
                    {
                        DisplayName = "Local Account SignIn",
                        Protocol = new Protocol{ Name = ProtocolName.OpenIdConnect},
                        Metadata =
                        {
                            ["ProviderName"] = "https://sts.windows.net/"
                        }
                    }
                }
            };

            var expectedXml = @"
                <ClaimsProvider>
                  <DisplayName>Local Account SignIn</DisplayName>
                  <TechnicalProfiles>
                    <TechnicalProfile Id=""login-NonInteractive"">
                      <DisplayName>Local Account SignIn</DisplayName>
                      <Protocol Name=""OpenIdConnect"" />
                      <Metadata>
                        <Item Key=""ProviderName"">https://sts.windows.net/</Item>
                      </Metadata>
                    </TechnicalProfile>
                  </TechnicalProfiles>
                </ClaimsProvider>
                ";

            AssertVisitedInput(input, expectedXml);
        }

    }
}
