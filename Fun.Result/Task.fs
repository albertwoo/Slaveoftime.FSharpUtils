﻿namespace Fun.Result

#if !FABLE_COMPILER

open System.Threading.Tasks


[<RequireQualifiedAccess>]
module Task =
    let map f (t: Task<_>) = task {
        let! x = t
        return f x
    }

    let bind f (t: Task<_>) = task {
        let! x = t
        return! f x
    }

    let sleep (ms: int) (t: Task<_>) = task {
        do! Task.Delay ms
        return! t
    }

    let toUnitTask (t: Task) = task { do! t }

    let runSynchronously (t: Task<_>) =
        t.Wait()
        t.Result

    let retn x = Task.FromResult x

#endif
