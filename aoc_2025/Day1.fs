module aoc_2025.Day1

open System.IO
open aoc_2025
open aoc_2025.Helpers

module Day01 =
    let inputPath = "inputs/day_01_input.txt"
    let examplePath = "inputs/day_01_example.txt"

    let rounderModulo (input: int) : int = (input % 100 + 100) % 100

    let parseClicks (input: string) : int =
        let dir = input[0]
        let dist = rounderModulo (int input[1..])

        match dir with
        | 'L' -> -1 * dist
        | _ -> dist

    let GetResult (start: int, clicks: int list) : int =
        let initialState = (start, 0)

        let (finalPosition, finalCounter) =
            clicks
            |> List.fold
                (fun (currentPos, counter) click ->
                    let newPos = rounderModulo (currentPos - click)

                    let newCounter = if newPos = 0 then counter + 1 else counter

                    (newPos, newCounter))
                initialState

        finalCounter

    let solveExample () =
        let text: string list = Helpers.readLinesFromFile examplePath
        // let movements: int list = text |> List.map parseClicks
        let clicks = text |> List.map parseClicks

        let result = GetResult(50, clicks)
        result

    let solvePart1 () =
        let text: string list = Helpers.readLinesFromFile inputPath
        // let movements: int list = text |> List.map parseClicks
        let clicks = text |> List.map parseClicks

        let result = GetResult(50, clicks)
        result

    let run () =
        // Call the function with () and print the returned integer
        let resultOfPart1 = solvePart1 ()
        printfn "The final result of Part 1 is: %d" resultOfPart1
