# Habilitar o recurso WSL
dism.exe /online /enable-feature /featurename:Microsoft-Windows-Subsystem-Linux /all /norestart

# Habilitar o recurso de Máquina Virtual
dism.exe /online /enable-feature /featurename:VirtualMachinePlatform /all /norestart

# Definir o WSL 2 como versão padrão
wsl --set-default-version 2
