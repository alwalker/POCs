module PayGrade

open System
open SilverlightOdataFSharpPOC.Stuff.DataFeedServiceReference

let GetAllPayGrades =
    async {
        let context = new POCModel(new Uri "blargity blarg")
        let! res = context.BeginExecute null, null, null
        res
    }