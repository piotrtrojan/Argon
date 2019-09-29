using Argon.Webapp.Attributes;
using Argon.Webapp.CommandHandlers;
using Argon.Webapp.Commands;
using Argon.Webapp.Decorators;
using Argon.Webapp.QueryHandlers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Argon.Webapp.Utils
{
    public static class DecoratorRegistration
    {
        public static void AddDecorators(this IServiceCollection services)
        {
            var handlers = typeof(ICommand).Assembly.GetTypes()
                .Where(q => q.GetInterfaces().Any(y => IsHandlerInterface(y)))
                .Where(x => x.Name.EndsWith("Handler"))
                .ToList();

            foreach (var type in handlers)
            {
                AddHandler(services, type);
            }
        }

        private static bool IsHandlerInterface(Type type)
        {
            if (!type.IsGenericType)
                return false;
            var typeDefinition = type.GetGenericTypeDefinition();
            return typeDefinition == typeof(ICommandHandler<>) || typeDefinition == typeof(IQueryHandler<,>);
        }

        private static void AddHandler(IServiceCollection services, Type type)
        {
            var attributes = type.GetCustomAttributes(false);
            var pipeline = attributes
                .Select(x => ToDecorator(x))
                .Concat(new[] { type })
                .Reverse()
                .ToList();
            var interfaceType = type.GetInterfaces().Single(x => IsHandlerInterface(x));
            var factory = BuildPipeline(pipeline, interfaceType);
            services.AddTransient(interfaceType, factory);
        }

        private static Type ToDecorator(object attribute)
        {
            var type = attribute.GetType();
            if (type == typeof(CommandLogAtribute))
                return typeof(CommandLogDecorator<>);

            // other decorators/attributes goes here.
            throw new ArgumentException($"Unknown Decorator registred: {type.Name}.");

        }

        private static Func<IServiceProvider, object> BuildPipeline(ICollection<Type> pipeline, Type interfaceType)
        {
            var ctors = pipeline
                .Select(q =>
                {
                    Type type = q.IsGenericType ? q.MakeGenericType(interfaceType.GenericTypeArguments) : q;
                    return type.GetConstructors().Single();
                })
                .ToList();
            Func<IServiceProvider, object> func = provider => 
            {
                object current = null;
                foreach (ConstructorInfo ctor in ctors)
                {
                    List<ParameterInfo> paramsInfo = ctor.GetParameters().ToList();
                    object[] parameters = GetParameters(paramsInfo, current, provider);
                    current = ctor.Invoke(parameters);
                }
                return current;
            };
            return func;
        }

        private static object[] GetParameters(List<ParameterInfo> parameterInfos, object current, IServiceProvider provider)
        {
            var result = new object[parameterInfos.Count];
            for (int i = 0; i < parameterInfos.Count; i++)
            {
                result[i] = GetParamter(parameterInfos[i], current, provider);
            }
            return result;
        }

        private static object GetParamter(ParameterInfo parameterInfo, object current, IServiceProvider provider)
        {
            var parameterType = parameterInfo.ParameterType;

            if (IsHandlerInterface(parameterType))
                return current;

            object service = provider.GetService(parameterType);
            if (service != null)
                return service;
            throw new ArgumentException($"The type {parameterType} not found.");
        }
    }
}
