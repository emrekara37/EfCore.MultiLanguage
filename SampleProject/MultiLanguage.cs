using System;

namespace SampleProject
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class MultiLanguage : Attribute
    {
    }
}