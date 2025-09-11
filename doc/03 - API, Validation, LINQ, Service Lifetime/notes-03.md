# 📌 Notes

## 🔹 What is an API Response?

An **API response** is what the server sends back after a client request.  
It usually contains:

- **HTTP Status Code** → outcome of the request.
- **Headers** → metadata like `Content-Type`, caching, etc.
- **Body (payload)** → the actual data (JSON, XML, text, etc.).

---

# 📌 Problem Details (RFC 7807)

## 🔹 What is Problem Details?

**Problem Details** is a standardized format for representing API errors in a consistent way.

Instead of returning different error objects for each endpoint, you always return a **structured JSON response**.

---

## 🔹 Why Use Problem Details?

- ✅ **Consistency** → All errors follow the same structure.
- ✅ **Machine-friendly** → Clients can parse fields like `status` and `type`.
- ✅ **Extensible** → You can add extra fields (`errors`, `traceId`).
- ✅ **Standards-based** → Widely supported, based on an official RFC.

---

### 🔹Standard JSON Format Example

```json
{
  "type": "https://example.com/probs/validation-error",
  "title": "One or more validation errors occurred.",
  "status": 400,
  "detail": "The Name field is required.",
  "instance": "/users/123"
}
```

---

## 🔹 Common HTTP Status Codes

### ✅ Success

- **200 OK** → Request succeeded, returns data.
- **201 Created** → Resource successfully created (often with `Location` header).
- **202 Accepted** → Request accepted, but still processing.
- **204 No Content** → Success, but no body returned (e.g., DELETE).

### ⚠️ Client Errors

- **400 Bad Request** → Invalid request (bad JSON, missing field, etc.).
- **401 Unauthorized** → Authentication required / invalid credentials.
- **403 Forbidden** → Authenticated, but not allowed.
- **404 Not Found** → Resource doesn’t exist.
- **409 Conflict** → Conflict with current state (duplicate, version issue).

### ❌ Server Errors

- **500 Internal Server Error** → Unexpected server failure.
- **502 Bad Gateway** → Invalid response from upstream service.
- **503 Service Unavailable** → Service overloaded or down.
- **504 Gateway Timeout** → Server didn’t respond in time.

---

# 📌 FluentValidation – Comprehensive Notes

## 🔹 What is FluentValidation?

**FluentValidation** is a .NET library used to create **validation rules for objects, commands, or DTOs** in a clean, readable, and maintainable way.

Key points:

- Uses **fluent, chainable syntax** for defining rules.
- Keeps **validation logic separate from business logic**.
- Integrates with **ASP.NET Core**, **Minimal API**, **MediatR**, and MVC.
- Supports **complex rules, nested objects, and collections**.
- Works well with **ProblemDetails** and **Swagger/OpenAPI** for standardized error responses.

---

## 🔹 Why Use FluentValidation?

- ✅ **Readable and maintainable** – easy to understand rules.
- ✅ **Reusable** – one validator can be used in multiple endpoints or handlers.
- ✅ **Consistent error structure** – integrates well with standardized API error formats.
- ✅ **Extensible** – supports custom error messages, conditions, and complex logic.
- ✅ **Separation of concerns** – validation is not mixed with business logic.

---

# LINQ in .NET

## 🔹 What is LINQ?

**LINQ (Language Integrated Query)** is a set of query operators built into C# (and other .NET languages) that allows you to query data in a **declarative** way.

You can use LINQ to filter, sort, group, and transform data from:

- collections (`List<T>`, arrays),
- databases (via **Entity Framework**, LINQ to SQL),
- XML files,
- and even data streams.

---

## 🔹 Why is LINQ useful?

✅ Replaces loops (`for`, `foreach`) with shorter, more readable code  
✅ Provides a unified way of working with different data sources  
✅ Type-safe (checked at compile time)

---

# Delegates in LINQ

## 🔹 What is a Delegate?

A **delegate** is like a variable that can store a function.  
It allows you to **pass code as a parameter** to another method.

In LINQ, delegates tell operators **what to do** with each element.

---

## 🔹 Common Delegate Types

- `Func<T, TResult>` → takes a value, returns a result  
  Example: `Func<int, bool>` → takes an `int`, returns `true/false`
- `Action<T>` → takes a value, returns nothing
- `Predicate<T>` → same as `Func<T, bool>`

---

## 🔹 Delegates in Action

Example with `Where`:

```csharp
var result = numbers.Where(n => n > 5);
```

Here:

- `Where` needs a function `Func<int, bool>`
- `n => n > 5` is a **lambda expression** that matches this delegate
- LINQ calls this function for each element in `numbers`

---

## 🔹 Without vs With LINQ

Without LINQ:

```csharp
List<int> filtered = new List<int>();
foreach (var n in numbers)
{
    if (n > 5)
        filtered.Add(n);
}
```

With LINQ:

```csharp
var filtered = numbers.Where(n => n > 5);
```

👉 Both do the same thing.  
LINQ is shorter because it uses delegates.

---

