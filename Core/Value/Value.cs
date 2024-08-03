using System;
using UnityEngine;
using System.Collections.Generic;
using VRC.Dynamics;

namespace net.narazaka.avatarmenucreator.value
{
    [Serializable]
    public class Value : IEquatable<Value>
    {
        public static explicit operator bool(Value value) => value.AsBool();
        public static explicit operator float(Value value) => value.AsFloat();
        public static explicit operator int(Value value) => value.AsInt();
        public static explicit operator Vector3(Value value) => value.AsVector3();
        public static explicit operator VRCPhysBoneBase.PermissionFilter(Value value) => value.AsPermissionFilterValue();

        public static implicit operator Value(bool value) => new BoolValue(value);
        public static implicit operator Value(float value) => new FloatValue(value);
        public static implicit operator Value(int value) => new IntValue(value);
        public static implicit operator Value(Vector3 value) => new Vector3Value(value);
        public static implicit operator Value(VRCPhysBoneBase.PermissionFilter value) => new PermissionFilterValue(value);

        [SerializeField]
        protected float[] value;

        public Value() { value = new float[0]; }
        public Value(float[] value) { this.value = value; }

        public bool Equals(Value other)
        {
            if (other == null) return false;
            if (value.Length != other.value.Length) return false;

            for (int i = 0; i < value.Length; i++)
            {
                if (this.value[i] != other.value[i]) return false;
            }
            return true;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Value);
        }

        public override int GetHashCode() {
            if (value.Length == 1) return value[0].GetHashCode();
            if (value.Length == 2) return HashCode.Combine(value[0], value[1]);
            if (value.Length == 3) return HashCode.Combine(value[0], value[1], value[2]);
            return 0;
        }

        public static bool operator ==(Value left, Value right)
        {
            if (ReferenceEquals(left, right)) return true;
            if (ReferenceEquals(left, null)) return false;
            return left.Equals(right);
        }

        public static bool operator !=(Value left, Value right)
        {
            return !(left == right);
        }
    }
}
