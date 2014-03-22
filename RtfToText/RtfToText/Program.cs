using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace RtfToText
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Count() != 1) return;

            string filename = args[0];
            if (!System.IO.File.Exists(filename)) return;

            string rtf_content;
            try
            {
                rtf_content = System.IO.File.ReadAllText(filename);
            }
            catch (Exception ex)
            {
                Console.Error.Write(ex.Message);
                return;
            }

            Console.Write(ConvertToPlainText(rtf_content));
        }

        static string ConvertToPlainText(string rtf_content)
        {
            RichTextBox rt = new RichTextBox
            {
                Rtf = rtf_content,
            };
            return rt.Text;
        }
    }
}
