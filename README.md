# Azure Functions Bindings for App Center Push

[![Build Status](https://dev.azure.com/shibayan/azure-functions-appcenterpush-extension/_apis/build/status/Build%20azure-functions-appcenterpush-extension?branchName=master)](https://dev.azure.com/shibayan/azure-functions-appcenterpush-extension/_build/latest?definitionId=30&branchName=master)

## NuGet Packages

Package Name | Target Framework | NuGet
---|---|---
WebJobs.Extensions.AppCenterPush | .NET Standard 2.0 | [![NuGet](https://img.shields.io/nuget/v/WebJobs.Extensions.AppCenterPush.svg)](https://www.nuget.org/packages/WebJobs.Extensions.AppCenterPush)

## Basic usage

```csharp
public static class Functions
{
    // Use IAsyncCollector<T>
    [FunctionName("Function1")]
    public static async Task<IActionResult> Function1(
        [HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequest req,
        [AppCenterPush(OwnerName = "owner", AppName = "app")] IAsyncCollector<AppCenterPushMessage> collector,
        ILogger log)
    {
        await collector.AddAsync(new AppCenterPushMessage
        {
            Content = new AppCenterPushContent
            {
                Name = "First Push From App Center",
                Title = "Push From App Center",
                Body = "Hello! Isn't this an amazing notification message?",
                CustomData = new { key1 = "val1", key2 = "val2" }
            }
        });

        return new OkResult();
    }
    
    // Use returning value
    [FunctionName("Function2")]
    [return: AppCenterPush(OwnerName = "owner", AppName = "app")]
    public static AppCenterPushMessage Function2(
        [HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequest req,
        ILogger log)
    {
        return new AppCenterPushMessage
        {
            Content = new AppCenterPushContent
            {
                Name = "First Push From App Center",
                Title = "Push From App Center",
                Body = "Hello! Isn't this an amazing notification message?",
                CustomData = new { key1 = "val1", key2 = "val2" }
            }
        };
    }
}
```

```json
{
  "IsEncrypted": false,
  "Values": {
    "AzureWebJobsStorage": "",
    "FUNCTIONS_WORKER_RUNTIME": "dotnet",
    "AppCenterPushApiToken": "<APP CENTER API TOKEN>"
  }
}
```

![image](https://user-images.githubusercontent.com/1356444/58454220-47c28880-810d-11e9-8718-b66cbcccfa60.png)


## Push Targeting

### Audience

```csharp
await collector.AddAsync(new AppCenterPushMessage
{
    Content = new AppCenterPushContent
    {
        Name = "First Push From App Center",
        Title = "Push From App Center",
        Body = "Hello! Isn't this an amazing notification message?",
        CustomData = new { key1 = "val1", key2 = "val2" }
    },
    Target = new AppCenterPushAudiencesTarget
    {
        Audiences = new[] { "dog-lovers", "cyclists" }
    }
});
```

### Devices

```csharp
await collector.AddAsync(new AppCenterPushMessage
{
    Content = new AppCenterPushContent
    {
        Name = "First Push From App Center",
        Title = "Push From App Center",
        Body = "Hello! Isn't this an amazing notification message?",
        CustomData = new { key1 = "val1", key2 = "val2" }
    },
    Target = new AppCenterPushDevicesTarget
    {
        Devices = new[] { "00000000-0000-0000-0000-000000000001","00000000-0000-0000-0000-000000000002", "00000000-0000-0000-0000-000000000003" }
    }
});
```

### User Ids

```csharp
await collector.AddAsync(new AppCenterPushMessage
{
    Content = new AppCenterPushContent
    {
        Name = "First Push From App Center",
        Title = "Push From App Center",
        Body = "Hello! Isn't this an amazing notification message?",
        CustomData = new { key1 = "val1", key2 = "val2" }
    },
    Target = new AppCenterPushUserIdsTarget
    {
        UserIds = new[] { "james@somecompany.com", "allison@somecompany.com", "anna@somecompany.com" }
    }
});
```

### Account Ids

```csharp
await collector.AddAsync(new AppCenterPushMessage
{
    Content = new AppCenterPushContent
    {
        Name = "First Push From App Center",
        Title = "Push From App Center",
        Body = "Hello! Isn't this an amazing notification message?",
        CustomData = new { key1 = "val1", key2 = "val2" }
    },
    Target = new AppCenterPushAccountIdsTarget
    {
        AccountIds = new[] { "00000000-0000-0000-0000-000000000001", "00000000-0000-0000-0000-000000000002", "00000000-0000-0000-0000-000000000003" }
    }
});
```

## License

This project is licensed under the [MIT License](https://github.com/shibayan/azure-functions-appcenterpush-extension/blob/master/LICENSE)
