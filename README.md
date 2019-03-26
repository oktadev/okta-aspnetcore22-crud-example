# Live Music Finder

This is an application that allows users to enter live music shows that they know about so that others can see upcoming shows.

## Getting Started

Clone the repsository.

```sh
git clone 
```

## Steps

1. Create a model for the Live Music Show.
2. `dotnet add package Microsoft.EntityFrameworkCore.SQLite`
3. `ApplicationDbContext`
4. `ConfigureServices()` method add `services.AddDbContext<ApplicationDbContext>(options => options.UseSQLite("Data Source=LiveMusicFinder.db"));`
5. Add `ApplicationDbContext dbContext` to `Configure()` method signature
6. Add `dbContext.Database.EnsureCreated();` to `Configure()` method
7. `dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design`
8. `dotnet aspnet-codegenerator controller -name LiveShowsController -async -m LiveMusicFinder.Models.LiveShow -dc LiveMusicFinder.Data.ApplicationDbContext -namespace Controllers -outDir Controllers -udl`
9. `dotnet add package Okta.AspNetCore --version 1.1.5`
10. Add the `AddAuthentication()` method with `OktaMvcOptions`


## Getting Help


## License
Apache 2.0 (see [LICENSE](LICENSE))