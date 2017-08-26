using ExpenseTracker.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Business.Interface
{
    public interface IAuthenticate
    {
        bool IsValid(Credentials credentails);

        string BuildToken(Credentials credentials);
    }
}
