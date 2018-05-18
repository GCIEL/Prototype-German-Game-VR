// ----------------------------------------------------------------------------
// GCIEL - Scriptable Object Variables
// 
// Author: Zachary Segall
// Date:   02/13/2018
//
// Modeled after Game Architecture with Scriptable Objects 
// Author: Ryan Hipple
// ----------------------------------------------------------------------------

using System;

namespace GCIEL.Toolkit
{
    [Serializable]
    public class StringReference
    {
        public bool UseConstant = true;
        public string ConstantValue;
        public StringVariable Variable;

        public StringReference()
        { }

        public StringReference(string value)
        {
            UseConstant = true;
            ConstantValue = value;
        }

        public string Value
        {
            get { return UseConstant ? ConstantValue : Variable.Value; }
        }

        public static implicit operator string(StringReference reference)
        {
            return reference.Value;
        }
    }
}