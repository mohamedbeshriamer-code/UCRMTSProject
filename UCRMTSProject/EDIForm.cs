using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCRMTS.dll.Models;

namespace UCRMTSProject
{
    public class EDIForm :UCRMTS.dll.Forms.EditView
    {
        public EDIForm()
        {
            
        }
        public EDIForm(CuscarInterchange cuscarInterchange)
            :base(cuscarInterchange)
        {
            
        }
    }
}
