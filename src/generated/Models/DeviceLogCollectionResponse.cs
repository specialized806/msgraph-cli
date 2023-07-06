using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace ApiSdk.Models {
    /// <summary>
    /// Windows Log Collection request entity.
    /// </summary>
    public class DeviceLogCollectionResponse : Entity, IParsable {
        /// <summary>The User Principal Name (UPN) of the user that enrolled the device.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? EnrolledByUser { get; set; }
#nullable restore
#else
        public string EnrolledByUser { get; set; }
#endif
        /// <summary>The DateTime of the expiration of the logs.</summary>
        public DateTimeOffset? ExpirationDateTimeUTC { get; set; }
        /// <summary>The UPN for who initiated the request.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? InitiatedByUserPrincipalName { get; set; }
#nullable restore
#else
        public string InitiatedByUserPrincipalName { get; set; }
#endif
        /// <summary>Indicates Intune device unique identifier.</summary>
        public Guid? ManagedDeviceId { get; set; }
        /// <summary>The DateTime the request was received.</summary>
        public DateTimeOffset? ReceivedDateTimeUTC { get; set; }
        /// <summary>The DateTime of the request.</summary>
        public DateTimeOffset? RequestedDateTimeUTC { get; set; }
        /// <summary>The size of the logs in KB. Valid values -1.79769313486232E+308 to 1.79769313486232E+308</summary>
        public double? SizeInKB { get; set; }
        /// <summary>AppLogUploadStatus</summary>
        public AppLogUploadState? Status { get; set; }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static new DeviceLogCollectionResponse CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new DeviceLogCollectionResponse();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"enrolledByUser", n => { EnrolledByUser = n.GetStringValue(); } },
                {"expirationDateTimeUTC", n => { ExpirationDateTimeUTC = n.GetDateTimeOffsetValue(); } },
                {"initiatedByUserPrincipalName", n => { InitiatedByUserPrincipalName = n.GetStringValue(); } },
                {"managedDeviceId", n => { ManagedDeviceId = n.GetGuidValue(); } },
                {"receivedDateTimeUTC", n => { ReceivedDateTimeUTC = n.GetDateTimeOffsetValue(); } },
                {"requestedDateTimeUTC", n => { RequestedDateTimeUTC = n.GetDateTimeOffsetValue(); } },
                {"sizeInKB", n => { SizeInKB = n.GetDoubleValue(); } },
                {"status", n => { Status = n.GetEnumValue<AppLogUploadState>(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteStringValue("enrolledByUser", EnrolledByUser);
            writer.WriteDateTimeOffsetValue("expirationDateTimeUTC", ExpirationDateTimeUTC);
            writer.WriteStringValue("initiatedByUserPrincipalName", InitiatedByUserPrincipalName);
            writer.WriteGuidValue("managedDeviceId", ManagedDeviceId);
            writer.WriteDateTimeOffsetValue("receivedDateTimeUTC", ReceivedDateTimeUTC);
            writer.WriteDateTimeOffsetValue("requestedDateTimeUTC", RequestedDateTimeUTC);
            writer.WriteDoubleValue("sizeInKB", SizeInKB);
            writer.WriteEnumValue<AppLogUploadState>("status", Status);
        }
    }
}
