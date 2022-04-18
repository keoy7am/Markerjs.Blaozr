# MarkerJS.Blazor

## About

This package is a wrapper around [markerjs](https://github.com/ailon/markerjs2) to facilitate its use in Blazor applications.
(Currently only wraps basic functions)

### Support with commercial licenses

Under the [linkware license](https://github.com/ailon/markerjs2/blob/master/LICENSE),

All commercial licenses come with email support and major version upgrades subscription. The first year of the subscription is included in the initial purchase. Later on, the subscription renews for approximately half of the initial license price per year (you can see the exact price in the shopping cart). This subscription is optional and you can cancel it at any time. Your license is perpetual and never expires. [(Markerjs official website)](https://markerjs.com/buy)

### Project startup sponsor

Special thanks to [dindins](https://github.com/dindins) for supporting this project.

In order to be able to separate this module, the project was delayed for a few days
 (It was a blazor module required for closed source projects)
 

## Installation

```bash
No content yet
```

## Quick Start guide

1. Add the following script reference to the bottom of th body section 
In index.html (for Blazor WebAssembly) or _Host.cshtml (for Blazor server)

```html
<script src="_content/Markerjs.Blazor/js/markerjs2.js"></script>
<script src="_content/Markerjs.Blazor/js/markerjs-live.js"></script>
```

2. Register services to Application

```C#
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddMarkerJs(); // Add this line
```

3. Add Namespace to _Import.cs (Optional)

```C#
@using Markerjs.Blazor.Components
```

### MarkerArea Component

```C#
@using Markerjs.Blazor.Components

<MarkerArea @ref="_markerArea" Src="_content/Markerjs.Blazor/test.jpg" Class="img-fluid" Style="max-width:50%;" JsonText="@JsonText"/>

@code{
    private MarkerArea? _markerArea{ get; set; }
}
```

**Methods**

|Method|Description|
|---|---|
|ShowMarkerArea|Open the image marker|
|GetConfig|Get config (Json)|

**Parameters**

|Name|Description|
|---|---|
|Src| Image source url|
|Class|CSS Class|
|Style|CSS Style|
|JsonText|For binding json content|

### MarkerView Component

```C#
@using Markerjs.Blazor.Components

<MarkerView @ref="_markerView" Src="_content/Markerjs.Blazor/test.jpg" Class="img-fluid" Style="max-width:50%;" JsonText="@JsonText" />

@code{
    private MarkerView? _markerView { get; set; }
}
```

**Methods**

|Method|Description|
|---|---|
|ToggleMarkers|Toggle markers from json config |

**Parameters**

|Name|Description|
|---|---|
|Src| Image source url|
|Class|CSS Class|
|Style|CSS Style|
|JsonText|For binding json content|
