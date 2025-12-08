module aoc_2025.Day2
open aoc_2025

module Day02 =
    let parseInput (inputti: string) =
        inputti.Split(',')
        |> Array.map (fun item ->
            let parts = item.Split('-')
            (int64 parts.[0], int64 parts.[1])
        )
        
    let findInvalidID (idNumber: int64) =
        let idString = string idNumber

        if idString.Length % 2 = 0 then
            let mid = idString.Length / 2
            
            let firstHalf = idString.[..mid-1]
            let secondHalf = idString.[mid..]

            if firstHalf = secondHalf then
                idNumber
            else
                0
        else
            0

        
    let rec checkRepetition (pattern: string) (input: string) =
        if input.Length = 0 then
            true
        elif input.StartsWith(pattern) then
            checkRepetition pattern (input.Substring(pattern.Length))
        else
            false

    
    let findInvalidIdPart2 (idNumber: int64) =
        let idString = string idNumber
        let mid = idString.Length / 2
        let firstHalf = idString.[..mid-1]

        let halfPatterns = 
            [| 0 .. firstHalf.Length - 1 |]
            |> Array.map (fun i -> firstHalf.[..i])
            |> Array.filter (fun pattern -> checkRepetition pattern (idString))
            
        if not (Array.isEmpty halfPatterns) then
            idNumber
        else
            0

        
       
    let solve_example = 
        let example_input = parseInput(Helpers.readTxtFile("inputs/day_02_example.txt"))
        let result =
            example_input
            |> Array.collect (fun (a,b) -> [|a .. b|])
            |> Array.map findInvalidID
            |> Array.sum
        printfn "%A" result
        
    let solve_input =
        let example_input = parseInput(Helpers.readTxtFile("inputs/day_02_input.txt"))
        let result =
            example_input
            |> Array.collect (fun (a,b) -> [|a .. b|])
            |> Array.map findInvalidID
            |> Array.sum
        printfn "%A" result
        
    let solve_example2 = 
        let example_input = parseInput(Helpers.readTxtFile("inputs/day_02_example.txt"))
        let result =
            example_input
            |> Array.collect (fun (a,b) -> [|a .. b|])
            |> Array.map findInvalidIdPart2
            |> Array.filter(fun id -> id <> 0)
            |> (fun arr -> 
                printfn "Filtered array content: %A" arr
                arr) 
            |> Array.sum

        result
        
    let solve_input_p2 = 
        let example_input = parseInput(Helpers.readTxtFile("inputs/day_02_input.txt"))
        let result =
            example_input
            |> Array.collect (fun (a,b) -> [|a .. b|])
            |> Array.map findInvalidIdPart2
            |> Array.filter(fun id -> id <> 0)
            |> (fun arr -> 
                printfn "Filtered array content: %A" arr
                arr) 
            |> Array.sum

        result 

    
    let run () =
        // solve_example
        // solve_input
        printfn "%A" solve_example2
        printfn "%A" solve_input_p2