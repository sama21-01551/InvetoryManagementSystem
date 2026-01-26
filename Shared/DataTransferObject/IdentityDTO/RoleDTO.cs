using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObject.IdentityDTO
{
    public class RoleDTO
    {
    
        public string userName { get; set; }
        public string ID { get; set; }
       // public string Role { get; set; }
        private string role;

        public string Role
        {
            get { return role; }
            set { role=value ; }
        }

    }
}
