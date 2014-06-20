namespace Ficient

type Either<'TSuccess, 'TFailure> =
  | Success of 'TSuccess
  | Failure of 'TFailure


module Either =

  let succeed x = Success x
  let fail    x = Failure x

  let apply successFunc failureFunc either =
    match either with Success s -> successFunc s | Failure f -> failureFunc f

  let bind binder either =
    either |> apply binder fail

  let map mapping either =
    either |> apply (mapping >> succeed) fail

  let bimap successMapping failureMapping either =
    either |> apply (successMapping >> succeed) (failureMapping >> fail)

  let iter (successAction : _ -> unit) (failureAction : _ -> unit) either =
    either |> apply successAction failureAction

  let iterOrException action either =
    either |> iter action raise

  let getOrException either =
    match either with Success s -> s | Failure f -> raise f

  let toOption either =
    match either with Success s -> Some s | _ -> None

  let ofOption failure option =
    match option with Some x -> Success x | _ -> Failure failure

  let tryCatch f x =
    try f x |> succeed with ex -> fail ex

  // Either を返す関数の合成（>> 演算子の Either 版）
  let (>=>) func1 func2 =
    fun input -> match func1 input with Success s -> func2 s | Failure f -> Failure f

  // |> 演算子の Either 版
  let (|=>) either binder =
    either |> bind binder

