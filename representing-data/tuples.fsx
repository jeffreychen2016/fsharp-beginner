(*CREATE TUPLES*)

let point = (1.0, 2.0)
let gitHubStars = ("dotnet/fsharp", 2800)

(*GET DATA*)
fst gitHubStars // get first item - fst is an function from F#
snd gitHubStars // get second item - snd is an function from F#

// get tuple values and bind to names
let projectName, stars = gitHubStars

printfn $"{projectName}: {stars}"

// ignore Stars
let projectName2, _ = gitHubStars

printfn $"{projectName2}"
