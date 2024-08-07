type StringGitHubProject = 
    {
        ProjectName: string
        Stars: int
        State: string
    }

let fakeProject = 
    {
        ProjectName = "Amazing Project"
        Stars = 0
        State = "any random string" // No enforcement
    }

(*DEFINE DESCRIMINATED UNION*)

// {| Maintainer: string |} is anonymous record type
// Active of {| Maintainer: string |} basically means - if it is `Active`, also need to provide `Maintainer`
type ProjectState = 
    | Archived
    | Active of {| Maintainer: string |}

type GitHubProject = 
    {
        ProjectName: string
        Stars: int
        State: ProjectState
    }

(*USE DESCRIMINATED UNION*)
let archivedProject = {
    ProjectName = "archived project"
    Stars = 1500
    State = Archived
}

let activeProject = {
    ProjectName = "active project"
    Stars = 1500
    State = Active {| Maintainer = "F# Team" |}
}
