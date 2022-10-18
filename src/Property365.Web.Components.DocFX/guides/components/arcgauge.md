# ArcGauge component
This article demonstrates how to use Property365ArcGauge.
## Basic usage
Here is basic example that creates an arc gauge with minimal configuration.
```
<Property365ArcGauge Style="width: 300px; height: 300px">
  <Property365ArcGaugeScale>
    <Property365ArcGaugeScaleValue Value="50" />
  </Property365ArcGaugeScale>
</Property365ArcGauge>
```
Property365ArcGaugeScale tag is used to add a scale and configure its options - min and max value, start and end angle, tick display etc.
Property365ArcGaugeScaleValue tag adds and configures a value of the ArcGaugeScale it is a child of.

Property365 Blazor gauges can have multiple scales and every scale can have multiple pointers or values.
## Scale configuration
### Min, max and step
By default the `Min` property of both scale types (Arc and Arc) is set to `0`. `Max` is set to `100` and `Step` is set to `20`.

To override the defaults use the `Min`, `Max` and `Step` properties of the `Property365ArcGaugeScale` tag.
```
<Property365ArcGauge Style="width: 300px; height: 300px">
  <Property365ArcGaugeScale Min="100" Max="1000" Step="100">
    <Property365ArcGaugeScaleValue Value="50" />
  </Property365ArcGaugeScale>
</Property365ArcGauge>
```
### Tick configuration
By default the Property365ArcGaugeScale does not display ticks. You need to set the `TickPosition` property to `GaugeTickPosition.Outside` or `GaugeTickPosition.Inside`. To hide the ticks altogether use `GaugeTickPosition.None`.
```
<Property365ArcGauge Style="width: 300px; height: 300px">
  <Property365ArcGaugeScale TickPosition="GaugeTickPosition.Outside">
    <Property365ArcGaugeScaleValue Value="50" />
  </Property365ArcGaugeScale>
</Property365ArcGauge>
```
Minor ticks are not displayed by default. To display them set the MinorStep property to a value greater than `0`.
```
<Property365ArcGauge Style="width: 300px; height: 300px">
  <Property365ArcGaugeScale TickPosition="GaugeTickPosition.Outside" MinorStep="5">
    <Property365ArcGaugeScaleValue Value="50" />
  </Property365ArcGaugeScale>
</Property365ArcGauge>
```
### Change the start and and angles
By default the `StartAngle` property of the gauge scales is set to `-90` and `EndAngle` is set to `90`. This makes
the default shape half a circle. Here is how to create a gauge which is a full circle:
```
<Property365ArcGauge>
  <Property365ArcGaugeScale StartAngle="0" EndAngle="360">
    <Property365ArcGaugeScaleValue Value="50" />
  </Property365ArcGaugeScale>
</Property365ArcGauge>
```
### Format the values
The scale ticks labels displays values with default formatting (`ToString()`). This can be customized in two ways - via the `FormatString` or the `Formatter` properties.

`FormatString` supports the [standard .NET Number formats](https://docs.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings).

```
<Property365ArcGauge Style="width: 300px; height: 300px">
  <Property365ArcGaugeScale FormatString="{0:C}">
    <Property365ArcGaugeScaleValue Value="50" />
  </Property365GaugeGaugeScale>
</Property365GaugeGauge>
```

```
<Property365ArcGauge Style="width: 300px; height: 300px">
  <Property365ArcGaugeScale Formatter=@(value => value.ToString())>
    <Property365ArcGaugeScaleValue Value="50" />
  </Property365GaugeGaugeScale>
</Property365GaugeGauge>
```
### Change the scale position

You can use the `X` and `Y` property of the scales to change the position of their center. Both properties have a default value of `0.5` which means
that by default the center of a scale is the middle of the gauge. `X` and `Y` are a multiplier of the width and height.

For example you can move the center of the scale to the bottom of the component by setting `Y` to `1`.

```
<Property365ArcGauge Style="width: 300px; height: 300px">
  <Property365ArcGaugeScale Y="1">
    <Property365ArcGaugeScaleValue Value="50" />
  </Property365GaugeGaugeScale>
</Property365GaugeGauge>
```

Using `X` and `Y` is also useful when you have multiple scales - this allows you to prevent them from overlapping which they will do by default.

### Change the scale radius

By default the radius is set to be half the size of the Gauge - the smaller of its pixel width or height. You can tweak that
by setting the `Radius` property. It is also a multiplier - the value you specify is multiplied by the initial value (half the width or height depending on which is smaller).
The reason Radius is a multiplier and not an absolute value is responsiveness - users of smaller devices would expect to see a scale which is proportionally the same.

Here is how to make a scale twice as small

```
<Property365ArcGauge Style="width: 300px; height: 300px">
  <Property365ArcGaugeScale Radius="0.5">
    <Property365ArcGaugeScaleValue Value="50" />
  </Property365GaugeGaugeScale>
</Property365GaugeGauge>
```
## Value configuration
### Hide the value
By default the `Value` property is displayed below the scale. You can hide it by setting the `ShowValue` property to `false`.
```
<Property365ArcGauge>
  <Property365ArcGaugeScale>
    <Property365ArcGaugeScaleValue Value="50" ShowValue="false" />
  </Property365ArcGaugeScale>
</Property365ArcGauge>
```
### Customize the value display
Use the `Template` property of the pointer to tweak the default value appearance.
```
<Property365ArcGauge>
  <Property365ArcGaugeScale Min="0" Max="260">
    <Property365ArcGaugeScaleValue Value=@value>
      <Template Context="value">
        <h4>
            @value.Value <sup>km/h</sup>
        </h4>
      </Template>
    </Property365ArcGaugeScaleValue>
  </Property365ArcGaugeScale>
</Property365ArcGauge>
```