namespace Vidly.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }
        public short signUpFee { get; set; }
        public byte durationInMonth { get; set; }
        public byte discountRate { get; set; }

    }
}