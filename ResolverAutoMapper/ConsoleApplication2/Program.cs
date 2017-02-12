using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.RecognizePostfixes("_VN");
                cfg.RecognizePostfixes("_EN");
                cfg.CreateMap<DomainClass, Child>();
                cfg.CreateMap<DomainClass, Parent>()
                    .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                    .ForMember(d => d.A, opt => opt.MapFrom(s => s.A))
                    .ForMember(d => d.Child_VN,
                        opt => opt.MapFrom(
                            s => Mapper.Map<Child>(s)
                            )
                      )
                    .ForMember(d => d.Child_EN,
                        opt => opt.MapFrom(s => Mapper.Map<Child>(s)));
            });
            var dm = new DomainClass { Id = 1, A = "A", B_VN = "B_VN", B_EN = "B_EN" };
            var pa = Mapper.Map<Parent>(dm);
            var t = 1;
        }
    }
}
