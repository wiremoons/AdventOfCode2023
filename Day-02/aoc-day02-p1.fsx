// Advent of Code 2023
// Day 02 Part 1
//
#r "nuget: Unquote"
open Swensen.Unquote
open System

// Read in the final puzzle 'input' as a list of strings
let input =
    System.IO.File.ReadAllLines $"""{__SOURCE_DIRECTORY__}/puzzle_input.txt"""
    |> List.ofSeq

// Read in the test puzzle input 'example' as a list of strings    
let example =
    System.IO.File.ReadAllLines $"""{__SOURCE_DIRECTORY__}/test_input.txt"""
    |> List.ofSeq

// define the types needed
type Colour = Red | Green | Blue
type Hand = (Colour * int) list
type Game = {Id:int; Hands: Hand list }

let parse (line: string) =    
    let parseColour (colourCount : string) : (Colour * int) =
        let [|rawCount; rawColour|] = colourCount.Split(" ")
        let Count = rawCount |> int
        let Colour =
            match rawColour with
            | "red" -> Red
            | "green" -> Green
            | "blue" -> Blue
        (Colour, Count)

    let parseHand (hand:string) =
        let colourCounts = hand.Split(", ")
        colourCounts |> Seq.map parseColour |> Seq.toList
        
    let [| Game; handfulls |] = line.Split(": ")
    let gameId = Game.Split(" ")[1] |> int
    
    let hands =
        handfulls.Split("; ")
        |> Array.map parseHand
        |> List.ofSeq
        
    { Id = gameId; Hands = hands }

let isPossible (game : Game) =
    // 12 red cubes, 13 green cubes, and 14 blue
    let isPossibleHand (hand: Hand) =
        // use tryFind in case a colour is not in a hand - provide a default in case
        let (_,rc) = hand |> List.tryFind (fun (c,_) -> c = Red) |> Option.defaultValue (Red,0)
        let (_,gc) = hand |> List.tryFind (fun (c,_) -> c = Green) |> Option.defaultValue (Green,0)
        let (_,bc) = hand |> List.tryFind (fun (c,_) -> c = Blue) |> Option.defaultValue (Blue,0)
        rc <= 12 && gc <= 13 && bc <= 14
    
    game.Hands |> List.forall isPossibleHand

let solvePuzzle data = 
    let games = data |> List.map parse
    let possibleGames = games |> List.filter isPossible
    let answer = possibleGames |> Seq.sumBy _.Id
    answer

// 'example' == test data  or  'input' == puzzle data

// Test Example: possible games 1,2,5 = 8
solvePuzzle example
// Puzzle Input: 2149
solvePuzzle input

let run () =
    printf "Testing..."
    test <@ solvePuzzle example = 8 @>
    printf "Done."

run ()