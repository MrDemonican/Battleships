using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipsRecrutation.Enlargements
{
    public static class EnumEnlargements
    {
        //Setting atrribute of type value - used by Status function in Squer class
        public static AttributeKey GetAttributeOfType<AttributeKey>(this Enum enumVal) where AttributeKey : System.Attribute
        {
            var type = enumVal.GetType();
            var memInfo = type.GetMember(enumVal.ToString());
            var attributes = memInfo[0].GetCustomAttributes(typeof(AttributeKey), false);
            return (attributes.Length > 0) ? (AttributeKey)attributes[0] : null;
        }
    }
}

