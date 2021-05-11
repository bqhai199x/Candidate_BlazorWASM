using Candidae_Blazor.Toastr.CustomConverters;
using Candidae_Blazor.Toastr.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Candidae_Blazor.Toastr
{
    public class ToastrOptions
    {
        [JsonConverter(typeof(CustomEnumDescriptionConverter<ToastrPosition>))]
        [JsonPropertyName("positionClass")]
        public ToastrPosition Position { get; set; }

        [JsonConverter(typeof(CustomEnumDescriptionConverter<ToastrHideMethod>))]
        [JsonPropertyName("hideMethod")]
        public ToastrHideMethod HideMethod { get; set; }

        [JsonConverter(typeof(CustomEnumDescriptionConverter<ToastrShowMethod>))]
        [JsonPropertyName("showMethod")]
        public ToastrShowMethod ShowMethod { get; set; }

        [JsonPropertyName("closeButton")]
        public bool CloseButton { get; set; }

        [JsonPropertyName("hideDuration")]
        public int HideDuration { get; set; }
    }
}
