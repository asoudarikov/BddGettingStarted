using Reqnroll.Bindings;
using Reqnroll.Plugins;
using Reqnroll.UnitTestProvider;

[assembly: RuntimePlugin(typeof(GettingStarted.StepDefinitions.StepArgumentTypeConverterConfigurationPlugin))]

namespace GettingStarted.StepDefinitions
{
    public class StepArgumentTypeConverterConfigurationPlugin: IRuntimePlugin
    {
        public void Initialize(RuntimePluginEvents runtimePluginEvents, RuntimePluginParameters runtimePluginParameters, UnitTestProviderConfiguration unitTestProviderConfiguration)
        {
            runtimePluginEvents.CustomizeTestThreadDependencies += (sender, e) =>
            {
                e.ObjectContainer.RegisterTypeAs<ExtendedStepArgumentTypeConverter, IStepArgumentTypeConverter>();
            };
        }
    }
}
