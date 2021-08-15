using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace SampleProject
{
    public class Language
    {
        public Language()
        {
        }

        public Language(string code)
        {
            var culture = CultureInfo.GetCultureInfo(code);
            if (culture == null)
            {
                throw new CultureNotFoundException();
            }

            Code = code;
            Name = culture.NativeName;
        }

        public Language(string code, string name)
        {
            Code = code;
            Name = name;
        }

        [Key] public string Code { get; set; }
        public string Name { get; set; }
    }
}