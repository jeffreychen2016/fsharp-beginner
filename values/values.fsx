(*VALUE TYPES*)

// String value
"New Yok"

// Boolean value
true

// Integer value
13

// Tuple
(1.0, 3.0)

// List value
["F#";"C#"]

// Lambda expression / Anonymous function value
fun input -> input / 3

(*VALUE BINDING*)
let cityName = "New Yok"

let fsharpIsAwesome = true

let luckyNumber = 13

let coordinates = (1.0, 3.0)

let toDoList = ["F#";"C#"]

let divideByThree input = input / 3

(*EXPLICIT TYPE ANNOTATIONS*)
let (luckyNumberString: string) = "13"

(*UPDATING VALUES*)
// cityName <- "New York" // Throws error because in F# all data are immutable

// let correctCityName = "New York"

(*MUTABLE VALUES*)
let mutable mutableCityName = "New Yok"

mutableCityName <- "New York"