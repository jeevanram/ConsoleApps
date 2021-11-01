using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftExchangeProblem
{
    public class Participant
    {
        public string Name { get; set; }
        public string EmailAddress { get; set; }

        //Gift Sent to
        public Participant Sender { get; set; }

        //Gift from
        public Participant Recipient { get; set; }

        public bool HasSender()
        {
            return (this.Sender != null);
        }

        public bool HasRecipient()
        {
            return (this.Recipient != null);
        }

        public bool HasAllMatches()
        {
            return this.HasSender() && this.HasRecipient();
        }

        public void ResetSenderAndRecipient()
        {
            this.Sender = null;
            this.Recipient = null;
        }

    }
}
