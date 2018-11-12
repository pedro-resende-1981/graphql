using System.Collections.Generic;
using System.Linq;
using GraphQL.Types;

namespace GraphQLPoc.Api.Extensions
{
    public static class ResolveFieldContextExtensions
    {
        public static List<string> GetSelectedPropertiesList(this ResolveFieldContext<object> context)
        {
            var selectedProperties = context.SubFields.Keys.ToList();

            return selectedProperties;
        }

        public static string GetSelectedPropertiesListAsString(this ResolveFieldContext<object> context)
        {
            var selectedProperties = context.SubFields.Keys;

            return selectedProperties.Any() ? string.Join(',', selectedProperties) : string.Empty;
        }
    }
}
