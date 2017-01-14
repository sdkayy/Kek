using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kek.Utils
{
    public class PostArgs
    {
        private string message;
        private string link;
        public PostArgs(string message, string link)
        {
            this.message = message;
            this.link = link;
        }

        public string Message
        {
            get
            {
                return message;
            }
        }

        public string Link
        {
            get
            {
                return link;
            }
        }
    }
}
