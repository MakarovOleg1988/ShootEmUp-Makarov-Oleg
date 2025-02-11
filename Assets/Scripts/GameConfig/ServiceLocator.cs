using System;
using System.Collections.Generic;

namespace ShootEmUp
{
    public static class ServiceLocator
    {
        private static Dictionary<Type, object> _services = new();

        public static void AddServices(Type servicesType, object service)
        {
            _services[servicesType] = service;
        }

        public static T GetService<T>() where T : class
        {
            return _services[typeof(T)] as T;
        }

        public static object GetService(Type servicesType)
        {
            return _services[servicesType];
        }
    }
}