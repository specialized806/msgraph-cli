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
namespace ApiSdk.RoleManagement.Directory.RoleDefinitions.Item.InheritsPermissionsFrom.Item {
    /// <summary>Builds and executes requests for operations under \roleManagement\directory\roleDefinitions\{unifiedRoleDefinition-id}\inheritsPermissionsFrom\{unifiedRoleDefinition-id1}</summary>
    public class UnifiedRoleDefinitionItemRequestBuilder {
        /// <summary>Path parameters for the request</summary>
        private Dictionary<string, object> PathParameters { get; set; }
        /// <summary>The request adapter to use to execute the requests.</summary>
        private IRequestAdapter RequestAdapter { get; set; }
        /// <summary>Url template to use to build the URL for the current request builder</summary>
        private string UrlTemplate { get; set; }
        /// <summary>
        /// Read-only collection of role definitions that the given role definition inherits from. Only Azure AD built-in roles support this attribute.
        /// </summary>
        public Command BuildDeleteCommand() {
            var command = new Command("delete");
            command.Description = "Read-only collection of role definitions that the given role definition inherits from. Only Azure AD built-in roles support this attribute.";
            // Create options for all the parameters
            var unifiedRoleDefinitionIdOption = new Option<string>("--unified-role-definition-id", description: "key: id of unifiedRoleDefinition") {
            };
            unifiedRoleDefinitionIdOption.IsRequired = true;
            command.AddOption(unifiedRoleDefinitionIdOption);
            var unifiedRoleDefinitionId1Option = new Option<string>("--unified-role-definition-id1", description: "key: id of unifiedRoleDefinition") {
            };
            unifiedRoleDefinitionId1Option.IsRequired = true;
            command.AddOption(unifiedRoleDefinitionId1Option);
            command.SetHandler(async (object[] parameters) => {
                var unifiedRoleDefinitionId = (string) parameters[0];
                var unifiedRoleDefinitionId1 = (string) parameters[1];
                var cancellationToken = (CancellationToken) parameters[2];
                PathParameters.Clear();
                PathParameters.Add("unifiedRoleDefinition_id", unifiedRoleDefinitionId);
                PathParameters.Add("unifiedRoleDefinition_id1", unifiedRoleDefinitionId1);
                var requestInfo = CreateDeleteRequestInformation(q => {
                });
                await RequestAdapter.SendNoContentAsync(requestInfo, errorMapping: default, cancellationToken: cancellationToken);
                Console.WriteLine("Success");
            }, new CollectionBinding(unifiedRoleDefinitionIdOption, unifiedRoleDefinitionId1Option, new TypeBinding(typeof(CancellationToken))));
            return command;
        }
        /// <summary>
        /// Read-only collection of role definitions that the given role definition inherits from. Only Azure AD built-in roles support this attribute.
        /// </summary>
        public Command BuildGetCommand() {
            var command = new Command("get");
            command.Description = "Read-only collection of role definitions that the given role definition inherits from. Only Azure AD built-in roles support this attribute.";
            // Create options for all the parameters
            var unifiedRoleDefinitionIdOption = new Option<string>("--unified-role-definition-id", description: "key: id of unifiedRoleDefinition") {
            };
            unifiedRoleDefinitionIdOption.IsRequired = true;
            command.AddOption(unifiedRoleDefinitionIdOption);
            var unifiedRoleDefinitionId1Option = new Option<string>("--unified-role-definition-id1", description: "key: id of unifiedRoleDefinition") {
            };
            unifiedRoleDefinitionId1Option.IsRequired = true;
            command.AddOption(unifiedRoleDefinitionId1Option);
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
                var unifiedRoleDefinitionId = (string) parameters[0];
                var unifiedRoleDefinitionId1 = (string) parameters[1];
                var select = (string[]) parameters[2];
                var expand = (string[]) parameters[3];
                var output = (FormatterType) parameters[4];
                var query = (string) parameters[5];
                var jsonNoIndent = (bool) parameters[6];
                var outputFilter = (IOutputFilter) parameters[7];
                var outputFormatterFactory = (IOutputFormatterFactory) parameters[8];
                var cancellationToken = (CancellationToken) parameters[9];
                PathParameters.Clear();
                PathParameters.Add("unifiedRoleDefinition_id", unifiedRoleDefinitionId);
                PathParameters.Add("unifiedRoleDefinition_id1", unifiedRoleDefinitionId1);
                var requestInfo = CreateGetRequestInformation(q => {
                    q.Select = select;
                    q.Expand = expand;
                });
                var response = await RequestAdapter.SendPrimitiveAsync<Stream>(requestInfo, errorMapping: default, cancellationToken: cancellationToken);
                var formatter = outputFormatterFactory.GetFormatter(output);
                response = await outputFilter?.FilterOutputAsync(response, query, cancellationToken) ?? response;
                var formatterOptions = output.GetOutputFormatterOptions(new FormatterOptionsModel(!jsonNoIndent));
                await formatter.WriteOutputAsync(response, formatterOptions, cancellationToken);
            }, new CollectionBinding(unifiedRoleDefinitionIdOption, unifiedRoleDefinitionId1Option, selectOption, expandOption, outputOption, queryOption, jsonNoIndentOption, new TypeBinding(typeof(IOutputFilter)), new TypeBinding(typeof(IOutputFormatterFactory)), new TypeBinding(typeof(CancellationToken))));
            return command;
        }
        /// <summary>
        /// Read-only collection of role definitions that the given role definition inherits from. Only Azure AD built-in roles support this attribute.
        /// </summary>
        public Command BuildPatchCommand() {
            var command = new Command("patch");
            command.Description = "Read-only collection of role definitions that the given role definition inherits from. Only Azure AD built-in roles support this attribute.";
            // Create options for all the parameters
            var unifiedRoleDefinitionIdOption = new Option<string>("--unified-role-definition-id", description: "key: id of unifiedRoleDefinition") {
            };
            unifiedRoleDefinitionIdOption.IsRequired = true;
            command.AddOption(unifiedRoleDefinitionIdOption);
            var unifiedRoleDefinitionId1Option = new Option<string>("--unified-role-definition-id1", description: "key: id of unifiedRoleDefinition") {
            };
            unifiedRoleDefinitionId1Option.IsRequired = true;
            command.AddOption(unifiedRoleDefinitionId1Option);
            var bodyOption = new Option<string>("--body") {
            };
            bodyOption.IsRequired = true;
            command.AddOption(bodyOption);
            command.SetHandler(async (object[] parameters) => {
                var unifiedRoleDefinitionId = (string) parameters[0];
                var unifiedRoleDefinitionId1 = (string) parameters[1];
                var body = (string) parameters[2];
                var cancellationToken = (CancellationToken) parameters[3];
                PathParameters.Clear();
                PathParameters.Add("unifiedRoleDefinition_id", unifiedRoleDefinitionId);
                PathParameters.Add("unifiedRoleDefinition_id1", unifiedRoleDefinitionId1);
                using var stream = new MemoryStream(Encoding.UTF8.GetBytes(body));
                var parseNode = ParseNodeFactoryRegistry.DefaultInstance.GetRootParseNode("application/json", stream);
                var model = parseNode.GetObjectValue<UnifiedRoleDefinition>(UnifiedRoleDefinition.CreateFromDiscriminatorValue);
                var requestInfo = CreatePatchRequestInformation(model, q => {
                });
                await RequestAdapter.SendNoContentAsync(requestInfo, errorMapping: default, cancellationToken: cancellationToken);
                Console.WriteLine("Success");
            }, new CollectionBinding(unifiedRoleDefinitionIdOption, unifiedRoleDefinitionId1Option, bodyOption, new TypeBinding(typeof(CancellationToken))));
            return command;
        }
        /// <summary>
        /// Instantiates a new UnifiedRoleDefinitionItemRequestBuilder and sets the default values.
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        /// </summary>
        public UnifiedRoleDefinitionItemRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) {
            _ = pathParameters ?? throw new ArgumentNullException(nameof(pathParameters));
            _ = requestAdapter ?? throw new ArgumentNullException(nameof(requestAdapter));
            UrlTemplate = "{+baseurl}/roleManagement/directory/roleDefinitions/{unifiedRoleDefinition_id}/inheritsPermissionsFrom/{unifiedRoleDefinition_id1}{?select,expand}";
            var urlTplParams = new Dictionary<string, object>(pathParameters);
            PathParameters = urlTplParams;
            RequestAdapter = requestAdapter;
        }
        /// <summary>
        /// Read-only collection of role definitions that the given role definition inherits from. Only Azure AD built-in roles support this attribute.
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
        /// Read-only collection of role definitions that the given role definition inherits from. Only Azure AD built-in roles support this attribute.
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
        /// Read-only collection of role definitions that the given role definition inherits from. Only Azure AD built-in roles support this attribute.
        /// <param name="body"></param>
        /// <param name="h">Request headers</param>
        /// <param name="o">Request options</param>
        /// </summary>
        public RequestInformation CreatePatchRequestInformation(UnifiedRoleDefinition body, Action<IDictionary<string, string>> h = default, IEnumerable<IRequestOption> o = default) {
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
        /// <summary>Read-only collection of role definitions that the given role definition inherits from. Only Azure AD built-in roles support this attribute.</summary>
        public class GetQueryParameters : QueryParametersBase {
            /// <summary>Expand related entities</summary>
            public string[] Expand { get; set; }
            /// <summary>Select properties to be returned</summary>
            public string[] Select { get; set; }
        }
    }
}
