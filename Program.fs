// Learn more about F# at http://fsharp.org

open System

// Not optimized. Do not use
let rec fiboRec (n: int) =
    match n with
    | 1 -> 1
    | 2 -> 1
    | n -> fiboRec(n-1) + fiboRec(n-2)

let fiboSeq (n: int) = 
    if n = 0 then 0L
    else
        let buffer = Array.create n 0L
        let setBuffer = fun pos value -> buffer.[pos] <- value
        for i in 0 .. n-1 do
            match i with
            | 0 -> setBuffer i 1L |> ignore
            | 1 -> setBuffer i 1L |> ignore
            | i -> setBuffer i (buffer.[i-1] + buffer.[i-2]) |> ignore
        buffer.[n-1]

let maxFiboWithInt64 =
    let mutable res = 0L
    let mutable loopCount = 0
    while(res >= 0L) do
        loopCount <- loopCount+ 1
        res <- fiboSeq loopCount
    printfn "maxValue: %d, max count: %d" res loopCount


[<EntryPoint>]
let main argv =
    if argv.Length > 0 then printfn "%d" (fiboSeq (argv.[0] |> int))
    else maxFiboWithInt64
    0 // return an integer exit code
