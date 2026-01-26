using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer
{
    public class DataforResult<Tentity>
    {
       
        public int TotalPages { get; set; }
       // public int CurrentPage { get; set; }
        public IEnumerable<Tentity> Data { get; set; }
        public int PageSize { get; set; }
        // public bool hasnext => CurrentPage < TotalPages;
        // public bool HasNext { get => CurrentPage < TotalPages;  }
        // public bool HasNext {  get; set; }
        //private int currentpage;


        //public int CurrentPage
        //{
        //    get { return currentpage; }
        //    set { if (value > TotalPages) currentpage = 1; else currentpage = value; }
        //}
        public int CurrentPage { get; set; }
        private bool hasnext;

        public bool HasNext
        {
            get { return hasnext; }
            set { if (CurrentPage < TotalPages) hasnext = true; else hasnext= false; }
        }


        public bool hasprevious => CurrentPage > 1;   //3  
       
    }
}
