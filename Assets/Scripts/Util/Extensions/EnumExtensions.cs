using System;

namespace Util.Extensions {
    public static class EnumExtensions {
        public static string GetName(this Enum val) {
            Type tagType = val.GetType();
            return Enum.GetName(tagType, val);
        }
    }
}