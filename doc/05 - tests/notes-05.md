# TESTS, MOCKS AND BUILDERS

# 🧪 xUnit & NUnit

---

## NUnit – common attributes
- ✅ **[Test]** – marks a test method.
- 🔄 **[TestCase]** – runs a test multiple times with different input values.
- ⚙️ **[SetUp]** – method executed before each test (initialization).
- 🧹 **[TearDown]** – method executed after each test (cleanup).
- 🏷️ **[TestFixture]** – marks a test class (optional in modern NUnit).

---

# 🧩 xUnit – Attributes and Usage

## Common attributes
- ✅ **[Fact]** – defines a single test method without parameters.
- 🔄 **[Theory]** – defines a parameterized test method.
- ✏️ **[InlineData(...)]** – supplies inline arguments to a theory.
- 📦 **[MemberData(...)]** – supplies arguments from a property or method.
- 🗂️ **[ClassData(...)]** – supplies arguments from a class implementing `IEnumerable<object[]>`.

---

## Setup and Teardown
- ⚙️ **Constructor** – runs before each test (setup logic)
- 🧹 **IDisposable.Dispose()** – runs after each test (teardown logic)

--

# 🎯 Moq

---

## What is Moq?

Moq is a popular library in the .NET ecosystem used for creating **mocks (simulations) of objects** in unit tests. It allows developers to isolate the code under test by replacing real dependencies with controlled stand-ins.

In short:

- 🧩 **Unit testing framework**
- 🎭 **Simulated implementations of interfaces and virtual classes**
- 🚫 **Test code without relying on actual external dependencies** (databases, APIs, files)

---

## Example of using Moq

```csharp
using Moq;
using Xunit;

public interface ICalculator
{
    int Add(int a, int b);
}

public class CalculatorService
{
    private readonly ICalculator _calculator;

    public CalculatorService(ICalculator calculator)
    {
        _calculator = calculator;
    }

    public int AddFive(int value)
    {
        return _calculator.Add(value, 5);
    }
}

public class CalculatorServiceTests
{
    [Fact]
    public void AddFive_ShouldReturnCorrectResult()
    {
        // 🎭 Creating mock
        var mockCalculator = new Mock<ICalculator>();
        
        // ⚙️ Define behaviour
        mockCalculator.Setup(c => c.Add(It.IsAny<int>(), 5))
                      .Returns<int, int>((a, b) => a + b);
        
        var service = new CalculatorService(mockCalculator.Object);
        
        var result = service.AddFive(10);
        
        Assert.Equal(15, result);
        
        // ✅ Check if method was called exactly once
        mockCalculator.Verify(c => c.Add(10, 5), Times.Once);
    }
}
```

---

# Real-world mock practice in .NET teams

## 🟢 Moq – most commonly used

- It is the **dominant choice in most .NET projects**.  
- **Why?**  
  - Stable and well-documented.  
  - Easy to integrate with xUnit, NUnit, MSTest.  
  - Sufficient for most cases (interfaces, virtual methods).  
- In **new projects**, it is practically the standard: **xUnit + Moq**.

---

## 🟡 NSubstitute and FakeItEasy – alternatives

- Popular in some teams, mainly because:  
  - More **readable syntax**.  
  - Easier to create **stubs in simple tests**.  
- They are used, but **less frequently than Moq**.  
- Usually chosen when the team values **shorter, natural test code**.

---

## 🔴 JustMock and Typemock

- More niche, used only in:  
  - **Legacy code** (older projects, difficult dependencies).  
  - When **mocking static or sealed classes** is required (not supported by Moq).  
- Commercial or more advanced, so **rarely used in new projects**.

---

## 🔧 Mocking Frameworks Comparison

