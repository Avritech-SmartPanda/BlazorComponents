# ProgressBar component
This article demonstrates how to use the ProgressBar component. 

## Get and set the value
As all Property365 Blazor input components the ProgressBar has a `Value` property which gets and sets the value of the component.
Use `@bind-Value` to get the user input. 

```
<Property365ProgressBar @bind-Value="@value"  />

@code {
    double value = 55;
}
```

## ProgressBar in indeterminate mode
```
<Property365ProgressBar Value="100" ShowValue="false" Mode="ProgressBarMode.Indeterminate" />
```

## ProgressBar in max value > 100
```
<Property365ProgressBar Value="156" Max="200" />
```

