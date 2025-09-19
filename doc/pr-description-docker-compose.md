# 📌 Description
This PR adds Docker Compose support to enable local development. It includes a [`.env`](.env ) file with the required credentials for the database, making it easier to configure and run the application locally.

---

# ✅ Type of Changes
Select the applicable options (remove the rest):

- [x] 🔧 Configuration / CI/CD

---

# 🔗 Related Issues
Closes #...

---

# 🧪 How to Test
1. Ensure Docker is installed and running on your machine.
2. Run `docker-compose up` to start the application and database.
3. Verify that the application connects to the database using the credentials in the [`.env`](.env ) file.

**Expected result:** The application runs locally and connects to the database without issues.

---

# 📋 Author Checklist
Make sure that:
- [x] The code works locally
- [x] Unit/integration tests were run and passed
- [x] Documentation has been updated if necessary
- [x] Changes follow the code/project style
- [x] Commits have clear and descriptive messages
- [x] Related issues are linked (`Closes #...`)
- [x] PR does not include unnecessary changes (e.g., build files)

---

# 👀 Reviewer Checklist
Reviewers should check:
- [ ] Does the PR solve the reported issue?
- [ ] Is the code readable and consistent with conventions?
- [ ] Are there obvious bugs or performance issues?
- [ ] Is test coverage sufficient?
- [ ] Is documentation adequate?

---

# ℹ️ Additional Notes
The [`.env`](.env ) file includes the following database credentials:
- `CONNECTIONSTRINGS__DEFAULTCONNECTION`
- `POSTGRES_DB`
- `POSTGRES_USER`
- `POSTGRES_PASSWORD`

These are used to configure the database connection for local development.