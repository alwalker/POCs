namespace ServiceLayer
open System.ServiceProcess

//This has to be in a seperate file!
module Main = 
    [<EntryPoint>] 
    let Main(args) = 
        ServiceBase.Run(new WindowsService())
        0
        