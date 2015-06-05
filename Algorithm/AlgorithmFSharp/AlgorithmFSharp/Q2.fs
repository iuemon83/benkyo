// n クイーン問題
module Q2
// 全探索
module Zentansaku =
    open System

    let rec createJunretuRec (nokori: int list) (junretu: int list) = 
        if (List.isEmpty nokori) then seq{ yield List.rev junretu }
        else
            seq{
                for x in nokori do
                    let nn = nokori |> List.filter(fun n -> not (n = x))
                    let jj = x :: junretu
                    yield! createJunretuRec nn jj }

    // 指定した範囲内のすべてのパターンの順列を生成します。
    let createJunretu start last = createJunretuRec [start..last] []

    let isValid (junretu : int list) =
        let lastIndex = (junretu |> List.length) - 1

        [0 .. lastIndex - 1] |> List.forall(fun i ->
            not ([i + 1 .. lastIndex] |> List.exists(fun j ->
                Math.Abs(i - j) = Math.Abs(junretu.[i] - junretu.[j]))))

    let start n = 
        printfn "全探索"
        let patternCount =
            createJunretu 1 n
            |> Seq.filter isValid
            |> Seq.map(fun x -> printfn "%A" x)
            |> Seq.length

        printfn "%dパターン" patternCount
            
// バックトラック
module BackTrack =
    open System
    
    let rec createJunretuRec (nokori: int list) (junretu: int list) isValid = 
        if (not (isValid junretu)) then seq{ yield [] }
        elif (List.isEmpty nokori) then seq{ yield List.rev junretu }
        else
            seq{
                for x in nokori do
                    let nn = nokori |> List.filter(fun n -> not (n = x))
                    let jj = x :: junretu
                    yield! createJunretuRec nn jj isValid }
            |> Seq.filter(fun x -> not (List.isEmpty x))

    // 指定した範囲内のすべてのパターンの順列を生成します。
    let createJunretu start last isValid = createJunretuRec [start..last] [] isValid

    let isValid (junretu : int list) =
        let lastIndex = (junretu |> List.length) - 1

        [0 .. lastIndex - 1] |> List.forall(fun i ->
            not ([i + 1 .. lastIndex] |> List.exists(fun j ->
                Math.Abs(i - j) = Math.Abs(junretu.[i] - junretu.[j]))))

    let start n = 
        printfn "バックトラック"
        let patternCount =
            createJunretu 1 n isValid
            |> Seq.filter isValid
            |> Seq.map(fun x -> printfn "%A" x)
            |> Seq.length

        printfn "%dパターン" patternCount

            

