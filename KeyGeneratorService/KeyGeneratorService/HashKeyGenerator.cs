using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace KeyGeneratorService
{
    class MD5HashKeyGenerator : IKeyGenerator
    {
        private string GetShortKey(string actualURL)
        {
            HashAlgorithm hashAlgorithm = MD5.Create();
            var hashBytes = hashAlgorithm.ComputeHash(Encoding.ASCII.GetBytes(actualURL));
            string base64String = Convert.ToBase64String(hashBytes);
            SwapCharactersInRandom(ref base64String,7);
            PickRandomSevenCharLengthString(ref base64String);
            return base64String;
        }

        //Pick random 7 characters from the hash
        private void PickRandomSevenCharLengthString(ref string base64String)
        {
            Random random = new Random();
            List<int> randomIndexParsed = new List<int>();
            int randomIndex = 0;
            char[] base64StringCharArray = base64String.ToCharArray();
            base64String = string.Empty;
            for (int i = 0; i < 7; i++)
            {
                do
                {
                    randomIndex = random.Next(0, base64StringCharArray.Length);
                } while (randomIndexParsed.Contains(randomIndex));
                randomIndexParsed.Add(randomIndex);
                base64String += base64StringCharArray[randomIndex];
            }
        }

        //swap randon number of elements in hash
        private void SwapCharactersInRandom(ref string base64String, int numberOfTimesToSwap)
        {
            Random random = new Random();
            char[] base64StringCharArray = base64String.ToCharArray();
            while (numberOfTimesToSwap > 0)
            {
                int index1 = random.Next(0, base64String.Length);
                int index2 = random.Next(0, base64String.Length);
                //swap the randomly picked index positions
                char temp = base64String[index1];
                base64StringCharArray[index1] = base64StringCharArray[index2];
                base64StringCharArray[index2] = temp;
                numberOfTimesToSwap--;

            }
            base64String = String.Join("",base64StringCharArray);
        }

        private long GetValueFromShortKey(string shortKey)
        {

            return 1;
        }

        public void UpdateShortKeyOnURLRecord(URLShortenerDAO urlRecord)
        {
            urlRecord.ShortURL = GetShortKey(urlRecord.ActualURL);
        }

        public URLShortenerDAO GetDBRecordByShortKey(string shortKey,List<URLShortenerDAO> urlRecords)
        {
            return urlRecords.Find(urlRecord => urlRecord.ShortURL == shortKey);
        }
    }
}
