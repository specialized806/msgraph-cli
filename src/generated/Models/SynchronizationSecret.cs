using System.Runtime.Serialization;
using System;
namespace ApiSdk.Models {
    public enum SynchronizationSecret {
        [EnumMember(Value = "None")]
        None,
        [EnumMember(Value = "UserName")]
        UserName,
        [EnumMember(Value = "Password")]
        Password,
        [EnumMember(Value = "SecretToken")]
        SecretToken,
        [EnumMember(Value = "AppKey")]
        AppKey,
        [EnumMember(Value = "BaseAddress")]
        BaseAddress,
        [EnumMember(Value = "ClientIdentifier")]
        ClientIdentifier,
        [EnumMember(Value = "ClientSecret")]
        ClientSecret,
        [EnumMember(Value = "SingleSignOnType")]
        SingleSignOnType,
        [EnumMember(Value = "Sandbox")]
        Sandbox,
        [EnumMember(Value = "Url")]
        Url,
        [EnumMember(Value = "Domain")]
        Domain,
        [EnumMember(Value = "ConsumerKey")]
        ConsumerKey,
        [EnumMember(Value = "ConsumerSecret")]
        ConsumerSecret,
        [EnumMember(Value = "TokenKey")]
        TokenKey,
        [EnumMember(Value = "TokenExpiration")]
        TokenExpiration,
        [EnumMember(Value = "Oauth2AccessToken")]
        Oauth2AccessToken,
        [EnumMember(Value = "Oauth2AccessTokenCreationTime")]
        Oauth2AccessTokenCreationTime,
        [EnumMember(Value = "Oauth2RefreshToken")]
        Oauth2RefreshToken,
        [EnumMember(Value = "SyncAll")]
        SyncAll,
        [EnumMember(Value = "InstanceName")]
        InstanceName,
        [EnumMember(Value = "Oauth2ClientId")]
        Oauth2ClientId,
        [EnumMember(Value = "Oauth2ClientSecret")]
        Oauth2ClientSecret,
        [EnumMember(Value = "CompanyId")]
        CompanyId,
        [EnumMember(Value = "UpdateKeyOnSoftDelete")]
        UpdateKeyOnSoftDelete,
        [EnumMember(Value = "SynchronizationSchedule")]
        SynchronizationSchedule,
        [EnumMember(Value = "SystemOfRecord")]
        SystemOfRecord,
        [EnumMember(Value = "SandboxName")]
        SandboxName,
        [EnumMember(Value = "EnforceDomain")]
        EnforceDomain,
        [EnumMember(Value = "SyncNotificationSettings")]
        SyncNotificationSettings,
        [EnumMember(Value = "SkipOutOfScopeDeletions")]
        SkipOutOfScopeDeletions,
        [EnumMember(Value = "Oauth2AuthorizationCode")]
        Oauth2AuthorizationCode,
        [EnumMember(Value = "Oauth2RedirectUri")]
        Oauth2RedirectUri,
        [EnumMember(Value = "ApplicationTemplateIdentifier")]
        ApplicationTemplateIdentifier,
        [EnumMember(Value = "Oauth2TokenExchangeUri")]
        Oauth2TokenExchangeUri,
        [EnumMember(Value = "Oauth2AuthorizationUri")]
        Oauth2AuthorizationUri,
        [EnumMember(Value = "AuthenticationType")]
        AuthenticationType,
        [EnumMember(Value = "Server")]
        Server,
        [EnumMember(Value = "PerformInboundEntitlementGrants")]
        PerformInboundEntitlementGrants,
        [EnumMember(Value = "HardDeletesEnabled")]
        HardDeletesEnabled,
        [EnumMember(Value = "SyncAgentCompatibilityKey")]
        SyncAgentCompatibilityKey,
        [EnumMember(Value = "SyncAgentADContainer")]
        SyncAgentADContainer,
        [EnumMember(Value = "ValidateDomain")]
        ValidateDomain,
        [EnumMember(Value = "TestReferences")]
        TestReferences,
        [EnumMember(Value = "ConnectionString")]
        ConnectionString,
    }
}