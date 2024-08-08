// start to end
for i = 1 to 3 do 
    printfn $"{i}"

// reverse
for i = 3 downto 1 do  
    printfn $"{i}"

// for in
let todoList = ["Learn F#"; "Create app"; "Profit!"]

for todo in todoList do
    printfn $"{todo}"

// collection generation
[for todo in todoList do todo.ToUpper()]

// while loop
open System

let mutable input = ""
while (input <> "q") do
    input <- Console.ReadLine()
    printfn $"{input}"