using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Model
{
    public class ExpectedDataModel
    {
        // add properties for your expected data in your test cases

        [JsonProperty("expected_heading_in_about_page")]
        public string ExpectedHeadingInAboutPage { get; set; }
    }
}
