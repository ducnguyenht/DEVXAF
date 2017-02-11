using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Mapper.Initialize(cfg =>
                cfg.CreateMap<Source, Destination>()
                .ForMember(dest => dest.Content_VN, opt => opt.ResolveUsing<CustomResolverVi>())
                .ForMember(dest => dest.Content_EN, opt => opt.ResolveUsing<CustomResolverEn>())
            );
            var source = new Source
                {
                    Value1_VI = 5,
                    Value2_VI = 7,
                    Value1_EN = 4,
                    Value2_EN = 8
                };

            var result = Mapper.Map<Source, Destination>(source);
        }

    }
}
