// このサンプルは、F# 言語の要素を紹介します。
//
// *******************************************************************************************************
//    F# Interactive でコードを実行するには、コードの一部を強調表示して、Alt キーを押しながら Enter キーを押すか、右マウス ボタンをクリックし 
//   [対話形式で実行] を選択します。[表示] メニューから F# Interactive ウィンドウを開くことができます。
// *******************************************************************************************************
//
// F# の詳細については、次のページを参照してください:
//     http://fsharp.net
//
// F# で使用するその他のテンプレートについては、Visual Studio の 'オンライン テンプレート' を参照してください。
//     ([新しいプロジェクト] --> [オンライン テンプレート]) を参照してください。
//
// F# の個々のトピックについては、次のページを参照してください:
//     http://go.microsoft.com/fwlink/?LinkID=234174 (F# 開発ポータル)
//     http://go.microsoft.com/fwlink/?LinkID=124614 (Code Gallery)
//     http://go.microsoft.com/fwlink/?LinkId=235173 (Math/Stats のプログラミング)
//     http://go.microsoft.com/fwlink/?LinkId=235176 (グラフ作成)

// 目次:
//    - 整数と基本的な関数
//    - ブール値
//    - 文字列
//    - タプル
//    - リストとリストの処理
//    - クラス
//    - ジェネリック クラス
//    - インターフェイスの実装
//    - 配列
//    - シーケンス
//    - 再帰関数
//    - レコード型
//    - 共用体型
//    - オプション型            
//    - パターン マッチ        
//    - 測定単位        
//    - 並列配列プログラミング
//    - イベントの使用
//    - 型プロバイダーを使用したデータベース アクセス
//    - 型データベースを使用した OData アクセス



// ---------------------------------------------------------------
//         整数と基本的な関数
// ---------------------------------------------------------------

module Integers = 
    let sampleInteger = 176

    /// 最初の整数から演算を行います
    let sampleInteger2 = (sampleInteger/4 + 5 - 7) * 4

    /// 0 ～ 99 の数値のリストです
    let sampleNumbers = [ 0 .. 99 ]

    /// 0 ～ 99 のすべての数値とその平方を含むすべてのタプルのリストです
    let sampleTableOfSquares = [ for i in 0 .. 99 -> (i, i*i) ]

    // 次の行では、汎用向けに %A を使用して、タプルを含むリストを出力します
    printfn "The table of squares from 0 to 99 is:\n%A" sampleTableOfSquares


module BasicFunctions = 

    // 'let' を使用し、整数引数を受け入れ、整数を返す関数を定義します。
    let func1 x = x*x + 3             

    // かっこは、関数引数では省略可能です
    let func1a (x) = x*x + 3             

    /// 関数を適用します。'let' を使用し、関数の戻り値の結果に名前を付けます。
    /// 変数の型は、関数の戻り値の型から推論されます。
    let result1 = func1 4573
    printfn "The result of squaring the integer 4573 and adding 3 is %d" result1

    // 必要であれば、'(引数:型)' を使用してパラメーター名の型に注釈を付けます。
    let func2 (x:int) = 2*x*x - x/5 + 3

    let result2 = func2 (7 + 4)
    printfn "The result of applying the 1st sample function to (7 + 4) is %d" result2

    let func3 x = 
        if x < 100.0 then 
            2.0*x*x - x/5.0 + 3.0
        else 
            2.0*x*x + x/5.0 - 37.0

    let result3 = func3 (6.5 + 4.5)
    printfn "The result of applying the 2nd sample function to (6.5 + 4.5) is %f" result3



// ---------------------------------------------------------------
//         ブール値
// ---------------------------------------------------------------

module SomeBooleanValues = 

    let boolean1 = true
    let boolean2 = false

    let boolean3 = not boolean1 && (boolean2 || false)

    printfn "The expression 'not boolean1 && (boolean2 || false)' is %A" boolean3



// ---------------------------------------------------------------
//         文字列
// ---------------------------------------------------------------

module StringManipulation = 

    let string1 = "Hello"
    let string2  = "world"

    /// @ を使用し、verbatim 文字列リテラルを作成します
    let string3 = @"c:\Program Files\"

    /// 三重引用符で囲んだ文字列リテラルを使用し
    let string4 = """He said "hello world" after you did"""

    let helloWorld = string1 + " " + string2 // 間にスペースを挿入して 2 つの文字列を連結します
    printfn "%s" helloWorld

    /// 結果の文字列の 1 つから最初の 7 文字を取得して作成された文字列です
    let substring = helloWorld.[0..6]
    printfn "%s" substring



