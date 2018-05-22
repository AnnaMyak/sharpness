$rootDir = "\\wsi-stor01\TagesScans\Routine\VSF\2017"


$exePath = "C:\Users\seidelf\source\repos\Florian_Projects\SharpnessExplorationCurrent\SharpnessExplorationCurrent\bin\x64\Release\SharpnessExplorationCurrent.exe"

foreach($slidepath in Get-ChildItem -Path $rootDir -Recurse -Filter "*.vsf")
{
    Write-Host "#####################################################"
    Write-Host "Processing slide: "$slidepath.FullName

    # leave if sharpness should already exist!
    if(Test-Path ($slidepath.DirectoryName + "\meta\sharpness"))
    {
        Write-Host "Sharpness Directory already exists!"
        continue
    }
    
    # run sharpness analysis
    & $exePath $slidepath.FullName

    Write-Host "Done with slide: " $slidepath
}