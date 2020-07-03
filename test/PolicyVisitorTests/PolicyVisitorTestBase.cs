using B2CCustomPolicyGenerator;
using NUnit.Framework;
using System.Xml.Linq;

namespace B2CCustomPolicyGenerator.Tests.PolicyVisitorTests
{
    public abstract class PolicyVisitorTestBase<T>
    {
        protected XNode? Visit(T input)
        {
            var visitor = new PolicyVisitor();
            return Visit(visitor, input);
        }

        protected abstract XNode? Visit(PolicyVisitor visitor, T input);

        protected void AssertVisitedInput(T input, string expectedXml)
        {
            AssertXml(Visit(input)!, expectedXml);
        }

        protected void AssertXml(XNode node, string expectedXml)
        {
            var actualXmlString = node.ToString();
            var normalizedExpectedXml = XElement.Parse(expectedXml).ToString();

            Assert.That(actualXmlString, Is.EqualTo(normalizedExpectedXml));
        }
    }
}