// ---------------------------------------------------------------
//         タプル (順序付けられた値セット)
// ---------------------------------------------------------------

module Tuples = 

    /// 整数のシンプルなタプルです
    let tuple1 = (1, 2, 3)

    /// タプルの 2 つの値の順序を入れ替える関数。
    /// クイック ヒントに、関数はジェネリック型であることが推論されると示されます。
    let swapElems (a, b) = (b, a)

    printfn "The result of swapping (1, 2) is %A" (swapElems (1,2))

    /// 整数、文字列、および倍精度浮動小数点数で構成されるタプル
    let tuple2 = (1, "fred", 3.1415)

    printfn "tuple1: %A    tuple2: %A" tuple1 tuple2
    


// ---------------------------------------------------------------
//         リストおよびリストの処理
// ---------------------------------------------------------------

module Lists = 

    let list1 = [ ]            /// 空白のリスト

    let list2 = [ 1; 2; 3 ]    /// 3 つの要素のリスト

    let list3 = 42 :: list2    /// 冒頭に '42' が追加された新しいリスト

    let numberList = [ 1 .. 1000 ]  /// 1 ～ 1000 の整数のリスト

    /// 1 年のすべての日を含むリスト
    let daysList = 
        [ for month in 1 .. 12 do
              for day in 1 .. System.DateTime.DaysInMonth(2012, month) do 
                  yield System.DateTime(2012, month, day) ]

    /// チェス盤の黒いマス目の座標のタプルを含むリスト。
    let blackSquares = 
        [ for i in 0 .. 7 do
              for j in 0 .. 7 do 
                  if (i+j) % 2 = 1 then 
                      yield (i, j) ]

    /// パイプライン演算子を使用して List.map に引数を渡し、numberList の数を二乗します    
    let squares = 
        numberList 
        |> List.map (fun x -> x*x) 

    /// 3 で割り切れる数の二乗和を計算します。
    let sumOfSquaresUpTo n = 
        numberList
        |> List.filter (fun x -> x % 3 = 0)
        |> List.sumBy (fun x -> x * x)



// ---------------------------------------------------------------
//         クラス
// ---------------------------------------------------------------

module DefiningClasses = 

    /// クラスのコンストラクターは、dx と dy の 2 つの引数を取ります。どちらも浮動小数点型です。
    type Vector2D(dx : float, dy : float) = 
        /// オブジェクトの構築時に計算されるベクター長です
        let length = sqrt (dx*dx + dy*dy)

        // 'this' は、オブジェクトの自己識別子の名前を指定します。
        // インスタンス メソッドでは、メンバー名の前に表示される必要があります。
        member this.DX = dx  

        member this.DY = dy

        member this.Length = length

        member this.Scale(k) = Vector2D(k * this.DX, k * this.DY)
    
    /// Vector2D クラスのインスタンス
    let vector1 = Vector2D(3.0, 4.0)

    /// 元のオブジェクトを変更せずに、新しく調節されたベクター オブジェクトを取得します
    let vector2 = vector1.Scale(10.0)

    printfn "Length of vector1: %f      Length of vector2: %f" vector1.Length vector2.Length



// ---------------------------------------------------------------
//         ジェネリック クラス
// ---------------------------------------------------------------

module DefiningGenericClasses = 

    type StateTracker<'T>(initialElement: 'T) = // 'T は、クラスの型パラメーター

        /// 状態を配列に保存します
        let mutable states = [ initialElement ]

        /// 状態のリストに新しい要素を追加します
        member this.UpdateState newState = 
            states <- newState :: states  // '<-' 演算子を使用し、値を変換します

        /// 状態の履歴のリスト全体を取得します
        member this.History = states

        /// 最新の状態を取得します
        member this.Current = states.Head

    /// 状態トラッカー クラスの 'int' インスタンス。型パラメーターは推論されていることに注意してください。
    let tracker = StateTracker 10

    // 状態を追加します
    tracker.UpdateState 17



// ---------------------------------------------------------------
//         インターフェイスの実装
// ---------------------------------------------------------------

/// IDisposable を実装する型
type ReadFile() =

    let file = new System.IO.StreamReader("readme.txt")

    member this.ReadLine() = file.ReadLine()

    // このクラスの IDisposable メンバーの実装
    interface System.IDisposable with    
        member this.Dispose() = file.Close()



