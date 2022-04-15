using Markerjs.Blazor.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace Markerjs.Blazor.Services
{
    internal class MarkerJSService : IAsyncDisposable, IMarkerJS
    {
        private readonly Lazy<Task<IJSObjectReference>> moduleTask;

        public MarkerJSService(IJSRuntime jsRuntime)
        {
            moduleTask = new(() => jsRuntime.InvokeAsync<IJSObjectReference>(
               "import", "./_content/Markerjs.Blazor/MarkerJs.export.js").AsTask());
        }

        public async Task SetSourceImage(ElementReference target, string id)
        {
            var module = await moduleTask.Value;
            await module.InvokeVoidAsync("setSourceImage", target, id);
        }
        public async Task ShowMarkerArea(ElementReference target, string id)
        {
            var module = await moduleTask.Value;
            await module.InvokeVoidAsync("showMarkerArea", target, id);
        }

        public async Task<JsonObject> GetConfigFromMarkerArea(string id)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<JsonObject>("GetConfigFromMarkerArea", id);
        }

        public async Task LoadConfigToMarkerView(string id, JsonObject config)
        {
            var module = await moduleTask.Value;
            await module.InvokeVoidAsync("LoadConfigToMarkerView", id, config);
        }

        public async Task ShowMarkerView(ElementReference target, JsonObject config)
        {
            var module = await moduleTask.Value;
            await module.InvokeVoidAsync("showMarkerView", target, config);
        }

        //public async Task ShowMarkerArea(ElementReference target, UIStyleSettings styleSettings, MarkerTypes markerTypes = MarkerTypes.ALL_MARKER_TYPES)
        //{
        //    var module = await moduleTask.Value;
        //    await module.InvokeVoidAsync("setMarkerAreaUIStyle", target, styleSettings);
        //}

        //public async Task SetMarkerAreaUIStyle(ElementReference target, UIStyleSettings styleSettings)
        //{
        //    throw new NotImplementedException();
        //}

        //public async Task SetMarkerAreaMarkerTypes(MarkerTypes markerTypes)
        //{
        //    throw new NotImplementedException();
        //}

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
