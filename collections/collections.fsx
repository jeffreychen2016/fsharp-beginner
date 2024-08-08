(*CREATE COLLECTIONS*)

// List

// Built-in creation function
List.init<int> 10 (fun i -> i) // creates 10 elements in a list from 0 to 9
List.init<int> 10 (fun i -> i * 2) // creates 10 elements in a list and each element times 2

// Inline initialization
[1; 2; 3] // list with elements 1 to 3
[1..10] // list with elements 1 to 10

// Array
Array.init<int> 10 (id)
Array2D.init<int> 3 3 (fun x _ -> x)

[|1; 2; 3 |]
[|1..10|]

// Sequence
Seq.init<int> 10 (fun i -> i)
Seq.initInfinite<int> (fun i -> i)

seq {1; 2; 3}
seq {1..10}

(*ACCESS ELEMENTS*)
open System

type Transaction =
    {
        Date: DateTime
        CustomerId: string
        Amount: double
    }

let transactions = 
    [
        { 
            Date = new DateTime(2021, 1, 1)
            CustomerId = "1"
            Amount = 20.01 
        }
        { 
            Date = new DateTime(2022, 1, 1)
            CustomerId = "2"
            Amount = 20.02
        }
    ]

// Get first element
transactions.Head

// Get rest of elements
transactions.Tail

// Access by index
// this is just a demo
// Access by index is more efficient on arrays
transactions.[0] // similar to head
transactions.[1..] // similar to tail

// Built-in collection operations
transactions
|> List.find (fun transaction -> transaction.CustomerId = "1")

transactions
|> List.find (fun transaction -> transaction.CustomerId = "4") // throw error

// Handle missing data using Option type
transactions
|> List.tryFind (fun x -> x.CustomerId = "4") // return None

transactions
|> List.tryFind (fun x -> x.CustomerId = "1") // return Some of first transaction

// Append & Prepend
let todoList = ["Learn F#"; "Create app"; "Profit!"]

["Repeat"] |> List.append todoList // append
todoList |> List.append ["Make coffee"] // prepend

(*CONVERT COLLECTION*)
let transactionArray = transactions |> Array.ofList
let transactionSeq = transactions |> Seq.ofList

(*OPERATIONS*)
transactions
|> List.map
    (fun transaction -> 
        let taxRate = 0.3
        
        // {||} is anonymous record
        {| PreTax = transaction.Amount 
           Tax = transaction.Amount * taxRate
           Total = transaction.Amount * (1.0 + taxRate)|})
        

transactions
|> List.iter (fun transaction -> printfn $"{transaction.CustomerId}")

transactions
|> List.sumBy (fun transaction -> transaction.Amount)

transactions
|> List.averageBy (fun transaction -> transaction.Amount)

transactions
|> List.filter (fun transaction -> transaction.Date > DateTime(2000, 1, 1))

transactions
|> List.sortBy (fun transaction -> transaction.Date)

transactions
|> List.sortByDescending (fun transaction -> transaction.Date)

transactions
|> List.filter (fun transaction -> transaction.Date > DateTime(2000, 1, 1))
|> List.sortByDescending (fun transaction -> transaction.Date)


