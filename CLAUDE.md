As a Senior fullstack developer, the task is evaluate this backend application and complete some tasks that are required for the production release. Create a Domain.md with all the entities and i will review it and fix the purpose of this, after updating it we'll start to work, we will require to integrate with app-alfaguara repo for a complete work. Run the application on local environment 

## What the app is
ALFAGUARACLUB.BACKEND is a .net 8 solution built as clean architecture for handling different internal of a club: 
The club has diferent sites, which have different costcenters, which have different number of spaces and in those space are carried out different quantity of activities 
The club counts with several spaces such as leisure lounges, theater, pools, stable, tennis fields, squash fields, bowling; which belong to a costcenter and are distributed through different sites. The idea is managing all those process and other process of create and book different activities, receive PQR of clients and also handle different products or services and an integration to a MercadoPago api for payment process.

There are two defined roles (Admin, user) in the system and consequently different kind of users that inherit from these roles: worker for Admin and principal user, associated user and guest user for user role. The function of admin is handle all administrative process and insertion of information  about sites, spaces, activities, products and services and, Coupon Monthly ,the user (Principal and guest) query about activities, book activities ,see the sites information and buy different products, guest user is just for query information and be added into different activities 
The system will also have a Parameter module which will have some constants or variables that can change with the time

## Tech Stack
As mentioned before is a clean architecture monolithic solution built in .NET 8 which implement CQRS with Mediator, IRepository
 There are several controllers exposed to be connected with a frontend developed in Angular: Each controller handle for different funcitonality 
 ORM EFCore
 Database Mysql 

 ## Repository Layout
 ALFAGUARACLUB.BACKEND
 /
 |---AlfaguaraClub.Application.UnitTest/  #Unit and integration test from Application layer
    |- AlfaguaraClub.Backend.Api #Controllers, program.cs file and optionsetup files
    |- AlfaguaraClub.Backend.Application #CQRS, DTOs, interfaces, validators
    |- AlfaguaraClub.Backend.Domain   #Entities and Enums
    |- AlfaguaraClub.Backend.Infraestructure # JWT Implementation and Notification logic
    |- AlfaguaraClub.Backend.Persistence EF Core, DbContext, migrations and repositories

## Architecture

## Dependency
Api -> Application <-Infraestructure
Api ->Application <- Persistence

### Layer Responsibilities
| Layer | Project | What goes here | What must NOT go here |
| Domain | `AlfaguaraClub.Domain` | Entity classes, enums, value objects | Logic, EF attributes, service calls |
| Application | `AlfaguaraClub.Application` | Commands, Queries, Handlers, DTOs, repository interfaces, validators | EF Core, HTTP clients, file I/O |
| Infrastructure | `AlfaguaraClub.Infraestructure` | Exchange rate HTTP client, file storage service | EF Core DbContext, endpoint logic |
| Persistence | `AlfaguaraClub.Persistence` | `AppDbContext`, migrations, repository implementations | Business logic, DTO mapping |
| API | `AlfaguaraClub.Api` | Endpoint registration, DI wiring, middleware | Business logic, data access |

### CQRS Conventions

Every user-initiated action is a Command or Query:

- **Commands** mutate state. Named `<Action><Entity>Command`. Return `BaseResponse` with a state of transaction.
- **Queries** read state and never mutate. Named `Get<Entity>Query`. Return `<EntityDto>` or `<EntityVm>` as collection or individual entities.
- **Handlers** are the only place where repository methods are called. Handlers map entities to DTOs before returning.
- **Endpoints** contain exactly one statement: `return await mediator.Send(commandOrQuery)`.


### Repository Pattern

Base interface `IRepository<T>` provides:

```csharp
Task<T?> GetByIdAsync(long id);
Task<IList<T>> GetAllAsync();
Task<T> AddAsync(T entity);
Task UpdateAsync(T entity);
Task DeleteAsync(T entity);
IQueryable<T> Query();           // tracked — use for writes
IQueryable<T> QueryNoTracking(); // read-only — use for queries
```

Add entity-specific methods to the entity's own interface only when the base is insufficient. Repositories return domain entities; DTO mapping happens in handlers.
