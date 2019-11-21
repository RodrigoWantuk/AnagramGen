using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnagramaGen
{
    public class AnagramableString
    {
        private String value;
        public string Value { get => value; set => this.value = value; }

        public AnagramableString(String _value)
        {
            this.Value = _value;
        }

        public bool IsAnagram(String source)
        {
            return StringUtils.IsAnagram(this.value, source);
        }

        public override string ToString() 
        { 
            return this.value; 
        }

        public override bool Equals(object obj)
        {
            return this.value.Equals(obj);
        }

        public override int GetHashCode()
        {
            return this.value.GetHashCode();
        }

    }
}
