module aoc_2025.Helpers

open System.IO

let readLinesFromFile (filePath: string) : string list =
    try
        let linesArray = File.ReadAllLines(filePath)
        List.ofArray linesArray
    with
    | :? FileNotFoundException ->
        printfn "Error: The file was not found at path '%s'" filePath
        []
    | ex ->
        printfn "An unexpected error occurred: %s" ex.Message
        []


// let path = "movements.txt"
// let content = [
//     "L68"; "L30"; "R48"; "L5"; "R60";
//     "L55"; "L1"; "L99"; "R14"; "L82"
// ]
// File.WriteAllLines(path, content)
//
// // 2. Call the function with the path to your file.
// let movements = readLinesFromFile path
//
// // 3. Print the results to verify.
// printfn "Successfully read the following lines from the file:"
// movements |> List.iter (fun line -> printfn "'%s'" line)
//
// // Example of what the 'movements' list will contain:
// // val movements : string list =
// //   ["L68"; "L30"; "R48"; "L5"; "R60"; "L55"; "L1"; "L99"; "R14"; "L82"]
