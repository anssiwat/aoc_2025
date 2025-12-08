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

let readTxtFile (filePath: string) : string =
    try
        File.ReadAllText(filePath)
    with
    | :? FileNotFoundException ->
        printfn "Error: The file was not found at path '%s'" filePath
        "" 
    | ex ->
        printfn "An unexpected error occurred: %s" ex.Message
        ""