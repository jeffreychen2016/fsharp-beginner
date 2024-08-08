// conditional expression
open System.IO

let processFile (fileName:string) = 
    let fileExtension = Path.GetExtension(fileName)

    if fileExtension = ".fs" then
        printfn "This is a source file"
    elif fileExtension = ".fsx" then
        printfn "This is a script file"
    else printfn "Can not process file"

processFile "test.fs"
processFile "script.fsx"
processFile "README.md"

// exception handling
let divide x y = 
    try 
        Some(x / y)
    with
        | :? System.DivideByZeroException -> printfn "Can not divide by 0"; None
        | ex -> printfn "Some other exception occured"; None

divide 10 2
divide 1 0

