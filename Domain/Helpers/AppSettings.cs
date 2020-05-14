using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Helpers
{
    public class AppSettings
    {
        public string Secret { get; set; }
        public string TimeZoneInServer { get; set; }
        public string DefaultRegionCountryCode { get; set; }
        public string KeyForEncrypting { get; set; }
        public string KeyForEncrypting2 { get; set; }
    }
}
