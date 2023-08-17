$allObject = Get-ChildItem c:\project\azure-sdk-for-net\sdk -Exclude "core" |Foreach-Object {Get-ChildItem -Path $_.FullName -Directory -Filter "Azure.*"} |Sort-Object| Get-Unique
$all = @()
$allObject | ForEach-Object {
    $all += @($_.Name)
}

$mgmtObject = Get-ChildItem c:\project\azure-sdk-for-net\sdk -Exclude "core" |Foreach-Object {Get-ChildItem -Path $_.FullName -Directory -Filter "Azure.ResourceManager.*"} | Sort-Object | Get-Unique
$mgmt = @()
$mgmtObject | ForEach-Object {
    $mgmt += @($_.Name)
}

$dpg = $all | Where-Object { $mgmt -notcontains $_}

Start-Transcript -Path "./sdksResult.txt"
Write-Host "Total SDK packages: $($all.Count)"
$all | ForEach-Object {
    # Write-Host $_.Name
    Write-Host $_
}

Write-Host "Total mgmt SDK packages: $($mgmt.Count)"
$mgmt | ForEach-Object {
    # Write-Host $_.Name
    Write-Host $_
}

Write-Host "Total data-plane SDK packages: $($dpg.Count)"
$dpg | ForEach-Object {
    Write-Host $_
}
Stop-Transcript