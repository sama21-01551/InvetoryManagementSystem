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
    public class SerialProfile : Profile
    {
        public SerialProfile()
        {

            CreateMap<ItemSerialNumber, SerialNumberDTO>().ReverseMap();

        }



    }
}
