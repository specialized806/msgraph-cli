using ApiSdk.Models;
using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace ApiSdk.Users.Item.FindMeetingTimes {
    /// <summary>Provides operations to call the findMeetingTimes method.</summary>
    public class FindMeetingTimesRequestBody : IAdditionalDataHolder, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>The attendees property</summary>
        public List<AttendeeBase> Attendees { get; set; }
        /// <summary>The isOrganizerOptional property</summary>
        public bool? IsOrganizerOptional { get; set; }
        /// <summary>The locationConstraint property</summary>
        public ApiSdk.Models.LocationConstraint LocationConstraint { get; set; }
        /// <summary>The maxCandidates property</summary>
        public int? MaxCandidates { get; set; }
        /// <summary>The meetingDuration property</summary>
        public TimeSpan? MeetingDuration { get; set; }
        /// <summary>The minimumAttendeePercentage property</summary>
        public double? MinimumAttendeePercentage { get; set; }
        /// <summary>The returnSuggestionReasons property</summary>
        public bool? ReturnSuggestionReasons { get; set; }
        /// <summary>The timeConstraint property</summary>
        public ApiSdk.Models.TimeConstraint TimeConstraint { get; set; }
        /// <summary>
        /// Instantiates a new findMeetingTimesRequestBody and sets the default values.
        /// </summary>
        public FindMeetingTimesRequestBody() {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static FindMeetingTimesRequestBody CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new FindMeetingTimesRequestBody();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"attendees", n => { Attendees = n.GetCollectionOfObjectValues<AttendeeBase>(AttendeeBase.CreateFromDiscriminatorValue).ToList(); } },
                {"isOrganizerOptional", n => { IsOrganizerOptional = n.GetBoolValue(); } },
                {"locationConstraint", n => { LocationConstraint = n.GetObjectValue<ApiSdk.Models.LocationConstraint>(ApiSdk.Models.LocationConstraint.CreateFromDiscriminatorValue); } },
                {"maxCandidates", n => { MaxCandidates = n.GetIntValue(); } },
                {"meetingDuration", n => { MeetingDuration = n.GetTimeSpanValue(); } },
                {"minimumAttendeePercentage", n => { MinimumAttendeePercentage = n.GetDoubleValue(); } },
                {"returnSuggestionReasons", n => { ReturnSuggestionReasons = n.GetBoolValue(); } },
                {"timeConstraint", n => { TimeConstraint = n.GetObjectValue<ApiSdk.Models.TimeConstraint>(ApiSdk.Models.TimeConstraint.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteCollectionOfObjectValues<AttendeeBase>("attendees", Attendees);
            writer.WriteBoolValue("isOrganizerOptional", IsOrganizerOptional);
            writer.WriteObjectValue<ApiSdk.Models.LocationConstraint>("locationConstraint", LocationConstraint);
            writer.WriteIntValue("maxCandidates", MaxCandidates);
            writer.WriteTimeSpanValue("meetingDuration", MeetingDuration);
            writer.WriteDoubleValue("minimumAttendeePercentage", MinimumAttendeePercentage);
            writer.WriteBoolValue("returnSuggestionReasons", ReturnSuggestionReasons);
            writer.WriteObjectValue<ApiSdk.Models.TimeConstraint>("timeConstraint", TimeConstraint);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
