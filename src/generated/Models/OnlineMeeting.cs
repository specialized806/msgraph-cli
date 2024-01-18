// <auto-generated/>
using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace ApiSdk.Models {
    public class OnlineMeeting : OnlineMeetingBase, IParsable {
        /// <summary>The attendeeReport property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public byte[]? AttendeeReport { get; set; }
#nullable restore
#else
        public byte[] AttendeeReport { get; set; }
#endif
        /// <summary>The broadcastSettings property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public BroadcastMeetingSettings? BroadcastSettings { get; set; }
#nullable restore
#else
        public BroadcastMeetingSettings BroadcastSettings { get; set; }
#endif
        /// <summary>The meeting creation time in UTC. Read-only.</summary>
        public DateTimeOffset? CreationDateTime { get; set; }
        /// <summary>The meeting end time in UTC.</summary>
        public DateTimeOffset? EndDateTime { get; set; }
        /// <summary>The externalId property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? ExternalId { get; set; }
#nullable restore
#else
        public string ExternalId { get; set; }
#endif
        /// <summary>The isBroadcast property</summary>
        public bool? IsBroadcast { get; set; }
        /// <summary>The participants associated with the online meeting, including the organizer and the attendees.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public MeetingParticipants? Participants { get; set; }
#nullable restore
#else
        public MeetingParticipants Participants { get; set; }
#endif
        /// <summary>The recordings of an online meeting. Read-only.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<CallRecording>? Recordings { get; set; }
#nullable restore
#else
        public List<CallRecording> Recordings { get; set; }
#endif
        /// <summary>The meeting start time in UTC.</summary>
        public DateTimeOffset? StartDateTime { get; set; }
        /// <summary>The transcripts of an online meeting. Read-only.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<CallTranscript>? Transcripts { get; set; }
#nullable restore
#else
        public List<CallTranscript> Transcripts { get; set; }
#endif
        /// <summary>
        /// Instantiates a new onlineMeeting and sets the default values.
        /// </summary>
        public OnlineMeeting() : base() {
            OdataType = "#microsoft.graph.onlineMeeting";
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static new OnlineMeeting CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new OnlineMeeting();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public override IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"attendeeReport", n => { AttendeeReport = n.GetByteArrayValue(); } },
                {"broadcastSettings", n => { BroadcastSettings = n.GetObjectValue<BroadcastMeetingSettings>(BroadcastMeetingSettings.CreateFromDiscriminatorValue); } },
                {"creationDateTime", n => { CreationDateTime = n.GetDateTimeOffsetValue(); } },
                {"endDateTime", n => { EndDateTime = n.GetDateTimeOffsetValue(); } },
                {"externalId", n => { ExternalId = n.GetStringValue(); } },
                {"isBroadcast", n => { IsBroadcast = n.GetBoolValue(); } },
                {"participants", n => { Participants = n.GetObjectValue<MeetingParticipants>(MeetingParticipants.CreateFromDiscriminatorValue); } },
                {"recordings", n => { Recordings = n.GetCollectionOfObjectValues<CallRecording>(CallRecording.CreateFromDiscriminatorValue)?.ToList(); } },
                {"startDateTime", n => { StartDateTime = n.GetDateTimeOffsetValue(); } },
                {"transcripts", n => { Transcripts = n.GetCollectionOfObjectValues<CallTranscript>(CallTranscript.CreateFromDiscriminatorValue)?.ToList(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public override void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteByteArrayValue("attendeeReport", AttendeeReport);
            writer.WriteObjectValue<BroadcastMeetingSettings>("broadcastSettings", BroadcastSettings);
            writer.WriteDateTimeOffsetValue("creationDateTime", CreationDateTime);
            writer.WriteDateTimeOffsetValue("endDateTime", EndDateTime);
            writer.WriteStringValue("externalId", ExternalId);
            writer.WriteBoolValue("isBroadcast", IsBroadcast);
            writer.WriteObjectValue<MeetingParticipants>("participants", Participants);
            writer.WriteCollectionOfObjectValues<CallRecording>("recordings", Recordings);
            writer.WriteDateTimeOffsetValue("startDateTime", StartDateTime);
            writer.WriteCollectionOfObjectValues<CallTranscript>("transcripts", Transcripts);
        }
    }
}