| Framework | Mock Type | Test Integration | Ease of Use | Advantages | Limitations | Typical Use Cases |
|-----------|-----------|-----------------|------------|-----------|------------|----------------|
| 🟦 **Moq** | Interfaces & virtual methods | xUnit, NUnit, MSTest | Very simple | Popular, well-documented, strong call verification | Cannot mock static/sealed classes without extra tools | Unit testing, dependency isolation, interaction verification |
| 🟩 **NSubstitute** | Interfaces & virtual methods | xUnit, NUnit, MSTest | Very simple | Intuitive setup, easy stubs | Limited advanced verification vs Moq | Quick, readable unit tests |
| 🟧 **FakeItEasy** | Interfaces & virtual methods | xUnit, NUnit, MSTest | Simple & friendly | Easy to learn, good API | Some advanced scenarios need combination | Unit testing, call verification, returning values |
| 🟥 **JustMock (Telerik)** | Interfaces, virtual, static, sealed | xUnit, NUnit, MSTest | Medium | Can mock static/sealed classes, advanced features | Paid version, more complex | Advanced mocking, legacy code, integration testing |
| 🟪 **Typemock Isolator** | All classes incl. sealed/static | xUnit, NUnit, MSTest | Medium | Mocks everything, even hard dependencies | Commercial | Legacy code testing, full mocking without code changes |

---

# 🧪 Unit Test Patterns: AAA vs Arrange + Act&Assert

---

## 1️⃣ AAA – Arrange, Act, Assert

**Steps:**
1. 🛠️ **Arrange** – prepare objects, mocks, and data.  
2. ▶️ **Act** – call the method under test.  
3. ✅ **Assert** – verify results.

**Example: Normal output**

```csharp
// 🛠️ Arrange
var calculator = new Calculator();
int a = 2, b = 3;

// ▶️ Act
var result = calculator.Add(a, b);

// ✅ Assert
Assert.Equal(5, result);
```

---

## 2️⃣ Arrange + Act&Assert (for exceptions)

**Steps:**
1. 🛠️ **Arrange** – prepare objects and data.  
2. ⚡ **Act & Assert** – call the method inside an assertion that expects an exception.

**Example: Testing exceptions**

```csharp
// 🛠️ Arrange
var calculator = new Calculator();

// ⚡ Act & Assert
var ex = Assert.Throws<DivideByZeroException>(() => calculator.Divide(5, 0));
Assert.Equal("Cannot divide by zero", ex.Message);
```

---

### ⚡ Key Differences

| Pattern | Action | Assertion | Typical Use Case | Pros |
|---------|--------|----------|----------------|------|
| 🟢 **AAA** | Separate `Act` | Separate `Assert` | Normal return values | Clear separation, readable, maintainable |
| 🔴 **Arrange + Act&Assert** | Combined `Act & Assert` | Exception assertion | Exception testing | Concise, natural for exceptions |

---

# ⚡ Exceptions in .NET

Exceptions in .NET are used to **handle errors and unexpected situations** during program execution. They allow programs to respond to problems gracefully instead of crashing.

---

## 1️⃣ What is an Exception?

- An **exception** is an object that represents an error or unexpected condition.  
- All exceptions in .NET inherit from the base class `System.Exception`.  
- Common built-in exceptions include:  

| Exception | Description |
|-----------|-------------|
| `ArgumentException` | Invalid argument passed to a method. |
| `ArgumentNullException` | Null argument passed where it is not allowed. |
| `ArgumentOutOfRangeException` | Argument is outside the allowable range. |
| `InvalidOperationException` | Method call is invalid for the current object state. |
| `NotImplementedException` | Method or operation is not implemented. |
| `NotSupportedException` | Operation is not supported. |
| `FormatException` | Input string is not in the correct format. |
| `OverflowException` | Arithmetic operation exceeds the allowable range of the type. |
| `UnauthorizedAccessException` | Attempt to access a resource without permission. |
| `SecurityException` | Security violation detected. |

---

## 2️⃣ Throwing Exceptions

You can **throw an exception** using the `throw` keyword:

```csharp
public void Divide(int a, int b)
{
    if (b == 0)
        throw new DivideByZeroException("Cannot divide by zero");
    
    var result = a / b;
}
```

