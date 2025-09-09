# ☁️ What is the Cloud?

## ☁️ In Computing
The **cloud (cloud computing)** is a model of delivering IT services over the internet. Instead of buying and maintaining your own servers, you use resources provided by cloud vendors such as **Amazon Web Services (AWS), Microsoft Azure, or Google Cloud Platform (GCP)**.

### Main models of cloud services:
- **IaaS (Infrastructure as a Service)** – Infrastructure like servers and storage.  
- **PaaS (Platform as a Service)** – Platforms to build and deploy applications.  
- **SaaS (Software as a Service)** – Ready-to-use apps delivered online (e.g., Gmail, Dropbox).  

---

# 🌍 How Hosting a Website in the Cloud Works

Hosting a website in the cloud replaces traditional hosting on a single server with scalable cloud infrastructure.

## Steps:
1. **Develop your website** – using HTML, React, WordPress, etc.  
2. **Choose a cloud provider** – AWS, GCP, Azure, or simpler ones like Vercel, Netlify, Heroku.  
3. **Deploy the code**  
   - **Static site**: upload files (e.g., to AWS S3, Vercel, Netlify).  
   - **Dynamic site**: run on virtual servers (EC2, Compute Engine, Azure VM).  
4. **Add a database** (optional): e.g., AWS RDS, Google Cloud SQL.  
5. **Configure domain and DNS**: point your domain to the cloud service.  
6. **Scaling**: if traffic spikes, cloud services allocate more resources automatically.  

---

# 🌩️ The Big Three: AWS, Azure, and Google Cloud

---

## 🔍 Quick Comparison
| Feature | AWS | Azure | GCP |
|---------|-----|-------|-----|
| **Launch** | 2006 | 2010 | 2008 |
| **Strength** | Scale, # of services | Microsoft integration | AI, Big Data |
| **Clients** | Netflix, Airbnb, NASA | BMW, Samsung, eBay | Spotify, PayPal |
| **Best for** | Enterprises, broad use cases | Corporates with MS tools | Startups, data-heavy apps |

---

# ⚙️ How the Cloud Replaces Traditional Servers

## Traditional (on-premises) approach:
- Buy physical servers.  
- Maintain infrastructure (power, cooling, security).  
- Install OS and apps manually.  
- Scaling = buying more servers.  
- Downtime risk if hardware fails.  

## Cloud approach:
- Rent infrastructure online.  
- Provider manages physical servers.  
- Quickly scale up/down as needed.  
- Pay-as-you-go billing.  
- Redundancy across multiple data centers → high availability.  
- Built-in security and backups.  

💡 **Analogy:** like electricity. Companies once had their own generators; now they just plug into the power grid. Cloud computing works the same way.  

---

# 📦 IaaS, PaaS, SaaS Explained

These are the three main service models in cloud computing. They differ by **how much responsibility you keep** vs. how much the provider manages.

---

## 🔹 IaaS – *Infrastructure as a Service*
- Provides: virtual servers, storage, networking.  
- You install and manage OS, apps, configs.  
- **Examples:** AWS EC2, Azure VM, Google Compute Engine.  
- **Analogy:** renting an empty apartment, you furnish it yourself.  

---

## 🔹 PaaS – *Platform as a Service*
- Provides: a platform to build/run apps.  
- No server or OS management.  
- You focus on code and deployment.  
- **Examples:** Google App Engine, Azure App Service, AWS Elastic Beanstalk, Heroku.  
- **Analogy:** renting a fully furnished apartment – just move in and live.  

---

## 🔹 SaaS – *Software as a Service*
- Provides: ready-to-use applications over the internet.  
- No installation or maintenance required.  
- You simply use the app.  
- **Examples:** Gmail, Dropbox, Office 365, Slack, Zoom.  
- **Analogy:** staying in a hotel – everything is provided, you just use it.  

---

## 🔍 Comparison Table

| Model | You Control | Provider Controls | Examples |
|-------|-------------|-------------------|----------|
| **IaaS** | OS, apps, configs | Hardware, networking | AWS EC2, Azure VM |
| **PaaS** | Application code | Servers, OS, runtime | Google App Engine, Heroku |
| **SaaS** | Just usage | Everything else | Gmail, Office 365 |

---

💡 **Pizza Analogy:**  
- IaaS – you buy dough and toppings, then bake yourself.  
- PaaS – you get a baked pizza, but can choose toppings.  
- SaaS – you get a ready slice, just eat it.  

# YAML 

| Feature             | YAML 🟢                                   | JSON 🔵                           | XML 🟠                               |
|--------------------|------------------------------------------|---------------------------------|-------------------------------------|
| **Format**          | Human-readable text                        | Text-based, more "technical"    | Text-based, lots of tags `<tag>`    |
| **Readability**     | ✅ Very high                               | ⚡ Medium                        | ❌ Low for large data                |
| **Comments**        | ✅ Yes (`# comment`)                        | ❌ No                             | ✅ Yes (`<!-- comment -->`)          |
| **Hierarchy**       | Indentation defines structure              | Braces `{}` and brackets `[]`   | Hierarchy via tags                   |
| **Dictionaries**    | ✅ Yes (`key: value`)                       | ✅ Yes (`"key": "value"`)        | ✅ Yes (tags or attributes)          |
| **Lists**           | ✅ Yes (`- item`)                           | ✅ Yes (`[item1, item2]`)        | ✅ Yes (repeating tags)              |
| **Data types**      | String, number, boolean, null             | String, number, boolean, null  | Mostly string; types via attributes |
| **Common use**      | Config files (Docker Compose, GitHub Actions) | API communication (REST)       | Document data, legacy APIs (SOAP)   |
| **Advantages**      | ✅ Human-readable, supports comments        | ✅ Easy to parse, widely used    | ✅ Flexible, supports schemas        |
| **Disadvantages**   | ⚠️ Sensitive to indentation                 | ⚠️ No comments, less readable in large files | ⚠️ Verbose, many tags, harder to read |


## Use-case

### Propozycja nowej kategorii
### Zapraszanie pracownika do firmy