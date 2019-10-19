param (
    [string]$target = ""
)

Write-Host -ForegroundColor Green "NuGetContentGenerator started for target platform $target..."

Function Get-PSScriptRoot
{
    $ScriptRoot = ""

    try
    {
        $ScriptRoot = Get-Variable -Name PSScriptRoot -ValueOnly -ErrorAction Stop
    }
    catch
    {
        $ScriptRoot = Split-Path $script:MyInvocation.MyCommand.Path
    }
    Write-Output $ScriptRoot
}

$srcDir = Get-PSScriptRoot
$srcDirFilter = "bin|obj"
$dstDir = $srcDir + "\contentFiles\cs\" + $target  
$csExtension = "*.cs"
$csppExtension = ".cs.pp"

try
{	
	# Retrieve list of files 
	$files = Get-ChildItem -Recurse -Path $srcDir -Include $csExtension | Where-Object {$_.PSParentPath -notmatch $srcDirFilter}

	# Get path names 
	foreach ($file in $files)
	{
		$path = $file.DirectoryName.Replace($srcDir, $dstDir)
       
		if (-not (Test-Path -Path $path))
		{
			New-Item -Path $path -ItemType Directory | Out-Null
		}
       
		$filename = $file.BaseName + $csppExtension

		Copy-Item -Path $file -Destination $(Join-Path -Path $path -ChildPath $filename) -Force
	}
}
catch
{
	Write-Host -ForegroundColor Red "ERROR - NuGetContentGenerator failed with error:"
	Write-Host -ForegroundColor Red $_.Exception.Message
	return 
}

Write-Host -ForegroundColor Green "SUCCESS - NuGetContentGenerator finished successfully for $target"
