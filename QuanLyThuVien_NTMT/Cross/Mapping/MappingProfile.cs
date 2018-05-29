using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
//using AutoMapper;
using Cross.ViewModel;
using Elect.Mapper.AutoMapper;
using Elect.Mapper.AutoMapper.IMappingExpressionUtils;
using OA.Data.Model;

namespace Cross.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //CreateMap<CreateDocGiaModel,DocGia>().IgnoreAllNonExisting();
        }
    }
}
