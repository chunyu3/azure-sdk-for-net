 $candidate = Get-ChildItem c:\project\azure-sdk-for-net\sdk -Exclude "core"| Foreach-Object {Get-ChildItem -Path $_.FullName -Exclude @("Microsoft.*", "*.json")} |Foreach-Object {Join-Path $_.FullName "src"}| Foreach-Object {Get-ChildItem -Path $_ -Exclude @("Generated", "*.csproj", "Properties", "*.md")} |Foreach-Object {echo $_.FullName}
 $candidateFiles = @();
 foreach ($file in $candidate) {
     if ($file.Contains(".cs")) {
        #  echo $file
         $candidateFiles += @($file)
     } else {
        # echo "directory $file"
        $candidateFiles += Get-ChildItem -Path $file -Recurse -Include "*.cs" |Foreach-Object {echo $_.FullName}
     }
 }

#  echo $candidateFiles

 $count = 0;
 $fileCount = 0;
 $result = @()
 $set = New-Object System.Collections.Generic.HashSet[string]
 $serviceInfoRegex = "\/sdk\/(?<service>.*)\/(?<package>.*)\/src\/"
 foreach ($file in $candidateFiles) {
    if ($file.Contains("Generated")) {
        continue;
    }
    
    $fileContent = Get-Content -Path $file
    $match = ($fileContent | Select-String -Pattern "HttpMessage Create.*Request").LineNumber
    if ($match.count -gt 0) {
        $fileCount += 1
        foreach ($line in $match) {
            $count += 1
            # echo $file
            # echo $fileContent[$line - 1]
            $result += @([PSCustomObject]@{
                file = $file
                line = $line
                content = $fileContent[$line - 1]
            })
        }

        $filePath= $file -replace "\\", "/"

        $filematch = $filePath -match $serviceInfoRegex
        if ($filematch) {
            $package = $matches["package"]
            if (!$set.Contains($package)) {
                $set.Add($package)
                # echo $package
            }
        }
    }
 }

 Start-Transcript -Path "./customizeResult.txt"
 Write-Host "Total files which contains customized CreateXXXRequest methods:$fileCount"
 Write-Host "Total customized CreateXXXRequest methods: $count"
#  Write-Host $result
$result | ForEach-Object {
    # Write-Host $_.file
    # Write-Host $_.line
    # Write-Host $_.content
    Write-Host $_.file $_.line
}

Write-Host "Total affected SDKs:"$set.Count
# Write-Host $set
$set | ForEach-Object {
    Write-Host $_
}
Stop-Transcript