window.MarkerViews = []; // store componets object

export function toggleMarkers(id, target, config) {
    let markerView;
    const query = GetView(id);
    if (query !== undefined) markerView = query.MarkerView;

    if (markerView === undefined || !markerView.isOpen) {
        markerView = new markerjs2live.MarkerView(target);
        markerView.show(config);
        if (query === undefined)
            MarkerViews.push({ Id: id, MarkerView: markerView });
    } else {
        markerView.close();
    }
}

function GetView(id) {
    if (window.MarkerViews.length > 0) {
        let query = window.MarkerViews.find(x => x.Id === id);
        if (query !== undefined)
            return query;
    }

    return undefined;
}