// <auto-generated/>
using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace ApiSdk.Models.IdentityGovernance {
    public class CustomTaskExtensionCalloutData : ApiSdk.Models.CustomExtensionData, IParsable {
        /// <summary>The subject property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public ApiSdk.Models.User? Subject { get; set; }
#nullable restore
#else
        public ApiSdk.Models.User Subject { get; set; }
#endif
        /// <summary>The task property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public TaskObject? Task { get; set; }
#nullable restore
#else
        public TaskObject Task { get; set; }
#endif
        /// <summary>The taskProcessingresult property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public ApiSdk.Models.IdentityGovernance.TaskProcessingResult? TaskProcessingresult { get; set; }
#nullable restore
#else
        public ApiSdk.Models.IdentityGovernance.TaskProcessingResult TaskProcessingresult { get; set; }
#endif
        /// <summary>The workflow property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public ApiSdk.Models.IdentityGovernance.Workflow? Workflow { get; set; }
#nullable restore
#else
        public ApiSdk.Models.IdentityGovernance.Workflow Workflow { get; set; }
#endif
        /// <summary>
        /// Instantiates a new customTaskExtensionCalloutData and sets the default values.
        /// </summary>
        public CustomTaskExtensionCalloutData() : base() {
            OdataType = "#microsoft.graph.identityGovernance.customTaskExtensionCalloutData";
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static new CustomTaskExtensionCalloutData CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new CustomTaskExtensionCalloutData();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public override IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"subject", n => { Subject = n.GetObjectValue<ApiSdk.Models.User>(ApiSdk.Models.User.CreateFromDiscriminatorValue); } },
                {"task", n => { Task = n.GetObjectValue<TaskObject>(TaskObject.CreateFromDiscriminatorValue); } },
                {"taskProcessingresult", n => { TaskProcessingresult = n.GetObjectValue<ApiSdk.Models.IdentityGovernance.TaskProcessingResult>(ApiSdk.Models.IdentityGovernance.TaskProcessingResult.CreateFromDiscriminatorValue); } },
                {"workflow", n => { Workflow = n.GetObjectValue<ApiSdk.Models.IdentityGovernance.Workflow>(ApiSdk.Models.IdentityGovernance.Workflow.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public override void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteObjectValue<ApiSdk.Models.User>("subject", Subject);
            writer.WriteObjectValue<TaskObject>("task", Task);
            writer.WriteObjectValue<ApiSdk.Models.IdentityGovernance.TaskProcessingResult>("taskProcessingresult", TaskProcessingresult);
            writer.WriteObjectValue<ApiSdk.Models.IdentityGovernance.Workflow>("workflow", Workflow);
        }
    }
}
