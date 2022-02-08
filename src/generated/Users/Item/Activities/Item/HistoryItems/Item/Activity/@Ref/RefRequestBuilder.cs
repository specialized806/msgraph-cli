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
namespace ApiSdk.Users.Item.Activities.Item.HistoryItems.Item.Activity.@Ref {
    /// <summary>Builds and executes requests for operations under \users\{user-id}\activities\{userActivity-id}\historyItems\{activityHistoryItem-id}\activity\$ref</summary>
    public class RefRequestBuilder {
        /// <summary>Path parameters for the request</summary>
        private Dictionary<string, object> PathParameters { get; set; }
        /// <summary>The request adapter to use to execute the requests.</summary>
        private IRequestAdapter RequestAdapter { get; set; }
        /// <summary>Url template to use to build the URL for the current request builder</summary>
        private string UrlTemplate { get; set; }
        /// <summary>
        /// Optional. NavigationProperty/Containment; navigation property to the associated activity.
        /// </summary>
        public Command BuildDeleteCommand() {
            var command = new Command("delete");
            command.Description = "Optional. NavigationProperty/Containment; navigation property to the associated activity.";
            // Create options for all the parameters
            var userIdOption = new Option<string>("--user-id", description: "key: id of user") {
            };
            userIdOption.IsRequired = true;
            command.AddOption(userIdOption);
            var userActivityIdOption = new Option<string>("--useractivity-id", description: "key: id of userActivity") {
            };
            userActivityIdOption.IsRequired = true;
            command.AddOption(userActivityIdOption);
            var activityHistoryItemIdOption = new Option<string>("--activityhistoryitem-id", description: "key: id of activityHistoryItem") {
            };
            activityHistoryItemIdOption.IsRequired = true;
            command.AddOption(activityHistoryItemIdOption);
            command.SetHandler(async (string userId, string userActivityId, string activityHistoryItemId) => {
                var requestInfo = CreateDeleteRequestInformation(q => {
                });
                await RequestAdapter.SendNoContentAsync(requestInfo);
                // Print request output. What if the request has no return?
                Console.WriteLine("Success");
            }, userIdOption, userActivityIdOption, activityHistoryItemIdOption);
            return command;
        }
        /// <summary>
        /// Optional. NavigationProperty/Containment; navigation property to the associated activity.
        /// </summary>
        public Command BuildGetCommand() {
            var command = new Command("get");
            command.Description = "Optional. NavigationProperty/Containment; navigation property to the associated activity.";
            // Create options for all the parameters
            var userIdOption = new Option<string>("--user-id", description: "key: id of user") {
            };
            userIdOption.IsRequired = true;
            command.AddOption(userIdOption);
            var userActivityIdOption = new Option<string>("--useractivity-id", description: "key: id of userActivity") {
            };
            userActivityIdOption.IsRequired = true;
            command.AddOption(userActivityIdOption);
            var activityHistoryItemIdOption = new Option<string>("--activityhistoryitem-id", description: "key: id of activityHistoryItem") {
            };
            activityHistoryItemIdOption.IsRequired = true;
            command.AddOption(activityHistoryItemIdOption);
            command.SetHandler(async (string userId, string userActivityId, string activityHistoryItemId) => {
                var requestInfo = CreateGetRequestInformation(q => {
                });
                var result = await RequestAdapter.SendPrimitiveAsync<string>(requestInfo);
                // Print request output. What if the request has no return?
                using var serializer = RequestAdapter.SerializationWriterFactory.GetSerializationWriter("application/json");
                serializer.WriteStringValue(null, result);
                using var content = serializer.GetSerializedContent();
                using var reader = new StreamReader(content);
                var strContent = await reader.ReadToEndAsync();
                Console.Write(strContent + "\n");
            }, userIdOption, userActivityIdOption, activityHistoryItemIdOption);
            return command;
        }
        /// <summary>
        /// Optional. NavigationProperty/Containment; navigation property to the associated activity.
        /// </summary>
        public Command BuildPutCommand() {
            var command = new Command("put");
            command.Description = "Optional. NavigationProperty/Containment; navigation property to the associated activity.";
            // Create options for all the parameters
            var userIdOption = new Option<string>("--user-id", description: "key: id of user") {
            };
            userIdOption.IsRequired = true;
            command.AddOption(userIdOption);
            var userActivityIdOption = new Option<string>("--useractivity-id", description: "key: id of userActivity") {
            };
            userActivityIdOption.IsRequired = true;
            command.AddOption(userActivityIdOption);
            var activityHistoryItemIdOption = new Option<string>("--activityhistoryitem-id", description: "key: id of activityHistoryItem") {
            };
            activityHistoryItemIdOption.IsRequired = true;
            command.AddOption(activityHistoryItemIdOption);
            var bodyOption = new Option<string>("--body") {
            };
            bodyOption.IsRequired = true;
            command.AddOption(bodyOption);
            command.SetHandler(async (string userId, string userActivityId, string activityHistoryItemId, string body) => {
                using var stream = new MemoryStream(Encoding.UTF8.GetBytes(body));
                var parseNode = ParseNodeFactoryRegistry.DefaultInstance.GetRootParseNode("application/json", stream);
                var model = parseNode.GetObjectValue<ApiSdk.Users.Item.Activities.Item.HistoryItems.Item.Activity.@Ref.@Ref>();
                var requestInfo = CreatePutRequestInformation(model, q => {
                });
                await RequestAdapter.SendNoContentAsync(requestInfo);
                // Print request output. What if the request has no return?
                Console.WriteLine("Success");
            }, userIdOption, userActivityIdOption, activityHistoryItemIdOption, bodyOption);
            return command;
        }
        /// <summary>
        /// Instantiates a new RefRequestBuilder and sets the default values.
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        /// </summary>
        public RefRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) {
            _ = pathParameters ?? throw new ArgumentNullException(nameof(pathParameters));
            _ = requestAdapter ?? throw new ArgumentNullException(nameof(requestAdapter));
            UrlTemplate = "{+baseurl}/users/{user_id}/activities/{userActivity_id}/historyItems/{activityHistoryItem_id}/activity/$ref";
            var urlTplParams = new Dictionary<string, object>(pathParameters);
            PathParameters = urlTplParams;
            RequestAdapter = requestAdapter;
        }
        /// <summary>
        /// Optional. NavigationProperty/Containment; navigation property to the associated activity.
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
        /// Optional. NavigationProperty/Containment; navigation property to the associated activity.
        /// <param name="h">Request headers</param>
        /// <param name="o">Request options</param>
        /// </summary>
        public RequestInformation CreateGetRequestInformation(Action<IDictionary<string, string>> h = default, IEnumerable<IRequestOption> o = default) {
            var requestInfo = new RequestInformation {
                HttpMethod = Method.GET,
                UrlTemplate = UrlTemplate,
                PathParameters = PathParameters,
            };
            h?.Invoke(requestInfo.Headers);
            requestInfo.AddRequestOptions(o?.ToArray());
            return requestInfo;
        }
        /// <summary>
        /// Optional. NavigationProperty/Containment; navigation property to the associated activity.
        /// <param name="body"></param>
        /// <param name="h">Request headers</param>
        /// <param name="o">Request options</param>
        /// </summary>
        public RequestInformation CreatePutRequestInformation(ApiSdk.Users.Item.Activities.Item.HistoryItems.Item.Activity.@Ref.@Ref body, Action<IDictionary<string, string>> h = default, IEnumerable<IRequestOption> o = default) {
            _ = body ?? throw new ArgumentNullException(nameof(body));
            var requestInfo = new RequestInformation {
                HttpMethod = Method.PUT,
                UrlTemplate = UrlTemplate,
                PathParameters = PathParameters,
            };
            requestInfo.SetContentFromParsable(RequestAdapter, "application/json", body);
            h?.Invoke(requestInfo.Headers);
            requestInfo.AddRequestOptions(o?.ToArray());
            return requestInfo;
        }
        /// <summary>
        /// Optional. NavigationProperty/Containment; navigation property to the associated activity.
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
        /// Optional. NavigationProperty/Containment; navigation property to the associated activity.
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="h">Request headers</param>
        /// <param name="o">Request options</param>
        /// <param name="responseHandler">Response handler to use in place of the default response handling provided by the core service</param>
        /// </summary>
        public async Task<string> GetAsync(Action<IDictionary<string, string>> h = default, IEnumerable<IRequestOption> o = default, IResponseHandler responseHandler = default, CancellationToken cancellationToken = default) {
            var requestInfo = CreateGetRequestInformation(h, o);
            return await RequestAdapter.SendPrimitiveAsync<string>(requestInfo, responseHandler, cancellationToken);
        }
        /// <summary>
        /// Optional. NavigationProperty/Containment; navigation property to the associated activity.
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="h">Request headers</param>
        /// <param name="model"></param>
        /// <param name="o">Request options</param>
        /// <param name="responseHandler">Response handler to use in place of the default response handling provided by the core service</param>
        /// </summary>
        public async Task PutAsync(ApiSdk.Users.Item.Activities.Item.HistoryItems.Item.Activity.@Ref.@Ref model, Action<IDictionary<string, string>> h = default, IEnumerable<IRequestOption> o = default, IResponseHandler responseHandler = default, CancellationToken cancellationToken = default) {
            _ = model ?? throw new ArgumentNullException(nameof(model));
            var requestInfo = CreatePutRequestInformation(model, h, o);
            await RequestAdapter.SendNoContentAsync(requestInfo, responseHandler, cancellationToken);
        }
    }
}