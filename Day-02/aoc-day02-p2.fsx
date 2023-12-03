// Advent of Code 2023
// Day 02 Part 2
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

type State = { Red:int; Green: int; Blue:int }

let minimal (game : Game) : State =
    let visitHand state hand =
        let (_,rc) =
            hand
            |> List.tryFind (fun (c,_) -> c = Red)
            |> Option.defaultValue (Red,0)
            
        let (_,gc) =
            hand
            |> List.tryFind (fun (c,_) -> c = Green)
            |> Option.defaultValue (Green,0)
        
        let (_,bc) =
            hand
            |> List.tryFind (fun (c,_) -> c = Blue)
            |> Option.defaultValue (Blue,0)
        
        { Red =
            if rc > state.Red then
                rc
            else state.Red
          Green =
             if gc > state.Green then
                 gc
             else
                 state.Green
          Blue =
             if bc > state.Blue then
                 bc
             else
                 state.Blue }

    game.Hands
    |> List.fold visitHand {Red =0; Green=0; Blue=0}

let power (s : State) = s.Red * s.Blue * s.Green    

let solvePuzzle data = 
    let games = data |> List.map parse
    let minimalGames = games |> List.map minimal
    let powers = minimalGames |> List.map power
    powers |> List.sum

// 'example' == test data  or  'input' == puzzle data

// Test Example: 2286
solvePuzzle example
// Puzzle Input: 71274
solvePuzzle input

let run () =
    printf "Testing..."
    test <@ solvePuzzle example = 2286 @>
    printf "Done."

run ()