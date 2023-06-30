using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_PP.Classes
{
    public class DebugClass
    {
        /// <summary>
        /// Очистка файла с отладочной информацией
        /// </summary>
        public static void NewFile()
        {
            if (File.Exists("Diagnostic.txt"))
            {
                File.Delete("Diagnostic.txt");
                Trace.Listeners.Add(new TextWriterTraceListener("Diagnostic.txt"));
            }
            else
            {
                Trace.Listeners.Add(new TextWriterTraceListener("Diagnostic.txt"));
            }
        }

        /// <summary>
        /// Запись в файл с отладочной информацией
        /// </summary>
        /// <param name="s">Строковая переменная для записи в отладочный файл</param>
        public static void WriteDebug(string s)
        {
            Debug.WriteLine(s);
            Trace.WriteLine(s);
            Trace.Flush();
        }
    }
}
