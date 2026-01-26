using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Pagination
{
    public abstract class Result<Tentity>
    {
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
        public IEnumerable<Tentity> Data { get; set; }
        public int PageSize { get; set; }
        public bool hasnext => CurrentPage < TotalPages;
        public bool hasprevious => CurrentPage > 1;   //3  








    }
}
