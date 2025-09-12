różnice między monolitem, mikroserwisami a modularnym monolitem

caching (Redis)

architektura

DDD, CQRS

Konteneryzacja

Relational vs NonRelational 

SQL Server !!! przepięcie z postgres na sql server
Triggers

Logs

- [ ] 🏛️ Monolith vs Microservices vs Modular Monolith
    - **Monolith**: Single deployable unit, tightly coupled components.  
      _Pros_: simple to develop, easy to test.  
      _Cons_: hard to scale, slow releases.  
    - **Microservices**: Independently deployable services, each owning its data.  
      _Pros_: scalable, flexible, isolated failures.  
      _Cons_: complex infrastructure, inter-service communication.  
    - **Modular Monolith**: Single deployable unit but internally modular.  
      _Pros_: easier refactoring, faster than microservices.  
      _Cons_: scaling is limited compared to microservices.

- [ ] 🧰 Caching (Redis)
    - In-memory key-value store.
    - Use cases: session storage, reducing DB load, caching expensive queries.
    - Example: `GET user:123` → if missing → fetch from DB → store in Redis.

- [ ] 🏗️ Architecture
    - Layered, hexagonal, event-driven, microkernel, serverless patterns.
    - Consider maintainability, scalability, and deployment strategy.

- [ ] 📦 DDD (Domain-Driven Design)
    - Focus on domain logic.
    - Entities, Value Objects, Aggregates, Repositories.
- [ ] ⚡ CQRS (Command Query Responsibility Segregation)
    - Separate reads and writes.
    - Often combined with Event Sourcing.

- [ ] 🐳 Containerization
    - Docker for packaging apps and dependencies.
    - Kubernetes for orchestration.
    - Ensures environment consistency across dev, test, prod.

- [ ] 💾 Relational vs NonRelational
    - **Relational (SQL)**: structured, ACID, strong consistency.  
      Examples: SQL Server, PostgreSQL, MySQL.
    - **NonRelational (NoSQL)**: flexible schema, often eventual consistency.  
      Examples: MongoDB, Cassandra, Redis.

- [ ] 🟦 SQL Server (migration from PostgreSQL)
    - Differences: T-SQL syntax, identity columns, functions, stored procedures.
    - Considerations: data types, sequences, triggers.
- [ ] ⚡ Triggers
    - Automate actions in DB on insert/update/delete.
    - Use with care (can affect performance and debugging).

- [ ] 📜 Logs
    - Collect structured logs (Serilog, ELK, Application Insights).
    - Include correlation IDs, timestamps, severity levels.
    - _Note_: Logging is critical for observability and troubleshooting.
