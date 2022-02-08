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
namespace ApiSdk.Sites.Item.Onenote.Notebooks.GetRecentNotebooksWithIncludePersonalNotebooks {
    /// <summary>Builds and executes requests for operations under \sites\{site-id}\onenote\notebooks\microsoft.graph.getRecentNotebooks(includePersonalNotebooks={includePersonalNotebooks})</summary>
    public class GetRecentNotebooksWithIncludePersonalNotebooksRequestBuilder {
        /// <summary>Path parameters for the request</summary>
        private Dictionary<string, object> PathParameters { get; set; }
        /// <summary>The request adapter to use to execute the requests.</summary>
        private IRequestAdapter RequestAdapter { get; set; }
        /// <summary>Url template to use to build the URL for the current request builder</summary>
        private string UrlTemplate { get; set; }
        /// <summary>
        /// Invoke function getRecentNotebooks
        /// </summary>
        public Command BuildGetCommand() {
            var command = new Command("get");
            command.Description = "Invoke function getRecentNotebooks";
            // Create options for all the parameters
            var siteIdOption = new Option<string>("--site-id", description: "key: id of site") {
            };
            siteIdOption.IsRequired = true;
            command.AddOption(siteIdOption);
            var includePersonalNotebooksOption = new Option<bool?>("--includepersonalnotebooks", description: "Usage: includePersonalNotebooks={includePersonalNotebooks}") {
            };
            includePersonalNotebooksOption.IsRequired = true;
            command.AddOption(includePersonalNotebooksOption);
            command.SetHandler(async (string siteId, bool? includePersonalNotebooks) => {
                var requestInfo = CreateGetRequestInformation(q => {
                });
                var result = await RequestAdapter.SendCollectionAsync<ApiSdk.Sites.Item.Onenote.Notebooks.GetRecentNotebooksWithIncludePersonalNotebooks.GetRecentNotebooksWithIncludePersonalNotebooks>(requestInfo);
                // Print request output. What if the request has no return?
                using var serializer = RequestAdapter.SerializationWriterFactory.GetSerializationWriter("application/json");
                serializer.WriteCollectionOfObjectValues(null, result);
                using var content = serializer.GetSerializedContent();
                using var reader = new StreamReader(content);
                var strContent = await reader.ReadToEndAsync();
                Console.Write(strContent + "\n");
            }, siteIdOption, includePersonalNotebooksOption);
            return command;
        }
        /// <summary>
        /// Instantiates a new GetRecentNotebooksWithIncludePersonalNotebooksRequestBuilder and sets the default values.
        /// <param name="includePersonalNotebooks">Usage: includePersonalNotebooks={includePersonalNotebooks}</param>
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        /// </summary>
        public GetRecentNotebooksWithIncludePersonalNotebooksRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter, bool? includePersonalNotebooks = default) {
            _ = pathParameters ?? throw new ArgumentNullException(nameof(pathParameters));
            _ = requestAdapter ?? throw new ArgumentNullException(nameof(requestAdapter));
            UrlTemplate = "{+baseurl}/sites/{site_id}/onenote/notebooks/microsoft.graph.getRecentNotebooks(includePersonalNotebooks={includePersonalNotebooks})";
            var urlTplParams = new Dictionary<string, object>(pathParameters);
            urlTplParams.Add("includePersonalNotebooks", includePersonalNotebooks);
            PathParameters = urlTplParams;
            RequestAdapter = requestAdapter;
        }
        /// <summary>
        /// Invoke function getRecentNotebooks
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
        /// Invoke function getRecentNotebooks
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="h">Request headers</param>
        /// <param name="o">Request options</param>
        /// <param name="responseHandler">Response handler to use in place of the default response handling provided by the core service</param>
        /// </summary>
        public async Task<IEnumerable<ApiSdk.Sites.Item.Onenote.Notebooks.GetRecentNotebooksWithIncludePersonalNotebooks.GetRecentNotebooksWithIncludePersonalNotebooks>> GetAsync(Action<IDictionary<string, string>> h = default, IEnumerable<IRequestOption> o = default, IResponseHandler responseHandler = default, CancellationToken cancellationToken = default) {
            var requestInfo = CreateGetRequestInformation(h, o);
            return await RequestAdapter.SendCollectionAsync<ApiSdk.Sites.Item.Onenote.Notebooks.GetRecentNotebooksWithIncludePersonalNotebooks.GetRecentNotebooksWithIncludePersonalNotebooks>(requestInfo, responseHandler, cancellationToken);
        }
    }
}