using Newtonsoft.Json;
using System.Collections.Generic;

namespace Core.Model
{
    public class ApiResourcesModel
    {
        [JsonProperty("pdf_request_endpoint")]
        public string PdfRequestEndpoint { get; set; }

        [JsonProperty("pdf_request_content_type")]
        public string PdfRequestContentType { get; set; }

        [JsonProperty("metadata_request_endpoint")]
        public string MetadataRequestEndpoint { get; set; }

        [JsonProperty("metadata_request_content_type")]
        public string MetadataRequestContentType { get; set; }

        [JsonProperty("page_items_request_endpoint")]
        public string PageItemsRequestEndpoint { get; set; }

        [JsonProperty("page_items")]
        public Dictionary<string, string[]> PageItems { get; set; }
    }
}