// ---------------------------------------------------------------
//         配列
// ---------------------------------------------------------------

module Arrays = 

    /// 空の配列です
    let array1 = [| |]

    let array2 = [| "hello"; "world"; "and"; "hello"; "world"; "again" |]

    let array3 = [| 1 .. 1000 |]

    /// "hello" と "world" のみを含む配列
    let array4 = [| for word in array2 do
                        if word.Contains("l") then 
                            yield word |]

    /// インデックスによって初期化され、0 ～ 2000 の間の偶数を含む配列
    let evenNumbers = Array.init 1001 (fun n -> n * 2) 

    /// スライス表記法を使用してサブ配列を抽出します
    let evenNumbersSlice = evenNumbers.[0..500]

    for word in array4 do 
        printfn "word: %s" word

    // 左矢印代入演算子を使用し、配列の要素を変更します
    array2.[1] <- "WORLD!"

    /// 'h' で始まる単語の長さの合計を計算します
    let sumOfLengthsOfWords = 
        array2
        |> Array.filter (fun x -> x.StartsWith "h")
        |> Array.sumBy (fun x -> x.Length)



// ---------------------------------------------------------------
//         シーケンス
// ---------------------------------------------------------------

module Sequences = 
    // シーケンスはオンデマンドで評価され、繰り返されるたびに再評価されます。
    // F# シーケンスは System.Collections.Generic.IEnumerable<'T> のインスタンスであるため、
    // Seq 関数はリストと配列にも適用できます。

    /// 空のシーケンスです
    let seq1 = Seq.empty

    let seq2 = seq { yield "hello"; yield "world"; yield "and"; yield "hello"; yield "world"; yield "again" }

    let numbersSeq = seq { 1 .. 1000 }

    /// "hello" と "world" のみを含む、もう 1 つの配列
    let seq3 = 
        seq { for word in seq2 do
                  if word.Contains("l") then 
                      yield word }

    let evenNumbers = Seq.init 1001 (fun n -> n * 2) 

    let rnd = System.Random()

    /// 無限シーケンス (ランダム ウォーク)
    //  yield! を使用し、サブシーケンスの各要素を返します (IEnumerable.SelectMany と類似)。
    let rec randomWalk x =
        seq { yield x
              yield! randomWalk (x + rnd.NextDouble() - 0.5) }

    let first100ValuesOfRandomWalk = 
        randomWalk 5.0 
        |> Seq.truncate 100
        |> Seq.toList



// ---------------------------------------------------------------
//         再帰関数
// ---------------------------------------------------------------

module RecursiveFunctions  = 
              
    /// 整数の階乗を計算します。'let rec' を使用し、再帰関数を定義します
    let rec factorial n = 
        if n = 0 then 1 else n * factorial (n-1)

    /// 2 つの整数の最大公約数を計算します。
    //  すべての再帰関数の呼び出しは末尾呼び出しであるため、コンパイラは関数をループにします。
    //  これによりパフォーマンスが向上し、メモリの消費を抑えることができます。
    let rec greatestCommonFactor a b =                       
        if a = 0 then b
        elif a < b then greatestCommonFactor a (b - a)           
        else greatestCommonFactor (a - b) b

    /// 再帰関数を使用し、整数のリストの合計を計算します。
    let rec sumList xs =
        match xs with
        | []    -> 0
        | y::ys -> y + sumList ys

    /// ヘルパー関数を結果アキュムレータと共に使用し、関数を末尾再帰にします
    let rec private sumListTailRecHelper accumulator xs =
        match xs with
        | []    -> accumulator
        | y::ys -> sumListTailRecHelper (accumulator+y) ys

    let sumListTailRecursive xs = sumListTailRecHelper 0 xs



// ---------------------------------------------------------------
//         レコード型
// ---------------------------------------------------------------

module RecordTypes = 

    // レコード型を定義します
    type ContactCard = 
        { Name     : string;
          Phone    : string;
          Verified : bool }
              
    let contact1 = { Name = "Alf" ; Phone = "(206) 555-0157" ; Verified = false }

    // 新しいレコード (contact1 のコピー) を作成します。
    // ただし '電話番号' および '検証済み' フィールドには別の値が挿入されています
    let contact2 = { contact1 with Phone = "(206) 555-0112"; Verified = true }

    /// 'ContactCard' オブジェクトを文字列に変換します
    let showCard c = 
        c.Name + " Phone: " + c.Phone + (if not c.Verified then " (unverified)" else "")
        


