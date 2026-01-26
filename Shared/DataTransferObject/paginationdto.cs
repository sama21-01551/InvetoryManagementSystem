using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObject
{
    public class paginationdto<Tentity>
    {
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
         public bool HasNext {  get; set; }
       // public bool HasNext => CurrentPage < TotalPages;

        public IEnumerable<Tentity> Data { get; set; }
    }
}
