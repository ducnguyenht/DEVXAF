using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;


    public static class automapperExtensions {
        public static IMappingExpression<TDestination, TSource> ReverseMapWithForMemberPreserved41<TSource, TDestination>
        (this IMappingExpression<TSource, TDestination> expression) {
            var existingMaps = Mapper.GetAllTypeMaps().First(x => x.SourceType.Equals(typeof(TSource))
                && x.DestinationType.Equals(typeof(TDestination)));
            var reversedMapping = Mapper.CreateMap<TDestination, TSource>();

            foreach(var map in existingMaps.GetPropertyMaps()) {
                var newDestionationName = map.SourceMember.Name;
                var newDestinationType = typeof(TSource).GetProperties()
                    .Single(p => p.Name == newDestionationName).PropertyType;
                var newSourceName = map.DestinationProperty.Name;
                var newSourceType = typeof(TDestination).GetProperties()
                    .Single(p => p.Name == newSourceName).PropertyType;
                var newSourceTypeCode = System.Type.GetTypeCode(newSourceType);

                //if the names already match AM will handle so just let it do its thing
                if(newSourceName == newDestionationName)
                    continue;

                ////generic lists and collections not supported, you'll need to map 
                ////manually on the reverse side (but only if their names don't match)
                if(newSourceType.IsGenericType)
                    continue;

                ////types must be of the same kind
                if((newSourceType.IsValueType && !newDestinationType.IsValueType) ||
                    (!newSourceType.IsValueType && newDestinationType.IsValueType))
                    continue;

                if(newSourceType.IsValueType)
                    reversedMapping.ForMember(newDestionationName, o => o.UseValue(map.UseDestinationValue));
                else
                    reversedMapping.ForMember(newDestionationName, o => o.MapFrom<Object>(newSourceName));
            } //end of foreach GetPropertyMaps() block
            return reversedMapping;
        } //end ReverseMapWithForMemberPreserved41

        public static IMappingExpression<TDestination, TSource> ReverseMapWithForMemberPreserved<TSource, TDestination>
       (this IMappingExpression<TSource, TDestination> expression, IMapperConfiguration cfg) {
            var reversedMapping = cfg.CreateMap<TDestination, TSource>();
            foreach(var map in expression.TypeMap.GetPropertyMaps()) {
                var newDestionationName = map.SourceMember.Name;
                var newDestinationType = typeof(TSource).GetProperties().Single(p => p.Name == newDestionationName).PropertyType;
                var newSourceName = map.DestinationProperty.Name;
                var newSourceType = typeof(TDestination).GetProperties().Single(p => p.Name == newSourceName).PropertyType;
                var newSourceTypeCode = System.Type.GetTypeCode(newSourceType);

                //if the names already match AM will handle so just let it do its thing
                if(newSourceName == newDestionationName)
                    continue;

                //generic lists and collections not supported, you'll need to map 
                //manually on the reverse side (but only if their names don't match)
                if(newSourceType.IsGenericType)
                    continue;

                ////types must be of the same kind
                if((newSourceType.IsValueType && !newDestinationType.IsValueType) ||
                    (!newSourceType.IsValueType && newDestinationType.IsValueType))
                    continue;

                if(newSourceType.IsValueType)
                    reversedMapping.ForMember(newDestionationName, o => o.UseValue(map.UseDestinationValue));
                else
                    reversedMapping.ForMember(newDestionationName, o => o.MapFrom<Object>(newSourceName));
            } //end of foreach GetPropertyMaps() block
            return reversedMapping;
        } //end ReverseMapWithForMemberPreserved
    }
