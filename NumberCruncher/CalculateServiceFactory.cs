using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace NumberCruncher
{
    class CalculateServiceFactory : ICalculateServiceFactory
    {
        private readonly List<Type> _calculateServiceTypes;
        private readonly Dictionary<string, ICalculateService> _calculateServiceDictionary;

        public List<string> ServiceKeys => Enumerable.ToList<string>(_calculateServiceDictionary.Keys);

        public CalculateServiceFactory()
        {
            var iCalculateServiceType = typeof(ICalculateService);
            _calculateServiceTypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(a => a.GetTypes())
                .Where(t => iCalculateServiceType.IsAssignableFrom(t))
                .ToList();

            _calculateServiceDictionary = new Dictionary<string, ICalculateService>();
            foreach (var type in _calculateServiceTypes)
            {
                if (type.IsInterface) continue;
                var ctors = type.GetConstructors(BindingFlags.Default);
                if (ctors.Length > 0)
                {
                    var service = ctors[0].Invoke(new object[] { });
                    _calculateServiceDictionary.Add(((ICalculateService) service).StrategyName,
                        service as ICalculateService);
                }
                else
                {
                    var service = (ICalculateService) Activator.CreateInstance(type);
                    _calculateServiceDictionary.Add(((ICalculateService)service).StrategyName,
                        service as ICalculateService);
                }
            }
        }
        
        public ICalculateService GetCalculateService(string name)
        {
            if(!_calculateServiceDictionary.ContainsKey(name)) throw new Exception("Invalid ICalculateService");
            return _calculateServiceDictionary[name];
        }
    }
}