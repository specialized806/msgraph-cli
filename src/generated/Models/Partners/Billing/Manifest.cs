// <auto-generated/>
using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace ApiSdk.Models.Partners.Billing {
    public class Manifest : ApiSdk.Models.Entity, IParsable {
        /// <summary>The total file count for this partner tenant ID.</summary>
        public int? BlobCount { get; set; }
        /// <summary>A collection of blob objects that contain details of all the files for the partner tenant ID.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<Blob>? Blobs { get; set; }
#nullable restore
#else
        public List<Blob> Blobs { get; set; }
#endif
        /// <summary>The date and time when a manifest resource was created. The timestamp type represents date and time information using ISO 8601 format and is always in UTC. For example, midnight UTC on Jan 1, 2014 is 2014-01-01T00:00:00Z.</summary>
        public DateTimeOffset? CreatedDateTime { get; set; }
        /// <summary>The billing data file format. The possible value is: compressedJSONLines. Each blob is a compressed file and data in the file is in JSON lines format. Decompress the file to access the data.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? DataFormat { get; set; }
#nullable restore
#else
        public string DataFormat { get; set; }
#endif
        /// <summary>Version of data represented by the manifest. Any change in eTag indicates a new data version.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? ETag { get; set; }
#nullable restore
#else
        public string ETag { get; set; }
#endif
        /// <summary>Indicates the division of data. If a given partition has more than the supported number, the data is split into multiple files, each file representing a specific partitionValue. By default, the data in the file is partitioned by the number of line items.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? PartitionType { get; set; }
#nullable restore
#else
        public string PartitionType { get; set; }
#endif
        /// <summary>The Microsoft Entra tenant ID of the partner.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? PartnerTenantId { get; set; }
#nullable restore
#else
        public string PartnerTenantId { get; set; }
#endif
        /// <summary>The root directory that contains all the files.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? RootDirectory { get; set; }
#nullable restore
#else
        public string RootDirectory { get; set; }
#endif
        /// <summary>The SAS token for accessing the directory or an individual file in the directory.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? SasToken { get; set; }
#nullable restore
#else
        public string SasToken { get; set; }
#endif
        /// <summary>The version of the manifest schema.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? SchemaVersion { get; set; }
#nullable restore
#else
        public string SchemaVersion { get; set; }
#endif
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static new Manifest CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new Manifest();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public override IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"blobCount", n => { BlobCount = n.GetIntValue(); } },
                {"blobs", n => { Blobs = n.GetCollectionOfObjectValues<Blob>(Blob.CreateFromDiscriminatorValue)?.ToList(); } },
                {"createdDateTime", n => { CreatedDateTime = n.GetDateTimeOffsetValue(); } },
                {"dataFormat", n => { DataFormat = n.GetStringValue(); } },
                {"eTag", n => { ETag = n.GetStringValue(); } },
                {"partitionType", n => { PartitionType = n.GetStringValue(); } },
                {"partnerTenantId", n => { PartnerTenantId = n.GetStringValue(); } },
                {"rootDirectory", n => { RootDirectory = n.GetStringValue(); } },
                {"sasToken", n => { SasToken = n.GetStringValue(); } },
                {"schemaVersion", n => { SchemaVersion = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public override void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteIntValue("blobCount", BlobCount);
            writer.WriteCollectionOfObjectValues<Blob>("blobs", Blobs);
            writer.WriteDateTimeOffsetValue("createdDateTime", CreatedDateTime);
            writer.WriteStringValue("dataFormat", DataFormat);
            writer.WriteStringValue("eTag", ETag);
            writer.WriteStringValue("partitionType", PartitionType);
            writer.WriteStringValue("partnerTenantId", PartnerTenantId);
            writer.WriteStringValue("rootDirectory", RootDirectory);
            writer.WriteStringValue("sasToken", SasToken);
            writer.WriteStringValue("schemaVersion", SchemaVersion);
        }
    }
}
