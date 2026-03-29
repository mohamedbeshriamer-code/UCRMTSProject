using indice.Edi;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCRMTS.dll.Interfaces;
using UCRMTS.dll.Models;

namespace UCRMTS.dll
{
    public class Cuscare95BParser : IEDIParser
    {
        IEdiGrammar grammar = EdiGrammar.NewEdiFact();
        EdiSerializer serializer = new EdiSerializer();
        public CuscarInterchange Deserilize(string interchange)
        {
            CuscarInterchange fullMessage = new CuscarInterchange();
            TextReader reader = new StringReader(interchange);
            
            var fullCascuare = serializer.Deserialize<CuscarInterchange>(reader, grammar);
            TextReader reader2 = new StringReader(interchange);
            var consigments = serializer.Deserialize<CascareConsigmentsMesssage>(reader2, grammar);
            if (consigments.Consignments != null)
            {
                foreach (var item in consigments.Consignments)
                {
                    item.ProcessDescriptionItem();
                }
            }


            fullCascuare.Consignments = consigments.Consignments;

            return fullCascuare;
        }

        public string Serilize<T>(T cuscarInterchange)
        {
            if (cuscarInterchange is CuscarInterchange)
            {
                throw new Exception("The Edi is not Compatiable");
            }


            using (var writer = new StringWriter())
            {
                serializer.Serialize(writer, grammar, cuscarInterchange);
                return writer.ToString();
            }




        }
 
       
    }
}
