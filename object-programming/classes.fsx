(*CLASSES*)
type Repo(name: string, stars: int) =
    // Private properties
    let baseUrl = "https://github.com"

    // Private method
    let incrementStarBy stars n = stars + n

    // Additional Constructors
    new() = Repo("", 0)

    // Instance Properties
    member this.Name = name // read-only (immutable)

    // val keyword is used to create mutable property
    member val Stars = stars with get, set //(mutable) 

    // Static Methods
    static member PrintHelp() = "Class that contains repo information"

    // Instance Methods
    member _.GetBaseUrl() = $"{baseUrl}"
    member this.GetRepoUrl() = $"{baseUrl}/{this.Name}"
    member this.IncrementStarBy(n) = this.Stars <- incrementStarBy this.Stars n

// Static members
Repo.PrintHelp()

// Create instance
let fsharpRepo = Repo("dotnet/fsharp", 2800)
let blankRepo = Repo()

(*ACCESS MEMBERS / PROPERTIES*)
fsharpRepo.Name
fsharpRepo.GetBaseUrl()
fsharpRepo.Stars <- 3000 // Stars has getter and setter
fsharpRepo.IncrementStarBy 2
fsharpRepo.Stars