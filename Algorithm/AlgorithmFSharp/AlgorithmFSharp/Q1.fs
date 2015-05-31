// 魔法陣
module Q1
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
let isValid (junretu: int []) = 
    let row1 = junretu.[0] + junretu.[1] + junretu.[2]
    
    junretu.[3] + junretu.[4] + junretu.[5] = row1
        && junretu.[6] + junretu.[7] + junretu.[8] = row1
        && junretu.[0] + junretu.[3] + junretu.[6] = row1
        && junretu.[1] + junretu.[4] + junretu.[7] = row1
        && junretu.[2] + junretu.[5] + junretu.[8] = row1
        && junretu.[0] + junretu.[4] + junretu.[8] = row1
        && junretu.[2] + junretu.[4] + junretu.[6] = row1

let start () =
    let patternCount =
        createJunretu 1 9
        |> Seq.map Seq.toArray
        |> Seq.filter isValid
        |> Seq.map(fun x -> printfn "%A" x)
        |> Seq.length

    printfn "%dパターン" patternCount
