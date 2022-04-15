using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace Markerjs.Blazor.Interfaces
{
    public interface IMarkerJSLive
    {
        public Task ToggleMarkers(string id, ElementReference target, string config);
    }
}
