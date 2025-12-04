module aoc_2025.Tests.Tests

open Xunit
open aoc_2025.Day1

type RounderModuloTests() =
    [<Fact>]
    member _.``99 + 1 = 0``() =
        let input = 99 + 1
        let result = Day01.rounderModulo input
        Assert.Equal(0, result)

    [<Fact>]
    member _.``15 - 45 = 70``() =
        let input = 15 - 45
        let result = Day01.rounderModulo input
        Assert.Equal(70, result)

    [<Fact>]
    member _.``0 - 1 = 99``() =
        let input = 0 - 1
        let result = Day01.rounderModulo input
        Assert.Equal(99, result)
