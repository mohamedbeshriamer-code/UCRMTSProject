using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCRMTS.dll.Models;

namespace UCRMTS.dll.Interfaces
{
    public interface IEDIParser
    {
         string Serilize<T>(T cuscarInterchange);

         CuscarInterchange Deserilize(string interchange);
    }
}