---

## 3️⃣ Catching Exceptions

You can **handle exceptions** using a `try-catch` block:

```csharp
try
{
    Divide(5, 0);
}
catch (DivideByZeroException ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}
```

- `try` contains the code that might throw an exception.  
- `catch` handles specific exceptions.  
- `finally` (optional) executes code regardless of whether an exception occurred:

```csharp
try
{
    // risky code
}
catch (Exception ex)
{
    // handle exception
}
finally
{
    // cleanup code
}
```

---

## 4️⃣ Best Practices

- Throw **specific exception types**, not just `Exception`.  
- Include a **descriptive message** when throwing exceptions.  
- Avoid using exceptions for normal control flow.  
- Catch exceptions **only if you can handle them** or log them properly.

---

## 5️⃣ Custom Exceptions

You can create your own exception classes by inheriting from `Exception`:

```csharp
public class MyCustomException : Exception
{
    public MyCustomException(string message) : base(message) { }
}
```

This is useful for defining **domain-specific error conditions**.

---

# 🔹 Object Builder Libraries in .NET

When writing unit tests in .NET, creating test objects repeatedly can be tedious. **Object builder libraries** help generate single objects or collections quickly, with controlled or automatic values.

---

## 🏗️ NBuilder

- **Purpose:** Quickly create objects and collections for testing.  
- **Key Features:**  
  - Fluent API to set specific properties.  
  - Generate single objects or lists (`CreateListOfSize`).  
  - Useful when you want **full control over the test data**.  
- **Example:**

```csharp
using FizzWare.NBuilder;

var user = Builder<User>.CreateNew()
    .With(u => u.Name = "John")
    .With(u => u.Age = 30)
    .Build();

var users = Builder<User>.CreateListOfSize(5)
    .All()
        .With(u => u.Age = 25)
    .Build();
```

---

## ⚡ AutoFixture / Ska

- **Purpose:** Rapid generation of objects with automatic or random property values.  
- **Key Features:**  
  - Automatically fills all properties of objects.  
  - Quickly create collections with `CreateMany`.  
  - Ideal when **exact property values are less important**, focus on testing logic.  
- **Example:**

```csharp
var fixture = new Fixture();

// Single object
var user = fixture.Create<User>();

// List of objects
var users = fixture.CreateMany<User>(5).ToList();
```

---

## 📝 Comparison: NBuilder vs AutoFixture / Ska

| Feature | NBuilder | AutoFixture / Ska |
|---------|----------|-----------------|
| **Fluent API** | ✅ Yes, easy to read and chain | ✅ Yes, simpler syntax |
| **Creating single objects** | ✅ Yes | ✅ Yes |
| **Creating lists / collections** | ✅ Yes, `CreateListOfSize` | ✅ Yes, `CreateMany` |
| **Automatic property population** | ❌ No, must set manually or use generators | ✅ Yes, default or random values |
| **Control over specific properties** | ✅ Fluent `.With()` syntax | ✅ Can override specific properties |
| **Popular use cases** | Controlled test objects, explicit property setting | Fast object generation, automatic data |
| **Complexity** | Low, readable | Low to moderate (slightly more setup for customizations) |
| **Best for** | Tests where exact values matter | Tests where value details are not critical |

---

### ✅ Summary

- **NBuilder**: Best when you need **full control** over test objects and collections with readable, fluent syntax.  
- **AutoFixture / Ska**: Best for **rapid, automatic object creation**, saving time on boilerplate setup.  
- Often combined with **xUnit + Moq** to create fully automated, readable unit tests.

---

# ⚠️ When Not to Use Object Builder Libraries

While libraries like **NBuilder, AutoFixture, or Ska** are very helpful, there are scenarios where **manual object creation is preferable**.

---

## 1️⃣ Very Simple Objects

- If the object has only **1–2 properties**, using a builder adds unnecessary complexity.  
- Example:

