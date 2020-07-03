namespace B2CCustomPolicyGenerator.Model
{
    public class ClaimType
    {
        public ClaimType(string id)
        {
            Id = id;
        }

        public string Id { get; }
        public string DisplayName { get; set; }
        public ClaimDataType Type { get; set; }
    }
}
