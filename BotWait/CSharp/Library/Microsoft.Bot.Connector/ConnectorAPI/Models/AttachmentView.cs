// Code generated by Microsoft (R) AutoRest Code Generator 0.13.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Microsoft.Bot.Connector
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;

    /// <summary>
    /// Attachment View name and size
    /// </summary>
    public partial class AttachmentView
    {
        /// <summary>
        /// Initializes a new instance of the AttachmentView class.
        /// </summary>
        public AttachmentView() { }

        /// <summary>
        /// Initializes a new instance of the AttachmentView class.
        /// </summary>
        public AttachmentView(string viewId = default(string), int? size = default(int?))
        {
            ViewId = viewId;
            Size = size;
        }

        /// <summary>
        /// content type of the attachmnet
        /// </summary>
        [JsonProperty(PropertyName = "viewId")]
        public string ViewId { get; set; }

        /// <summary>
        /// Name of the attachment
        /// </summary>
        [JsonProperty(PropertyName = "size")]
        public int? Size { get; set; }

    }
}
