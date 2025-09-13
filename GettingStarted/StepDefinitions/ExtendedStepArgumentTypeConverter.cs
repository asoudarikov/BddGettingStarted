using Reqnroll.Bindings;
using Reqnroll.Bindings.Reflection;
using System.Globalization;
using System.Text.RegularExpressions;

namespace GettingStarted.StepDefinitions
{
    public class ExtendedStepArgumentTypeConverter : IStepArgumentTypeConverter
    {
        private static readonly Regex NullRegex = new(@"^(<null>|null)$", RegexOptions.IgnoreCase | RegexOptions.Compiled);

        private readonly StepArgumentTypeConverter _stepArgumentTypeConverter;

        public ExtendedStepArgumentTypeConverter(StepArgumentTypeConverter stepArgumentTypeConverter)
        {
            _stepArgumentTypeConverter = stepArgumentTypeConverter;
        }

        bool IsNullableType(IBindingType type)
        {
            var boundType = ((RuntimeBindingType)type).Type;
            return !boundType.IsValueType || (boundType.IsGenericType && boundType.GetGenericTypeDefinition() == typeof(Nullable<>));
        }

        public bool CanConvert(object value, IBindingType typeToConvertTo, CultureInfo cultureInfo)
        {
            return IsNullableType(typeToConvertTo) || _stepArgumentTypeConverter.CanConvert(value, typeToConvertTo, cultureInfo);
        }

        public async Task<object> ConvertAsync(object value, IBindingType typeToConvertTo, CultureInfo cultureInfo)
        {
            if (IsNullableType(typeToConvertTo) && (value is string v && NullRegex.IsMatch(v)))
                return null;
            return await _stepArgumentTypeConverter.ConvertAsync(value, typeToConvertTo, cultureInfo);
        }
    }
}
