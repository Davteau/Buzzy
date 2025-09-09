variable "environment" {
  description = "Environment (dev/staging/prod)"
  type        = string
  default     = "dev"
}

variable "db_admin_password" {
  description = "PostgreSQL admin password"
  type        = string
  sensitive   = true
}

variable "location" {
  description = "Azure Region"
  type        = string
  default     = "westeurope"
}

variable "project_name" {
  description = "Project Name"
  type        = string
  default     = "myapp"
}
