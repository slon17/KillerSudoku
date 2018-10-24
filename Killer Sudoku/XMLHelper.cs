using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Killer_Sudoku
{
    [System.Xml.Serialization.XmlInclude(typeof(Board))]
    class XMLHelper
    {

        public XMLHelper()
        {

        }

        public static void WriteXMLBoard(Board board)
        {
            XmlSerializer writer = new XmlSerializer(typeof(Board));
            var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "//board"+board.getSize()+".xml";
            //FileStream file = File.Create(path);
            TextWriter tw = new StreamWriter(path);

            writer.Serialize(tw, board);
            tw.Close();
        }
    }
}
