using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountsTestP.Api.Resolver
{
    public class DerivedClassDeserialization: DefaultContractResolver
    {
        public DerivedClassDeserialization()
        {
            NamingStrategy = new CamelCaseNamingStrategy();
        }

        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            return base.CreateProperties(type, memberSerialization)
                .OrderBy(p => BaseTypesAndSelf(p.DeclaringType).Count()).ToList();

            IEnumerable<Type> BaseTypesAndSelf(Type t)
            {
                while (t != null)
                {
                    yield return t;
                    t = t.BaseType;
                }
            }
        }
    }


}
