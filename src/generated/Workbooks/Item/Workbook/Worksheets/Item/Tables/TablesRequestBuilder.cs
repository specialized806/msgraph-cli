using ApiSdk.Models.Microsoft.Graph;
using ApiSdk.Workbooks.Item.Workbook.Worksheets.Item.Tables.Add;
using ApiSdk.Workbooks.Item.Workbook.Worksheets.Item.Tables.Count;
using ApiSdk.Workbooks.Item.Workbook.Worksheets.Item.Tables.Item;
using ApiSdk.Workbooks.Item.Workbook.Worksheets.Item.Tables.ItemAtWithIndex;
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
namespace ApiSdk.Workbooks.Item.Workbook.Worksheets.Item.Tables {
    /// <summary>Builds and executes requests for operations under \workbooks\{driveItem-id}\workbook\worksheets\{workbookWorksheet-id}\tables</summary>
    public class TablesRequestBuilder {
        /// <summary>Path parameters for the request</summary>
        private Dictionary<string, object> PathParameters { get; set; }
        /// <summary>The request adapter to use to execute the requests.</summary>
        private IRequestAdapter RequestAdapter { get; set; }
        /// <summary>Url template to use to build the URL for the current request builder</summary>
        private string UrlTemplate { get; set; }
        public Command BuildAddCommand() {
            var command = new Command("add");
            var builder = new ApiSdk.Workbooks.Item.Workbook.Worksheets.Item.Tables.Add.AddRequestBuilder(PathParameters, RequestAdapter);
            command.AddCommand(builder.BuildPostCommand());
            return command;
        }
        public List<Command> BuildCommand() {
            var builder = new WorkbookTableItemRequestBuilder(PathParameters, RequestAdapter);
            var commands = new List<Command>();
            commands.Add(builder.BuildClearFiltersCommand());
            commands.Add(builder.BuildColumnsCommand());
            commands.Add(builder.BuildConvertToRangeCommand());
            commands.Add(builder.BuildDeleteCommand());
            commands.Add(builder.BuildGetCommand());
            commands.Add(builder.BuildPatchCommand());
            commands.Add(builder.BuildReapplyFiltersCommand());
            commands.Add(builder.BuildRowsCommand());
            commands.Add(builder.BuildSortCommand());
            commands.Add(builder.BuildWorksheetCommand());
            return commands;
        }
        /// <summary>
        /// Collection of tables that are part of the worksheet. Read-only.
        /// </summary>
        public Command BuildCreateCommand() {
            var command = new Command("create");
            command.Description = "Collection of tables that are part of the worksheet. Read-only.";
            // Create options for all the parameters
            var driveItemIdOption = new Option<string>("--drive-item-id", description: "key: id of driveItem") {
            };
            driveItemIdOption.IsRequired = true;
            command.AddOption(driveItemIdOption);
            var workbookWorksheetIdOption = new Option<string>("--workbook-worksheet-id", description: "key: id of workbookWorksheet") {
            };
            workbookWorksheetIdOption.IsRequired = true;
            command.AddOption(workbookWorksheetIdOption);
            var bodyOption = new Option<string>("--body") {
            };
            bodyOption.IsRequired = true;
            command.AddOption(bodyOption);
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
                var driveItemId = (string) parameters[0];
                var workbookWorksheetId = (string) parameters[1];
                var body = (string) parameters[2];
                var output = (FormatterType) parameters[3];
                var query = (string) parameters[4];
                var jsonNoIndent = (bool) parameters[5];
                var outputFilter = (IOutputFilter) parameters[6];
                var outputFormatterFactory = (IOutputFormatterFactory) parameters[7];
                var cancellationToken = (CancellationToken) parameters[8];
                PathParameters.Clear();
                PathParameters.Add("driveItem_id", driveItemId);
                PathParameters.Add("workbookWorksheet_id", workbookWorksheetId);
                using var stream = new MemoryStream(Encoding.UTF8.GetBytes(body));
                var parseNode = ParseNodeFactoryRegistry.DefaultInstance.GetRootParseNode("application/json", stream);
                var model = parseNode.GetObjectValue<WorkbookTable>(WorkbookTable.CreateFromDiscriminatorValue);
                var requestInfo = CreatePostRequestInformation(model, q => {
                });
                var response = await RequestAdapter.SendPrimitiveAsync<Stream>(requestInfo, errorMapping: default, cancellationToken: cancellationToken);
                var formatter = outputFormatterFactory.GetFormatter(output);
                response = await outputFilter?.FilterOutputAsync(response, query, cancellationToken) ?? response;
                var formatterOptions = output.GetOutputFormatterOptions(new FormatterOptionsModel(!jsonNoIndent));
                await formatter.WriteOutputAsync(response, formatterOptions, cancellationToken);
            }, new CollectionBinding(driveItemIdOption, workbookWorksheetIdOption, bodyOption, outputOption, queryOption, jsonNoIndentOption, new TypeBinding(typeof(IOutputFilter)), new TypeBinding(typeof(IOutputFormatterFactory)), new TypeBinding(typeof(CancellationToken))));
            return command;
        }
        /// <summary>
        /// Collection of tables that are part of the worksheet. Read-only.
        /// </summary>
        public Command BuildListCommand() {
            var command = new Command("list");
            command.Description = "Collection of tables that are part of the worksheet. Read-only.";
            // Create options for all the parameters
            var driveItemIdOption = new Option<string>("--drive-item-id", description: "key: id of driveItem") {
            };
            driveItemIdOption.IsRequired = true;
            command.AddOption(driveItemIdOption);
            var workbookWorksheetIdOption = new Option<string>("--workbook-worksheet-id", description: "key: id of workbookWorksheet") {
            };
            workbookWorksheetIdOption.IsRequired = true;
            command.AddOption(workbookWorksheetIdOption);
            var topOption = new Option<int?>("--top", description: "Show only the first n items") {
            };
            topOption.IsRequired = false;
            command.AddOption(topOption);
            var skipOption = new Option<int?>("--skip", description: "Skip the first n items") {
            };
            skipOption.IsRequired = false;
            command.AddOption(skipOption);
            var searchOption = new Option<string>("--search", description: "Search items by search phrases") {
            };
            searchOption.IsRequired = false;
            command.AddOption(searchOption);
            var filterOption = new Option<string>("--filter", description: "Filter items by property values") {
            };
            filterOption.IsRequired = false;
            command.AddOption(filterOption);
            var countOption = new Option<bool?>("--count", description: "Include count of items") {
            };
            countOption.IsRequired = false;
            command.AddOption(countOption);
            var orderbyOption = new Option<string[]>("--orderby", description: "Order items by property values") {
                Arity = ArgumentArity.ZeroOrMore
            };
            orderbyOption.IsRequired = false;
            command.AddOption(orderbyOption);
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
                var driveItemId = (string) parameters[0];
                var workbookWorksheetId = (string) parameters[1];
                var top = (int?) parameters[2];
                var skip = (int?) parameters[3];
                var search = (string) parameters[4];
                var filter = (string) parameters[5];
                var count = (bool?) parameters[6];
                var orderby = (string[]) parameters[7];
                var select = (string[]) parameters[8];
                var expand = (string[]) parameters[9];
                var output = (FormatterType) parameters[10];
                var query = (string) parameters[11];
                var jsonNoIndent = (bool) parameters[12];
                var outputFilter = (IOutputFilter) parameters[13];
                var outputFormatterFactory = (IOutputFormatterFactory) parameters[14];
                var cancellationToken = (CancellationToken) parameters[15];
                PathParameters.Clear();
                PathParameters.Add("driveItem_id", driveItemId);
                PathParameters.Add("workbookWorksheet_id", workbookWorksheetId);
                var requestInfo = CreateGetRequestInformation(q => {
                    q.Top = top;
                    q.Skip = skip;
                    if (!String.IsNullOrEmpty(search)) q.Search = search;
                    if (!String.IsNullOrEmpty(filter)) q.Filter = filter;
                    q.Count = count;
                    q.Orderby = orderby;
                    q.Select = select;
                    q.Expand = expand;
                });
                var response = await RequestAdapter.SendPrimitiveAsync<Stream>(requestInfo, errorMapping: default, cancellationToken: cancellationToken);
                var formatter = outputFormatterFactory.GetFormatter(output);
                response = await outputFilter?.FilterOutputAsync(response, query, cancellationToken) ?? response;
                var formatterOptions = output.GetOutputFormatterOptions(new FormatterOptionsModel(!jsonNoIndent));
                await formatter.WriteOutputAsync(response, formatterOptions, cancellationToken);
            }, new CollectionBinding(driveItemIdOption, workbookWorksheetIdOption, topOption, skipOption, searchOption, filterOption, countOption, orderbyOption, selectOption, expandOption, outputOption, queryOption, jsonNoIndentOption, new TypeBinding(typeof(IOutputFilter)), new TypeBinding(typeof(IOutputFormatterFactory)), new TypeBinding(typeof(CancellationToken))));
            return command;
        }
        /// <summary>
        /// Instantiates a new TablesRequestBuilder and sets the default values.
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        /// </summary>
        public TablesRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) {
            _ = pathParameters ?? throw new ArgumentNullException(nameof(pathParameters));
            _ = requestAdapter ?? throw new ArgumentNullException(nameof(requestAdapter));
            UrlTemplate = "{+baseurl}/workbooks/{driveItem_id}/workbook/worksheets/{workbookWorksheet_id}/tables{?top,skip,search,filter,count,orderby,select,expand}";
            var urlTplParams = new Dictionary<string, object>(pathParameters);
            PathParameters = urlTplParams;
            RequestAdapter = requestAdapter;
        }
        /// <summary>
        /// Builds and executes requests for operations under \workbooks\{driveItem-id}\workbook\worksheets\{workbookWorksheet-id}\tables\microsoft.graph.count()
        /// </summary>
        public CountRequestBuilder Count() {
            return new CountRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>
        /// Collection of tables that are part of the worksheet. Read-only.
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
        /// Collection of tables that are part of the worksheet. Read-only.
        /// <param name="body"></param>
        /// <param name="h">Request headers</param>
        /// <param name="o">Request options</param>
        /// </summary>
        public RequestInformation CreatePostRequestInformation(WorkbookTable body, Action<IDictionary<string, string>> h = default, IEnumerable<IRequestOption> o = default) {
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
        /// Builds and executes requests for operations under \workbooks\{driveItem-id}\workbook\worksheets\{workbookWorksheet-id}\tables\microsoft.graph.itemAt(index={index})
        /// <param name="index">Usage: index={index}</param>
        /// </summary>
        public ItemAtWithIndexRequestBuilder ItemAtWithIndex(int? index) {
            _ = index ?? throw new ArgumentNullException(nameof(index));
            return new ItemAtWithIndexRequestBuilder(PathParameters, RequestAdapter, index);
        }
        /// <summary>Collection of tables that are part of the worksheet. Read-only.</summary>
        public class GetQueryParameters : QueryParametersBase {
            /// <summary>Include count of items</summary>
            public bool? Count { get; set; }
            /// <summary>Expand related entities</summary>
            public string[] Expand { get; set; }
            /// <summary>Filter items by property values</summary>
            public string Filter { get; set; }
            /// <summary>Order items by property values</summary>
            public string[] Orderby { get; set; }
            /// <summary>Search items by search phrases</summary>
            public string Search { get; set; }
            /// <summary>Select properties to be returned</summary>
            public string[] Select { get; set; }
            /// <summary>Skip the first n items</summary>
            public int? Skip { get; set; }
            /// <summary>Show only the first n items</summary>
            public int? Top { get; set; }
        }
    }
}
