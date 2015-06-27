// 魔法陣
module Q1
// 全探索
module Zentansaku =
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

    // 魔法陣として正しい場合はTrue、そうでなければFalse
    let isValid (junretu : int list) = 
        let row1 = junretu.[0] + junretu.[1] + junretu.[2]
    
        junretu.[3] + junretu.[4] + junretu.[5] = row1
            && junretu.[6] + junretu.[7] + junretu.[8] = row1
            && junretu.[0] + junretu.[3] + junretu.[6] = row1
            && junretu.[1] + junretu.[4] + junretu.[7] = row1
            && junretu.[2] + junretu.[5] + junretu.[8] = row1
            && junretu.[0] + junretu.[4] + junretu.[8] = row1
            && junretu.[2] + junretu.[4] + junretu.[6] = row1

    let start () =
        printfn "全探索"
        let patternCount =
            createJunretu 1 9
            |> Seq.filter isValid
            |> Seq.map(fun x -> printfn "%A" x)
            |> Seq.length

        printfn "%dパターン" patternCount

// バックトラック
module BackTrack = 
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

    // 魔法陣として正しい場合はTrue、そうでなければFalse
    let isValid junretu = 
        match List.length junretu with
        | 6 -> (junretu.[0] + junretu.[1] + junretu.[2]) = (junretu.[3] + junretu.[4] + junretu.[5])

        | 7 -> 
            let total = junretu.[0] + junretu.[1] + junretu.[2]
            junretu.[0] + junretu.[3] + junretu.[6] = total
                && junretu.[2] + junretu.[4] + junretu.[6] = total

        | 8 -> (junretu.[0] + junretu.[1] + junretu.[2]) = (junretu.[1] + junretu.[4] + junretu.[7])

        | 9 ->
            let total = junretu.[0] + junretu.[1] + junretu.[2]
            junretu.[6] + junretu.[7] + junretu.[8] = total
                && junretu.[2] + junretu.[5] + junretu.[8] = total
                && junretu.[0] + junretu.[4] + junretu.[8] = total

        | length -> length <= 9

    let start () =
        printfn "バックトラック"
        let patternCount =
            createJunretu 1 9 isValid
            |> Seq.map(fun x -> printfn "%A" x)
            |> Seq.length

        printfn "%dパターン" patternCount