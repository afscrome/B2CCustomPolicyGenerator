using B2CCustomPolicyGenerator;
using B2CCustomPolicyGenerator.Model;
using NUnit.Framework;
using System.Xml.Linq;

namespace B2CCustomPolicyGenerator.Tests.PolicyVisitorTests
{
    public class ProtocolTests : PolicyVisitorTestBase<Protocol>
    {
        protected override XNode Visit(PolicyVisitor visitor, Protocol input)
            => visitor.Visit(input);

        [Test]
        public void ProtocolWithoutHandler()
        {
            var protocol = new Protocol
            {
                Name = ProtocolName.None
            };

            var result = new PolicyVisitor().Visit(protocol);

            var expectedXml = @"<Protocol Name=""None"" />";

            AssertXml(result, expectedXml);
        }

        [Test]
        public void ProtocolWithHandler()
        {
            var protocol = new Protocol
            {
                Name = ProtocolName.Proprietary,
                Handler = "Web.TPEngine.Providers.PhoneFactorProtocolProvider, Web.TPEngine, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null"
            };

            var result = new PolicyVisitor().Visit(protocol);

            var expectedXml = @"<Protocol Name=""Proprietary"" Handler=""Web.TPEngine.Providers.PhoneFactorProtocolProvider, Web.TPEngine, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null"" />";

            AssertXml(result, expectedXml);
        }
    }
}
