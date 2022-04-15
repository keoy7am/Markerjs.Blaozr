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
    public partial class MarkerArea
    {
        [Inject]
        IJSRuntime? _jsRuntime { get; set; }
        [Inject]
        MarkerJSService _service { get; set; }
        ElementReference _sourceImageReference;
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
                if(_service is null)
                    _service = new MarkerJSService(_jsRuntime);
                if (JsonText is null)
                    JsonText = string.Empty;
                await Task.Delay(1);
                await InvokeAsync(StateHasChanged);
            }
        }
        private async Task SetSourceImage()
        {
            await _service.SetSourceImage(this._sourceImageReference, _elementReference.Id);
        }
        public async Task ShowArea()
        {
            await _service.ShowMarkerArea(this._elementReference, _elementReference.Id);
        }
        public async Task<string> GetConfig()
        {
            var jsonObj = await _service.GetConfigFromMarkerArea(_elementReference.Id);
            JsonText = jsonObj?.ToJsonString();
            return JsonText;
        }
    }
}
