using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethidPattern
{
    class ITInterviewProcess : InterviewProcess
    {
        public override void BarRaiser()
        {
            string message = $"InterviewId - {InterviewId} : IT BarRiaser - The Interviewer asks a coding challenge or design question to test your ability to handle it. ";
            message += "The Interviewer uses it to evaluate whether you will fit with the team.";
            Console.WriteLine(message);
        }

        public override void ManagerDiscussion()
        {
            string message = $"InterviewId - {InterviewId} : Manager Discussion - The Interviewer asks you to design a solution for the problem statement. ";
            message += "For example, an enhancement of a feature that you worked on in the previous project (or) a feature that the company is working on.";
            Console.WriteLine(message);

        }

        public override void TechnicalDiscussion()
        {
            Console.WriteLine($"InterviewId - {InterviewId} : IT Technical Discussion - Coding round to access your problem-solving skills.");
        }
    }
}
