using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyGeneratorService
{
    //Assume this is the class representation of the DB table
    public class URLShortenerDAO
    {
        public long SequenceId { get; set; }
        public string ActualURL { get; set; }
        public string ShortURL { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
