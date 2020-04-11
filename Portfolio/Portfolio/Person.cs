using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio
{
    class Person
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Job { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }



        public string FullInfo
        {
            get
            {
                return $"{ Firstname } { Lastname }||{Job} ||  {Email} / {Phone}";
            }

        }
    }
}
