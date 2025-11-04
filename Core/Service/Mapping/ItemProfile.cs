using AutoMapper;
using InvetoryManagementSystem;
using Shared.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Mapping
{
    public class ItemProfile :Profile
    {
     public ItemProfile()
        {
            CreateMap<ItemMaster, ItemMasterDTO>().ReverseMap();
            //    .ForMember(dist=>dist.   )
           


        }


    }
}
