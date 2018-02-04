using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLOG.BLL.Services.Abstracts
{
   public interface IMessageService
    {
        bool SendMessage(string subject, string message);
    }
}