## 🔹 Delegate Types per Operator

- `Where` → needs `Func<T, bool>`

  ```csharp
  var evens = numbers.Where(n => n % 2 == 0);
  ```

- `Select` → needs `Func<T, TResult>`

  ```csharp
  var doubled = numbers.Select(n => n * 2);
  ```

- `OrderBy` → needs `Func<T, TKey>`

  ```csharp
  var sorted = people.OrderBy(p => p.LastName);
  ```

- `GroupBy` → needs `Func<T, TKey>`
  ```csharp
  var grouped = people.GroupBy(p => p.Age);
  ```

---

## 🔹 Delegates vs Expression Trees

- **LINQ to Objects** (Lists, Arrays) → uses real delegates, runs in memory
- **LINQ to SQL / Entity Framework** → uses expression trees, which are converted into SQL queries

---

# Service Lifetimes in .NET (Transient, Scoped, Singleton)

## 🔹 What are Service Lifetimes?

In .NET Dependency Injection (DI), when you register a service, you must define its **lifetime**.  
The lifetime determines **how long an instance of the service will live**.

There are three main lifetimes:

---

## 1. **Transient**

- 🔄 A **new instance is created every time** the service is requested.
- **Use when:** the service is lightweight, stateless, and does not need to share data.
- **Example:**
  ```csharp
  services.AddTransient<IMyService, MyService>();
  ```
- 👉 Every consumer gets a fresh instance.

---

## 2. **Scoped**

- ♻️ **One instance per HTTP request (or scope)**.
- Within a single request, all consumers share the same instance.
- **Use when:** the service works with request-specific data, e.g. `DbContext`.
- **Example:**
  ```csharp
  services.AddScoped<IMyService, MyService>();
  ```
- 👉 Same request → same instance. Different request → new instance.

---

## 3. **Singleton**

- 🏛️ **One instance for the entire application lifetime**.
- All consumers, across all requests, share the same object.
- **Use when:** the service is stateless, thread-safe, and intended to be reused globally (e.g., caching, logging).
- **Example:**
  ```csharp
  services.AddSingleton<IMyService, MyService>();
  ```
- 👉 The same object is reused everywhere.

---

## 🔹 Comparison Table

| Lifetime      | Instances Created  | Typical Use Case                           |
| ------------- | ------------------ | ------------------------------------------ |
| **Transient** | New each time      | Lightweight, stateless helpers/services    |
| **Scoped**    | One per request    | Request-specific services (e.g. DbContext) |
| **Singleton** | One for entire app | Shared services (e.g. cache, config, log)  |

---

## 🔹 Best Practices

- Use **Transient** for lightweight, short-lived operations.
- Use **Scoped** for services tied to a single request (recommended for `DbContext`).
- Use **Singleton** for global, thread-safe, shared services.
- ❌ Do not register `DbContext` as Singleton or Transient → it should always be **Scoped**.

```csharp
services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));
```

---

## 🔹 Summary

- **Transient** → new instance every time (no shared state).
- **Scoped** → one instance per request (consistent state within request).
- **Singleton** → one instance for the whole app (global, shared).

---

# Encapsulation in C#

**Encapsulation** = hiding internal details of a class and providing a controlled interface to access data.

It is mainly achieved through **access modifiers** and sometimes with the `sealed` keyword.

---

## 🔹 Access Modifiers (Types of Encapsulation)

1. **Private**

- Access: only inside the class
- Use: hide fields or implementation details

```csharp
private int age;
```

2. **Protected**

- Access: inside the class and in derived classes
- Use: allow extensions but still hide implementation

```csharp
protected void CalculateSalary() { ... }
```

3. **Internal**

- Access: only within the same assembly/project
- Use: hide implementation from external libraries

```csharp
internal class Helper { ... }
```

4. **Protected Internal**

- Access: derived classes or same assembly
- Use: allow controlled access in specific scenarios

```csharp
protected internal void Log() { ... }
```

5. **Private Protected**

- Access: derived classes in the same assembly only
- Use: very strict encapsulation for extensions in same project

```csharp
private protected int counter;
```

6. **Public**

- Access: everywhere
- Use: expose safe API to external code

```csharp
public string Name { get; set; }
```

---

## 🔹 Sealed (Optional)

- Prevents a **class from being inherited** or a **method from being overridden**
- Helps **protect implementation** even further

```csharp
sealed class Logger { ... }
```

---

## 🔹 Summary Table

| Type               | Access Scope                                | Purpose                               |
| ------------------ | ------------------------------------------- | ------------------------------------- |
| Private            | Class only                                  | Hide internal fields/methods          |
| Protected          | Class + derived classes                     | Allow controlled inheritance          |
| Internal           | Same assembly                               | Hide from external projects           |
| Protected Internal | Derived classes or same assembly            | Flexible controlled access            |
| Private Protected  | Derived classes in same assembly only       | Very strict controlled access         |
| Public             | Everywhere                                  | Expose safe API                       |
| Sealed             | Class/method cannot be inherited/overridden | Protect implementation from extension |
