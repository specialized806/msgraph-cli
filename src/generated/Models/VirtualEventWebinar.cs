// <auto-generated/>
using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace ApiSdk.Models {
    public class VirtualEventWebinar : VirtualEvent, IParsable {
        /// <summary>To whom the webinar is visible.</summary>
        public MeetingAudience? Audience { get; set; }
        /// <summary>Identity information of coorganizers of the webinar.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<CommunicationsUserIdentity>? CoOrganizers { get; set; }
#nullable restore
#else
        public List<CommunicationsUserIdentity> CoOrganizers { get; set; }
#endif
        /// <summary>Registration records of the webinar.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<VirtualEventRegistration>? Registrations { get; set; }
#nullable restore
#else
        public List<VirtualEventRegistration> Registrations { get; set; }
#endif
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static new VirtualEventWebinar CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new VirtualEventWebinar();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public override IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"audience", n => { Audience = n.GetEnumValue<MeetingAudience>(); } },
                {"coOrganizers", n => { CoOrganizers = n.GetCollectionOfObjectValues<CommunicationsUserIdentity>(CommunicationsUserIdentity.CreateFromDiscriminatorValue)?.ToList(); } },
                {"registrations", n => { Registrations = n.GetCollectionOfObjectValues<VirtualEventRegistration>(VirtualEventRegistration.CreateFromDiscriminatorValue)?.ToList(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public override void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteEnumValue<MeetingAudience>("audience", Audience);
            writer.WriteCollectionOfObjectValues<CommunicationsUserIdentity>("coOrganizers", CoOrganizers);
            writer.WriteCollectionOfObjectValues<VirtualEventRegistration>("registrations", Registrations);
        }
    }
}
