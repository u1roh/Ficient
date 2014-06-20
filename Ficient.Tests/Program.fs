open NUnit
open NUnit.Framework
open FsUnit
open Ficient

type SampleTest () =
  [<Test>]
  member __.Piyopiyo () =
    1 + 1 |> should equal 2

type MaybeTest () =
  [<Test>]
  member __.Computation () =
    let list = [0; 1; 2]
    let result = maybe {
      let! even = list |> List.tryFind (fun x -> x % 2 = 0)
      let! odd  = list |> List.tryFind (fun x -> x % 2 = 1)
      return even + odd
    }
    result |> should equal (Some 1)


[<EntryPoint>]
let main argv = 
    printfn "%A" argv
    0 // 整数の終了コードを返します
