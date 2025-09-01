# 📝 Projektowa Checklista

---

## 1. Soft 💻
- [ ] Zainstalowane IDE (Visual Studio / VS Code / Rider)
- [ ] .NET 9 SDK
- [ ] System kontroli wersji (Git)
- [ ] Przeglądarka do testowania API (Chrome / Edge / Postman / Insomnia)
- [ ] Menedżer pakietów (NuGet, npm, yarn lub pnpm jeśli frontend)
- [ ] Narzędzia do debugowania/logowania (Serilog, VS Debugger)

---

## 2. Repo 📦
- [ ] Utworzone repozytorium Git
- [ ] `.gitignore` odpowiedni dla .NET
- [ ] Branching model ustalony (main/develop/feature)
- [ ] README.md z instrukcjami uruchomienia projektu

---

## 3. Temat 🎯

### 3.1 Scaffolding Backend
- [ ] **Pusta solucja** – utworzenie minimalnego projektu .NET
- [ ] **Minimal API** – ustawienie podstawowych endpointów
- [ ] **Scalar** – podłączenie nowoczesnego UI dokumentacji API
- [ ] **SQL** – wybór bazy danych (SQLite, SQL Server, PostgreSQL)
- [ ] **ORM** – Object-Relational Mapping
- [ ] **Refleksja w soft dev**

## 4. MediatR i handlery
- [ ] Dlaczego handlery z MediatR przypominają serwisy?
  - Każdy handler realizuje **jedną, spójną operację biznesową**
  - Podobnie jak serwis, enkapsuluje logikę i może być wywoływany niezależnie
  - Różnica: handlery są często **bardziej granularne** i skupione na pojedynczym request-cie