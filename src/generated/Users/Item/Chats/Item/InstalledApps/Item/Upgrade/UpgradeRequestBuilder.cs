using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Cli.Commons.Binding;
using Microsoft.Kiota.Cli.Commons.IO;
using System;
using System.Collections.Generic;
using System.CommandLine;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace ApiSdk.Users.Item.Chats.Item.InstalledApps.Item.Upgrade {
    /// <summary>Provides operations to call the upgrade method.</summary>
    public class UpgradeRequestBuilder {
        /// <summary>Path parameters for the request</summary>
        private Dictionary<string, object> PathParameters { get; set; }
        /// <summary>The request adapter to use to execute the requests.</summary>
        private IRequestAdapter RequestAdapter { get; set; }
        /// <summary>Url template to use to build the URL for the current request builder</summary>
        private string UrlTemplate { get; set; }
        /// <summary>
        /// Invoke action upgrade
        /// </summary>
        public Command BuildPostCommand() {
            var command = new Command("post");
            command.Description = "Invoke action upgrade";
            // Create options for all the parameters
            var userIdOption = new Option<string>("--user-id", description: "key: id of user") {
            };
            userIdOption.IsRequired = true;
            command.AddOption(userIdOption);
            var chatIdOption = new Option<string>("--chat-id", description: "key: id of chat") {
            };
            chatIdOption.IsRequired = true;
            command.AddOption(chatIdOption);
            var teamsAppInstallationIdOption = new Option<string>("--teams-app-installation-id", description: "key: id of teamsAppInstallation") {
            };
            teamsAppInstallationIdOption.IsRequired = true;
            command.AddOption(teamsAppInstallationIdOption);
            command.SetHandler(async (object[] parameters) => {
                var userId = (string) parameters[0];
                var chatId = (string) parameters[1];
                var teamsAppInstallationId = (string) parameters[2];
                var cancellationToken = (CancellationToken) parameters[3];
                var requestInfo = CreatePostRequestInformation(q => {
                });
                requestInfo.PathParameters.Add("user%2Did", userId);
                requestInfo.PathParameters.Add("chat%2Did", chatId);
                requestInfo.PathParameters.Add("teamsAppInstallation%2Did", teamsAppInstallationId);
                await RequestAdapter.SendNoContentAsync(requestInfo, errorMapping: default, cancellationToken: cancellationToken);
                Console.WriteLine("Success");
            }, new CollectionBinding(userIdOption, chatIdOption, teamsAppInstallationIdOption, new TypeBinding(typeof(CancellationToken))));
            return command;
        }
        /// <summary>
        /// Instantiates a new UpgradeRequestBuilder and sets the default values.
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        /// </summary>
        public UpgradeRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) {
            _ = pathParameters ?? throw new ArgumentNullException(nameof(pathParameters));
            _ = requestAdapter ?? throw new ArgumentNullException(nameof(requestAdapter));
            UrlTemplate = "{+baseurl}/users/{user%2Did}/chats/{chat%2Did}/installedApps/{teamsAppInstallation%2Did}/microsoft.graph.upgrade";
            var urlTplParams = new Dictionary<string, object>(pathParameters);
            PathParameters = urlTplParams;
            RequestAdapter = requestAdapter;
        }
        /// <summary>
        /// Invoke action upgrade
        /// <param name="headers">Request headers</param>
        /// <param name="options">Request options</param>
        /// </summary>
        public RequestInformation CreatePostRequestInformation(Action<IDictionary<string, string>> headers = default, IEnumerable<IRequestOption> options = default) {
            var requestInfo = new RequestInformation {
                HttpMethod = Method.POST,
                UrlTemplate = UrlTemplate,
                PathParameters = PathParameters,
            };
            headers?.Invoke(requestInfo.Headers);
            requestInfo.AddRequestOptions(options?.ToArray());
            return requestInfo;
        }
    }
}