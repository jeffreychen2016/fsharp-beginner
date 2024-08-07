(*INTERFACES*)
#r "nuget:FSharp.Data"

open FSharp.Data
open System.IO

// defined interface
// takes in a string and return HtmlDocument
type IHtmlParser =
    abstract member ParseHtml: string -> HtmlDocument

type WebParser () = 
    // implements the interface
    interface IHtmlParser with
        member this.ParseHtml url = HtmlDocument.Load(url)
        
    // this exposes ParseHtml on the instance
    // in another word, this is the `public` method
    member this.ParseHtml url = (this :> IHtmlParser).ParseHtml(url)

type FileParser () =
    interface IHtmlParser with
        member this.ParseHtml filePath = 
            filePath 
            |> File.ReadAllText
            |> fun fileContents -> HtmlDocument.Parse(fileContents)
    member this.ParseHtml filePath = (this :> IHtmlParser).ParseHtml(filePath)

// create parsers
// :> operator is type casting
let webParser = WebParser() :> IHtmlParser
let fileParser : IHtmlParser = FileParser() :> IHtmlParser

// function to handle parsing of html
let parseHtml (parser: IHtmlParser) (source: string) = parser.ParseHtml(source)

// use web parser
parseHtml webParser "https://github.com/dotnet/fsharp"

// use file parser
Path.Join(__SOURCE_DIRECTORY__, "fsharp-github-repo.html")
|> parseHtml fileParser


(*OBJECT EXPRESSIONS*)
// object expressions simplify the process of implementing the interfaces
// implement IHtmlParser to parse HTML contents from url
let webParserE =
    { new IHtmlParser with
        member this.ParseHtml url = HtmlDocument.Load(url)}

let fileParserE = 
    { new IHtmlParser with 
        member this.ParseHtml filePath = 
            filePath
            |> File.ReadAllText
            |> fun fileContents -> HtmlDocument.Parse(fileContents)}

// parse wtih webParser
parseHtml webParserE "https://github.com/dotnet/fsharp"

// parse with fileParser
Path.Join(__SOURCE_DIRECTORY__, "fsharp-github-repo.html")
|> parseHtml fileParserE

