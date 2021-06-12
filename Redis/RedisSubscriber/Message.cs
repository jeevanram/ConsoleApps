using System;
using System.Collections.Generic;
using System.Text;

namespace RedisSubscriber
{
    class Message
    {
        public string MessageTitle { get; set; }
        public string MessageDescription { get; set; }
        public string MessageGeneratedBy { get; set; }
        public DateTime MessageGeneratedAt { get; set; }
    }
}
