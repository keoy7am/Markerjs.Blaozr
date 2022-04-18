using Markerjs.Blazor.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Markerjs.Blazor.Components
{
    public partial class MarkerView
    {
        [Inject]
        IJSRuntime? _jsRuntime { get; set; }
        [Inject]
        MarkerJSLiveService? _service { get; set; }
        ElementReference _elementReference;
        #region Parameters
        [Parameter]
        public string? Src { get; set; }
        [Parameter]
        public string? Class { get; set; }
        [Parameter]
        public string? Style { get; set; }
        [Parameter]
        public string JsonText { get; set; }
        #endregion
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                if (_service is null)
                    _service = new MarkerJSLiveService(_jsRuntime);
                if (JsonText is null)
                    JsonText = string.Empty;
                await Task.Delay(1).ConfigureAwait(false);
                await InvokeAsync(StateHasChanged);
            }
        }
        public async Task ToggleMarkers()
        {
            await _service.ToggleMarkers(this._elementReference.Id, _elementReference, JsonText);
        }
    }
}
