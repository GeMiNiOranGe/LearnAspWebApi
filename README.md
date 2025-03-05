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
  * [How to add a database context](#How-to-add-a-database-context)

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
dotnet new webapi --output WebApi

# For using controllers
dotnet new webapi --output WebApi --use-controllers
```

2. Link project to solution, [learn more](https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-sln).
```bash
dotnet sln add WebApi
```

### How to run project
#### Using [.NET CLI](https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-run).
```bash
# For a normal run
dotnet run --project WebApi

# For enabling hot-reloading
dotnet watch run --project WebApi
```

- With SSL certificate, [learn more](https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?tabs=visual-studio-code#run-the-project). The `dotnet dev-certs` command [docs](https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-dev-certs)
```bash
dotnet watch run --project WebApi --launch-profile https
```

#### Using [VSCode UI](https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?tabs=visual-studio-code#create-a-web-api-project).
> When Visual Studio Code requests that you add assets to build and debug the project, select **Yes**. If Visual Studio Code doesn't offer to add build and debug assets, select **View > Command Palette** and type "`.NET`" into the search box. From the list of commands, select the `.NET: Generate Assets for Build and Debug` command.

Press `F5` on the keyboard to run the project.

### How to add project-to-project (P2P) references
[Learn more](https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-add-reference).
```bash
dotnet add WebApi reference Application
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
dotnet add WebApi package NSwag.AspNetCore
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

### How to add a database context
> The Microsoft.EntityFrameworkCore.Design package is required for either command-line or Package Manager Console-based tooling, and is a dependency of dotnet-ef and Microsoft.EntityFrameworkCore.Tools.

Install EF Design, [learn more](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Design).

```bash
dotnet add WebApi package Microsoft.EntityFrameworkCore.Design --version 9.0.2
```

CLI [documentation](https://learn.microsoft.com/en-us/ef/core/cli/dotnet).

Install EF CLI as a global tool, [learn more](https://www.nuget.org/packages/dotnet-ef).
```bash
dotnet tool install --global dotnet-ef --version 9.0.2
```

Install EF Core, [Learn more](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore).
```bash
dotnet add Infrastructure package Microsoft.EntityFrameworkCore --version 9.0.2
```

Create a dbcontext, [how to scaffold](https://learn.microsoft.com/en-us/ef/core/cli/dotnet#dotnet-ef-dbcontext-scaffold).
```bash
dotnet ef dbcontext scaffold `
  "Name=ConnectionStrings:Development" `
  Microsoft.EntityFrameworkCore.SqlServer `
  --project Infrastructure `
  --startup-project WebApi `
  --context LearnAspWebApiContext `
  --context-dir Data `
  --output-dir Models `
  --no-onconfiguring
```
