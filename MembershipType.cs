using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCUdemy1.Models
{
    public class MembershipType
    {
        public byte Id { get;set; }
        public short SignUpFee { get; set; }
        public byte DurationInMonth { get; set; }
        public byte DiscountRate { get; set; }
        public string MemberShipTypeName { get; set; }
        public static readonly byte Unknown = 0;
        public static readonly byte PayAsyoUGO = 1;
        public static readonly byte Annual = 2;
         
    }
}