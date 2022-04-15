using Markerjs.Blazor.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Markerjs.Blazor.Services
{
    internal class MarkerJSLiveService : IAsyncDisposable, IMarkerJSLive
    {
        private readonly Lazy<Task<IJSObjectReference>> moduleTask;

        public MarkerJSLiveService(IJSRuntime jsRuntime)
        {
            moduleTask = new(() => jsRuntime.InvokeAsync<IJSObjectReference>(
               "import", "./_content/Markerjs.Blazor/MarkerJsLive.export.js").AsTask());
        }
        public async Task ToggleMarkers(string id, ElementReference target, string jsonText)
{
            var config = JsonObject.Parse(jsonText);
            var module = await moduleTask.Value;
            await module.InvokeVoidAsync("showMarkerView", target, config);
        }
        public async ValueTask DisposeAsync()
        {
            if (moduleTask.IsValueCreated)
            {
                var module = await moduleTask.Value;
                await module.DisposeAsync();
            }
        }
    }
}