```csharp
var user = new User { Name = "John", Age = 30 };
```

- ✅ Manual creation is **clearer and more readable**.

---

## 2️⃣ Highly Specific Test Data

- When a test requires **exact, specific values** or complex relationships between properties.  
- Builders or generators may **obscure the intent** of the test.  

```csharp
var order = new Order
{
    Id = 123,
    CustomerId = 456,
    Items = new List<Item>
    {
        new Item { Name = "Item1", Quantity = 2 },
        new Item { Name = "Item2", Quantity = 1 }
    }
};
```

- Here, manual creation ensures **full control over the data**.

---

## 3️⃣ Tests That Depend on Side Effects

- If the object interacts with **external resources** (files, database, services), automatic generation may create **invalid or meaningless values**.  
- Manual setup ensures **valid and meaningful test objects**.

---

## 4️⃣ Small, One-Off Tests

- For **quick tests** or prototypes, adding a builder dependency may be **overkill**.  
- Sometimes it's simpler to create objects inline.

---

## 5️⃣ Readability & Maintainability Concerns

- In teams unfamiliar with the library, using builders can make tests **harder to read**.  
- If a test requires a **very specific configuration**, the fluent API can become **verbose and less clear** than simple object initialization.

---

### ✅ Summary

- **Use libraries** when creating **multiple objects, large collections, or randomized data**.  
- **Avoid libraries** for **simple, highly controlled, or one-off objects**.  
- The goal is always **clarity and maintainability** of your tests, not just reducing lines of code.

---

# ⚡ Using Methods to Apply DRY in Unit Tests

In unit testing, you often have repeated steps like **creating test objects, mocks, or setup logic**. To avoid duplication and follow the **DRY principle**, you can extract common code into separate methods.

---

## 1️⃣ Common Setup Methods

Instead of repeating the same initialization in every test:

```csharp
[Fact]
public void Test1()
{
    var calculator = new Calculator();
    var result = calculator.Add(2, 3);
    Assert.Equal(5, result);
}

[Fact]
public void Test2()
{
    var calculator = new Calculator();
    var result = calculator.Add(10, 20);
    Assert.Equal(30, result);
}
```

You can extract a **helper method**:

```csharp
private Calculator CreateCalculator() => new Calculator();

[Fact]
public void Test1()
{
    var calculator = CreateCalculator();
    Assert.Equal(5, calculator.Add(2, 3));
}

[Fact]
public void Test2()
{
    var calculator = CreateCalculator();
    Assert.Equal(30, calculator.Add(10, 20));
}
```

✅ Advantages:  
- Less duplication  
- Easier maintenance  
- Tests focus only on the logic being tested

---

## 2️⃣ Reusable Assertion Methods

You can also extract **common assertions**:

```csharp
private void AssertAddition(int a, int b, int expected)
{
    var calculator = new Calculator();
    var result = calculator.Add(a, b);
    Assert.Equal(expected, result);
}

[Fact]
public void Test1() => AssertAddition(2, 3, 5);

[Fact]
public void Test2() => AssertAddition(10, 20, 30);
```

---

## 3️⃣ DRY for Mocks

When using **Moq or other mock frameworks**, you can create **helper methods for frequently used mocks**:

```csharp
private Mock<ICalculator> CreateMockCalculator()
{
    var mock = new Mock<ICalculator>();
    mock.Setup(c => c.Add(It.IsAny<int>(), It.IsAny<int>()))
        .Returns<int, int>((a, b) => a + b);
    return mock;
}

[Fact]
public void TestWithMock()
{
    var mock = CreateMockCalculator();
    Assert.Equal(15, mock.Object.Add(10, 5));
}
```

---

### ✅ Key Takeaways

- Extract repeated **setup, object creation, or assertions** into methods.  
- Helps **keep tests short, readable, and maintainable**.  
- Avoids violating **DRY**, especially in large test suites.  
- Combine with **builder libraries (NBuilder / AutoFixture)** for maximum reuse and clarity.
