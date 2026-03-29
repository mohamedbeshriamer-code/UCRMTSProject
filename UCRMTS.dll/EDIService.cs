using indice.Edi;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCRMTS.dll.Implementation;
using UCRMTS.dll.Interfaces;
using UCRMTS.dll.Models;

namespace UCRMTS.dll
{
    public enum EDIType
    {
        Cuscare95B = 0,
        IFCSUM = 1
    }
    public class EDIService 
    {
        public CuscarInterchange Deserialize(string message)
        {
            var currentMessage = DetectType(message);
            IEDIParser parser;
            switch (currentMessage)
            {
                case EDIType.Cuscare95B:
                    parser = new Cuscare95BParser();
                    break;
                case EDIType.IFCSUM:
                    parser = new IFCSUMParser();
                    break;
                default:
                    throw new Exception("Unsuppoted EDI");

            }
            return parser.Deserilize(message);
        }

        public EDIType DetectType(string fullMessage)
        {
            if (fullMessage.Contains("CUSCAR:D:95B"))
            {
                return EDIType.Cuscare95B;
            }
            else if (fullMessage.Contains("IFCSUM"))
            {
                return EDIType.IFCSUM;
            }
            else
            {
                throw new NotImplementedException("File is not Supported");
            }
        }



        public int SaveBillOfLadingExport(CuscarInterchange message)
        {
            throw new NotImplementedException();
        }

        public int SaveBillOfLadingImport(CuscarInterchange message)
        {
            throw new NotImplementedException();
        }

        public string Selialize(CuscarInterchange message)
        {
            var writer = new StringWriter();
            
              var grammar = EdiGrammar.NewEdiFact();
            var serializer = new EdiSerializer();

            serializer.Serialize(writer, grammar, serializer);
            return writer.ToString();
        }

        public void Selialize(string path , CuscarInterchange message)
        {
            using (TextWriter writer = new StreamWriter(path))
            {
                var grammar = EdiGrammar.NewEdiFact();
                var serializer = new EdiSerializer();

                 serializer.Serialize(writer, grammar, message);
            }
         
        }
        public string Selialize<T>(T message, IEDIParser parser)
        {

            return parser.Serilize(message);


        }
    }

}