// ---------------------------------------------------------------
//         共用体型
// ---------------------------------------------------------------

module UnionTypes = 

    /// トランプのスートを表します
    type Suit = 
        | Hearts 
        | Clubs 
        | Diamonds 
        | Spades

    /// トランプのランクを表します
    type Rank = 
        /// 2 ～ 10 の札のランクを表します
        | Value of int
        | Ace
        | King
        | Queen
        | Jack
        static member GetAllRanks() = 
            [ yield Ace
              for i in 2 .. 10 do yield Value i
              yield Jack
              yield Queen
              yield King ]
                                   
    type Card =  { Suit: Suit; Rank: Rank }
              
    /// デッキ上のすべてのカードを表すリストを返します
    let fullDeck = 
        [ for suit in [ Hearts; Diamonds; Clubs; Spades] do
              for rank in Rank.GetAllRanks() do 
                  yield { Suit=suit; Rank=rank } ]

    /// 'カード' オブジェクトを文字列に変換します
    let showCard c = 
        let rankString = 
            match c.Rank with 
            | Ace -> "Ace"
            | King -> "King"
            | Queen -> "Queen"
            | Jack -> "Jack"
            | Value n -> string n
        let suitString = 
            match c.Suit with 
            | Clubs -> "clubs"
            | Diamonds -> "diamonds"
            | Spades -> "spades"
            | Hearts -> "hearts"
        rankString  + " of " + suitString

    let printAllCards() = 
        for card in fullDeck do 
            printfn "%s" (showCard card)



// ---------------------------------------------------------------
//         オプション型
// ---------------------------------------------------------------

module OptionTypes = 
    /// オプション値とは、'Some' または 'None' が指定されたあらゆる種類の値です。
    /// F# コードで広く使用され、他の多くの言語で null 参照が使用される
    /// ケースを表します。

    type Customer = { zipCode : decimal option }

    /// 顧客の郵便番号の出荷ゾーンを計算する抽象クラスです。
    /// 'getState' および 'getShippingZone' 抽象メソッドの実装が指定されています。
    [<AbstractClass>]
    type ShippingCalculator =
        abstract getState : decimal -> string option
        abstract getShippingZone : string -> int

        /// 顧客の郵便番号に対応する出荷ゾーンを返します
        /// 顧客には郵便番号がまだ割り当てられていないか、郵便番号が無効です
        member this.customerShippingZone(customer : Customer) =
            customer.zipCode |> Option.bind this.getState |> Option.map this.getShippingZone



// ---------------------------------------------------------------
//         パターン マッチング
// ---------------------------------------------------------------

module PatternMatching = 

    /// 個人の姓および名のレコード
    type Person = {     
        First : string
        Last  : string
    }

    /// 3 種類の社員の判別共用体を定義します
    type Employee = 
        | Engineer  of Person
        | Manager   of Person * list<Employee>            // マネージャーがレポートのリストを所有しています
        | Executive of Person * list<Employee> * Employee // 役員にはアシスタントが付きます

    /// 管理階層構造の中で、ある社員の下にいる全員の数 (社員自身を含む) を数えます
    let rec countReports(emp : Employee) = 
        1 + match emp with
            | Engineer(id) -> 
                0
            | Manager(id, reports) -> 
                reports |> List.sumBy countReports 
            | Executive(id, reports, assistant) ->
                (reports |> List.sumBy countReports) + countReports assistant


    /// 名前が "Dave" で、レポートのないすべてのマネージャー/役員を検索します
    let rec findDaveWithOpenPosition(emps : Employee list) =
        emps 
        |> List.filter(function 
                       | Manager({First = "Dave"}, []) -> true       // [] は空白のリストに一致します
                       | Executive({First = "Dave"}, [], _) -> true
                       | _ -> false)                                 // '_' は、任意のものに一致するワイルドカード パターンです
                                                                     // これは "or else" ケースを処理します



// ---------------------------------------------------------------
//         測定単位
// ---------------------------------------------------------------

