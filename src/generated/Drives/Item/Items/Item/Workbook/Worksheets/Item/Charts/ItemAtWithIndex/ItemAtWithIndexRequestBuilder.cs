// <auto-generated/>
using ApiSdk.Drives.Item.Items.Item.Workbook.Worksheets.Item.Charts.ItemAtWithIndex.Axes;
using ApiSdk.Drives.Item.Items.Item.Workbook.Worksheets.Item.Charts.ItemAtWithIndex.DataLabels;
using ApiSdk.Drives.Item.Items.Item.Workbook.Worksheets.Item.Charts.ItemAtWithIndex.Format;
using ApiSdk.Drives.Item.Items.Item.Workbook.Worksheets.Item.Charts.ItemAtWithIndex.Image;
using ApiSdk.Drives.Item.Items.Item.Workbook.Worksheets.Item.Charts.ItemAtWithIndex.ImageWithWidth;
using ApiSdk.Drives.Item.Items.Item.Workbook.Worksheets.Item.Charts.ItemAtWithIndex.ImageWithWidthWithHeight;
using ApiSdk.Drives.Item.Items.Item.Workbook.Worksheets.Item.Charts.ItemAtWithIndex.ImageWithWidthWithHeightWithFittingMode;
using ApiSdk.Drives.Item.Items.Item.Workbook.Worksheets.Item.Charts.ItemAtWithIndex.Legend;
using ApiSdk.Drives.Item.Items.Item.Workbook.Worksheets.Item.Charts.ItemAtWithIndex.Series;
using ApiSdk.Drives.Item.Items.Item.Workbook.Worksheets.Item.Charts.ItemAtWithIndex.SetData;
using ApiSdk.Drives.Item.Items.Item.Workbook.Worksheets.Item.Charts.ItemAtWithIndex.SetPosition;
using ApiSdk.Drives.Item.Items.Item.Workbook.Worksheets.Item.Charts.ItemAtWithIndex.Title;
using ApiSdk.Drives.Item.Items.Item.Workbook.Worksheets.Item.Charts.ItemAtWithIndex.Worksheet;
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
namespace ApiSdk.Drives.Item.Items.Item.Workbook.Worksheets.Item.Charts.ItemAtWithIndex {
    /// <summary>
    /// Provides operations to call the itemAt method.
    /// </summary>
    public class ItemAtWithIndexRequestBuilder : BaseCliRequestBuilder {
        /// <summary>
        /// Provides operations to manage the axes property of the microsoft.graph.workbookChart entity.
        /// </summary>
        public Command BuildAxesNavCommand() {
            var command = new Command("axes");
            command.Description = "Provides operations to manage the axes property of the microsoft.graph.workbookChart entity.";
            var builder = new AxesRequestBuilder(PathParameters);
            var execCommands = new List<Command>();
            execCommands.Add(builder.BuildDeleteCommand());
            execCommands.Add(builder.BuildGetCommand());
            execCommands.Add(builder.BuildPatchCommand());
            foreach (var cmd in execCommands)
            {
                command.AddCommand(cmd);
            }
            return command;
        }
        /// <summary>
        /// Provides operations to manage the dataLabels property of the microsoft.graph.workbookChart entity.
        /// </summary>
        public Command BuildDataLabelsNavCommand() {
            var command = new Command("data-labels");
            command.Description = "Provides operations to manage the dataLabels property of the microsoft.graph.workbookChart entity.";
            var builder = new DataLabelsRequestBuilder(PathParameters);
            var execCommands = new List<Command>();
            execCommands.Add(builder.BuildDeleteCommand());
            execCommands.Add(builder.BuildGetCommand());
            execCommands.Add(builder.BuildPatchCommand());
            foreach (var cmd in execCommands)
            {
                command.AddCommand(cmd);
            }
            return command;
        }
        /// <summary>
        /// Provides operations to manage the format property of the microsoft.graph.workbookChart entity.
        /// </summary>
        public Command BuildFormatNavCommand() {
            var command = new Command("format");
            command.Description = "Provides operations to manage the format property of the microsoft.graph.workbookChart entity.";
            var builder = new FormatRequestBuilder(PathParameters);
            var execCommands = new List<Command>();
            execCommands.Add(builder.BuildDeleteCommand());
            execCommands.Add(builder.BuildGetCommand());
            execCommands.Add(builder.BuildPatchCommand());
            foreach (var cmd in execCommands)
            {
                command.AddCommand(cmd);
            }
            return command;
        }
        /// <summary>
        /// Invoke function itemAt
        /// </summary>
        public Command BuildGetCommand() {
            var command = new Command("get");
            command.Description = "Invoke function itemAt";
            var driveIdOption = new Option<string>("--drive-id", description: "The unique identifier of drive") {
            };
            driveIdOption.IsRequired = true;
            command.AddOption(driveIdOption);
            var driveItemIdOption = new Option<string>("--drive-item-id", description: "The unique identifier of driveItem") {
            };
            driveItemIdOption.IsRequired = true;
            command.AddOption(driveItemIdOption);
            var workbookWorksheetIdOption = new Option<string>("--workbook-worksheet-id", description: "The unique identifier of workbookWorksheet") {
            };
            workbookWorksheetIdOption.IsRequired = true;
            command.AddOption(workbookWorksheetIdOption);
            var indexOption = new Option<int?>("--index", description: "Usage: index={index}") {
            };
            indexOption.IsRequired = true;
            command.AddOption(indexOption);
            var outputOption = new Option<FormatterType>("--output", () => FormatterType.JSON);
            command.AddOption(outputOption);
            var queryOption = new Option<string>("--query");
            command.AddOption(queryOption);
            command.SetHandler(async (invocationContext) => {
                var driveId = invocationContext.ParseResult.GetValueForOption(driveIdOption);
                var driveItemId = invocationContext.ParseResult.GetValueForOption(driveItemIdOption);
                var workbookWorksheetId = invocationContext.ParseResult.GetValueForOption(workbookWorksheetIdOption);
                var index = invocationContext.ParseResult.GetValueForOption(indexOption);
                var output = invocationContext.ParseResult.GetValueForOption(outputOption);
                var query = invocationContext.ParseResult.GetValueForOption(queryOption);
                IOutputFilter outputFilter = invocationContext.BindingContext.GetService(typeof(IOutputFilter)) as IOutputFilter ?? throw new ArgumentNullException("outputFilter");
                IOutputFormatterFactory outputFormatterFactory = invocationContext.BindingContext.GetService(typeof(IOutputFormatterFactory)) as IOutputFormatterFactory ?? throw new ArgumentNullException("outputFormatterFactory");
                var cancellationToken = invocationContext.GetCancellationToken();
                var reqAdapter = invocationContext.GetRequestAdapter();
                var requestInfo = ToGetRequestInformation(q => {
                });
                if (driveId is not null) requestInfo.PathParameters.Add("drive%2Did", driveId);
                if (driveItemId is not null) requestInfo.PathParameters.Add("driveItem%2Did", driveItemId);
                if (workbookWorksheetId is not null) requestInfo.PathParameters.Add("workbookWorksheet%2Did", workbookWorksheetId);
                if (index is not null) requestInfo.PathParameters.Add("index", index);
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
        /// Provides operations to call the image method.
        /// </summary>
        public Command BuildImageNavCommand() {
            var command = new Command("image");
            command.Description = "Provides operations to call the image method.";
            var builder = new ImageRequestBuilder(PathParameters);
            var execCommands = new List<Command>();
            execCommands.Add(builder.BuildGetCommand());
            foreach (var cmd in execCommands)
            {
                command.AddCommand(cmd);
            }
            return command;
        }
        /// <summary>
        /// Provides operations to call the image method.
        /// </summary>
        public Command BuildImageWithWidthRbCommand() {
            var command = new Command("image-with-width");
            command.Description = "Provides operations to call the image method.";
            var builder = new ImageWithWidthRequestBuilder(PathParameters);
            var execCommands = new List<Command>();
            execCommands.Add(builder.BuildGetCommand());
            foreach (var cmd in execCommands)
            {
                command.AddCommand(cmd);
            }
            return command;
        }
        /// <summary>
        /// Provides operations to call the image method.
        /// </summary>
        public Command BuildImageWithWidthWithHeightRbCommand() {
            var command = new Command("image-with-width-with-height");
            command.Description = "Provides operations to call the image method.";
            var builder = new ImageWithWidthWithHeightRequestBuilder(PathParameters);
            var execCommands = new List<Command>();
            execCommands.Add(builder.BuildGetCommand());
            foreach (var cmd in execCommands)
            {
                command.AddCommand(cmd);
            }
            return command;
        }
        /// <summary>
        /// Provides operations to call the image method.
        /// </summary>
        public Command BuildImageWithWidthWithHeightWithFittingModeRbCommand() {
            var command = new Command("image-with-width-with-height-with-fitting-mode");
            command.Description = "Provides operations to call the image method.";
            var builder = new ImageWithWidthWithHeightWithFittingModeRequestBuilder(PathParameters);
            var execCommands = new List<Command>();
            execCommands.Add(builder.BuildGetCommand());
            foreach (var cmd in execCommands)
            {
                command.AddCommand(cmd);
            }
            return command;
        }
        /// <summary>
        /// Provides operations to manage the legend property of the microsoft.graph.workbookChart entity.
        /// </summary>
        public Command BuildLegendNavCommand() {
            var command = new Command("legend");
            command.Description = "Provides operations to manage the legend property of the microsoft.graph.workbookChart entity.";
            var builder = new LegendRequestBuilder(PathParameters);
            var execCommands = new List<Command>();
            execCommands.Add(builder.BuildDeleteCommand());
            execCommands.Add(builder.BuildGetCommand());
            execCommands.Add(builder.BuildPatchCommand());
            foreach (var cmd in execCommands)
            {
                command.AddCommand(cmd);
            }
            return command;
        }
        /// <summary>
        /// Provides operations to manage the series property of the microsoft.graph.workbookChart entity.
        /// </summary>
        public Command BuildSeriesNavCommand() {
            var command = new Command("series");
            command.Description = "Provides operations to manage the series property of the microsoft.graph.workbookChart entity.";
            var builder = new SeriesRequestBuilder(PathParameters);
            var execCommands = new List<Command>();
            execCommands.Add(builder.BuildGetCommand());
            execCommands.Add(builder.BuildPostCommand());
            foreach (var cmd in execCommands)
            {
                command.AddCommand(cmd);
            }
            return command;
        }
        /// <summary>
        /// Provides operations to call the setData method.
        /// </summary>
        public Command BuildSetDataNavCommand() {
            var command = new Command("set-data");
            command.Description = "Provides operations to call the setData method.";
            var builder = new SetDataRequestBuilder(PathParameters);
            var execCommands = new List<Command>();
            execCommands.Add(builder.BuildPostCommand());
            foreach (var cmd in execCommands)
            {
                command.AddCommand(cmd);
            }
            return command;
        }
        /// <summary>
        /// Provides operations to call the setPosition method.
        /// </summary>
        public Command BuildSetPositionNavCommand() {
            var command = new Command("set-position");
            command.Description = "Provides operations to call the setPosition method.";
            var builder = new SetPositionRequestBuilder(PathParameters);
            var execCommands = new List<Command>();
            execCommands.Add(builder.BuildPostCommand());
            foreach (var cmd in execCommands)
            {
                command.AddCommand(cmd);
            }
            return command;
        }
        /// <summary>
        /// Provides operations to manage the title property of the microsoft.graph.workbookChart entity.
        /// </summary>
        public Command BuildTitleNavCommand() {
            var command = new Command("title");
            command.Description = "Provides operations to manage the title property of the microsoft.graph.workbookChart entity.";
            var builder = new TitleRequestBuilder(PathParameters);
            var execCommands = new List<Command>();
            execCommands.Add(builder.BuildDeleteCommand());
            execCommands.Add(builder.BuildGetCommand());
            execCommands.Add(builder.BuildPatchCommand());
            foreach (var cmd in execCommands)
            {
                command.AddCommand(cmd);
            }
            return command;
        }
        /// <summary>
        /// Provides operations to manage the worksheet property of the microsoft.graph.workbookChart entity.
        /// </summary>
        public Command BuildWorksheetNavCommand() {
            var command = new Command("worksheet");
            command.Description = "Provides operations to manage the worksheet property of the microsoft.graph.workbookChart entity.";
            var builder = new WorksheetRequestBuilder(PathParameters);
            var execCommands = new List<Command>();
            execCommands.Add(builder.BuildGetCommand());
            foreach (var cmd in execCommands)
            {
                command.AddCommand(cmd);
            }
            return command;
        }
        /// <summary>
        /// Instantiates a new ItemAtWithIndexRequestBuilder and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        public ItemAtWithIndexRequestBuilder(Dictionary<string, object> pathParameters) : base("{+baseurl}/drives/{drive%2Did}/items/{driveItem%2Did}/workbook/worksheets/{workbookWorksheet%2Did}/charts/itemAt(index={index})", pathParameters) {
        }
        /// <summary>
        /// Instantiates a new ItemAtWithIndexRequestBuilder and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        public ItemAtWithIndexRequestBuilder(string rawUrl) : base("{+baseurl}/drives/{drive%2Did}/items/{driveItem%2Did}/workbook/worksheets/{workbookWorksheet%2Did}/charts/itemAt(index={index})", rawUrl) {
        }
        /// <summary>
        /// Invoke function itemAt
        /// </summary>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public RequestInformation ToGetRequestInformation(Action<RequestConfiguration<DefaultQueryParameters>>? requestConfiguration = default) {
#nullable restore
#else
        public RequestInformation ToGetRequestInformation(Action<RequestConfiguration<DefaultQueryParameters>> requestConfiguration = default) {
#endif
            var requestInfo = new RequestInformation(Method.GET, UrlTemplate, PathParameters);
            requestInfo.Configure(requestConfiguration);
            requestInfo.Headers.TryAdd("Accept", "application/json");
            return requestInfo;
        }
    }
}
