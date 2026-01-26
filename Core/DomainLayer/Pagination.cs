using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer
{
    public class Pagination
    {
        public int Maxpagenumber { get; set; } = 10;
        public int Minpagenumber { get; set; } = 1;
        public int Pagesize { get; set; } = 10;
        private int pagenumber;
        public int PageNumber
        {
            get { return pagenumber; }
            set { if (value > Maxpagenumber) pagenumber = 1; else if (value < Minpagenumber) pagenumber = Minpagenumber; else pagenumber = value; }//pagenumber = (value > Maxpagenumber) ? Maxpagenumber : value; && (value<Minpagenumber)?Minpagenumber:value}
        }
       // private int Currentpage;

        //public int currentpage
        //{
        //    get { return Currentpage; }
        //    set { Currentpage = PageNumber; }
        //}

    }
}
