module aoc_2025.Day1

open System.IO
open aoc_2025

module Day01 =
    let inputPath = "inputs/day_01_input.txt"
    let examplePath = "inputs/day_01_example.txt"

    let rounderModulo (input: int) : int = (input % 100 + 100) % 100

    let parseClicks (input: string) : int =
        let dir = input[0]
        let dist = int input[1..]

        match dir with
        | 'L' -> -1 * dist
        | _ -> dist

    let GetResultPart1 (start: int, clicks: int list) : int =
        let initialState = (start, 0)

        let (finalPosition, finalCounter) =
            clicks
            |> List.fold
                (fun (currentPos, counter) click ->
                    let newPos = rounderModulo (currentPos - rounderModulo (click))

                    let newCounter = if newPos = 0 then counter + 1 else counter

                    (newPos, newCounter))
                initialState

        finalCounter

    let GetResultPart2 (start: int, clicks: int list) : int =
        let initialState = (start, 0)

        let (finalPosition, finalCounter) =
            clicks
            |> List.fold
                (fun (currentPos, counter) click ->
                    let newPos = rounderModulo (currentPos + rounderModulo (click))
                    let orbits = abs (int click / 100)

                    let passed: bool =
                        currentPos + (click % 100) >= 100
                        || currentPos + (click % 100) <= 0 && currentPos <> 0

                    let total_orbits = orbits + (if passed then 1 else 0)
                    let newCounter = counter + total_orbits

                    (newPos, newCounter))
                initialState

        finalCounter

    let solveExample () =
        let text: string list = Helpers.readLinesFromFile examplePath
        let clicks = text |> List.map parseClicks

        let result = GetResultPart2(50, clicks)
        result

    let solvePart1 () =
        let text: string list = Helpers.readLinesFromFile inputPath
        let clicks = text |> List.map parseClicks

        let result = GetResultPart1(50, clicks)
        result

    let solvePart2 () =
        let text: string list = Helpers.readLinesFromFile inputPath
        let clicks = text |> List.map parseClicks

        let result = GetResultPart2(50, clicks)
        result

    let run () =
        let resultOfPart1 = solvePart1 ()
        printfn "The final result of Part 1 is: %d" resultOfPart1
        let resultOfPart2 = solvePart2 ()
        printfn "The final result of Part 2 is: %d" resultOfPart2
