using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace EfCore.MultiLanguage.Lib
{
    public class Translation : IEnumerable<TranslationContent>
    {
        public string Id { get; set; }
        public ICollection<TranslationContent> TranslationContents { get; set; }
        public Translation()
        {
            TranslationContents = new List<TranslationContent>();
            Id = Guid.NewGuid().ToString();
        }

        public Translation(string content) : this(content, CultureInfo.CurrentCulture.Name)
        {
        }

        public Translation(string content, string cultureName) : this()
        {
            AddTranslation(content, cultureName);
        }
        
        public TranslationContent Current =>
            TranslationContents.Single(p => p.LanguageCode == CultureInfo.CurrentCulture.Name);

        public string CurrentContent => Current.Content;

        public TranslationContent GetByLanguage(string language)
        {
            return TranslationContents.Single(p => p.LanguageCode == language);
        }
        
        public IEnumerator<TranslationContent> GetEnumerator()
        {
            return TranslationContents.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void AddTranslation(string content)
        {
            TranslationContents.Add(new TranslationContent(content));
        }

        public void AddTranslation(string content, string language)
        {
            TranslationContents.Add(new TranslationContent(content, language));
        }

        public void RemoveTranslation(string language)
        {
            var item = TranslationContents.Single(p => p.LanguageCode == language);
            TranslationContents.Remove(item);
        }
        public int Count => TranslationContents.Count;
        public static implicit operator string(Translation ml) => ml.Current.Content;
        public static explicit operator Translation(string value) => new(value);

        public override string ToString()
        {
            return Current;
        }
        
    }
}