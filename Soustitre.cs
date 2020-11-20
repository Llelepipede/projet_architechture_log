using System;
using System.Collections.Generic;
using System.Text;

namespace projet_log
{
    class Soustitre
    {

        public TimeSpan heuredep;
        public TimeSpan heurefin;
        public string value;

        public Soustitre(TimeSpan heuredep, TimeSpan heurefin, string value)
        {
            this.heuredep = heuredep;
            this.heurefin = heurefin;
            this.value = value;
        }
    }
}
