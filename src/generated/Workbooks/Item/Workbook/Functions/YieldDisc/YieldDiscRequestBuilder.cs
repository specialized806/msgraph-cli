using ApiSdk.Models.Microsoft.Graph;
using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace ApiSdk.Workbooks.Item.Workbook.Functions.YieldDisc {
    /// <summary>Builds and executes requests for operations under \workbooks\{driveItem-id}\workbook\functions\microsoft.graph.yieldDisc</summary>
    public class YieldDiscRequestBuilder {
        /// <summary>Path parameters for the request</summary>
        private Dictionary<string, object> PathParameters { get; set; }
        /// <summary>The request adapter to use to execute the requests.</summary>
        private IRequestAdapter RequestAdapter { get; set; }
        /// <summary>Url template to use to build the URL for the current request builder</summary>
        private string UrlTemplate { get; set; }
        /// <summary>
        /// Invoke action yieldDisc
        /// </summary>
        public Command BuildPostCommand() {
            var command = new Command("post");
            command.Description = "Invoke action yieldDisc";
            // Create options for all the parameters
            var driveItemIdOption = new Option<string>("--driveitem-id", description: "key: id of driveItem") {
            };
            driveItemIdOption.IsRequired = true;
            command.AddOption(driveItemIdOption);
            var bodyOption = new Option<string>("--body") {
            };
            bodyOption.IsRequired = true;
            command.AddOption(bodyOption);
            command.SetHandler(async (string driveItemId, string body) => {
                using var stream = new MemoryStream(Encoding.UTF8.GetBytes(body));
                var parseNode = ParseNodeFactoryRegistry.DefaultInstance.GetRootParseNode("application/json", stream);
                var model = parseNode.GetObjectValue<YieldDiscRequestBody>();
                var requestInfo = CreatePostRequestInformation(model, q => {
                });
                var result = await RequestAdapter.SendAsync<YieldDiscResponse>(requestInfo);
                // Print request output. What if the request has no return?
                using var serializer = RequestAdapter.SerializationWriterFactory.GetSerializationWriter("application/json");
                serializer.WriteObjectValue(null, result);
                using var content = serializer.GetSerializedContent();
                using var reader = new StreamReader(content);
                var strContent = await reader.ReadToEndAsync();
                Console.Write(strContent + "\n");
            }, driveItemIdOption, bodyOption);
            return command;
        }
        /// <summary>
        /// Instantiates a new YieldDiscRequestBuilder and sets the default values.
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        /// </summary>
        public YieldDiscRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) {
            _ = pathParameters ?? throw new ArgumentNullException(nameof(pathParameters));
            _ = requestAdapter ?? throw new ArgumentNullException(nameof(requestAdapter));
            UrlTemplate = "{+baseurl}/workbooks/{driveItem_id}/workbook/functions/microsoft.graph.yieldDisc";
            var urlTplParams = new Dictionary<string, object>(pathParameters);
            PathParameters = urlTplParams;
            RequestAdapter = requestAdapter;
        }
        /// <summary>
        /// Invoke action yieldDisc
        /// <param name="body"></param>
        /// <param name="h">Request headers</param>
        /// <param name="o">Request options</param>
        /// </summary>
        public RequestInformation CreatePostRequestInformation(YieldDiscRequestBody body, Action<IDictionary<string, string>> h = default, IEnumerable<IRequestOption> o = default) {
            _ = body ?? throw new ArgumentNullException(nameof(body));
            var requestInfo = new RequestInformation {
                HttpMethod = Method.POST,
                UrlTemplate = UrlTemplate,
                PathParameters = PathParameters,
            };
            requestInfo.SetContentFromParsable(RequestAdapter, "application/json", body);
            h?.Invoke(requestInfo.Headers);
            requestInfo.AddRequestOptions(o?.ToArray());
            return requestInfo;
        }
        /// <summary>
        /// Invoke action yieldDisc
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="h">Request headers</param>
        /// <param name="model"></param>
        /// <param name="o">Request options</param>
        /// <param name="responseHandler">Response handler to use in place of the default response handling provided by the core service</param>
        /// </summary>
        public async Task<YieldDiscResponse> PostAsync(YieldDiscRequestBody model, Action<IDictionary<string, string>> h = default, IEnumerable<IRequestOption> o = default, IResponseHandler responseHandler = default, CancellationToken cancellationToken = default) {
            _ = model ?? throw new ArgumentNullException(nameof(model));
            var requestInfo = CreatePostRequestInformation(model, h, o);
            return await RequestAdapter.SendAsync<YieldDiscResponse>(requestInfo, responseHandler, cancellationToken);
        }
        /// <summary>Union type wrapper for classes workbookFunctionResult</summary>
        public class YieldDiscResponse : IParsable {
            /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
            public IDictionary<string, object> AdditionalData { get; set; }
            /// <summary>Union type representation for type workbookFunctionResult</summary>
            public WorkbookFunctionResult WorkbookFunctionResult { get; set; }
            /// <summary>
            /// Instantiates a new yieldDiscResponse and sets the default values.
            /// </summary>
            public YieldDiscResponse() {
                AdditionalData = new Dictionary<string, object>();
            }
            /// <summary>
            /// The deserialization information for the current model
            /// </summary>
            public IDictionary<string, Action<T, IParseNode>> GetFieldDeserializers<T>() {
                return new Dictionary<string, Action<T, IParseNode>> {
                    {"workbookFunctionResult", (o,n) => { (o as YieldDiscResponse).WorkbookFunctionResult = n.GetObjectValue<WorkbookFunctionResult>(); } },
                };
            }
            /// <summary>
            /// Serializes information the current object
            /// <param name="writer">Serialization writer to use to serialize this model</param>
            /// </summary>
            public void Serialize(ISerializationWriter writer) {
                _ = writer ?? throw new ArgumentNullException(nameof(writer));
                writer.WriteObjectValue<WorkbookFunctionResult>("workbookFunctionResult", WorkbookFunctionResult);
                writer.WriteAdditionalData(AdditionalData);
            }
        }
    }
}