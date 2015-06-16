// アナグラム
module Q4

open System.IO

// 単語の一覧をアナグラム別にまとめます。
let computeAnagramGroupList (wordList: string seq) = 
    wordList |> Seq.groupBy(fun word ->  word.ToCharArray() |> Array.sort |> (fun c -> System.String c))

let start filePath =
    let wordList = File.ReadLines filePath
    let anagramGroupList = computeAnagramGroupList wordList

    anagramGroupList
    |> Seq.map(fun anagramGroup -> printfn "%A : %A" (fst anagramGroup) ((snd anagramGroup) |> (fun word -> System.String.Join(", ", word))))
    |> Seq.toList