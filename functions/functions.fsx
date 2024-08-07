(*LAMBDA FUNCTIONS*)
fun () -> printfn "Hello World"
fun x -> x + 1
fun x y -> x + y

(*DEFINING NAMED FUNCTIONS*)
let addOne x = x + 1 // short hand for let addOne = fun x -> x + 1

(*CALLING FUNCTION*)
addOne 3

(*TYPE ANNOTATIONS*)

// without annotation and complier can not infer types
// when seeing types like 'a -> 'b -> 'c, it means the complier does not know how to infer the types
// you can pass in whatever you want...
let buildUrlNoAnnotations protocol baseUrl path = $"{protocol}://{baseUrl}/{path}"

buildUrlNoAnnotations 1 "github.com" (1.0, 2.0)

// with annotation
let buildUrl (protocol: string) (baseUrl: string) (path: string) = $"{protocol}://{baseUrl}/{path}"

buildUrl "http" "github.com" "dotnet/fsharp"

(*WORKING WITH MISSING DATA*)
#r "nuget:FSharp.Data"

open FSharp.Data
open System.IO

let getHtml (htmlFile: string) : HtmlDocument option = 
    try 
        let html = HtmlDocument.Load(htmlFile)
        Some(html)
    with
    | ex -> 
            printfn $"Error: {ex}"
            None

// this throws becasue HtmlDocument.Load does not return option
// HtmlDocument.Load "UriThatDoesNotExist" 

getHtml "UriThatDoesNotExist" // return None

let htmlPath = Path.Join(__SOURCE_DIRECTORY__, "fsharp-github-repo.html")

getHtml htmlPath // return Some

(*PIPELINES*)

let getLinks (html: HtmlDocument option) =
    // pattern match over option type to get '<a>' html tags in document
    match html with
        | Some (x) -> x.Descendants ["a"]
        | None -> Seq.empty

// Call getHtml and getlinks
getLinks (getHtml htmlPath)

// Use pipe operator |> to call getHtml and getLinks
htmlPath |> getHtml |> getLinks

(*COMPOSITION*)
// Use composition operator >> to combine getHtml and getLinks into one function
let getLinksFromHtml = getHtml >> getLinks

// Call getLinksFromHtml
getLinksFromHtml htmlPath

// Use pipe operator and lambda expression for additional process
htmlPath
|> getLinksFromHtml
|> fun links -> printfn $"{links}"