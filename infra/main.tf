provider "azurerm" {
  features {}
}

# Resource Group
resource "azurerm_resource_group" "rg" {
  name     = "${var.project_name}-${var.environment}-rg"
  location = var.location
}

# Application Insights
resource "azurerm_application_insights" "appinsights" {
  name                = "${var.project_name}-${var.environment}-ai"
  location            = azurerm_resource_group.rg.location
  resource_group_name = azurerm_resource_group.rg.name
  application_type    = "web"
}

# PostgreSQL Flexible Server
resource "azurerm_postgresql_flexible_server" "db" {
  name                   = "${var.project_name}-${var.environment}-pg"
  resource_group_name    = azurerm_resource_group.rg.name
  location               = azurerm_resource_group.rg.location
  administrator_login    = "pgadmin"
  administrator_password = var.db_admin_password
  sku_name               = "B_Standard_B1ms"
  storage_mb             = 32768
  version                = "13"
  backup_retention_days  = 7
}

# Key Vault
resource "azurerm_key_vault" "kv" {
  name                = "${var.project_name}${var.environment}kv"
  location            = azurerm_resource_group.rg.location
  resource_group_name = azurerm_resource_group.rg.name
  tenant_id           = data.azurerm_client_config.current.tenant_id
  sku_name            = "standard"
  purge_protection_enabled = false
}

data "azurerm_client_config" "current" {}

# App Service Plan
resource "azurerm_service_plan" "plan" {
  name                = "${var.project_name}-${var.environment}-asp"
  location            = azurerm_resource_group.rg.location
  resource_group_name = azurerm_resource_group.rg.name
  sku_name            = "B1"     
  os_type             = "Linux"
}

# App Service
resource "azurerm_app_service" "app" {
  name                = "${var.project_name}-${var.environment}-app"
  location            = azurerm_resource_group.rg.location
  resource_group_name = azurerm_resource_group.rg.name
  app_service_plan_id = azurerm_service_plan.plan.id
  https_only          = true

  app_settings = {
    "APPINSIGHTS_INSTRUMENTATIONKEY" = azurerm_application_insights.appinsights.instrumentation_key
    "POSTGRESQL_ADMIN_PASSWORD"      = var.db_admin_password
  }
}
