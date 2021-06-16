using System;
using System.Collections.Generic;
using System.IO;

namespace KeyGeneratorService
{
    class Program
    {
        static void Main(string[] args)
        {
            //Sample Key generator module demo for URLShortener
            List<URLShortenerDAO> uRLShortnerDAOs = new List<URLShortenerDAO>()
            {
                new URLShortenerDAO(){SequenceId=1,ActualURL="https://www.google.com",CreatedAt=DateTime.Now},
                new URLShortenerDAO(){SequenceId=2,ActualURL="https://www.github.com",CreatedAt=DateTime.Now}
            };

            IKeyGenerator numericKeyGenerator = new NumericKeyGenerator();
            numericKeyGenerator.UpdateShortKeyOnURLRecord(uRLShortnerDAOs[0]);
            URLShortenerDAO testResult = numericKeyGenerator.GetDBRecordByShortKey(uRLShortnerDAOs[0].ShortURL, uRLShortnerDAOs);

            //Please note : Code to avoid collisions are not part of the code, try to generate a different hash in case of collision
            IKeyGenerator hashKeyGenerator = new MD5HashKeyGenerator();
            hashKeyGenerator.UpdateShortKeyOnURLRecord(uRLShortnerDAOs[1]);
            testResult = hashKeyGenerator.GetDBRecordByShortKey(uRLShortnerDAOs[1].ShortURL, uRLShortnerDAOs);

            Console.ReadLine();
        }

       
    }
}
