module FizzBuzz
    open System

    let toDisplayText n = 
        let result =
            seq{
                if n % 3 = 0 then yield "Fizz"
                if n % 5 = 0 then yield "Buzz" }
            |> String.concat ""

        match result with
        | "" -> string n
        | _ -> result
    
    let Start n =
        [1 .. n]
        |> List.map toDisplayText
        |> List.map(fun str -> printfn "%s" str)

