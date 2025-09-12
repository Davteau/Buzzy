provider "azurerm" {
  features {}
  subscription_id = jsondecode(var.azure_credentials_json).subscriptionId
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

resource "azurerm_postgresql_flexible_server" "db" {
  name                   = "${lower(var.project_name)}-${lower(var.environment)}-pg"
  resource_group_name    = azurerm_resource_group.rg.name
  location               = azurerm_resource_group.rg.location
  administrator_login    = "pgadmin"
  administrator_password = var.db_admin_password
  sku_name               = "B_Standard_B1ms"
  storage_mb             = 32768
  version                = "15"
  backup_retention_days  = 7
  zone                   = "2"

  lifecycle {
    ignore_changes = [
      administrator_password
    ]
  }
}


data "azurerm_client_config" "current" {}

# Key Vault
resource "azurerm_key_vault" "kv" {
  name                = "${var.project_name}-${var.environment}-kv"
  location            = azurerm_resource_group.rg.location
  resource_group_name = azurerm_resource_group.rg.name
  tenant_id           = data.azurerm_client_config.current.tenant_id
  sku_name            = "standard"
  purge_protection_enabled = false
}

# App Service Plan
resource "azurerm_service_plan" "plan" {
  name                = "${var.project_name}-${var.environment}-asp"
  location            = azurerm_resource_group.rg.location
  resource_group_name = azurerm_resource_group.rg.name
  sku_name            = "B1"     
  os_type             = "Linux"
}

# App Service
resource "azurerm_linux_web_app" "app" {
  name                = "${var.project_name}-${var.environment}-app"
  location            = azurerm_resource_group.rg.location
  resource_group_name = azurerm_resource_group.rg.name
  service_plan_id     = azurerm_service_plan.plan.id

  site_config {
    always_on = true
  }

  identity {
    type = "SystemAssigned"
  }

  app_settings = { 
    "APPLICATIONINSIGHTS_CONNECTION_STRING" = azurerm_application_insights.appinsights.connection_string
   }

  https_only = true
}

resource "azurerm_role_assignment" "app_insights_access" {
  scope                = azurerm_application_insights.appinsights.id
  role_definition_name = "Monitoring Contributor"
  principal_id         = azurerm_linux_web_app.app.identity[0].principal_id
}
