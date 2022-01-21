using System;
using System.Collections.Generic;
using System.Text;

namespace SelfServices.Common.Entity
{
    public class Notification
    {
        public int NOTIFICATION_ID { get; set; }
        public long USERNO { get; set; }
        public string NOTIFICATION_TITLE { get; set; }
        public string NOTIFICATION_BODY { get; set; }
        public DateTime NOTIFICATION_DATE { get; set; }
        public bool IS_READ { get; set; }
    }
}
