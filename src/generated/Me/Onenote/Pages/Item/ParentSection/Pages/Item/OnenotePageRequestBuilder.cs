using ApiSdk.Me.Onenote.Pages.Item.ParentSection.Pages.Item.Content;
using ApiSdk.Me.Onenote.Pages.Item.ParentSection.Pages.Item.CopyToSection;
using ApiSdk.Me.Onenote.Pages.Item.ParentSection.Pages.Item.OnenotePatchContent;
using ApiSdk.Me.Onenote.Pages.Item.ParentSection.Pages.Item.Preview;
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
namespace ApiSdk.Me.Onenote.Pages.Item.ParentSection.Pages.Item {
    /// <summary>Builds and executes requests for operations under \me\onenote\pages\{onenotePage-id}\parentSection\pages\{onenotePage-id1}</summary>
    public class OnenotePageRequestBuilder {
        /// <summary>Path parameters for the request</summary>
        private Dictionary<string, object> PathParameters { get; set; }
        /// <summary>The request adapter to use to execute the requests.</summary>
        private IRequestAdapter RequestAdapter { get; set; }
        /// <summary>Url template to use to build the URL for the current request builder</summary>
        private string UrlTemplate { get; set; }
        public Command BuildContentCommand() {
            var command = new Command("content");
            var builder = new ApiSdk.Me.Onenote.Pages.Item.ParentSection.Pages.Item.Content.ContentRequestBuilder(PathParameters, RequestAdapter);
            command.AddCommand(builder.BuildGetCommand());
            command.AddCommand(builder.BuildPutCommand());
            return command;
        }
        public Command BuildCopyToSectionCommand() {
            var command = new Command("copy-to-section");
            var builder = new ApiSdk.Me.Onenote.Pages.Item.ParentSection.Pages.Item.CopyToSection.CopyToSectionRequestBuilder(PathParameters, RequestAdapter);
            command.AddCommand(builder.BuildPostCommand());
            return command;
        }
        /// <summary>
        /// The collection of pages in the section.  Read-only. Nullable.
        /// </summary>
        public Command BuildDeleteCommand() {
            var command = new Command("delete");
            command.Description = "The collection of pages in the section.  Read-only. Nullable.";
            // Create options for all the parameters
            var onenotePageIdOption = new Option<string>("--onenotepage-id", description: "key: id of onenotePage") {
            };
            onenotePageIdOption.IsRequired = true;
            command.AddOption(onenotePageIdOption);
            var onenotePageId1Option = new Option<string>("--onenotepage-id1", description: "key: id of onenotePage") {
            };
            onenotePageId1Option.IsRequired = true;
            command.AddOption(onenotePageId1Option);
            command.SetHandler(async (string onenotePageId, string onenotePageId1) => {
                var requestInfo = CreateDeleteRequestInformation(q => {
                });
                await RequestAdapter.SendNoContentAsync(requestInfo);
                // Print request output. What if the request has no return?
                Console.WriteLine("Success");
            }, onenotePageIdOption, onenotePageId1Option);
            return command;
        }
        /// <summary>
        /// The collection of pages in the section.  Read-only. Nullable.
        /// </summary>
        public Command BuildGetCommand() {
            var command = new Command("get");
            command.Description = "The collection of pages in the section.  Read-only. Nullable.";
            // Create options for all the parameters
            var onenotePageIdOption = new Option<string>("--onenotepage-id", description: "key: id of onenotePage") {
            };
            onenotePageIdOption.IsRequired = true;
            command.AddOption(onenotePageIdOption);
            var onenotePageId1Option = new Option<string>("--onenotepage-id1", description: "key: id of onenotePage") {
            };
            onenotePageId1Option.IsRequired = true;
            command.AddOption(onenotePageId1Option);
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
            command.SetHandler(async (string onenotePageId, string onenotePageId1, string[] select, string[] expand) => {
                var requestInfo = CreateGetRequestInformation(q => {
                    q.Select = select;
                    q.Expand = expand;
                });
                var result = await RequestAdapter.SendAsync<OnenotePage>(requestInfo);
                // Print request output. What if the request has no return?
                using var serializer = RequestAdapter.SerializationWriterFactory.GetSerializationWriter("application/json");
                serializer.WriteObjectValue(null, result);
                using var content = serializer.GetSerializedContent();
                using var reader = new StreamReader(content);
                var strContent = await reader.ReadToEndAsync();
                Console.Write(strContent + "\n");
            }, onenotePageIdOption, onenotePageId1Option, selectOption, expandOption);
            return command;
        }
        public Command BuildOnenotePatchContentCommand() {
            var command = new Command("onenote-patch-content");
            var builder = new ApiSdk.Me.Onenote.Pages.Item.ParentSection.Pages.Item.OnenotePatchContent.OnenotePatchContentRequestBuilder(PathParameters, RequestAdapter);
            command.AddCommand(builder.BuildPostCommand());
            return command;
        }
        /// <summary>
        /// The collection of pages in the section.  Read-only. Nullable.
        /// </summary>
        public Command BuildPatchCommand() {
            var command = new Command("patch");
            command.Description = "The collection of pages in the section.  Read-only. Nullable.";
            // Create options for all the parameters
            var onenotePageIdOption = new Option<string>("--onenotepage-id", description: "key: id of onenotePage") {
            };
            onenotePageIdOption.IsRequired = true;
            command.AddOption(onenotePageIdOption);
            var onenotePageId1Option = new Option<string>("--onenotepage-id1", description: "key: id of onenotePage") {
            };
            onenotePageId1Option.IsRequired = true;
            command.AddOption(onenotePageId1Option);
            var bodyOption = new Option<string>("--body") {
            };
            bodyOption.IsRequired = true;
            command.AddOption(bodyOption);
            command.SetHandler(async (string onenotePageId, string onenotePageId1, string body) => {
                using var stream = new MemoryStream(Encoding.UTF8.GetBytes(body));
                var parseNode = ParseNodeFactoryRegistry.DefaultInstance.GetRootParseNode("application/json", stream);
                var model = parseNode.GetObjectValue<OnenotePage>();
                var requestInfo = CreatePatchRequestInformation(model, q => {
                });
                await RequestAdapter.SendNoContentAsync(requestInfo);
                // Print request output. What if the request has no return?
                Console.WriteLine("Success");
            }, onenotePageIdOption, onenotePageId1Option, bodyOption);
            return command;
        }
        /// <summary>
        /// Instantiates a new OnenotePageRequestBuilder and sets the default values.
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        /// </summary>
        public OnenotePageRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) {
            _ = pathParameters ?? throw new ArgumentNullException(nameof(pathParameters));
            _ = requestAdapter ?? throw new ArgumentNullException(nameof(requestAdapter));
            UrlTemplate = "{+baseurl}/me/onenote/pages/{onenotePage_id}/parentSection/pages/{onenotePage_id1}{?select,expand}";
            var urlTplParams = new Dictionary<string, object>(pathParameters);
            PathParameters = urlTplParams;
            RequestAdapter = requestAdapter;
        }
        /// <summary>
        /// The collection of pages in the section.  Read-only. Nullable.
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
        /// The collection of pages in the section.  Read-only. Nullable.
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
        /// The collection of pages in the section.  Read-only. Nullable.
        /// <param name="body"></param>
        /// <param name="h">Request headers</param>
        /// <param name="o">Request options</param>
        /// </summary>
        public RequestInformation CreatePatchRequestInformation(OnenotePage body, Action<IDictionary<string, string>> h = default, IEnumerable<IRequestOption> o = default) {
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
        /// The collection of pages in the section.  Read-only. Nullable.
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
        /// The collection of pages in the section.  Read-only. Nullable.
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="h">Request headers</param>
        /// <param name="o">Request options</param>
        /// <param name="q">Request query parameters</param>
        /// <param name="responseHandler">Response handler to use in place of the default response handling provided by the core service</param>
        /// </summary>
        public async Task<OnenotePage> GetAsync(Action<GetQueryParameters> q = default, Action<IDictionary<string, string>> h = default, IEnumerable<IRequestOption> o = default, IResponseHandler responseHandler = default, CancellationToken cancellationToken = default) {
            var requestInfo = CreateGetRequestInformation(q, h, o);
            return await RequestAdapter.SendAsync<OnenotePage>(requestInfo, responseHandler, cancellationToken);
        }
        /// <summary>
        /// The collection of pages in the section.  Read-only. Nullable.
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="h">Request headers</param>
        /// <param name="model"></param>
        /// <param name="o">Request options</param>
        /// <param name="responseHandler">Response handler to use in place of the default response handling provided by the core service</param>
        /// </summary>
        public async Task PatchAsync(OnenotePage model, Action<IDictionary<string, string>> h = default, IEnumerable<IRequestOption> o = default, IResponseHandler responseHandler = default, CancellationToken cancellationToken = default) {
            _ = model ?? throw new ArgumentNullException(nameof(model));
            var requestInfo = CreatePatchRequestInformation(model, h, o);
            await RequestAdapter.SendNoContentAsync(requestInfo, responseHandler, cancellationToken);
        }
        /// <summary>
        /// Builds and executes requests for operations under \me\onenote\pages\{onenotePage-id}\parentSection\pages\{onenotePage-id1}\microsoft.graph.preview()
        /// </summary>
        public PreviewRequestBuilder Preview() {
            return new PreviewRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The collection of pages in the section.  Read-only. Nullable.</summary>
        public class GetQueryParameters : QueryParametersBase {
            /// <summary>Expand related entities</summary>
            public string[] Expand { get; set; }
            /// <summary>Select properties to be returned</summary>
            public string[] Select { get; set; }
        }
    }
}