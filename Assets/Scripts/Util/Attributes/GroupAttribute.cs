using UnityEngine;

namespace Util.Attributes {
    public class GroupAttribute : PropertyAttribute {
        public GroupAttribute(string tag) {
            Tag = tag;
        }

        public string Tag { get; }
    }
}