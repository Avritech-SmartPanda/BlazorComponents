# SSRSViewer component
This article demonstrates how to use SSRSViewer. Use this component to access Microsoft SQL Server Reporting Services.

```
<Property365SSRSViewer ReportName="Untitled" ReportServer="http://localhost/ReportServer/" UseProxy="true">
  <Parameters>
    <Property365SSRSViewerParameter ParameterName="Param1" Value="1" />
    <Property365SSRSViewerParameter ParameterName="Param2" Value="2" />
  </Parameters>
</Property365SSRSViewer>
```

When `UseProxy` is set to `true` a special `ReportController` will be accessed instead directly accessing report server URL.
