using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace ApiSdk.Models {
    public class RemoteItem : IAdditionalDataHolder, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>Identity of the user, device, and application which created the item. Read-only.</summary>
        public IdentitySet CreatedBy { get; set; }
        /// <summary>Date and time of item creation. Read-only.</summary>
        public DateTimeOffset? CreatedDateTime { get; set; }
        /// <summary>Indicates that the remote item is a file. Read-only.</summary>
        public ApiSdk.Models.File File { get; set; }
        /// <summary>Information about the remote item from the local file system. Read-only.</summary>
        public ApiSdk.Models.FileSystemInfo FileSystemInfo { get; set; }
        /// <summary>Indicates that the remote item is a folder. Read-only.</summary>
        public ApiSdk.Models.Folder Folder { get; set; }
        /// <summary>Unique identifier for the remote item in its drive. Read-only.</summary>
        public string Id { get; set; }
        /// <summary>Image metadata, if the item is an image. Read-only.</summary>
        public ApiSdk.Models.Image Image { get; set; }
        /// <summary>Identity of the user, device, and application which last modified the item. Read-only.</summary>
        public IdentitySet LastModifiedBy { get; set; }
        /// <summary>Date and time the item was last modified. Read-only.</summary>
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        /// <summary>Optional. Filename of the remote item. Read-only.</summary>
        public string Name { get; set; }
        /// <summary>If present, indicates that this item is a package instead of a folder or file. Packages are treated like files in some contexts and folders in others. Read-only.</summary>
        public ApiSdk.Models.Package Package { get; set; }
        /// <summary>Properties of the parent of the remote item. Read-only.</summary>
        public ItemReference ParentReference { get; set; }
        /// <summary>Indicates that the item has been shared with others and provides information about the shared state of the item. Read-only.</summary>
        public ApiSdk.Models.Shared Shared { get; set; }
        /// <summary>Provides interop between items in OneDrive for Business and SharePoint with the full set of item identifiers. Read-only.</summary>
        public ApiSdk.Models.SharepointIds SharepointIds { get; set; }
        /// <summary>Size of the remote item. Read-only.</summary>
        public long? Size { get; set; }
        /// <summary>If the current item is also available as a special folder, this facet is returned. Read-only.</summary>
        public ApiSdk.Models.SpecialFolder SpecialFolder { get; set; }
        /// <summary>Video metadata, if the item is a video. Read-only.</summary>
        public ApiSdk.Models.Video Video { get; set; }
        /// <summary>DAV compatible URL for the item.</summary>
        public string WebDavUrl { get; set; }
        /// <summary>URL that displays the resource in the browser. Read-only.</summary>
        public string WebUrl { get; set; }
        /// <summary>
        /// Instantiates a new remoteItem and sets the default values.
        /// </summary>
        public RemoteItem() {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static RemoteItem CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new RemoteItem();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"createdBy", n => { CreatedBy = n.GetObjectValue<IdentitySet>(IdentitySet.CreateFromDiscriminatorValue); } },
                {"createdDateTime", n => { CreatedDateTime = n.GetDateTimeOffsetValue(); } },
                {"file", n => { File = n.GetObjectValue<ApiSdk.Models.File>(ApiSdk.Models.File.CreateFromDiscriminatorValue); } },
                {"fileSystemInfo", n => { FileSystemInfo = n.GetObjectValue<ApiSdk.Models.FileSystemInfo>(ApiSdk.Models.FileSystemInfo.CreateFromDiscriminatorValue); } },
                {"folder", n => { Folder = n.GetObjectValue<ApiSdk.Models.Folder>(ApiSdk.Models.Folder.CreateFromDiscriminatorValue); } },
                {"id", n => { Id = n.GetStringValue(); } },
                {"image", n => { Image = n.GetObjectValue<ApiSdk.Models.Image>(ApiSdk.Models.Image.CreateFromDiscriminatorValue); } },
                {"lastModifiedBy", n => { LastModifiedBy = n.GetObjectValue<IdentitySet>(IdentitySet.CreateFromDiscriminatorValue); } },
                {"lastModifiedDateTime", n => { LastModifiedDateTime = n.GetDateTimeOffsetValue(); } },
                {"name", n => { Name = n.GetStringValue(); } },
                {"package", n => { Package = n.GetObjectValue<ApiSdk.Models.Package>(ApiSdk.Models.Package.CreateFromDiscriminatorValue); } },
                {"parentReference", n => { ParentReference = n.GetObjectValue<ItemReference>(ItemReference.CreateFromDiscriminatorValue); } },
                {"shared", n => { Shared = n.GetObjectValue<ApiSdk.Models.Shared>(ApiSdk.Models.Shared.CreateFromDiscriminatorValue); } },
                {"sharepointIds", n => { SharepointIds = n.GetObjectValue<ApiSdk.Models.SharepointIds>(ApiSdk.Models.SharepointIds.CreateFromDiscriminatorValue); } },
                {"size", n => { Size = n.GetLongValue(); } },
                {"specialFolder", n => { SpecialFolder = n.GetObjectValue<ApiSdk.Models.SpecialFolder>(ApiSdk.Models.SpecialFolder.CreateFromDiscriminatorValue); } },
                {"video", n => { Video = n.GetObjectValue<ApiSdk.Models.Video>(ApiSdk.Models.Video.CreateFromDiscriminatorValue); } },
                {"webDavUrl", n => { WebDavUrl = n.GetStringValue(); } },
                {"webUrl", n => { WebUrl = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteObjectValue<IdentitySet>("createdBy", CreatedBy);
            writer.WriteDateTimeOffsetValue("createdDateTime", CreatedDateTime);
            writer.WriteObjectValue<ApiSdk.Models.File>("file", File);
            writer.WriteObjectValue<ApiSdk.Models.FileSystemInfo>("fileSystemInfo", FileSystemInfo);
            writer.WriteObjectValue<ApiSdk.Models.Folder>("folder", Folder);
            writer.WriteStringValue("id", Id);
            writer.WriteObjectValue<ApiSdk.Models.Image>("image", Image);
            writer.WriteObjectValue<IdentitySet>("lastModifiedBy", LastModifiedBy);
            writer.WriteDateTimeOffsetValue("lastModifiedDateTime", LastModifiedDateTime);
            writer.WriteStringValue("name", Name);
            writer.WriteObjectValue<ApiSdk.Models.Package>("package", Package);
            writer.WriteObjectValue<ItemReference>("parentReference", ParentReference);
            writer.WriteObjectValue<ApiSdk.Models.Shared>("shared", Shared);
            writer.WriteObjectValue<ApiSdk.Models.SharepointIds>("sharepointIds", SharepointIds);
            writer.WriteLongValue("size", Size);
            writer.WriteObjectValue<ApiSdk.Models.SpecialFolder>("specialFolder", SpecialFolder);
            writer.WriteObjectValue<ApiSdk.Models.Video>("video", Video);
            writer.WriteStringValue("webDavUrl", WebDavUrl);
            writer.WriteStringValue("webUrl", WebUrl);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
