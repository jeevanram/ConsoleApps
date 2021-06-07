using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethidPattern
{
    abstract class InterviewProcess : IInterviewProcess
    {
        public string InterviewId { get; } = Guid.NewGuid().ToString()[^4..];

        public abstract void BarRaiser();

        public void InitialHRDiscussion()
        {
            string message = $"InterviewId - {InterviewId} : HR calls the candidate and explains about the job description";
            message += "HR discuss with the candidate and understand their interest and expectation";
            Console.WriteLine(message);
        }

        public abstract void ManagerDiscussion();

        public void OfferDiscussion()
        {
            Console.WriteLine($"InterviewId - {InterviewId} : Final offer negotiation between the HR and the Candidate");
        }

        public void ResumeScreening()
        {
            Console.WriteLine($"InterviewId - {InterviewId} : HR and Hiring manager screen the resume to identify potential employees resume");
        }

        public abstract void TechnicalDiscussion();

        public void Process()
        {
            ResumeScreening();
            InitialHRDiscussion();
            TechnicalDiscussion();
            BarRaiser();
            ManagerDiscussion();
            OfferDiscussion();
        }
    }
}
