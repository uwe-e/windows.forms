# Clean-VSSRepo.ps1
# Purpose: Clean up legacy VSS-exported folder before Git migration

param (
    [string]$RepoPath = ".",
    [string]$GitIgnorePath = ".gitignore"
)

Write-Host "🔍 Scanning repository at $RepoPath..."

# Define patterns to delete
$deletePatterns = @(
    "bin", "obj", "Backup", "Temp", "Debug", "Release",
    "*.suo", "*.user", "*.log", "*.pdb", "*.ilk", "*.aps", "*.sdf",
    "*.vssscc", "*.vspscc", "*.sscc", "vssver.scc", "vssver2.scc",
    "*.exe", "*.dll", "*.lib", "*.class", "*.jar", "*.pyc", "*.cache", "*.tmp", "*.bak"
)

foreach ($pattern in $deletePatterns) {
    Get-ChildItem -Path $RepoPath -Recurse -Force -Include $pattern | ForEach-Object {
        try {
            Remove-Item $_.FullName -Force -Recurse -ErrorAction SilentlyContinue
            Write-Host "🗑️ Removed: $($_.FullName)"
        } catch {
            Write-Warning "⚠️ Could not remove: $($_.FullName)"
        }
    }
}

# Generate .gitignore
$gitIgnoreContent = @"
# .gitignore for legacy .NET/VSS project
bin/
obj/
Backup/
Temp/
Debug/
Release/
*.suo
*.user
*.log
*.pdb
*.ilk
*.aps
*.sdf
*.vssscc
*.vspscc
*.sscc
vssver.scc
vssver2.scc
*.exe
*.dll
*.lib
*.class
*.jar
*.pyc
*.cache
*.tmp
*.bak
"@

#Set-Content -Path (Join-Path $RepoPath $GitIgnorePath) -Value $gitIgnoreContent -Encoding UTF8
#Write-Host "✅ .gitignore created at $GitIgnorePath"

Write-Host "🎉 Cleanup complete. Ready for Git initialization!"
