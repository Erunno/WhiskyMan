using Autofac.Extras.Moq;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using WhiskyMan.Repositories.Mapping;

namespace WhiskyMan.Repositories.Tests
{
    class MapperForTesting : IMapper
    {
        IMapper mapper;

        public MapperForTesting()
        {
            mapper = MapperProvider.GetMapper();
        }

        public IConfigurationProvider ConfigurationProvider => mapper.ConfigurationProvider;
        public Func<Type, object> ServiceCtor => mapper.ServiceCtor;
        public TDestination Map<TDestination>(object source, Action<IMappingOperationOptions<object, TDestination>> opts) => mapper.Map(source, opts);
        public TDestination Map<TSource, TDestination>(TSource source, Action<IMappingOperationOptions<TSource, TDestination>> opts) => mapper.Map(source, opts);
        public TDestination Map<TSource, TDestination>(TSource source, TDestination destination, Action<IMappingOperationOptions<TSource, TDestination>> opts) => mapper.Map(source, destination, opts);
        public object Map(object source, Type sourceType, Type destinationType, Action<IMappingOperationOptions<object, object>> opts) => mapper.Map(source, sourceType, destinationType, opts);
        public object Map(object source, object destination, Type sourceType, Type destinationType, Action<IMappingOperationOptions<object, object>> opts) => mapper.Map(source, destination, sourceType, destinationType, opts);
        public TDestination Map<TDestination>(object source) => mapper.Map<TDestination>(source);
        public TDestination Map<TSource, TDestination>(TSource source) => mapper.Map<TSource, TDestination>(source);
        public TDestination Map<TSource, TDestination>(TSource source, TDestination destination) => mapper.Map(source, destination);
        public object Map(object source, Type sourceType, Type destinationType) => mapper.Map(source, sourceType, destinationType);
        public object Map(object source, object destination, Type sourceType, Type destinationType) => mapper.Map(source, destination, sourceType, destinationType);
        public IQueryable<TDestination> ProjectTo<TDestination>(IQueryable source, object parameters = null, params Expression<Func<TDestination, object>>[] membersToExpand) => mapper.ProjectTo(source, parameters, membersToExpand);
        public IQueryable<TDestination> ProjectTo<TDestination>(IQueryable source, IDictionary<string, object> parameters, params string[] membersToExpand) => mapper.ProjectTo<TDestination>(source, parameters, membersToExpand);
        public IQueryable ProjectTo(IQueryable source, Type destinationType, IDictionary<string, object> parameters = null, params string[] membersToExpand) => mapper.ProjectTo(source, destinationType, parameters, membersToExpand);
    }
}
