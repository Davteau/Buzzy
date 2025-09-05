
# 📌 Podsumowanie dnia

## 🔹 Git i Commity
- Nie ma oficjalnego **RFC** dla commitów, ale istnieją de facto standardy:
  - **Conventional Commits (Angular style)** – `feat`, `fix`, `docs`, `chore` itd.  
  - **Git style** – krótki tytuł, opis szczegółowy, tryb rozkazujący.  
- Ułatwienia w pisaniu commitów:
  - **Commitizen** – interaktywne tworzenie commitów.  

---

## ⚙️ Visual Studio & projekty
- Folder `Application` nie był widoczny, bo **nie miał `.csproj`**.  
- Utworzyłeś **Class Library**, dzięki czemu pojawił się w solution.  
- Podział odpowiedzialności:
  - `Api` → punkt wejścia (`WebApplication`, endpointy).  
  - `Application` → logika, feature’y, modele, handlery, walidacja.  

---

## 🛠️ Problemy i rozwiązania
- **Metadata file not found** → `Application` się nie budował → `Api` nie miało DLL.  
  - Rozwiązanie: clean/rebuild solution, poprawny `TargetFramework`, brak błędów w `Application`.  
- **`WebApplication` w `Application` nie działa** → normalne (Class Library nie zna ASP.NET).  
  - Rozwiązanie: logika w `Application`, endpointy zawsze w `Api`.  
- Endpointy rejestrujesz w `Api` przez extension methods, np. `app.MapUserEndpoints();`.

---

## 📦 MediatR i feature’y
- W `Api` endpoint wysyła request do `Application` przez **MediatR**.  
- `Application` zawiera `Request` + `Handler`.  
- `Api` tylko wywołuje `mediator.Send()`.  
- Ważne:
  - `Api` musi mieć **referencję do `Application`**.  
  - Klasy w `Application` muszą być **publiczne** i z poprawnym namespace.  
  - Przykład: `using Application.Common.Models;`.

---

## 🧩 Rola Class Library
- **Dlaczego `Application` jako Class Library?**
  - Oddziela logikę biznesową od warstwy webowej.  
  - Ułatwia testowanie i wielokrotne użycie (np. w workerach).  
  - Wymusza czystą architekturę i przejrzystość zależności.  

---

## 📌 Efekt końcowy
- Solution zawiera `Api` + `Application`.  
- Rozumiesz, dlaczego `Application` nie używa `WebApplication`.  
- Potrafisz podpiąć klasy z `Application` do endpointów w `Api`.  
- Widzisz różnicę między podejściem `Api/Features` a `Application` jako osobnym projektem.
