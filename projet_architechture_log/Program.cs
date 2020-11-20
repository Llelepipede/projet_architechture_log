using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace projet_architechture_log
{
    class Program
    {
        static void Main()
        {
            traducteur traducteur = new traducteur(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\srt\test.srt");
            Task.WaitAll(traducteur.affichage());

        }
    }
}
