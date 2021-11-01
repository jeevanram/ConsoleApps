using GiftExchangeProblem.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftExchangeProblem
{
    public class MatcherGenerator
    {
        private readonly INotificationService _notificationService;
        private readonly IInputUtility _inputUtility;
        public List<Participant> Participants { get; set; }

        public MatcherGenerator(INotificationService notificationService, IInputUtility inputUtility)
        {
            this._notificationService = notificationService;
            this._inputUtility = inputUtility;
        }

        public void LoadParticipants()
        {
            Participants = this._inputUtility.ReadingInputData();
        }

        public bool HasAllParticipantMatched()
        {
       
            foreach(Participant participant in Participants)
            {
                if (!participant.HasAllMatches())
                    return false;
            }
            return true;
        }

        public void ResetAllParticipantsSenderAndRecipient()
        {
            foreach (Participant participant in Participants)
            {
                participant.ResetSenderAndRecipient();
            }
        }
        public void PerformMatch()
        {
            bool IsEveryoneMatched = false;
            while(!IsEveryoneMatched)
            {
                ResetAllParticipantsSenderAndRecipient();
                for (int i=0;i<Participants.Count;i++)
                {
                    Participant currentParticipant = Participants[i];
                    if (!currentParticipant.HasSender())
                    {
                        List<Participant> unmatchedParticipants = Participants.Where(pt => !pt.HasRecipient() && pt.EmailAddress != currentParticipant.EmailAddress).ToList();
                        Random random = new Random();
                        int randomIndex = random.Next(unmatchedParticipants.Count);
                        if(!unmatchedParticipants[randomIndex].HasRecipient())
                        {
                            currentParticipant.Sender = unmatchedParticipants[randomIndex];
                            unmatchedParticipants[randomIndex].Recipient = currentParticipant;
                        }
                    }
                }

                IsEveryoneMatched = this.HasAllParticipantMatched();
            }
        }

        public void NotifyAllParticipants()
        {
            foreach(Participant participant in Participants)
            {
                _notificationService.Notify(participant);
            }
        }



    }
}
