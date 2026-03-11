using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyUrl.ViewModels
{
    public class TinyURLDTOViewModel
    {
        public int TinyURLId { get; set; }
        public string OriginalUrl { get; set; }
        public string ShortCode { get; set; }
        public int TotalClickCount { get; set; } = 0;
        public bool IsPrivate { get; set; }
    }
}
