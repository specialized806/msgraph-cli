// <auto-generated/>
using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
namespace ApiSdk.Models
{
    #pragma warning disable CS1591
    public class OnAuthenticationMethodLoadStartExternalUsersSelfServiceSignUp : OnAuthenticationMethodLoadStartHandler, IParsable
    #pragma warning restore CS1591
    {
        /// <summary>The identityProviders property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<IdentityProviderBase>? IdentityProviders { get; set; }
#nullable restore
#else
        public List<IdentityProviderBase> IdentityProviders { get; set; }
#endif
        /// <summary>
        /// Instantiates a new <see cref="OnAuthenticationMethodLoadStartExternalUsersSelfServiceSignUp"/> and sets the default values.
        /// </summary>
        public OnAuthenticationMethodLoadStartExternalUsersSelfServiceSignUp() : base()
        {
            OdataType = "#microsoft.graph.onAuthenticationMethodLoadStartExternalUsersSelfServiceSignUp";
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="OnAuthenticationMethodLoadStartExternalUsersSelfServiceSignUp"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static new OnAuthenticationMethodLoadStartExternalUsersSelfServiceSignUp CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new OnAuthenticationMethodLoadStartExternalUsersSelfServiceSignUp();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public override IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers())
            {
                { "identityProviders", n => { IdentityProviders = n.GetCollectionOfObjectValues<IdentityProviderBase>(IdentityProviderBase.CreateFromDiscriminatorValue)?.ToList(); } },
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
            writer.WriteCollectionOfObjectValues<IdentityProviderBase>("identityProviders", IdentityProviders);
        }
    }
}
