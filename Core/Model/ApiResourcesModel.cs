using Newtonsoft.Json;

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
    }
}