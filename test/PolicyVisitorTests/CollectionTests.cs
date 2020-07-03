using B2CCustomPolicyGenerator;
using NUnit.Framework;
using System.Collections.Generic;
using System.Xml.Linq;

namespace B2CCustomPolicyGenerator.Tests.PolicyVisitorTests
{
    public class CollectionTests : PolicyVisitorTestBase<List<string>>
    {
        protected override XNode? Visit(PolicyVisitor visitor, List<string> input)
            => visitor.VisitCollection("SomeCollection", input, x => new XElement(x));


        [Test]
        public void When_Collection_Is_Empty()
        {
            var result = Visit(new List<string>());
            Assert.IsNull(result);
        }

        [Test]
        public void When_Collection_Is_Provided()
        {
            var input = new List<string>() { "First", "Second" };

            var expectedXml = @"
                <SomeCollection>
                    <First />
                    <Second />
                </SomeCollection>";

            AssertVisitedInput(input, expectedXml);
        }
    }
}
