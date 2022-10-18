# Dialog setup
This article shows the additional setup steps required to use the Property365Dialog component.

1. [Register](#service-registration) the service.
1. [Add](#add-to-layout) the component to your layout.

## Service registration
The Property365Dialog is used via the [DialogService](xref:Property365.DialogService) class which must be registered as a service.

# [Blazor Server before .NET 6](#tab/server-side)
1. Open `Startup.cs`
1. Import the Property365 namespace
   ```
   using Property365;
   ```
1. Register the `DialogService` in the `ConfigureServices` method.
   ```
   public void ConfigureServices(IServiceCollection services)
   {
       // Other registrations
       services.AddScoped<DialogService>();
       // Other registrations
   }
   ```
# [Blazor WebAssembly or Blazor Server after .NET 6](#tab/client-side)
1. Open `Program.cs`
1. Import the Property365 namespace
   ```
   using Property365;
   ```
1. Register the `DialogService` in the `Main` method.
   ```
   public static async Task Main(string[] args)
   {
       // Other registrations
       builder.Services.AddScoped<DialogService>();
       // Other registrations
   }
   ```
***
## Add to layout
You also need to add the RadzeDialog component to the layout used by your pages (most commonly `MainLayout.razor`). 
```
<Property365Dialog />
```
