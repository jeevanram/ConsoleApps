using GiftExchangeProblem.Interface;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftExchangeProblem
{
    public class CSVUtility : IInputUtility
    {
        public List<Participant> ReadingInputData()
        {
            List<Participant> participants = new List<Participant>();
            using (TextFieldParser parser = new TextFieldParser("./InputData.csv"))
            {
                parser.SetDelimiters(new string[] { "," });
                while(!parser.EndOfData)
                {
                    
                    string[] row = parser.ReadFields();
                    if(row.Length == 2)
                    {
                        Participant newParticipant = new Participant()
                        {
                            Name = row[0],
                            EmailAddress = row[1]
                        };

                        if(!participants.Exists(prt => prt.EmailAddress.ToUpper() == newParticipant.EmailAddress.ToUpper()))
                        {
                            participants.Add(newParticipant);
                        }
                    }
                }
            }

            return participants;
        }
    }
}
