#r "nuget:FSharp.Data"

open FSharp.Data

let getHtml (source:string) =
    async {
        // ! this allows other operation to continue to perform as the async task is performed
        let! html = HtmlDocument.AsyncLoad(source)
        return html
    }

"https://docs.microsoft.com/dotnet/fsharp"
|> getHtml
|> Async.RunSynchronously

// run multiple async in parallel
let documents =
    [
        "https://docs.microsoft.com/dotnet/fsharp"
        "https://docs.microsoft.com/dotnet/fsharp"
        "https://docs.microsoft.com/dotnet/fsharp"
    ]

documents
|> List.map getHtml
|> Async.Parallel
|> Async.RunSynchronously
// |> Array.length

// run in order
documents
|> List.map getHtml
|> Async.Sequential
|> Async.RunSynchronously


(*TASK INTEROP*)
open System.Net.Http

let getHtmlTask (source:string) =
    async {
        use client = new HttpClient()
        // use `Async.AwaitTask` to convert `Task` to `Async`
        let! html = client.GetStringAsync(source) |> Async.AwaitTask
        let parsedHtml = HtmlDocument.Parse(html)
        return parsedHtml
    }

"https://docs.microsoft.com/dotnet/fsharp"
|> getHtmlTask
|> Async.RunSynchronously