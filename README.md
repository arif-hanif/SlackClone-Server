# SlackCloneNET

## Description

This is an ASP.Net Core 3.0 API app.

## [Documentation](https://arif-hanif.gitbook.io/slackclone/)

## Local Build and Configuration

For production environments, secrets are configured via environment variables. For development, the ASP.Net Core Secret Manager is used to store sensitive configuration locally in a system-protected user profile folder.

To set this up on your development system, perform the following steps after cloning the repo:

Run the command:

   <pre>type "&lt;full path to settings.json&gt;" | dotnet user-secrets set</pre>

That's it! You should be able to build and run the project within Visual Studio.

For more information about using Secret Manager, including setting it up in a new project or modifying values, see the [documentation](https://docs.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-3.0&tabs=windows).

## Debugging

...

## Deployment/DevOps

### Database Migrations

<pre>dotnet ef migrations add "MIGRATION NAME"</pre>
<pre>dotnet ef database update</pre>

## Dependencies

- Dotnet Core 3.0
- ASP.NET
- Microsoft.EntityFrameworCore
- HotChocolate
- Npgsql
