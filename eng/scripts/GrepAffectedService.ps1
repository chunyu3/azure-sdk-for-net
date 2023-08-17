$generated = Get-ChildItem -Path 'c:\project\azure-sdk-for-net\sdk' -Recurse -Directory -Filter 'Generated' | ForEach-Object {
    # Find the directory name in the parent heirarchy that matches Azure.*
    $parent = $_.Parent
    while ($parent -ne $null -and !$parent.Name.StartsWith('Azure.')) {
        $parent = $parent.Parent
    }
    if ($parent -ne $null -and $parent.Name -ne $null -and $parent.Name.StartsWith('Azure.')) {
        $parent.Name # + ' ' + $_.FullName
    }
} | Sort-Object | Get-Unique

$all = Get-ChildItem -Path 'c:\project\azure-sdk-for-net\sdk' -Recurse -Directory -Filter 'Azure.*' | ForEach-Object {
    if($_.Name.StartsWith('Azure.') -and !$_.Name.StartsWith('Azure.Core') -and !$_.Name.StartsWith('Azure.Extensions') -and !$_.Name.EndsWith('.Perf') -and !$_.Name.EndsWith('Tests') -and !$_.Name.EndsWith('.Common') -and !$_.Name.EndsWith('.Shared')) {
        $_.Name
    }
} | Sort-Object | Get-Unique

# Find the difference between the two sets
$missing = $all | Where-Object { $generated -notcontains $_}

$missing | ForEach-Object {
    Write-Host $_
}