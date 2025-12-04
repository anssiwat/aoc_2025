open System
open aoc_2025.Day1


let runDay day =
    match day with
    | 1 -> Day01.run ()
    // add more cases as you add days
    | _ -> failwithf "Unknown day %d" day

[<EntryPoint>]
let main argv =
    // Now, we call our run function from within the main entry point.
    Day01.run()

    // The main function MUST return an integer exit code.
    // 0 is the standard for success.
    0