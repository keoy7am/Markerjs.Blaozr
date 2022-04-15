window.MarkerAreas = []; // store componets

export function setSourceImage(sourceImage, id) {
    let query = GetArea(id);
    if (query === undefined)
        MarkerAreas.push({ Id: id, SourceImage: sourceImage, TargetRoot: sourceImage.parentElement });
}

export function showMarkerArea(target, id) {
    let query = GetArea(id);
    if (query === undefined) throw "can't find source image.";

    const markerArea = new markerjs2.MarkerArea(query.SourceImage);
    markerArea.targetRoot = query.TargetRoot;

    markerArea.addEventListener('render', (event) => {
        target.src = event.dataUrl;
        query.State = event.state;
    });

    markerArea.show();
    if (query !== undefined && query.State !== undefined)
        markerArea.restoreState(query.State);
}

export function GetConfigFromMarkerArea(id) {
    let area = GetArea(id);
    if (area !== undefined)
        return area.State;

    return undefined;
}

export function GetArea(id) {
    if (window.MarkerAreas.length > 0) {
        let query = window.MarkerAreas.find(x => x.Id === id);
        if (query !== undefined)
            return query;
    }

    return undefined;
}

/* not yet implemented */
export function setMarkerAreaUIStyle(target, styleConfig, markerType) {
    const markerArea = new markerjs2.MarkerArea(target);
    markerArea.uiStyleSettings.redoButtonVisible = styleConfig.redoButtonVisible;
    markerArea.uiStyleSettings.notesButtonVisible = styleConfig.notesButtonVisible;
    markerArea.uiStyleSettings.zoomButtonVisible = styleConfig.zoomButtonVisible;
    markerArea.uiStyleSettings.zoomOutButtonVisible = styleConfig.zoomOutButtonVisible;
    markerArea.uiStyleSettings.clearButtonVisible = styleConfig.clearButtonVisible;
}