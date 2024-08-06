#r "nuget:FSharp.Data"

open FSharp.Data

let html = Http.RequestString("https://docs.microsoft.com/dotnet/fsharp/")

printfn $"{html}"