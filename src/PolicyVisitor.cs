using B2CCustomPolicyGenerator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace B2CCustomPolicyGenerator
{
    public class PolicyVisitor
    {
        public XNode Visit(ClaimsProvider claimsProvider)
        {
            return new XElement(nameof(ClaimsProvider),
                new XElement("DisplayName", claimsProvider.DisplayName),
                VisitCollection("TechnicalProfiles", claimsProvider.TechnicalProfiles, Visit));
        }

        public XNode? VisitCollection<T>(string name, ICollection<T> items, Func<T, XNode> visitor)
        {
            if (!items.Any())
            {
                return null;
            }

            return new XElement(name, items.Select(visitor));
        }


        public XElement Visit(TechnicalProfile technicalProfile)
        {
            return new XElement(nameof(TechnicalProfile),
                new XAttribute("Id", technicalProfile.Id),
                new XElement("DisplayName", technicalProfile.DisplayName),
                Visit(technicalProfile.Protocol),
                VisitMetaData(technicalProfile.Metadata)
            );
        }

        public XElement? VisitMetaData(IDictionary<string, string> metaData)
        {
            if (metaData == null || !metaData.Any())
            {
                return null;
            }

            return new XElement("Metadata",
                metaData.Select(x =>
                {
                    var item = new XElement("Item");
                    item.SetAttributeValue("Key", x.Key);
                    item.SetValue(x.Value);
                    return item;
                }));
        }

        public XElement Visit(Protocol protocol)
        {
            var xmlElement = new XElement("Protocol",
                    new XAttribute("Name", protocol.Name.ToString())
                );

            if (!string.IsNullOrWhiteSpace(protocol.Handler))
            {
                xmlElement.Add(new XAttribute("Handler", protocol.Handler));
            }

            return xmlElement;
        }
    }
}
