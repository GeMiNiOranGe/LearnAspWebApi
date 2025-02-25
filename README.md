# LearnAspWebApi
> **Attention**: The minimum .NET SDK version is [9.0.2](https://dotnet.microsoft.com/en-us/download/dotnet/9.0).

## What to learn
- How to create `.gitignore`
```
dotnet new gitignore
```

- How to create `*.sln`
```
dotnet new sln
```

- How to create project
1. Create project, [learn more](https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-new).
```
# For minimal API
dotnet new webapi --output Presentation

# For controller
dotnet new webapi --output Presentation --use-controllers
```

2. Link project to solution, [learn more](https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-sln).
```
dotnet sln add Presentation
```
