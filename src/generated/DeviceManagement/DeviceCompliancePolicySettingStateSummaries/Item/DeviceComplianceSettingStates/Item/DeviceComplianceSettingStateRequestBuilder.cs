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
namespace ApiSdk.DeviceManagement.DeviceCompliancePolicySettingStateSummaries.Item.DeviceComplianceSettingStates.Item {
    /// <summary>Builds and executes requests for operations under \deviceManagement\deviceCompliancePolicySettingStateSummaries\{deviceCompliancePolicySettingStateSummary-id}\deviceComplianceSettingStates\{deviceComplianceSettingState-id}</summary>
    public class DeviceComplianceSettingStateRequestBuilder {
        /// <summary>Path parameters for the request</summary>
        private Dictionary<string, object> PathParameters { get; set; }
        /// <summary>The request adapter to use to execute the requests.</summary>
        private IRequestAdapter RequestAdapter { get; set; }
        /// <summary>Url template to use to build the URL for the current request builder</summary>
        private string UrlTemplate { get; set; }
        /// <summary>
        /// Not yet documented
        /// </summary>
        public Command BuildDeleteCommand() {
            var command = new Command("delete");
            command.Description = "Not yet documented";
            // Create options for all the parameters
            var deviceCompliancePolicySettingStateSummaryIdOption = new Option<string>("--devicecompliancepolicysettingstatesummary-id", description: "key: id of deviceCompliancePolicySettingStateSummary") {
            };
            deviceCompliancePolicySettingStateSummaryIdOption.IsRequired = true;
            command.AddOption(deviceCompliancePolicySettingStateSummaryIdOption);
            var deviceComplianceSettingStateIdOption = new Option<string>("--devicecompliancesettingstate-id", description: "key: id of deviceComplianceSettingState") {
            };
            deviceComplianceSettingStateIdOption.IsRequired = true;
            command.AddOption(deviceComplianceSettingStateIdOption);
            command.SetHandler(async (string deviceCompliancePolicySettingStateSummaryId, string deviceComplianceSettingStateId) => {
                var requestInfo = CreateDeleteRequestInformation(q => {
                });
                await RequestAdapter.SendNoContentAsync(requestInfo);
                // Print request output. What if the request has no return?
                Console.WriteLine("Success");
            }, deviceCompliancePolicySettingStateSummaryIdOption, deviceComplianceSettingStateIdOption);
            return command;
        }
        /// <summary>
        /// Not yet documented
        /// </summary>
        public Command BuildGetCommand() {
            var command = new Command("get");
            command.Description = "Not yet documented";
            // Create options for all the parameters
            var deviceCompliancePolicySettingStateSummaryIdOption = new Option<string>("--devicecompliancepolicysettingstatesummary-id", description: "key: id of deviceCompliancePolicySettingStateSummary") {
            };
            deviceCompliancePolicySettingStateSummaryIdOption.IsRequired = true;
            command.AddOption(deviceCompliancePolicySettingStateSummaryIdOption);
            var deviceComplianceSettingStateIdOption = new Option<string>("--devicecompliancesettingstate-id", description: "key: id of deviceComplianceSettingState") {
            };
            deviceComplianceSettingStateIdOption.IsRequired = true;
            command.AddOption(deviceComplianceSettingStateIdOption);
            var selectOption = new Option<string[]>("--select", description: "Select properties to be returned") {
                Arity = ArgumentArity.ZeroOrMore
            };
            selectOption.IsRequired = false;
            command.AddOption(selectOption);
            var expandOption = new Option<string[]>("--expand", description: "Expand related entities") {
                Arity = ArgumentArity.ZeroOrMore
            };
            expandOption.IsRequired = false;
            command.AddOption(expandOption);
            command.SetHandler(async (string deviceCompliancePolicySettingStateSummaryId, string deviceComplianceSettingStateId, string[] select, string[] expand) => {
                var requestInfo = CreateGetRequestInformation(q => {
                    q.Select = select;
                    q.Expand = expand;
                });
                var result = await RequestAdapter.SendAsync<DeviceComplianceSettingState>(requestInfo);
                // Print request output. What if the request has no return?
                using var serializer = RequestAdapter.SerializationWriterFactory.GetSerializationWriter("application/json");
                serializer.WriteObjectValue(null, result);
                using var content = serializer.GetSerializedContent();
                using var reader = new StreamReader(content);
                var strContent = await reader.ReadToEndAsync();
                Console.Write(strContent + "\n");
            }, deviceCompliancePolicySettingStateSummaryIdOption, deviceComplianceSettingStateIdOption, selectOption, expandOption);
            return command;
        }
        /// <summary>
        /// Not yet documented
        /// </summary>
        public Command BuildPatchCommand() {
            var command = new Command("patch");
            command.Description = "Not yet documented";
            // Create options for all the parameters
            var deviceCompliancePolicySettingStateSummaryIdOption = new Option<string>("--devicecompliancepolicysettingstatesummary-id", description: "key: id of deviceCompliancePolicySettingStateSummary") {
            };
            deviceCompliancePolicySettingStateSummaryIdOption.IsRequired = true;
            command.AddOption(deviceCompliancePolicySettingStateSummaryIdOption);
            var deviceComplianceSettingStateIdOption = new Option<string>("--devicecompliancesettingstate-id", description: "key: id of deviceComplianceSettingState") {
            };
            deviceComplianceSettingStateIdOption.IsRequired = true;
            command.AddOption(deviceComplianceSettingStateIdOption);
            var bodyOption = new Option<string>("--body") {
            };
            bodyOption.IsRequired = true;
            command.AddOption(bodyOption);
            command.SetHandler(async (string deviceCompliancePolicySettingStateSummaryId, string deviceComplianceSettingStateId, string body) => {
                using var stream = new MemoryStream(Encoding.UTF8.GetBytes(body));
                var parseNode = ParseNodeFactoryRegistry.DefaultInstance.GetRootParseNode("application/json", stream);
                var model = parseNode.GetObjectValue<DeviceComplianceSettingState>();
                var requestInfo = CreatePatchRequestInformation(model, q => {
                });
                await RequestAdapter.SendNoContentAsync(requestInfo);
                // Print request output. What if the request has no return?
                Console.WriteLine("Success");
            }, deviceCompliancePolicySettingStateSummaryIdOption, deviceComplianceSettingStateIdOption, bodyOption);
            return command;
        }
        /// <summary>
        /// Instantiates a new DeviceComplianceSettingStateRequestBuilder and sets the default values.
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        /// </summary>
        public DeviceComplianceSettingStateRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) {
            _ = pathParameters ?? throw new ArgumentNullException(nameof(pathParameters));
            _ = requestAdapter ?? throw new ArgumentNullException(nameof(requestAdapter));
            UrlTemplate = "{+baseurl}/deviceManagement/deviceCompliancePolicySettingStateSummaries/{deviceCompliancePolicySettingStateSummary_id}/deviceComplianceSettingStates/{deviceComplianceSettingState_id}{?select,expand}";
            var urlTplParams = new Dictionary<string, object>(pathParameters);
            PathParameters = urlTplParams;
            RequestAdapter = requestAdapter;
        }
        /// <summary>
        /// Not yet documented
        /// <param name="h">Request headers</param>
        /// <param name="o">Request options</param>
        /// </summary>
        public RequestInformation CreateDeleteRequestInformation(Action<IDictionary<string, string>> h = default, IEnumerable<IRequestOption> o = default) {
            var requestInfo = new RequestInformation {
                HttpMethod = Method.DELETE,
                UrlTemplate = UrlTemplate,
                PathParameters = PathParameters,
            };
            h?.Invoke(requestInfo.Headers);
            requestInfo.AddRequestOptions(o?.ToArray());
            return requestInfo;
        }
        /// <summary>
        /// Not yet documented
        /// <param name="h">Request headers</param>
        /// <param name="o">Request options</param>
        /// <param name="q">Request query parameters</param>
        /// </summary>
        public RequestInformation CreateGetRequestInformation(Action<GetQueryParameters> q = default, Action<IDictionary<string, string>> h = default, IEnumerable<IRequestOption> o = default) {
            var requestInfo = new RequestInformation {
                HttpMethod = Method.GET,
                UrlTemplate = UrlTemplate,
                PathParameters = PathParameters,
            };
            if (q != null) {
                var qParams = new GetQueryParameters();
                q.Invoke(qParams);
                qParams.AddQueryParameters(requestInfo.QueryParameters);
            }
            h?.Invoke(requestInfo.Headers);
            requestInfo.AddRequestOptions(o?.ToArray());
            return requestInfo;
        }
        /// <summary>
        /// Not yet documented
        /// <param name="body"></param>
        /// <param name="h">Request headers</param>
        /// <param name="o">Request options</param>
        /// </summary>
        public RequestInformation CreatePatchRequestInformation(DeviceComplianceSettingState body, Action<IDictionary<string, string>> h = default, IEnumerable<IRequestOption> o = default) {
            _ = body ?? throw new ArgumentNullException(nameof(body));
            var requestInfo = new RequestInformation {
                HttpMethod = Method.PATCH,
                UrlTemplate = UrlTemplate,
                PathParameters = PathParameters,
            };
            requestInfo.SetContentFromParsable(RequestAdapter, "application/json", body);
            h?.Invoke(requestInfo.Headers);
            requestInfo.AddRequestOptions(o?.ToArray());
            return requestInfo;
        }
        /// <summary>
        /// Not yet documented
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="h">Request headers</param>
        /// <param name="o">Request options</param>
        /// <param name="responseHandler">Response handler to use in place of the default response handling provided by the core service</param>
        /// </summary>
        public async Task DeleteAsync(Action<IDictionary<string, string>> h = default, IEnumerable<IRequestOption> o = default, IResponseHandler responseHandler = default, CancellationToken cancellationToken = default) {
            var requestInfo = CreateDeleteRequestInformation(h, o);
            await RequestAdapter.SendNoContentAsync(requestInfo, responseHandler, cancellationToken);
        }
        /// <summary>
        /// Not yet documented
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="h">Request headers</param>
        /// <param name="o">Request options</param>
        /// <param name="q">Request query parameters</param>
        /// <param name="responseHandler">Response handler to use in place of the default response handling provided by the core service</param>
        /// </summary>
        public async Task<DeviceComplianceSettingState> GetAsync(Action<GetQueryParameters> q = default, Action<IDictionary<string, string>> h = default, IEnumerable<IRequestOption> o = default, IResponseHandler responseHandler = default, CancellationToken cancellationToken = default) {
            var requestInfo = CreateGetRequestInformation(q, h, o);
            return await RequestAdapter.SendAsync<DeviceComplianceSettingState>(requestInfo, responseHandler, cancellationToken);
        }
        /// <summary>
        /// Not yet documented
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="h">Request headers</param>
        /// <param name="model"></param>
        /// <param name="o">Request options</param>
        /// <param name="responseHandler">Response handler to use in place of the default response handling provided by the core service</param>
        /// </summary>
        public async Task PatchAsync(DeviceComplianceSettingState model, Action<IDictionary<string, string>> h = default, IEnumerable<IRequestOption> o = default, IResponseHandler responseHandler = default, CancellationToken cancellationToken = default) {
            _ = model ?? throw new ArgumentNullException(nameof(model));
            var requestInfo = CreatePatchRequestInformation(model, h, o);
            await RequestAdapter.SendNoContentAsync(requestInfo, responseHandler, cancellationToken);
        }
        /// <summary>Not yet documented</summary>
        public class GetQueryParameters : QueryParametersBase {
            /// <summary>Expand related entities</summary>
            public string[] Expand { get; set; }
            /// <summary>Select properties to be returned</summary>
            public string[] Select { get; set; }
        }
    }
}