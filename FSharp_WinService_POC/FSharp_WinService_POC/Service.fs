namespace ServiceLayer
    open System.ComponentModel 
    open System.Configuration.Install 
    open System.ServiceProcess
    open System.IO
    
    type WindowsService() as this = 
        inherit ServiceBase()

        do 
            this.ServiceName <- "Name" 
            this.EventLog.Log <- "Application"
            
        override this.OnStart(args:string[]) = 
            base.OnStart(args)
            let file = new FileInfo @"C:\test.txt"
            use stream = file.CreateText()
            stream.WriteLine("Test!")
            stream.Close()
            
        override this.OnStop() = 
            base.OnStop()            

    [<RunInstaller(true)>] 
    type MyInstaller() as this = 
        inherit Installer() 
        do 
            let spi = new ServiceProcessInstaller() 
            let si = new ServiceInstaller() 
            spi.Account <- ServiceAccount.LocalSystem 
//            spi.Username <- "UserName" 
//            spi.Password <- "Password"

            si.DisplayName <- "Fance Name"
            si.StartType <- ServiceStartMode.Automatic 
            si.ServiceName <- "Fancy Name"

            this.Installers.Add(spi) |> ignore 
            this.Installers.Add(si) |> ignore