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