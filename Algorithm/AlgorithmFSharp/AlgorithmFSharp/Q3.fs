// トロミノ
module Q3

open System

// マスの状態を表します
type State = 
    | None
    | Break
    | Tromino of int

let makeCounter () =
    let i = ref 0
    (fun () ->
        i := !i + 1
        State.Tromino !i )

// 新しいトロミノの番号を取得します
let getNewTrominoNumber = makeCounter ()

// ランダムに選択した一マスを埋めます
let breakARandomGrid (gridList :State [][]) =
    let rowLength = Array.length gridList
 
    let rand = new Random();
    let x = rand.Next(0, rowLength - 1)
    let y = rand.Next(0, rowLength - 1)

    gridList.[x].[y] <- State.Break

// 指定した範囲における中心座標4点を取得します
let getCenter startX endX startY endY =
    let sideLength = endY - startY + 1
    let half = sideLength / 2

    startX + half - 1, startX + half,  startY + half - 1, startY + half

// 指定された範囲内にあるすでに埋まっているマスの座標を取得します
let getBreakCoord (gridList:State [][]) startX endX startY endY =
    [startX .. endX]
    |> List.collect(fun x -> [startY .. endY] |> List.map(fun y -> x, y))
    |> List.find(fun (x, y) -> not(gridList.[x].[y] = State.None))

// トロミノをセットするべき座標を計算します
let computeSetTrominoCoordList (gridList:State [][]) startX endX startY endY = 
    let centerLX, centerRX, centerBY, centerTY = getCenter startX endX startY endY

    let breakX, breakY = getBreakCoord gridList startX endX startY endY

    seq{
        if breakX > centerLX then
            yield centerLX, centerTY
            yield centerLX, centerBY
    
        if breakX < centerRX then
            yield centerRX, centerTY
            yield centerRX, centerBY

        if breakY > centerBY then
            yield centerLX, centerBY
            yield centerRX, centerBY

        if breakY < centerTY then
            yield centerLX, centerTY
            yield centerRX, centerTY }

// 指定した範囲にトロミノをセットします
let rec setTromino (gridList:State [][]) startX endX startY endY =
    // トロミノをセットする座標の一覧
    let setTrominoCoordList = computeSetTrominoCoordList gridList startX endX startY endY

    // トロミノをセット
    let trominoNumber = getNewTrominoNumber()
    setTrominoCoordList
    |> Seq.iter(fun (x, y) -> gridList.[x].[y] <- trominoNumber)

    let centerLX, centerRX, centerBY, centerTY = getCenter startX endX startY endY

    // 盤面を4分割して再帰
    match endX - startX + 1 with
    | 2 -> ()
    | _ ->
        setTromino gridList startX centerLX startY centerBY
        setTromino gridList startX centerLX centerTY endY
        setTromino gridList centerRX endX startY centerBY
        setTromino gridList centerRX endX centerTY endY

let start (n: int) = 
    let rowLength = int(Math.Pow(2.0, float n))

    // マスの状態(0: 何もない、-1: 欠けているマス、それ以外: トロミノ。同じ数字のマスが一つのトロミノを表す) [x][y]
    let gridList = Array.init rowLength (fun _ -> Array.init rowLength (fun _-> State.None))
    breakARandomGrid gridList

    let lastIndex = rowLength - 1
    setTromino gridList 0 lastIndex 0 lastIndex
    
    let stateToString state =
        let displayText =
            match state with
            | State.None -> "N"
            | State.Break -> "B"
            | State.Tromino n -> string n

        displayText.PadLeft 2

    gridList
        |> Array.iter(fun row -> row |> Array.map stateToString |> printfn "%A")


