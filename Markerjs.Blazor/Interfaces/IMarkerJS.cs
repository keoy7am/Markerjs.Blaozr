using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace Markerjs.Blazor.Interfaces
{
    public interface IMarkerJS
    {
        public Task ShowMarkerArea(ElementReference target, string stateRef);
        public Task<JsonObject> GetConfigFromMarkerArea(string id);
        public Task ShowMarkerView(ElementReference target, JsonObject config);
        //public Task ShowMarkerArea(ElementReference target, UIStyleSettings styleSettings, MarkerTypes markerTypes = MarkerTypes.ALL_MARKER_TYPES);
        //public Task SetMarkerAreaUIStyle(ElementReference target, UIStyleSettings styleSettings);
        //public Task SetMarkerAreaMarkerTypes(MarkerTypes markerTypes);
    }
}
