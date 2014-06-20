[<AutoOpen>]
module Ficient.Computations

type MaybeBuilder() =
  member this.Bind (x, f) = x |> Option.bind f
  member this.Return x    = Some x
  member this.Zero ()     = None


type EitherBuilder() =
  member this.Bind (x, f) = x |> Either.bind f
  member this.Return x    = x |> Either.succeed


//type ProgressBuilder() =
//  member this.Bind ((weight, p : Progress<_>), f : _ -> Progress<_>) =
//    Progress.Make (fun token -> (token.Run (weight, p) |> f).Run token)
//
//  member this.Bind (weight, f : unit -> Progress<_>) =
//    Progress.Make (fun token -> token.Notify weight; (f ()).Run token)
//
//  member this.Return x = Progress.Make (fun _ -> x)
 

let maybe     = MaybeBuilder()
let either    = EitherBuilder()
//let progress  = ProgressBuilder()
