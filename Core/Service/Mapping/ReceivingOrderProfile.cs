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
    public class ReceivingOrderProfile:Profile
    {
        public ReceivingOrderProfile()
        {
            CreateMap<ReceivingOrder,ReceivingOrderDTO>();
        }

    }
}
