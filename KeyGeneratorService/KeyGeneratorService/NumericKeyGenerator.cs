using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyGeneratorService
{
    class NumericKeyGenerator : IKeyGenerator
    {
        private string GetShortKey(long sequenceId)
        {
            string characterSet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789+/";

            string shortKey = string.Empty;

            // Convertion logic
            while (sequenceId > 0)
            {
                long charIndex = sequenceId % 64;
                shortKey += (characterSet[(int)charIndex]);
                sequenceId = sequenceId / 64;
            }

            // Reverse the output to get the ShortKey
            return Reverse(shortKey);
        }

        private string Reverse(string shortKey)
        {
            char[] shortKeyCharArray = shortKey.ToCharArray();
            Array.Reverse(shortKeyCharArray);
            return new string(shortKeyCharArray);
        }
    

        private long GetValueFromShortKey(string shortKey)
        {
            long returnValue = 0;
            for (int i = 0; i < shortKey.Length; i++)
            {
                if (shortKey[i] >= 'a' && shortKey[i] <= 'z')
                {
                    returnValue = 64 * returnValue + (shortKey[i] - 'a');
                }
                else if (shortKey[i] >= 'A' && shortKey[i] <= 'Z')
                {
                    returnValue = 64 * returnValue + (shortKey[i] - 'A') + 26;
                }
                else if (shortKey[i] >= '0' && shortKey[i] <= '9')
                {
                    returnValue = 64 * returnValue + (shortKey[i] - '0') + 52;
                }
                else if (shortKey[i] == '+')
                {
                    returnValue = 64 * returnValue + 62;
                }
                else if (shortKey[i] == '/')
                {
                    returnValue = 64 * returnValue + 63;
                }
            }
            return returnValue;

        }

        public void UpdateShortKeyOnURLRecord(URLShortenerDAO urlRecord)
        {
            urlRecord.ShortURL = GetShortKey(urlRecord.SequenceId);
        }

        public URLShortenerDAO GetDBRecordByShortKey(string shortKey,List<URLShortenerDAO> urlRecords)
        {
            long sequenceId = GetValueFromShortKey(shortKey);
            return urlRecords.Find(urlRecord => urlRecord.SequenceId == sequenceId);
        }
    }
}
