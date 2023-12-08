// Advent of Code 2023
// Day 04 Part 1
//
#r "nuget: Unquote"
open Swensen.Unquote

// Read in the final puzzle 'input' as a list of strings
let input =
    System.IO.File.ReadAllLines $"""{__SOURCE_DIRECTORY__}/puzzle_input.txt"""
    |> List.ofSeq

// Read in the test puzzle input 'example' as a list of strings    
let example =
    System.IO.File.ReadAllLines $"""{__SOURCE_DIRECTORY__}/test_input.txt"""
    |> List.ofSeq

// Record type to hold a single parsed card value
type Game =
    { CardId : string
      WinNumbers: Set<int>
      ElfNumbers: Set<int> } 

// accepts a line of the puzzle raw data and parses it into a record of type 'Game'
let parse (line: string) =    
    // test lines
    //let line: string = "Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53"
    //let (line: string) = "Card   1: 69 61 27 58 89 52 81 94 40 51 | 43 40 52 90 37 97 89 80 69 42 51 70 94 58 10 73 21 29 61 63 57 79 81 27 35"
    //let (line: string) = "Card   2:  5 75 37 76 98 32 24 83 44 50 | 80 75 91  5 33 52 31 96 83 92 46 98 55 65 48 24 44  4 32 60 88 37 76 50 77"
    //printfn $"Line: '{line}'"
    let [|cardAll:string; numbersAll:string|] = line.Split(":",System.StringSplitOptions.RemoveEmptyEntries)
    let [|win:string; elf:string|] = numbersAll.Split(" | ")
    let CardId = cardAll.Split(" ",System.StringSplitOptions.RemoveEmptyEntries)[1] |> string
    let WinNumbers = win.Split(" ",System.StringSplitOptions.RemoveEmptyEntries) |> Array.map int
    let ElfNumbers = elf.Split(" ",System.StringSplitOptions.RemoveEmptyEntries) |> Array.map int
    // return a single 'Game' record for the parsed 'line'
    { CardId = CardId
      WinNumbers = Set.ofSeq WinNumbers
      ElfNumbers = Set.ofSeq ElfNumbers }

let calculatePoints (cards:Game) =
    // count how many number match up comparing the winning numbers
    // with the actual scratch card numbers for each 'Game' set
    let points = Set.intersect cards.WinNumbers cards.ElfNumbers |> Seq.length
    // 2** of point minus one
    pown 2 (points - 1)

// read input 'data' either from example of puzzle input
let solvePuzzle (data:string list) =
    // send each line of data to be parsed into 'Game list' of all cards
    let cards = data |> List.map parse
    // for each 'Game' record calculate any points available
    let winningCards = cards |> List.map calculatePoints
    // return the total of all the winning cards points
    winningCards |> Seq.sum

// Test Example: 13
solvePuzzle example
// Puzzle Input: 26914
solvePuzzle input

// Tests section
let run () =
    printf "Testing..."
    test <@ solvePuzzle example = 13 @>
    printf "Done."

run ()
