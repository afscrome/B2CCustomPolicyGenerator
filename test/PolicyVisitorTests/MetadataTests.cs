using B2CCustomPolicyGenerator;
using NUnit.Framework;
using System.Collections.Generic;
using System.Xml.Linq;

namespace B2CCustomPolicyGenerator.Tests.PolicyVisitorTests
{
    public class MetadataTests : PolicyVisitorTestBase<IDictionary<string, string>>
    {

        protected override XNode? Visit(PolicyVisitor visitor, IDictionary<string, string> input)
            => visitor.VisitMetaData(input);


        [Test]
        public void When_Metadata_Is_Empty()
        {
            var result = Visit(new Dictionary<string, string>());
            Assert.IsNull(result);
        }

        [Test]
        public void When_Metadata_Is_Provided()
        {
            var input = new Dictionary<string, string>
            {
                ["Always"] = "look",
                ["Bright"] = "Side"
            };

            var expectedXml = @"
                <Metadata>
                    <Item Key=""Always"">look</Item>
                    <Item Key=""Bright"">Side</Item>
                </Metadata>";

            AssertVisitedInput(input, expectedXml);
        }

    }
}
