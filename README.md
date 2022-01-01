# Medoz.ThemeProvider

## Material design theme for Blazor
Provides material design colors and themes.

## Prerequisites
- [.NET 6.0](https://dotnet.microsoft.com/download/dotnet/6.0)

## Getting Start

Add the following to `MainLayout.razor`
```razor
@using Medoz.ThemeProvider
```

And add the following to `MainLayout.razor`
```razor
<ThemeProvider Theme="@theme">
    <PageTitle>Medoz.ThemeProvider.Test</PageTitle>
    <div class="page">
        ....
    </div>
</ThemeProvider>

@code {
    Theme theme { get; set; } = new Theme();
}
```

## Version
### 0.1.0
- create project.

## License
This project is licensed under the terms of the [MIT license](LICENSE).