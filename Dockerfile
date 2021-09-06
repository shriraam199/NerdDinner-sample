FROM mcr.microsoft.com/dotnet/framework/aspnet:4.8-windowsservercore-ltsc2019

SHELL ["powershell", "-command"]

COPY ./  /inetpub/wwwroot/NerdDinner

RUN Add-WindowsFeature NET-Framework-45-ASPNET
RUN Add-WindowsFeature Web-Asp-Net45
RUN New-IISSite -Name "NerdDinner" -PhysicalPath 'C:\inetpub\wwwroot\NerdDinner' -BindingInformation "*:8081:"
RUN Start-IISSite -Name "NerdDinner"
