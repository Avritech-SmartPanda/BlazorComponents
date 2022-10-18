# RadialGauge component
This article demonstrates how to use Property365RadialGauge. 
## Basic usage
Here is basic example that creates a radial gauge with minimal configuration.
```
<Property365RadialGauge Style="width: 300px; height: 300px">
  <Property365RadialGaugeScale>
    <Property365RadialGaugeScalePoiner Value="50" />
  </Property365RadialGaugeScale>
</Property365RadialGauge>
```
Property365RadialGaugeScale is used to add a scale and configure its options - min and max value, start and end angle, tick display etc.
Property365RadialGaugeScalePointer tag adds and configures a pointer of the RadialGaugeScale it is a child of. The key property here is `Value` - it specifies the value the pointer "points" to on the scale.

Property365 Blazor gauges can have multiple scales and every scale can have multiple pointers or values.
## Ranges
The Property365RadialGaugeScale supports ranges. A range applies a color between two values of the scale. For example this is often used to specify a "dangerous" zone of the scale
which a pointer isn't supposed to go to. A Property365RadialGaugeScale can have multiple ranges that should not overlap.
```
<Property365RadialGauge>
  <Property365RadialGaugeScale Min="0" Max="260">
    <Property365RadialGaugeScalePointer Value="50" />
    <Property365RadialGaugeScaleRange From="0" To="90" Fill="green" />
    <Property365RadialGaugeScaleRange From="90" To="140" Fill="orange" />
    <Property365RadialGaugeScaleRange From="140" To="260" Fill="red" />
  </Property365RadialGaugeScale>
</Property365RadialGauge>
```
## Scale configuration
### Min, max and step
By default the `Min` property of both scale types (Radial and Radial) is set to `0`. `Max` is set to `100` and `Step` is set to `20`.

To override the defaults use the `Min`, `Max` and `Step` properties of the `Property365RadialGaugeScale` tag.
```
<Property365RadialGauge Style="width: 300px; height: 300px">
  <Property365RadialGaugeScale Min="100" Max="1000" Step="100">
    <Property365RadialGaugeScalePointer Value="50" />
  </Property365RadialGaugeScale>
</Property365RadialGauge>
```
### Tick configuration
By default the Property365RadialGaugeScale does not display ticks. You need to set the `TickPosition` property to `GaugeTickPosition.Outside` or `GaugeTickPosition.Inside`. To hide the ticks altogether use `GaugeTickPosition.None`.
```
<Property365RadialGauge Style="width: 300px; height: 300px">
  <Property365RadialGaugeScale TickPosition="GaugeTickPosition.Outside">
    <Property365RadialGaugeScalePointer Value="50" />
  </Property365RadialGaugeScale>
</Property365RadialGauge>
```
Minor ticks are not displayed by default. To display them set the MinorStep property to a value greater than `0`.
```
<Property365RadialGauge Style="width: 300px; height: 300px">
  <Property365RadialGaugeScale TickPosition="GaugeTickPosition.Outside" MinorStep="5">
    <Property365RadialGaugeScalePointer Value="50" />
  </Property365RadialGaugeScale>
</Property365RadialGauge>
```
### Change the start and and angles
By default the `StartAngle` property of the gauge scales is set to `-90` and `EndAngle` is set to `90`. This makes
the default shape half a circle. Here is how to create a gauge which is a full circle:
```
<Property365RadialGauge>
  <Property365RadialGaugeScale StartAngle="0" EndAngle="360">
    <Property365RadialGaugeScalePointer Value="50" />
  </Property365RadialGaugeScale>
</Property365RadialGauge>
```
### Format the values
The scale ticks labels displays values with default formatting (`ToString()`). This can be customized in two ways - via the `FormatString` or the `Formatter` properties.

`FormatString` supports the [standard .NET Number formats](https://docs.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings).

```
<Property365RadialGauge Style="width: 300px; height: 300px">
  <Property365RadialGaugeScale FormatString="{0:C}">
    <Property365GaugeGaugeScalePointer Value="50" />
  </Property365GaugeGaugeScale>
</Property365GaugeGauge>
```

```
<Property365RadialGauge Style="width: 300px; height: 300px">
  <Property365RadialGaugeScale Formatter=@(value => value.ToString())>
    <Property365GaugeGaugeScalePointer Value="50" />
  </Property365GaugeGaugeScale>
</Property365GaugeGauge>
```
### Change the scale position

You can use the `X` and `Y` property of the scales to change the position of their center. Both properties have a default value of `0.5` which means
that by default the center of a scale is the middle of the gauge. `X` and `Y` are a multiplier of the width and height.

For example you can move the center of the scale to the bottom of the component by setting `Y` to `1`.

```
<Property365RadialGauge Style="width: 300px; height: 300px">
  <Property365RadialGaugeScale Y="1">
    <Property365GaugeGaugeScalePointer Value="50" />
  </Property365GaugeGaugeScale>
</Property365GaugeGauge>
```

Using `X` and `Y` is also useful when you have multiple scales - this allows you to prevent them from overlapping which they will do by default.
## Pointer configuration
### Pointer length
By default a RadialGaugeScalePointer is as long as the radius of its scale. You can controll that via the `Length` property which is a multiplier with a default value `1`.

Here is how to make the pointer half the radius:
```
<Property365RadialGauge>
  <Property365RadialGaugeScale>
    <Property365RadialGaugeScalePointer Value="50" Length="0.5" />
  </Property365RadialGaugeScale>
</Property365RadialGauge>
```
### Hide the pointer value
By default the `Value` property is displayed below the pointer. You can hide it by setting the `ShowValue` property to `false`.
```
<Property365RadialGauge>
  <Property365RadialGaugeScale>
    <Property365RadialGaugeScalePointer Value="50" ShowValue="false" />
  </Property365RadialGaugeScale>
</Property365RadialGauge>
```
### Customize the value display
Use the `Template` property of the pointer to tweak the default value appearance.

```
<Property365RadialGauge>
  <Property365RadialGaugeScale Min="0" Max="260">
    <Property365RadialGaugeScalePointer Value=@value>
      <Template Context="pointer">
        <h4>
            @pointer.Value <sup>km/h</sup>
        </h4>
      </Template>
    </Property365RadialGaugeScalePointer>
  </Property365RadialGaugeScale>
</Property365RadialGauge>
```