# 📝 Projektowa Checklista

---

## 1. Soft 💻
- [x] Zainstalowane IDE (Visual Studio / VS Code / Rider)
- [x] .NET 9 SDK
- [x] System kontroli wersji (Git)
- [x] Przeglądarka do testowania API (Chrome / Edge / Postman / Insomnia)
- [x] Menedżer pakietów (NuGet, npm, yarn lub pnpm jeśli frontend)
- [ ] Narzędzia do debugowania/logowania (Serilog, VS Debugger)

---

## 2. Repo 📦
- [x] Utworzone repozytorium Git
- [x] `.gitignore` odpowiedni dla .NET
- [x] Branching model ustalony (main/develop/feature)
- [x] README.md z instrukcjami uruchomienia projektu

---

## 3. Temat 🎯

### 3.1 Scaffolding Backend
- [x] **Pusta solucja** – utworzenie minimalnego projektu .NET
- [x] **Minimal API** – ustawienie podstawowych endpointów
- [x] **Scalar** – podłączenie nowoczesnego UI dokumentacji API
- [ ] **SQL** – wybór bazy danych (SQLite, SQL Server, PostgreSQL)
- [x] **ORM** – Object-Relational Mapping
- [ ] **Refleksja w soft dev**

## 4. MediatR i handlery
- [ ] Dlaczego handlery z MediatR przypominają serwisy?
  - Każdy handler realizuje **jedną, spójną operację biznesową**
  - Podobnie jak serwis, enkapsuluje logikę i może być wywoływany niezależnie
  - Różnica: handlery są często **bardziej granularne** i skupione na pojedynczym request-cie