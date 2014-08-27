using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Bifrost.Execution;
using Ninject;
using Rules;

namespace Web
{
    public class RulesModule : Ninject.Modules.NinjectModule
    {
        readonly Dictionary<string, Type> _ruleAndImplementations = new Dictionary<string, Type>();

        public override void Load()
        {
            RegisterRulesAndRuleImplementations();
        }

        void RegisterRulesAndRuleImplementations()
        {
            var typeDiscoverer = Kernel.Get<ITypeDiscoverer>();
            var ruleImplementations = typeDiscoverer.FindMultiple(typeof(IProvideARuleImplementation<>));

            foreach (var ruleImp in ruleImplementations)
            {
                var getImpMethod = ruleImp.GetMethods(BindingFlags.Public | BindingFlags.Instance).First(m => m.Name == "GetImplementation");

                if (getImpMethod.ReturnType.BaseType != typeof(MulticastDelegate))
                {
                    throw new ApplicationException(string.Format("The rule implementation provider '{0}' does not return a delegate", ruleImp.FullName));
                }

                var rule = getImpMethod.ReturnType.FullName;

                if (_ruleAndImplementations.ContainsKey(rule))
                {
                    throw new ApplicationException(string.Format("An implementation for rule '{0}' is already registered", rule));
                }

                _ruleAndImplementations.Add(rule, ruleImp);

                Kernel.Bind(getImpMethod.ReturnType).ToMethod((context) =>
                {
                    var targetType = context.Request.Target.Type;
                    var ruleType = _ruleAndImplementations[targetType.FullName];
                    var ruleImplementation = context.Kernel.Get(ruleType);
                    var ruleMethod = ruleType.GetMethods(BindingFlags.Public | BindingFlags.Instance).First(m => m.ReturnType == targetType);
                    return ruleMethod.Invoke(ruleImplementation, null);
                }).InTransientScope();
            }
        }
    }
}