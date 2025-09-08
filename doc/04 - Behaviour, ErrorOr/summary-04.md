# Daily Summary – Learning and Progress

## 1. Error Handling & Validation
- Implemented **ErrorOr** pattern for returning typed errors instead of throwing exceptions.
- Learned to create **ErrorOrExtensions** for mapping errors to HTTP responses:
  - `MatchToResult()`, `MatchToResultCreated()`, `MatchToResultNoContent()`.
- Used **FluentValidation** with a **ValidationBehaviour** pipeline in MediatR to automatically validate requests.
- Learned how to map **validation errors** to structured HTTP responses (`ValidationProblem`).

## 2. Testing
- Explored **Unit Testing** of handlers with **xUnit** and **FluentAssertions**.
- Learned to use **EF Core InMemory** for testing database operations.
- Discovered how to test **internal sealed classes** using:
  - `InternalsVisibleTo` attribute for separate test projects, or
  - Placing tests in the **same assembly** in a dedicated folder.
- Learned to run tests via CLI (`dotnet test`) and in Visual Studio / VS Code Test Explorer.

## 3. API Documentation & Scalar
- Learned to document **request and response types**, including examples and constraints (DataAnnotations).
- Added **global default responses** (400, 404, 500) for consistent API documentation.

## 4. Miscellaneous Learnings
- Learned why **throwing exceptions is costly** for performance; better to use typed error results where possible.
- Explored **RouteGroupBuilder** features: tags, summaries, descriptions.
- Understood how to show **field constraints** in Swagger for scalars (e.g., max length, required, range).
- Practiced handling nullable route parameters and returning custom validation errors instead of default BadRequest.

---

### ✅ Key Takeaways
- Separation of concerns: handlers, validators, and endpoints.
- Effective error handling with `ErrorOr`.
- Full API documentation even with minimal APIs / scalars.
- Writing testable code and organizing tests in the same assembly or separate projects.
- Clean, readable, and maintainable code structure with pipeline behaviors and DI.

