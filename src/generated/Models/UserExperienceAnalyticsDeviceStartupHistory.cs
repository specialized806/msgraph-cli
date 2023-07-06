using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace ApiSdk.Models {
    /// <summary>
    /// The user experience analytics device startup history entity contains device boot performance history details.
    /// </summary>
    public class UserExperienceAnalyticsDeviceStartupHistory : Entity, IParsable {
        /// <summary>The device core boot time in milliseconds. Supports: $select, $OrderBy. Read-only.</summary>
        public int? CoreBootTimeInMs { get; set; }
        /// <summary>The device core login time in milliseconds. Supports: $select, $OrderBy. Read-only.</summary>
        public int? CoreLoginTimeInMs { get; set; }
        /// <summary>The Intune device id of the device. Supports: $select, $OrderBy. Read-only.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? DeviceId { get; set; }
#nullable restore
#else
        public string DeviceId { get; set; }
#endif
        /// <summary>The impact of device feature updates on boot time in milliseconds. Supports: $select, $OrderBy. Read-only.</summary>
        public int? FeatureUpdateBootTimeInMs { get; set; }
        /// <summary>The impact of device group policy client on boot time in milliseconds. Supports: $select, $OrderBy. Read-only.</summary>
        public int? GroupPolicyBootTimeInMs { get; set; }
        /// <summary>The impact of device group policy client on login time in milliseconds. Supports: $select, $OrderBy. Read-only.</summary>
        public int? GroupPolicyLoginTimeInMs { get; set; }
        /// <summary>When TRUE, indicates the device boot record is associated with feature updates. When FALSE, indicates the device boot record is not associated with feature updates. Supports: $select, $OrderBy. Read-only.</summary>
        public bool? IsFeatureUpdate { get; set; }
        /// <summary>When TRUE, indicates the device login is the first login after a reboot. When FALSE, indicates the device login is not the first login after a reboot. Supports: $select, $OrderBy. Read-only.</summary>
        public bool? IsFirstLogin { get; set; }
        /// <summary>The user experience analytics device boot record&apos;s operating system version. Supports: $select, $OrderBy. Read-only.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? OperatingSystemVersion { get; set; }
#nullable restore
#else
        public string OperatingSystemVersion { get; set; }
#endif
        /// <summary>The time for desktop to become responsive during login process in milliseconds. Supports: $select, $OrderBy. Read-only.</summary>
        public int? ResponsiveDesktopTimeInMs { get; set; }
        /// <summary>Operating System restart category.</summary>
        public UserExperienceAnalyticsOperatingSystemRestartCategory? RestartCategory { get; set; }
        /// <summary>OS restart fault bucket. The fault bucket is used to find additional information about a system crash. Supports: $select, $OrderBy. Read-only.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? RestartFaultBucket { get; set; }
#nullable restore
#else
        public string RestartFaultBucket { get; set; }
#endif
        /// <summary>OS restart stop code. This shows the bug check code which can be used to look up the blue screen reason. Supports: $select, $OrderBy. Read-only.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? RestartStopCode { get; set; }
#nullable restore
#else
        public string RestartStopCode { get; set; }
#endif
        /// <summary>The device boot start time. The value cannot be modified and is automatically populated when the device performs a reboot. The Timestamp type represents date and time information using ISO 8601 format and is always in UTC time. For example, midnight UTC on Jan 1, 2022 would look like this: &apos;2022-01-01T00:00:00Z&apos;. Returned by default. Read-only.</summary>
        public DateTimeOffset? StartTime { get; set; }
        /// <summary>The device total boot time in milliseconds. Supports: $select, $OrderBy. Read-only.</summary>
        public int? TotalBootTimeInMs { get; set; }
        /// <summary>The device total login time in milliseconds. Supports: $select, $OrderBy. Read-only.</summary>
        public int? TotalLoginTimeInMs { get; set; }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static new UserExperienceAnalyticsDeviceStartupHistory CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new UserExperienceAnalyticsDeviceStartupHistory();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"coreBootTimeInMs", n => { CoreBootTimeInMs = n.GetIntValue(); } },
                {"coreLoginTimeInMs", n => { CoreLoginTimeInMs = n.GetIntValue(); } },
                {"deviceId", n => { DeviceId = n.GetStringValue(); } },
                {"featureUpdateBootTimeInMs", n => { FeatureUpdateBootTimeInMs = n.GetIntValue(); } },
                {"groupPolicyBootTimeInMs", n => { GroupPolicyBootTimeInMs = n.GetIntValue(); } },
                {"groupPolicyLoginTimeInMs", n => { GroupPolicyLoginTimeInMs = n.GetIntValue(); } },
                {"isFeatureUpdate", n => { IsFeatureUpdate = n.GetBoolValue(); } },
                {"isFirstLogin", n => { IsFirstLogin = n.GetBoolValue(); } },
                {"operatingSystemVersion", n => { OperatingSystemVersion = n.GetStringValue(); } },
                {"responsiveDesktopTimeInMs", n => { ResponsiveDesktopTimeInMs = n.GetIntValue(); } },
                {"restartCategory", n => { RestartCategory = n.GetEnumValue<UserExperienceAnalyticsOperatingSystemRestartCategory>(); } },
                {"restartFaultBucket", n => { RestartFaultBucket = n.GetStringValue(); } },
                {"restartStopCode", n => { RestartStopCode = n.GetStringValue(); } },
                {"startTime", n => { StartTime = n.GetDateTimeOffsetValue(); } },
                {"totalBootTimeInMs", n => { TotalBootTimeInMs = n.GetIntValue(); } },
                {"totalLoginTimeInMs", n => { TotalLoginTimeInMs = n.GetIntValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteIntValue("coreBootTimeInMs", CoreBootTimeInMs);
            writer.WriteIntValue("coreLoginTimeInMs", CoreLoginTimeInMs);
            writer.WriteStringValue("deviceId", DeviceId);
            writer.WriteIntValue("featureUpdateBootTimeInMs", FeatureUpdateBootTimeInMs);
            writer.WriteIntValue("groupPolicyBootTimeInMs", GroupPolicyBootTimeInMs);
            writer.WriteIntValue("groupPolicyLoginTimeInMs", GroupPolicyLoginTimeInMs);
            writer.WriteBoolValue("isFeatureUpdate", IsFeatureUpdate);
            writer.WriteBoolValue("isFirstLogin", IsFirstLogin);
            writer.WriteStringValue("operatingSystemVersion", OperatingSystemVersion);
            writer.WriteIntValue("responsiveDesktopTimeInMs", ResponsiveDesktopTimeInMs);
            writer.WriteEnumValue<UserExperienceAnalyticsOperatingSystemRestartCategory>("restartCategory", RestartCategory);
            writer.WriteStringValue("restartFaultBucket", RestartFaultBucket);
            writer.WriteStringValue("restartStopCode", RestartStopCode);
            writer.WriteDateTimeOffsetValue("startTime", StartTime);
            writer.WriteIntValue("totalBootTimeInMs", TotalBootTimeInMs);
            writer.WriteIntValue("totalLoginTimeInMs", TotalLoginTimeInMs);
        }
    }
}
