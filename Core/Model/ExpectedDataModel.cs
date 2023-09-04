using Newtonsoft.Json;

namespace Core.Model
{
    public class ExpectedDataModel
    {
        [JsonProperty("expected_heading_in_about_page")]
        public string HeadingInAboutPage { get; set; }

        [JsonProperty("expected_title_of_russian_language")]
        public string TitleOfRussianLanguage { get; set; }

        [JsonProperty("expected_title_of_english_language")]
        public string TitleOfEnglishLanguage { get; set; }

        [JsonProperty("expected_title_of_uzbek_language")]
        public string TitleOfUzbekLanguage { get; set; }

        [JsonProperty("search_request")]
        public string ArticleToBeSearched { get; set; }

        [JsonProperty("expected_article_title")]
        public string ArticleTitle { get; set; }

        [JsonProperty("search_request_language")]
        public string EnglishArticleTitle { get; set; }

        [JsonProperty("expected_title_in_russian_lang")]
        public string ArticleInRussianLang { get; set; }

        [JsonProperty("expected_title_in_uzb_lang")]
        public string ArticleInUzbLang { get; set; }

        [JsonProperty("expected_title_of_about_page_in_mobile")]
        public string ExpectedTitleOfAboutPageInMobile { get; set; }
    }
}
