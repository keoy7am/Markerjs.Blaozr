using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Markerjs.Blazor
{
    public class UIStyleSettings
    {
        public string DisplayMode { get { return _displayMode.ToString(); } }
        private DisplayMode _displayMode { get; set; }
        #region UI Custom
        #region CSS Class
        public string? ToolbarActiveButtonStyleColorsClassName { get; set; }
        public string? ToolbarOverflowBlockStyleColorsClassName { get; set; }
        public string? ToolboxStyleColorsClassName { get; set; }
        public string? ToolboxButtonRowStyleColorsClassName { get; set; }
        public string? ToolboxPanelRowStyleColorsClassName { get; set; }
        public string? ToolboxButtonStyleColorsClassName { get; set; }
        public string? ToolboxActiveButtonStyleColorsClassName { get; set; }
        #endregion
        #region Color
        public string? ToolboxColor { get; set; }
        public string? ToolboxAccentColor { get; set; }
        #endregion
        #endregion
        #region Control Visible
        public bool RedoButtonVisible { get; internal set; }
        public bool NotesButtonVisible { get; internal set; }
        public bool ZoomButtonVisible { get; internal set; }
        public bool ZoomOutButtonVisible { get; internal set; }
        public bool ClearButtonVisible { get; internal set; }
        #endregion
    }
    public enum DisplayMode
    {
        inline, // default, https://github.com/ailon/markerjs2/blob/7760d52f93942d04847a3165dd90cdc92fe7c8ad/src/MarkerArea.ts#L1585
        popup
    }
}
