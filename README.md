# LearnAspWebApi
> **Attention**: The minimum .NET SDK version is [9.0.2](https://dotnet.microsoft.com/en-us/download/dotnet/9.0).

## Table of Contents
* [Table of Contents](#Table-of-Contents)
* [What to learn](#What-to-learn)
  * [How to format code](#How-to-format-code)
  * [How to create `.gitignore`](#How-to-create-gitignore)
  * [How to create `*.sln`](#How-to-create-sln)
  * [How to create project](#How-to-create-project)
  * [How to run project](#How-to-run-project)
    * [Using .NET CLI](#Using-NET-CLI)
    * [Using VSCode UI](#Using-VSCode-UI)
  * [How to add project-to-project (P2P) references](#How-to-add-project-to-project-P2P-references)
  * [How to test](#How-to-test)
    * [Swagger](#Swagger)
    * [Scalar](#Scalar)

## What to learn
### How to format code
```bash
dotnet format .
```

You can use CSharpier
```bash
# Create a manifest
dotnet new tool-manifest

# Install csharpier
dotnet tool install csharpier

# Format code
dotnet csharpier .
```

You can use both and waste more than 10 seconds of your life.
```bash
dotnet csharpier .
dotnet format .
```

### How to create `.gitignore`
```bash
dotnet new gitignore
```

### How to create `*.sln`
```bash
dotnet new sln
```

### How to create project
1. Create project, [learn more](https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-new).
```bash
# For creating a minimal API
dotnet new webapi --output Presentation

# For using controllers
dotnet new webapi --output Presentation --use-controllers
```

2. Link project to solution, [learn more](https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-sln).
```bash
dotnet sln add Presentation
```

### How to run project
#### Using [.NET CLI](https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-run).
```bash
# For a normal run
dotnet run --project .\Presentation\

# For enabling hot-reloading
dotnet watch run --project .\Presentation\
```

- With SSL certificate, [learn more](https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?tabs=visual-studio-code#run-the-project). The `dotnet dev-certs` command [docs](https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-dev-certs)
```bash
dotnet watch run --project .\Presentation\ --launch-profile https
```

#### Using [VSCode UI](https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?tabs=visual-studio-code#create-a-web-api-project).
> When Visual Studio Code requests that you add assets to build and debug the project, select **Yes**. If Visual Studio Code doesn't offer to add build and debug assets, select **View > Command Palette** and type "`.NET`" into the search box. From the list of commands, select the `.NET: Generate Assets for Build and Debug` command.

Press `F5` on the keyboard to run the project.

### How to add project-to-project (P2P) references
[Learn more](https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-add-reference).
```bash
dotnet add Presentation reference Application
```
- For example: Presentation layer -> Business layer -> Data Access layer.
- Here, `->` indicates the reference direction of the project.

Normally, the Presentation layer can directly access the Data Access layer, but to separate this access, you must configure a `Directory.Build.props` file with the following attribute:

```xml
<Project>
  <ItemDefinitionGroup>
    <ProjectReference>
      <PrivateAssets>all</PrivateAssets>
    </ProjectReference>
  </ItemDefinitionGroup>
</Project>
```

Alternatively, this can be configured in the `*.csproj` file as follows:
```xml
<ProjectReference Include="..\Business.csproj" PrivateAssets="All" />
```

### How to test
#### Swagger
Install `NSwag.AspNetCore`, [learn more](https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?tabs=visual-studio-code#test-the-project).
```bash
dotnet add Presentation package NSwag.AspNetCore
```

Open OpenAPI 3.0 document serving middleware, Available at:
```
http(s)://localhost:<port>/openapi/v1.json
```

Open Swagger web to interact with the document, Available at:
```
http(s)://localhost:<port>/swagger
```

#### Scalar
Install `Scalar.AspNetCore`, [learn more](https://www.nuget.org/packages/Scalar.AspNetCore).
```bash
dotnet package search Scalar.AspNetCore
```

Open Scalar web to interact with the document, Available at:
```
http(s)://localhost:<port>/scalar
```

Further, we can use additional `{documentName}`. Here, `{documentName}` can be `v1`, `v2`, ... , `vn`. Available at:
```
http(s)://localhost:<port>/scalar/{documentName}
```

