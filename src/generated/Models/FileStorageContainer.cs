// <auto-generated/>
using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace ApiSdk.Models
{
    #pragma warning disable CS1591
    public class FileStorageContainer : Entity, IParsable
    #pragma warning restore CS1591
    {
        /// <summary>Container type ID of the fileStorageContainer. For details about container types, see Container Types. Each container must have only one container type. Read-only.</summary>
        public Guid? ContainerTypeId { get; set; }
        /// <summary>Date and time of the fileStorageContainer creation. Read-only.</summary>
        public DateTimeOffset? CreatedDateTime { get; set; }
        /// <summary>Custom property collection for the fileStorageContainer. Read-write.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public FileStorageContainerCustomPropertyDictionary? CustomProperties { get; set; }
#nullable restore
#else
        public FileStorageContainerCustomPropertyDictionary CustomProperties { get; set; }
#endif
        /// <summary>Provides a user-visible description of the fileStorageContainer. Read-write.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Description { get; set; }
#nullable restore
#else
        public string Description { get; set; }
#endif
        /// <summary>The display name of the fileStorageContainer. Read-write.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? DisplayName { get; set; }
#nullable restore
#else
        public string DisplayName { get; set; }
#endif
        /// <summary>The drive of the resource fileStorageContainer. Read-only.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public ApiSdk.Models.Drive? Drive { get; set; }
#nullable restore
#else
        public ApiSdk.Models.Drive Drive { get; set; }
#endif
        /// <summary>The set of permissions for users in the fileStorageContainer. Permission for each user is set by the roles property. The possible values are &apos;reader&apos;, &apos;writer&apos;, &apos;manager&apos;, and &apos;owner&apos;. Read-write.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<Permission>? Permissions { get; set; }
#nullable restore
#else
        public List<Permission> Permissions { get; set; }
#endif
        /// <summary>Status of the fileStorageContainer. Containers are created as inactive and require activation. Inactive containers are subjected to automatic deletion in 24 hours. The possible values are: inactive,  active. Read-only.</summary>
        public FileStorageContainerStatus? Status { get; set; }
        /// <summary>Data specific to the current user. Read-only.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public FileStorageContainerViewpoint? Viewpoint { get; set; }
#nullable restore
#else
        public FileStorageContainerViewpoint Viewpoint { get; set; }
#endif
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="FileStorageContainer"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static new FileStorageContainer CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new FileStorageContainer();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public override IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers())
            {
                { "containerTypeId", n => { ContainerTypeId = n.GetGuidValue(); } },
                { "createdDateTime", n => { CreatedDateTime = n.GetDateTimeOffsetValue(); } },
                { "customProperties", n => { CustomProperties = n.GetObjectValue<FileStorageContainerCustomPropertyDictionary>(FileStorageContainerCustomPropertyDictionary.CreateFromDiscriminatorValue); } },
                { "description", n => { Description = n.GetStringValue(); } },
                { "displayName", n => { DisplayName = n.GetStringValue(); } },
                { "drive", n => { Drive = n.GetObjectValue<ApiSdk.Models.Drive>(ApiSdk.Models.Drive.CreateFromDiscriminatorValue); } },
                { "permissions", n => { Permissions = n.GetCollectionOfObjectValues<Permission>(Permission.CreateFromDiscriminatorValue)?.ToList(); } },
                { "status", n => { Status = n.GetEnumValue<FileStorageContainerStatus>(); } },
                { "viewpoint", n => { Viewpoint = n.GetObjectValue<FileStorageContainerViewpoint>(FileStorageContainerViewpoint.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public override void Serialize(ISerializationWriter writer)
        {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteGuidValue("containerTypeId", ContainerTypeId);
            writer.WriteDateTimeOffsetValue("createdDateTime", CreatedDateTime);
            writer.WriteObjectValue<FileStorageContainerCustomPropertyDictionary>("customProperties", CustomProperties);
            writer.WriteStringValue("description", Description);
            writer.WriteStringValue("displayName", DisplayName);
            writer.WriteObjectValue<ApiSdk.Models.Drive>("drive", Drive);
            writer.WriteCollectionOfObjectValues<Permission>("permissions", Permissions);
            writer.WriteEnumValue<FileStorageContainerStatus>("status", Status);
            writer.WriteObjectValue<FileStorageContainerViewpoint>("viewpoint", Viewpoint);
        }
    }
}