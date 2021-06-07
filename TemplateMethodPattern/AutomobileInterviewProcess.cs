using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethidPattern
{
    class AutomobileInterviewProcess : InterviewProcess
    {
        public override void BarRaiser()
        {
            string message = $"InterviewId - {InterviewId} : Automobile BarRiaser - The Interviewer may ask you to design a car model of your own to assess your interest and passion. ";
            message += "The Interviewer uses it to evaluate whether you will fit with the team.";
            Console.WriteLine(message);
        }

        public override void ManagerDiscussion()
        {
            string message = $"InterviewId - {InterviewId} : Automobile Manager Discussion - The Interviewer may ask you to come up with a feature to attract more customers. ";
            message += "For example, improving fuel efficiency (or) including safety features.";
            Console.WriteLine(message);

        }

        public override void TechnicalDiscussion()
        {
            Console.WriteLine($"InterviewId - {InterviewId} : Automobile Technical Discussion - Engine diagnostics to understand your knowledge.");
        }
    }
}
