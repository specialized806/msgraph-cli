using ApiSdk.Models.Microsoft.Graph;
using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace ApiSdk.Workbooks.Item.Workbook.Functions.Fvschedule {
    public class FvscheduleRequestBody : IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        public Json Principal { get; set; }
        public Json Schedule { get; set; }
        /// <summary>
        /// Instantiates a new fvscheduleRequestBody and sets the default values.
        /// </summary>
        public FvscheduleRequestBody() {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<T, IParseNode>> GetFieldDeserializers<T>() {
            return new Dictionary<string, Action<T, IParseNode>> {
                {"principal", (o,n) => { (o as FvscheduleRequestBody).Principal = n.GetObjectValue<Json>(); } },
                {"schedule", (o,n) => { (o as FvscheduleRequestBody).Schedule = n.GetObjectValue<Json>(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteObjectValue<Json>("principal", Principal);
            writer.WriteObjectValue<Json>("schedule", Schedule);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}