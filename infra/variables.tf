variable "environment" {
  description = "Environment (dev/staging/prod)"
  type        = string
  default     = "dev"
}

variable "azure_credentials_json" {
  description = "Azure credentials JSON from GitHub Actions"
  type        = string
  sensitive   = true
}

variable "db_admin_password" {
  description = "PostgreSQL admin password"
  type        = string
  sensitive   = true
}

variable "location" {
  description = "Azure Region"
  type        = string
  default     = "polandcentral"
}

variable "project_name" {
  description = "Project Name"
  type        = string
  default     = "myapp"
}
