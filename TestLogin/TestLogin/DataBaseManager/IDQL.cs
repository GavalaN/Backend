using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestLogin_Server.Models;

namespace TestLogin_Server.DataBaseManager
{
    internal interface IDQL
    {
        List<Rekord> Select();
    }
}
