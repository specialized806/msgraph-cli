using ApiSdk.Models.Microsoft.Graph;
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
namespace ApiSdk.Policies.PermissionGrantPolicies.Item.Excludes.Item {
    /// <summary>Builds and executes requests for operations under \policies\permissionGrantPolicies\{permissionGrantPolicy-id}\excludes\{permissionGrantConditionSet-id}</summary>
    public class PermissionGrantConditionSetItemRequestBuilder {
        /// <summary>Path parameters for the request</summary>
        private Dictionary<string, object> PathParameters { get; set; }
        /// <summary>The request adapter to use to execute the requests.</summary>
        private IRequestAdapter RequestAdapter { get; set; }
        /// <summary>Url template to use to build the URL for the current request builder</summary>
        private string UrlTemplate { get; set; }
        /// <summary>
        /// Condition sets which are excluded in this permission grant policy. Automatically expanded on GET.
        /// </summary>
        public Command BuildDeleteCommand() {
            var command = new Command("delete");
            command.Description = "Condition sets which are excluded in this permission grant policy. Automatically expanded on GET.";
            // Create options for all the parameters
            var permissionGrantPolicyIdOption = new Option<string>("--permission-grant-policy-id", description: "key: id of permissionGrantPolicy") {
            };
            permissionGrantPolicyIdOption.IsRequired = true;
            command.AddOption(permissionGrantPolicyIdOption);
            var permissionGrantConditionSetIdOption = new Option<string>("--permission-grant-condition-set-id", description: "key: id of permissionGrantConditionSet") {
            };
            permissionGrantConditionSetIdOption.IsRequired = true;
            command.AddOption(permissionGrantConditionSetIdOption);
            command.SetHandler(async (object[] parameters) => {
                var permissionGrantPolicyId = (string) parameters[0];
                var permissionGrantConditionSetId = (string) parameters[1];
                var cancellationToken = (CancellationToken) parameters[2];
                PathParameters.Clear();
                PathParameters.Add("permissionGrantPolicy_id", permissionGrantPolicyId);
                PathParameters.Add("permissionGrantConditionSet_id", permissionGrantConditionSetId);
                var requestInfo = CreateDeleteRequestInformation(q => {
                });
                await RequestAdapter.SendNoContentAsync(requestInfo, errorMapping: default, cancellationToken: cancellationToken);
                Console.WriteLine("Success");
            }, new CollectionBinding(permissionGrantPolicyIdOption, permissionGrantConditionSetIdOption, new TypeBinding(typeof(CancellationToken))));
            return command;
        }
        /// <summary>
        /// Condition sets which are excluded in this permission grant policy. Automatically expanded on GET.
        /// </summary>
        public Command BuildGetCommand() {
            var command = new Command("get");
            command.Description = "Condition sets which are excluded in this permission grant policy. Automatically expanded on GET.";
            // Create options for all the parameters
            var permissionGrantPolicyIdOption = new Option<string>("--permission-grant-policy-id", description: "key: id of permissionGrantPolicy") {
            };
            permissionGrantPolicyIdOption.IsRequired = true;
            command.AddOption(permissionGrantPolicyIdOption);
            var permissionGrantConditionSetIdOption = new Option<string>("--permission-grant-condition-set-id", description: "key: id of permissionGrantConditionSet") {
            };
            permissionGrantConditionSetIdOption.IsRequired = true;
            command.AddOption(permissionGrantConditionSetIdOption);
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
            var outputOption = new Option<FormatterType>("--output", () => FormatterType.JSON){
                IsRequired = true
            };
            command.AddOption(outputOption);
            var queryOption = new Option<string>("--query");
            command.AddOption(queryOption);
            var jsonNoIndentOption = new Option<bool>("--json-no-indent", r => {
                if (bool.TryParse(r.Tokens.Select(t => t.Value).LastOrDefault(), out var value)) {
                    return value;
                }
                return true;
            }, description: "Disable indentation for the JSON output formatter.");
            command.AddOption(jsonNoIndentOption);
            command.SetHandler(async (object[] parameters) => {
                var permissionGrantPolicyId = (string) parameters[0];
                var permissionGrantConditionSetId = (string) parameters[1];
                var select = (string[]) parameters[2];
                var expand = (string[]) parameters[3];
                var output = (FormatterType) parameters[4];
                var query = (string) parameters[5];
                var jsonNoIndent = (bool) parameters[6];
                var outputFilter = (IOutputFilter) parameters[7];
                var outputFormatterFactory = (IOutputFormatterFactory) parameters[8];
                var cancellationToken = (CancellationToken) parameters[9];
                PathParameters.Clear();
                PathParameters.Add("permissionGrantPolicy_id", permissionGrantPolicyId);
                PathParameters.Add("permissionGrantConditionSet_id", permissionGrantConditionSetId);
                var requestInfo = CreateGetRequestInformation(q => {
                    q.Select = select;
                    q.Expand = expand;
                });
                var response = await RequestAdapter.SendPrimitiveAsync<Stream>(requestInfo, errorMapping: default, cancellationToken: cancellationToken);
                var formatter = outputFormatterFactory.GetFormatter(output);
                response = await outputFilter?.FilterOutputAsync(response, query, cancellationToken) ?? response;
                var formatterOptions = output.GetOutputFormatterOptions(new FormatterOptionsModel(!jsonNoIndent));
                await formatter.WriteOutputAsync(response, formatterOptions, cancellationToken);
            }, new CollectionBinding(permissionGrantPolicyIdOption, permissionGrantConditionSetIdOption, selectOption, expandOption, outputOption, queryOption, jsonNoIndentOption, new TypeBinding(typeof(IOutputFilter)), new TypeBinding(typeof(IOutputFormatterFactory)), new TypeBinding(typeof(CancellationToken))));
            return command;
        }
        /// <summary>
        /// Condition sets which are excluded in this permission grant policy. Automatically expanded on GET.
        /// </summary>
        public Command BuildPatchCommand() {
            var command = new Command("patch");
            command.Description = "Condition sets which are excluded in this permission grant policy. Automatically expanded on GET.";
            // Create options for all the parameters
            var permissionGrantPolicyIdOption = new Option<string>("--permission-grant-policy-id", description: "key: id of permissionGrantPolicy") {
            };
            permissionGrantPolicyIdOption.IsRequired = true;
            command.AddOption(permissionGrantPolicyIdOption);
            var permissionGrantConditionSetIdOption = new Option<string>("--permission-grant-condition-set-id", description: "key: id of permissionGrantConditionSet") {
            };
            permissionGrantConditionSetIdOption.IsRequired = true;
            command.AddOption(permissionGrantConditionSetIdOption);
            var bodyOption = new Option<string>("--body") {
            };
            bodyOption.IsRequired = true;
            command.AddOption(bodyOption);
            command.SetHandler(async (object[] parameters) => {
                var permissionGrantPolicyId = (string) parameters[0];
                var permissionGrantConditionSetId = (string) parameters[1];
                var body = (string) parameters[2];
                var cancellationToken = (CancellationToken) parameters[3];
                PathParameters.Clear();
                PathParameters.Add("permissionGrantPolicy_id", permissionGrantPolicyId);
                PathParameters.Add("permissionGrantConditionSet_id", permissionGrantConditionSetId);
                using var stream = new MemoryStream(Encoding.UTF8.GetBytes(body));
                var parseNode = ParseNodeFactoryRegistry.DefaultInstance.GetRootParseNode("application/json", stream);
                var model = parseNode.GetObjectValue<PermissionGrantConditionSet>(PermissionGrantConditionSet.CreateFromDiscriminatorValue);
                var requestInfo = CreatePatchRequestInformation(model, q => {
                });
                await RequestAdapter.SendNoContentAsync(requestInfo, errorMapping: default, cancellationToken: cancellationToken);
                Console.WriteLine("Success");
            }, new CollectionBinding(permissionGrantPolicyIdOption, permissionGrantConditionSetIdOption, bodyOption, new TypeBinding(typeof(CancellationToken))));
            return command;
        }
        /// <summary>
        /// Instantiates a new PermissionGrantConditionSetItemRequestBuilder and sets the default values.
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        /// </summary>
        public PermissionGrantConditionSetItemRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) {
            _ = pathParameters ?? throw new ArgumentNullException(nameof(pathParameters));
            _ = requestAdapter ?? throw new ArgumentNullException(nameof(requestAdapter));
            UrlTemplate = "{+baseurl}/policies/permissionGrantPolicies/{permissionGrantPolicy_id}/excludes/{permissionGrantConditionSet_id}{?select,expand}";
            var urlTplParams = new Dictionary<string, object>(pathParameters);
            PathParameters = urlTplParams;
            RequestAdapter = requestAdapter;
        }
        /// <summary>
        /// Condition sets which are excluded in this permission grant policy. Automatically expanded on GET.
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
        /// Condition sets which are excluded in this permission grant policy. Automatically expanded on GET.
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
        /// Condition sets which are excluded in this permission grant policy. Automatically expanded on GET.
        /// <param name="body"></param>
        /// <param name="h">Request headers</param>
        /// <param name="o">Request options</param>
        /// </summary>
        public RequestInformation CreatePatchRequestInformation(PermissionGrantConditionSet body, Action<IDictionary<string, string>> h = default, IEnumerable<IRequestOption> o = default) {
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
        /// <summary>Condition sets which are excluded in this permission grant policy. Automatically expanded on GET.</summary>
        public class GetQueryParameters : QueryParametersBase {
            /// <summary>Expand related entities</summary>
            public string[] Expand { get; set; }
            /// <summary>Select properties to be returned</summary>
            public string[] Select { get; set; }
        }
    }
}
