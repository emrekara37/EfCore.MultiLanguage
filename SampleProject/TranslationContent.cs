using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace SampleProject
{
    public class TranslationContent
    {
        public string Id { get; set; }
        public string Content { get; set; }
        [ForeignKey(nameof(TranslationId))] 
        public Translation Translation { get; set; }
        public string TranslationId { get; set; }
        [ForeignKey(nameof(LanguageCode))] public Language Language { get; set; }
        public string LanguageCode { get; set; }

        protected TranslationContent()
        {
            Id = Guid.NewGuid().ToString();
        }

        public TranslationContent(string content) : this(content, CultureInfo.CurrentCulture.Name)
        {
        }


        public TranslationContent(string content, string languageCode) : this()
        {
            SetContent(content, languageCode);
        }

        public void SetContent(string content, string languageCode)
        {
            Content = content;
            Language = new Language(languageCode);
            LanguageCode = languageCode;
        }

        public static implicit operator string(TranslationContent ml) => ml.Content;
        public static explicit operator TranslationContent(string value) => new(value);

        public override string ToString()
        {
            return Content;
        }
    }
}