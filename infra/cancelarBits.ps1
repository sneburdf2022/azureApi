#Ativar execução de proweshell
# execite o comando abaixo para ativar  execução de script
#Set-ExecutionPolicy RemoteSigned
# Obter todos os trabalhos do BITS
$jobs = Get-BitsTransfer

# Loop através de cada trabalho
foreach ($job in $jobs) {
    if ($job.JobState -eq 'Transferred') {
        # Cancelar o trabalho
        Remove-BitsTransfer -BitsJob $job
        Write-Host "Cancelado o trabalho com ID: $($job.JobId)"
    }
}