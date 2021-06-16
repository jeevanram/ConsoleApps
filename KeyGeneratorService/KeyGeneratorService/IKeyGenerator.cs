using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyGeneratorService
{
    public interface IKeyGenerator
    {
        public void UpdateShortKeyOnURLRecord(URLShortenerDAO urlRecord);
        public URLShortenerDAO GetDBRecordByShortKey(string shortKey, List<URLShortenerDAO> urlRecords);
    }
}
