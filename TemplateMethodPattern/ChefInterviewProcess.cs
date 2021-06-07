using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethidPattern
{
    class ChefInterviewProcess : InterviewProcess
    {
        public override void BarRaiser()
        {
            string message = $"InterviewId - {InterviewId} : Chef BarRiaser - The Interviewer may ask you to cook a signature dish and access your skills. ";
            message += "The Interviewer uses it to evaluate whether you will fit with the team.";
            Console.WriteLine(message);
        }

        public override void ManagerDiscussion()
        {
            string message = $"InterviewId - {InterviewId} : Chef Manager Discussion - The Interviewer may ask you to cook with them in their kitchen and access your team skills. ";
            message += "For example, preparing order for their customers.";
            Console.WriteLine(message);

        }

        public override void TechnicalDiscussion()
        {
            Console.WriteLine($"InterviewId - {InterviewId} : Chef Technical Discussion - Prepare your favorite dish in 60 minutes.");
        }
    }
}
