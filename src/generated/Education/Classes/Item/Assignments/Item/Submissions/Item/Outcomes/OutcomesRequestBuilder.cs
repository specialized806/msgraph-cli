// <auto-generated/>
using ApiSdk.Education.Classes.Item.Assignments.Item.Submissions.Item.Outcomes.Count;
using ApiSdk.Education.Classes.Item.Assignments.Item.Submissions.Item.Outcomes.Item;
using ApiSdk.Models.ODataErrors;
using ApiSdk.Models;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Cli.Commons.Extensions;
using Microsoft.Kiota.Cli.Commons.IO;
using Microsoft.Kiota.Cli.Commons;
using System.Collections.Generic;
using System.CommandLine;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System;
namespace ApiSdk.Education.Classes.Item.Assignments.Item.Submissions.Item.Outcomes {
    /// <summary>
    /// Provides operations to manage the outcomes property of the microsoft.graph.educationSubmission entity.
    /// </summary>
    public class OutcomesRequestBuilder : BaseCliRequestBuilder 
    {
        /// <summary>
        /// Provides operations to manage the outcomes property of the microsoft.graph.educationSubmission entity.
        /// </summary>
        /// <returns>A Tuple&lt;List&lt;Command&gt;, List&lt;Command&gt;&gt;</returns>
        public Tuple<List<Command>, List<Command>> BuildCommand()
        {
            var executables = new List<Command>();
            var builder = new EducationOutcomeItemRequestBuilder(PathParameters);
            executables.Add(builder.BuildDeleteCommand());
            executables.Add(builder.BuildGetCommand());
            executables.Add(builder.BuildPatchCommand());
            return new(executables, new(0));
        }
        /// <summary>
        /// Provides operations to count the resources in the collection.
        /// </summary>
        /// <returns>A <see cref="Command"/></returns>
        public Command BuildCountNavCommand()
        {
            var command = new Command("count");
            command.Description = "Provides operations to count the resources in the collection.";
            var builder = new CountRequestBuilder(PathParameters);
            var execCommands = new List<Command>();
            execCommands.Add(builder.BuildGetCommand());
            foreach (var cmd in execCommands)
            {
                command.AddCommand(cmd);
            }
            return command;
        }
        /// <summary>
        /// Create a new feedback resource for a submission. Only a teacher can perform this operation. To create a new file-based resource, upload the file to the feedback resources folder associated with the assignment. If the file doesn&apos;t exist or isn&apos;t in that folder, the POST request will fail.
        /// Find more info here <see href="https://learn.microsoft.com/graph/api/educationfeedbackresourceoutcome-post-outcomes?view=graph-rest-1.0" />
        /// </summary>
        /// <returns>A <see cref="Command"/></returns>
        public Command BuildCreateCommand()
        {
            var command = new Command("create");
            command.Description = "Create a new feedback resource for a submission. Only a teacher can perform this operation. To create a new file-based resource, upload the file to the feedback resources folder associated with the assignment. If the file doesn't exist or isn't in that folder, the POST request will fail.\n\nFind more info here:\n  https://learn.microsoft.com/graph/api/educationfeedbackresourceoutcome-post-outcomes?view=graph-rest-1.0";
            var educationClassIdOption = new Option<string>("--education-class-id", description: "The unique identifier of educationClass") {
            };
            educationClassIdOption.IsRequired = true;
            command.AddOption(educationClassIdOption);
            var educationAssignmentIdOption = new Option<string>("--education-assignment-id", description: "The unique identifier of educationAssignment") {
            };
            educationAssignmentIdOption.IsRequired = true;
            command.AddOption(educationAssignmentIdOption);
            var educationSubmissionIdOption = new Option<string>("--education-submission-id", description: "The unique identifier of educationSubmission") {
            };
            educationSubmissionIdOption.IsRequired = true;
            command.AddOption(educationSubmissionIdOption);
            var bodyOption = new Option<string>("--body", description: "The request body") {
            };
            bodyOption.IsRequired = true;
            command.AddOption(bodyOption);
            var outputOption = new Option<FormatterType>("--output", () => FormatterType.JSON);
            command.AddOption(outputOption);
            var queryOption = new Option<string>("--query");
            command.AddOption(queryOption);
            command.SetHandler(async (invocationContext) => {
                var educationClassId = invocationContext.ParseResult.GetValueForOption(educationClassIdOption);
                var educationAssignmentId = invocationContext.ParseResult.GetValueForOption(educationAssignmentIdOption);
                var educationSubmissionId = invocationContext.ParseResult.GetValueForOption(educationSubmissionIdOption);
                var body = invocationContext.ParseResult.GetValueForOption(bodyOption) ?? string.Empty;
                var output = invocationContext.ParseResult.GetValueForOption(outputOption);
                var query = invocationContext.ParseResult.GetValueForOption(queryOption);
                IOutputFilter outputFilter = invocationContext.BindingContext.GetService(typeof(IOutputFilter)) as IOutputFilter ?? throw new ArgumentNullException("outputFilter");
                IOutputFormatterFactory outputFormatterFactory = invocationContext.BindingContext.GetService(typeof(IOutputFormatterFactory)) as IOutputFormatterFactory ?? throw new ArgumentNullException("outputFormatterFactory");
                var cancellationToken = invocationContext.GetCancellationToken();
                var reqAdapter = invocationContext.GetRequestAdapter();
                using var stream = new MemoryStream(Encoding.UTF8.GetBytes(body));
                var parseNode = ParseNodeFactoryRegistry.DefaultInstance.GetRootParseNode("application/json", stream);
                var model = parseNode.GetObjectValue<EducationOutcome>(EducationOutcome.CreateFromDiscriminatorValue);
                if (model is null) {
                    Console.Error.WriteLine("No model data to send.");
                    return;
                }
                var requestInfo = ToPostRequestInformation(model, q => {
                });
                if (educationClassId is not null) requestInfo.PathParameters.Add("educationClass%2Did", educationClassId);
                if (educationAssignmentId is not null) requestInfo.PathParameters.Add("educationAssignment%2Did", educationAssignmentId);
                if (educationSubmissionId is not null) requestInfo.PathParameters.Add("educationSubmission%2Did", educationSubmissionId);
                requestInfo.SetContentFromParsable(reqAdapter, "application/json", model);
                var errorMapping = new Dictionary<string, ParsableFactory<IParsable>> {
                    {"4XX", ODataError.CreateFromDiscriminatorValue},
                    {"5XX", ODataError.CreateFromDiscriminatorValue},
                };
                var response = await reqAdapter.SendPrimitiveAsync<Stream>(requestInfo, errorMapping: errorMapping, cancellationToken: cancellationToken) ?? Stream.Null;
                response = (response != Stream.Null) ? await outputFilter.FilterOutputAsync(response, query, cancellationToken) : response;
                var formatter = outputFormatterFactory.GetFormatter(output);
                await formatter.WriteOutputAsync(response, cancellationToken);
            });
            return command;
        }
        /// <summary>
        /// Retrieve a list of educationOutcome objects. There are four types of outcomes: educationPointsOutcome, educationFeedbackOutcome, educationRubricOutcome, and educationFeedbackResourceOutcome. Only teachers, students, and applications with application permissions can perform this operation. A submission for a credit assignment (one that has no point value and no rubric) has an educationFeedbackOutcome. (It might also return an educationPointsOutcome, but that outcome is ignored.) A submission for a points assignment (one that has a point value assigned) has both an educationFeedbackOutcome and an educationPointsOutcome. A submission for an assignment with an attached rubric, if the rubric is a credit rubric (no points), has an educationFeedbackOutcome and an educationRubricOutcome. (It might also return an educationPointsOutcome, but that outcome is ignored.) A submission for an assignment with an attached rubric, if the rubric is a points rubric, has an educationFeedbackOutcome, an educationPointsOutcome, and an educationRubricOutcome. A submission for a feedback resource has an educationFeedbackResourceOutcome. All outcome types have a regular and a published property appropriate to that type of outcome; for example, points and publishedPoints, feedback and publishedFeedback. The regular property is the most recent value updated by the teacher; the published property is the most recent value returned to the student.
        /// Find more info here <see href="https://learn.microsoft.com/graph/api/educationsubmission-list-outcomes?view=graph-rest-1.0" />
        /// </summary>
        /// <returns>A <see cref="Command"/></returns>
        public Command BuildListCommand()
        {
            var command = new Command("list");
            command.Description = "Retrieve a list of educationOutcome objects. There are four types of outcomes: educationPointsOutcome, educationFeedbackOutcome, educationRubricOutcome, and educationFeedbackResourceOutcome. Only teachers, students, and applications with application permissions can perform this operation. A submission for a credit assignment (one that has no point value and no rubric) has an educationFeedbackOutcome. (It might also return an educationPointsOutcome, but that outcome is ignored.) A submission for a points assignment (one that has a point value assigned) has both an educationFeedbackOutcome and an educationPointsOutcome. A submission for an assignment with an attached rubric, if the rubric is a credit rubric (no points), has an educationFeedbackOutcome and an educationRubricOutcome. (It might also return an educationPointsOutcome, but that outcome is ignored.) A submission for an assignment with an attached rubric, if the rubric is a points rubric, has an educationFeedbackOutcome, an educationPointsOutcome, and an educationRubricOutcome. A submission for a feedback resource has an educationFeedbackResourceOutcome. All outcome types have a regular and a published property appropriate to that type of outcome; for example, points and publishedPoints, feedback and publishedFeedback. The regular property is the most recent value updated by the teacher; the published property is the most recent value returned to the student.\n\nFind more info here:\n  https://learn.microsoft.com/graph/api/educationsubmission-list-outcomes?view=graph-rest-1.0";
            var educationClassIdOption = new Option<string>("--education-class-id", description: "The unique identifier of educationClass") {
            };
            educationClassIdOption.IsRequired = true;
            command.AddOption(educationClassIdOption);
            var educationAssignmentIdOption = new Option<string>("--education-assignment-id", description: "The unique identifier of educationAssignment") {
            };
            educationAssignmentIdOption.IsRequired = true;
            command.AddOption(educationAssignmentIdOption);
            var educationSubmissionIdOption = new Option<string>("--education-submission-id", description: "The unique identifier of educationSubmission") {
            };
            educationSubmissionIdOption.IsRequired = true;
            command.AddOption(educationSubmissionIdOption);
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
            var outputOption = new Option<FormatterType>("--output", () => FormatterType.JSON);
            command.AddOption(outputOption);
            var queryOption = new Option<string>("--query");
            command.AddOption(queryOption);
            var allOption = new Option<bool>("--all");
            command.AddOption(allOption);
            command.SetHandler(async (invocationContext) => {
                var educationClassId = invocationContext.ParseResult.GetValueForOption(educationClassIdOption);
                var educationAssignmentId = invocationContext.ParseResult.GetValueForOption(educationAssignmentIdOption);
                var educationSubmissionId = invocationContext.ParseResult.GetValueForOption(educationSubmissionIdOption);
                var top = invocationContext.ParseResult.GetValueForOption(topOption);
                var skip = invocationContext.ParseResult.GetValueForOption(skipOption);
                var search = invocationContext.ParseResult.GetValueForOption(searchOption);
                var filter = invocationContext.ParseResult.GetValueForOption(filterOption);
                var count = invocationContext.ParseResult.GetValueForOption(countOption);
                var orderby = invocationContext.ParseResult.GetValueForOption(orderbyOption);
                var select = invocationContext.ParseResult.GetValueForOption(selectOption);
                var expand = invocationContext.ParseResult.GetValueForOption(expandOption);
                var output = invocationContext.ParseResult.GetValueForOption(outputOption);
                var query = invocationContext.ParseResult.GetValueForOption(queryOption);
                var all = invocationContext.ParseResult.GetValueForOption(allOption);
                IOutputFilter outputFilter = invocationContext.BindingContext.GetService(typeof(IOutputFilter)) as IOutputFilter ?? throw new ArgumentNullException("outputFilter");
                IOutputFormatterFactory outputFormatterFactory = invocationContext.BindingContext.GetService(typeof(IOutputFormatterFactory)) as IOutputFormatterFactory ?? throw new ArgumentNullException("outputFormatterFactory");
                IPagingService pagingService = invocationContext.BindingContext.GetService(typeof(IPagingService)) as IPagingService ?? throw new ArgumentNullException("pagingService");
                var cancellationToken = invocationContext.GetCancellationToken();
                var reqAdapter = invocationContext.GetRequestAdapter();
                var requestInfo = ToGetRequestInformation(q => {
                    q.QueryParameters.Top = top;
                    q.QueryParameters.Skip = skip;
                    if (!string.IsNullOrEmpty(search)) q.QueryParameters.Search = search;
                    if (!string.IsNullOrEmpty(filter)) q.QueryParameters.Filter = filter;
                    q.QueryParameters.Count = count;
                    q.QueryParameters.Orderby = orderby;
                    q.QueryParameters.Select = select;
                    q.QueryParameters.Expand = expand;
                });
                if (educationClassId is not null) requestInfo.PathParameters.Add("educationClass%2Did", educationClassId);
                if (educationAssignmentId is not null) requestInfo.PathParameters.Add("educationAssignment%2Did", educationAssignmentId);
                if (educationSubmissionId is not null) requestInfo.PathParameters.Add("educationSubmission%2Did", educationSubmissionId);
                var errorMapping = new Dictionary<string, ParsableFactory<IParsable>> {
                    {"4XX", ODataError.CreateFromDiscriminatorValue},
                    {"5XX", ODataError.CreateFromDiscriminatorValue},
                };
                var pagingData = new PageLinkData(requestInfo, null, itemName: "value", nextLinkName: "@odata.nextLink");
                var pageResponse = await pagingService.GetPagedDataAsync((info, token) => reqAdapter.SendNoContentAsync(info, cancellationToken: token), pagingData, all, cancellationToken);
                var response = pageResponse?.Response;
                IOutputFormatter? formatter = null;
                if (pageResponse?.StatusCode >= 200 && pageResponse?.StatusCode < 300) {
                    formatter = outputFormatterFactory.GetFormatter(output);
                    response = (response != Stream.Null) ? await outputFilter.FilterOutputAsync(response, query, cancellationToken) : response;
                } else {
                    formatter = outputFormatterFactory.GetFormatter(FormatterType.TEXT);
                }
                await formatter.WriteOutputAsync(response, cancellationToken);
            });
            return command;
        }
        /// <summary>
        /// Instantiates a new <see cref="OutcomesRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        public OutcomesRequestBuilder(Dictionary<string, object> pathParameters) : base("{+baseurl}/education/classes/{educationClass%2Did}/assignments/{educationAssignment%2Did}/submissions/{educationSubmission%2Did}/outcomes{?%24count,%24expand,%24filter,%24orderby,%24search,%24select,%24skip,%24top}", pathParameters)
        {
        }
        /// <summary>
        /// Instantiates a new <see cref="OutcomesRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        public OutcomesRequestBuilder(string rawUrl) : base("{+baseurl}/education/classes/{educationClass%2Did}/assignments/{educationAssignment%2Did}/submissions/{educationSubmission%2Did}/outcomes{?%24count,%24expand,%24filter,%24orderby,%24search,%24select,%24skip,%24top}", rawUrl)
        {
        }
        /// <summary>
        /// Retrieve a list of educationOutcome objects. There are four types of outcomes: educationPointsOutcome, educationFeedbackOutcome, educationRubricOutcome, and educationFeedbackResourceOutcome. Only teachers, students, and applications with application permissions can perform this operation. A submission for a credit assignment (one that has no point value and no rubric) has an educationFeedbackOutcome. (It might also return an educationPointsOutcome, but that outcome is ignored.) A submission for a points assignment (one that has a point value assigned) has both an educationFeedbackOutcome and an educationPointsOutcome. A submission for an assignment with an attached rubric, if the rubric is a credit rubric (no points), has an educationFeedbackOutcome and an educationRubricOutcome. (It might also return an educationPointsOutcome, but that outcome is ignored.) A submission for an assignment with an attached rubric, if the rubric is a points rubric, has an educationFeedbackOutcome, an educationPointsOutcome, and an educationRubricOutcome. A submission for a feedback resource has an educationFeedbackResourceOutcome. All outcome types have a regular and a published property appropriate to that type of outcome; for example, points and publishedPoints, feedback and publishedFeedback. The regular property is the most recent value updated by the teacher; the published property is the most recent value returned to the student.
        /// </summary>
        /// <returns>A <see cref="RequestInformation"/></returns>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public RequestInformation ToGetRequestInformation(Action<RequestConfiguration<OutcomesRequestBuilderGetQueryParameters>>? requestConfiguration = default)
        {
#nullable restore
#else
        public RequestInformation ToGetRequestInformation(Action<RequestConfiguration<OutcomesRequestBuilderGetQueryParameters>> requestConfiguration = default)
        {
#endif
            var requestInfo = new RequestInformation(Method.GET, UrlTemplate, PathParameters);
            requestInfo.Configure(requestConfiguration);
            requestInfo.Headers.TryAdd("Accept", "application/json");
            return requestInfo;
        }
        /// <summary>
        /// Create a new feedback resource for a submission. Only a teacher can perform this operation. To create a new file-based resource, upload the file to the feedback resources folder associated with the assignment. If the file doesn&apos;t exist or isn&apos;t in that folder, the POST request will fail.
        /// </summary>
        /// <returns>A <see cref="RequestInformation"/></returns>
        /// <param name="body">The request body</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public RequestInformation ToPostRequestInformation(EducationOutcome body, Action<RequestConfiguration<DefaultQueryParameters>>? requestConfiguration = default)
        {
#nullable restore
#else
        public RequestInformation ToPostRequestInformation(EducationOutcome body, Action<RequestConfiguration<DefaultQueryParameters>> requestConfiguration = default)
        {
#endif
            _ = body ?? throw new ArgumentNullException(nameof(body));
            var requestInfo = new RequestInformation(Method.POST, UrlTemplate, PathParameters);
            requestInfo.Configure(requestConfiguration);
            requestInfo.Headers.TryAdd("Accept", "application/json");
            return requestInfo;
        }
        /// <summary>
        /// Retrieve a list of educationOutcome objects. There are four types of outcomes: educationPointsOutcome, educationFeedbackOutcome, educationRubricOutcome, and educationFeedbackResourceOutcome. Only teachers, students, and applications with application permissions can perform this operation. A submission for a credit assignment (one that has no point value and no rubric) has an educationFeedbackOutcome. (It might also return an educationPointsOutcome, but that outcome is ignored.) A submission for a points assignment (one that has a point value assigned) has both an educationFeedbackOutcome and an educationPointsOutcome. A submission for an assignment with an attached rubric, if the rubric is a credit rubric (no points), has an educationFeedbackOutcome and an educationRubricOutcome. (It might also return an educationPointsOutcome, but that outcome is ignored.) A submission for an assignment with an attached rubric, if the rubric is a points rubric, has an educationFeedbackOutcome, an educationPointsOutcome, and an educationRubricOutcome. A submission for a feedback resource has an educationFeedbackResourceOutcome. All outcome types have a regular and a published property appropriate to that type of outcome; for example, points and publishedPoints, feedback and publishedFeedback. The regular property is the most recent value updated by the teacher; the published property is the most recent value returned to the student.
        /// </summary>
        public class OutcomesRequestBuilderGetQueryParameters 
        {
            /// <summary>Include count of items</summary>
            [QueryParameter("%24count")]
            public bool? Count { get; set; }
            /// <summary>Expand related entities</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            [QueryParameter("%24expand")]
            public string[]? Expand { get; set; }
#nullable restore
#else
            [QueryParameter("%24expand")]
            public string[] Expand { get; set; }
#endif
            /// <summary>Filter items by property values</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            [QueryParameter("%24filter")]
            public string? Filter { get; set; }
#nullable restore
#else
            [QueryParameter("%24filter")]
            public string Filter { get; set; }
#endif
            /// <summary>Order items by property values</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            [QueryParameter("%24orderby")]
            public string[]? Orderby { get; set; }
#nullable restore
#else
            [QueryParameter("%24orderby")]
            public string[] Orderby { get; set; }
#endif
            /// <summary>Search items by search phrases</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            [QueryParameter("%24search")]
            public string? Search { get; set; }
#nullable restore
#else
            [QueryParameter("%24search")]
            public string Search { get; set; }
#endif
            /// <summary>Select properties to be returned</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            [QueryParameter("%24select")]
            public string[]? Select { get; set; }
#nullable restore
#else
            [QueryParameter("%24select")]
            public string[] Select { get; set; }
#endif
            /// <summary>Skip the first n items</summary>
            [QueryParameter("%24skip")]
            public int? Skip { get; set; }
            /// <summary>Show only the first n items</summary>
            [QueryParameter("%24top")]
            public int? Top { get; set; }
        }
    }
}
