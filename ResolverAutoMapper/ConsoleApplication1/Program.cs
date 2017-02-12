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
            //Mapper.Initialize(cfg =>
            //{
            //    cfg.RecognizePrefixes("frm");

            //    cfg.CreateMap<Source, Destination>()
            //        .ForMember(dest => dest.Content_VN, opt => opt.ResolveUsing<CustomResolverVI>())
            //    .ForMember(dest => dest.Content_EN, opt => opt.ResolveUsing<CustomResolverEN>());
            //});
            Mapper.Initialize(cfg =>
            {
                cfg.RecognizePrefixes("frm");
                //cfg.RecognizePostfixes("_VI");
                //cfg.RecognizePostfixes("_EN");
                cfg.CreateMap<Source, Content>();
                cfg.CreateMap<Source, Destination>()

                    //.ForMember(dest => dest.Content_VN, opt => opt.ResolveUsing<CustomResolverVI>())
                    //.ForMember(dest => dest.Content_EN, opt => opt.ResolveUsing<CustomResolverEN>())
                .ForMember(dest => dest.Content_VN, opt => opt.ResolveUsing(
                        src => { return new Content { Value1 = src.Value1_VI, Value2 = src.Value2_VI }; }

                ))
                .ForMember(dest => dest.Content_EN, opt => opt.ResolveUsing(
                    src => Mapper.Map<Content>(src)

                ));
                // .ForMember(dest => dest.Content_VN, opt => opt.ResolveUsing(
                //    src => Mapper.Map<Content>(src)

                //));
            });
            var source = new Source
                {
                    Value1_VI = 5,
                    Value2_VI = 7,
                    Value1_EN = 4,
                    Value2_EN = 8,
                    frmValue = 1,
                    frmValue2 = 2,
                    Value3_VI = 3,
                    Value4_VI = 4,
                    Value5_VI = 5,
                    //Value3_EN = 6,
                    //Value4_EN = 7,
                    //Value5_EN = 8,
                };

            var result = Mapper.Map<Source, Destination>(source);
            int i = 1;
        }

    }
}
