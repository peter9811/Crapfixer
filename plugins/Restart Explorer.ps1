#Requires -RunAsAdministrator

# Check if running as Administrator
if (-not ([Security.Principal.WindowsPrincipal][Security.Principal.WindowsIdentity]::GetCurrent()).IsInRole([Security.Principal.WindowsBuiltInRole]::Administrator)) {
    Write-Warning "This script is recommended to be run as Administrator for best results."
    # Decide if you want to force exit or just warn
    # exit # Uncomment to force admin
}

# Function to show a message box
function Show-MessageBox {
    param (
        [string]$message,
        [string]$title = "Information"
    )
    Add-Type -AssemblyName PresentationFramework
    [System.Windows.MessageBox]::Show($message, $title)
}

# Stop Windows Explorer
Stop-Process -Name explorer -Force

# Start Windows Explorer
Start-Process explorer

# Show message box
Show-MessageBox -message "Windows Explorer has been restarted successfully." -title "Crapfixer"