(*DEFINE RECORDS*)
// this need ; because it is single line
// F# uses indentation and line breaks to delimit fields
type GitHubProject = {ProjectName: string; Stars: int}

(*CREATE RECORD*)
// this need ; because it is single line
// F# uses indentation and line breaks to delimit fields
let fsharp = {ProjectName = "dotnet/fsharp"; Stars = 2800}

(*ACCESS RECORD DATA*)
printfn $"{fsharp.ProjectName} has {fsharp.Stars} stars"

(*UPDATE RECORD DATA*)
let updatedFSharp = {fsharp with Stars = 2801}
printfn $"{updatedFSharp.ProjectName} now has {updatedFSharp.Stars} stars"


(*RECORD MEMBERS*)
type GitHubProjectWithMember = 
    {
        ProjectName: string
        Stars: int
    }
    // if uses labeled data within the type, uses `this` keyword. 
    // in this case `ProjectName`
    member this.GetUrl () = $"https://github.com/{this.ProjectName}"

    // this does not refer to any labeled data, hence it can just use `_`
    member _.GetCodeOwner () = "dotnet"

let fsharpProj = {
    ProjectName = "dotnet/fsharp"
    Stars = 2800
}

fsharpProj.GetUrl()
fsharpProj.GetCodeOwner()
