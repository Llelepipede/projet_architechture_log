using System;
using System.Threading.Tasks;

namespace projet_log
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
