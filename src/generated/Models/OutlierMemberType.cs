using System.Runtime.Serialization;
using System;
namespace ApiSdk.Models {
    public enum OutlierMemberType {
        [EnumMember(Value = "user")]
        User,
        [EnumMember(Value = "unknownFutureValue")]
        UnknownFutureValue,
    }
}
