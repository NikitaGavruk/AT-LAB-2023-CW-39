using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace AndroidUI.Driver
{
    public class DriverCapabilityModel
    {
        [JsonProperty("appium:automationName")]
        public string AutomationName { get; set; }

        [JsonProperty("deviceName")]
        public string DeviceName { get; set; }

        [JsonProperty("platformName")]
        public string PlatformName { get; set; }

        [JsonProperty("appium:appPackage")]
        public string Package { get; set; }

        [JsonProperty("appium:appActivity")]
        public string Activity { get; set; }
    }
}
