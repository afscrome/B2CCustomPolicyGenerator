using B2CCustomPolicyGenerator;
using B2CCustomPolicyGenerator.Model;
using NUnit.Framework;
using System.Xml.Linq;

namespace B2CCustomPolicyGenerator.Tests.PolicyVisitorTests
{
    public class TechnicalProfileTests : PolicyVisitorTestBase<TechnicalProfile>
    {
        protected override XNode Visit(PolicyVisitor visitor, TechnicalProfile input)
            => visitor.Visit(input);

        [Test]
        public void TechnicalProfile()
        {
            var input = new TechnicalProfile("login-NonInteractive")
            {
                DisplayName = "Local Account SignIn",
                Protocol = new Protocol { Name = ProtocolName.OpenIdConnect },
                Metadata =
                {
                    ["ProviderName"] = "https://sts.windows.net/"
                }
            };

            var expectedXml = @"
                <TechnicalProfile Id=""login-NonInteractive"">
                    <DisplayName>Local Account SignIn</DisplayName>
                    <Protocol Name=""OpenIdConnect"" />
                    <Metadata>
                    <Item Key=""ProviderName"">https://sts.windows.net/</Item>
                    </Metadata>
                </TechnicalProfile>";

            AssertVisitedInput(input, expectedXml);
        }
    }
}
