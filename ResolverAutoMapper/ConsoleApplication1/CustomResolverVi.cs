using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class CustomResolverVI : IValueResolver<Source, Destination, Content>
    {
        public Content Resolve(Source source, Destination destination, Content member, ResolutionContext context)
        {
            member.Value1 = source.Value1_VI;
            member.Value2 = source.Value2_VI;
            return member;
        }
    }
}
