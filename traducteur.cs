using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace projet_log
{
    class traducteur
    {
        
        public List<Soustitre> Soustitre = new List<Soustitre>();

        public traducteur(string path)
        {
            string totvalue;
            using (StreamReader sr = new StreamReader(path))
            {
                string s;
                totvalue = "";
                while ((s = sr.ReadLine()) != null)
                {
                    totvalue += s + "\n";
                }
            }
            //Console.WriteLine(totvalue);
            int i = 0;


            while (i + 1 < totvalue.Length)
            {
                int j = 0;
                string tempdep = "";
                string tempfin = "";
                string tempvalue = "";

                while (totvalue[i] != '\n' && i + 1 < totvalue.Length)
                {
                    i++;
                }
                i++;

                j = i;
                while (totvalue[i] != '\n' && i + 1 < totvalue.Length)
                {
                    if (i - j < 12)
                    {
                        tempdep += totvalue[i];
                    }
                    else if (-1 < i - (j + 17) && i - (j + 17) < 12)
                    {
                        tempfin += totvalue[i];
                    }
                    //Console.WriteLine("temps debut =" + tempdep + "\ntemps fin =" + tempfin);
                    i++;
                }

                i++;
                //Console.WriteLine("i:" + i + " < " + totvalue.Length);
                while ((totvalue[i] != '\n' || totvalue[i + 1] != '\n') && i + 2 < totvalue.Length)
                {
                    //Console.WriteLine("i:" + i + " < " + totvalue.Length);
                    tempvalue += totvalue[i];
                    i++;
                }

                tempvalue += totvalue[i];
                //Console.WriteLine(tempvalue);
                i++;
                while ((totvalue[i] < '0' || totvalue[i] > '9') && i + 1 < totvalue.Length)
                {
                    i++;
                }

                int h;
                int m;
                int s;
                int ms;

                h = ((tempdep[0] - '0') * 10) + (tempdep[1] - '0');
                m = ((tempdep[3] - '0') * 10) + (tempdep[4] - '0');
                s = ((tempdep[6] - '0') * 10) + (tempdep[7] - '0');
                ms = ((tempdep[9] - '0') * 100) + ((tempdep[10] - '0') * 10) + (tempdep[11] - '0');

                TimeSpan dep = new TimeSpan(0, h, m, s, ms);

                h = ((tempfin[0] - '0') * 10) + (tempfin[1] - '0');
                m = ((tempfin[3] - '0') * 10) + (tempfin[4] - '0');
                s = ((tempfin[6] - '0') * 10) + (tempfin[7] - '0');
                ms = ((tempfin[9] - '0') * 100) + ((tempfin[10] - '0') * 10) + (tempfin[11] - '0');

                TimeSpan fin = new TimeSpan(0, h, m, s, ms);

                Soustitre.Add(new Soustitre(dep, fin, tempvalue));
                //Console.WriteLine(Soustitre.Count);
            }

        }

        public async Task affichage()
        {
            DateTime start = DateTime.Now;
            TimeSpan last = new TimeSpan(0,0,0,0,0);

            int actual_st = 0;

            while(actual_st < Soustitre.Count)
            {
                
                await Task.Delay(Soustitre[actual_st].heuredep - last);
                Console.WriteLine(Soustitre[actual_st].value);
                last = Soustitre[actual_st].heuredep;
                await Task.Delay(Soustitre[actual_st].heurefin - last);
                Console.Clear();

                last = Soustitre[actual_st].heurefin;
                actual_st++;
            }
        }
    }
}