module UnitsOfMeasure = 

    // 数値型に対して F# 演算を使用すると、コードに測定単位の注釈を付けることができます

    open Microsoft.FSharp.Data.UnitSystems.SI.UnitNames

    [<Measure>]
    type mile =
        /// マイルからメートルへの変換係数: メートルは SI.UnitNames で定義されています
        static member asMeter = 1600.<meter/mile>

    let d  = 50.<mile>          // 距離はヤード ポンド単位で表現します
    let d2 = d * mile.asMeter   // 同じ距離をメートル法で表現します

    printfn "%A = %A" d d2
    // let error = d + d2       // コンパイル エラー: 測定単位が一致しません



// ---------------------------------------------------------------
//         並列配列プログラミング
// ---------------------------------------------------------------

module ParallelArrayProgramming = 
              
    let oneBigArray = [| 0 .. 100000 |]
    
    // CPU 集約型の計算を実行します 
    let rec computeSomeFunction x = 
        if x <= 2 then 1 
        else computeSomeFunction (x - 1) + computeSomeFunction (x - 2)
       
    // 大きい入力配列に対して並列マップを実行します
    let computeResults() = oneBigArray |> Array.Parallel.map (fun x -> computeSomeFunction (x % 20))

    printfn "Parallel computation results: %A" (computeResults())



// ---------------------------------------------------------------
//         イベントの使用
// ---------------------------------------------------------------

module Events = 

    open System

    // サブスクリプション ポイント (event.Publish) およびイベント トリガー (event.Trigger) で構成されるイベント オブジェクトのインスタンスを作成します
    let simpleEvent = new Event<int>() 

    // ハンドラーを追加します
    simpleEvent.Publish.Add(
        fun x -> printfn "this is handler was added with Publish.Add: %d" x)

    // イベントをトリガーします
    simpleEvent.Trigger(5)

    // 標準的な .NET 表記規則に従うイベントのインスタンスを作成します: (sender, EventArgs)
    let eventForDelegateType = new Event<EventHandler, EventArgs>()    

    // ハンドラーを追加します
    eventForDelegateType.Publish.AddHandler(
        EventHandler(fun _ _ -> printfn "this is handler was added with Publish.AddHandler"))

    // イベントをトリガーします (sender 引数を設定する必要があります)
    eventForDelegateType.Trigger(null, EventArgs.Empty)



// ---------------------------------------------------------------
//         型プロバイダーを使用したデータベース アクセス
// ---------------------------------------------------------------

module DatabaseAccess = 
              
    // F# から SQL データベースに簡単にアクセスするには、F# 型プロバイダーを使用します。
    // System.Data、System.Data.Linq、および FSharp.Data.TypeProviders.dll への参照を追加します。
    // サーバー エクスプローラーを使用して ConnectionString を作成できます。

    (*
    #r "System.Data"
    #r "System.Data.Linq"
    #r "FSharp.Data.TypeProviders"

    open Microsoft.FSharp.Data.TypeProviders
    
    type SqlConnection = SqlDataConnection<ConnectionString = @"Data Source=.\sqlexpress;Initial Catalog=tempdb;Integrated Security=True">
    let db = SqlConnection.GetDataContext()

    let table = 
        query { for r in db.Table do
                select r }
    *)


    // SqlDataConnection の代わりに、Entity Framework を使用してデータベースにアクセスする SqlEntityConnection を使用することもできます。

    ()



// ---------------------------------------------------------------
//         型プロバイダーを使用した OData アクセス
// ---------------------------------------------------------------

module OData = 

    (*
    open System.Data.Services.Client
    open Microsoft.FSharp.Data.TypeProviders

    // Azure Marketplace の人口と収入のデモグラフィックス OData サービスを使用します。
    // 詳細については、http://go.microsoft.com/fwlink/?LinkId=239712 を参照してください
    type Demographics = Microsoft.FSharp.Data.TypeProviders.ODataService<ServiceUri = "https://api.datamarket.azure.com/Esri/KeyUSDemographicsTrial/">
    let ctx = Demographics.GetDataContext()

    // Azure Marketplace アカウントには、https://datamarket.azure.com/account/info からサインアップできます
    ctx.Credentials <- System.Net.NetworkCredential ("<your liveID>", "<your Azure Marketplace Key>")

    let cities = query {
        for c in ctx.demog1 do
        where (c.StateName = "Washington")
        } 

    for c in cities do
        printfn "%A - %A" c.GeographyId c.PerCapitaIncome2010.Value
    *)

    ()



#if COMPILED
module BoilerPlateForForm = 
    [<System.STAThread>]
    do ()
    do System.Windows.Forms.Application.Run()
#endif
