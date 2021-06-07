using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethidPattern
{
    interface IInterviewProcess
    {
        public void ResumeScreening();
        public void InitialHRDiscussion();
        public void TechnicalDiscussion();
        public void BarRaiser();
        public void ManagerDiscussion();
        public void OfferDiscussion();
        public void Process();
    }
}
