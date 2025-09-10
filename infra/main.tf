provider "azurerm" {
  features {}
  subscription_id = jsondecode(var.azure_credentials_json).subscriptionId
}

# Resource Group
resource "azurerm_resource_group" "rg" {
  name     = "${var.project_name}-${var.environment}-rg"
  location = var.location
}
