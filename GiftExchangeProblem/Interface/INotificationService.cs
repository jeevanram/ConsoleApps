using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftExchangeProblem.Interface
{
    public interface INotificationService
    {
        public void Notify(Participant participant);
    }
}
