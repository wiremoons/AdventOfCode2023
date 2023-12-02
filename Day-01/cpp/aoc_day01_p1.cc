/*
 * @file aoc_day01_p1.cc
 * @brief Advent of Code (AOC) 2023 Puzzle solution for:  Day 01 Part 01.
 *
 * @author Simon Rowe <simon@wiremoons.com>
 * @license open-source released under "MIT License"
 *
 * @date originally created: 01 Dec 2023
 *
 * @details Advent of Code (AOC) 2023 Puzzle solution. See:
 * https://adventofcode.com/2023/
 */

//
// Build with the provide 'Makefile' or execute:
// clang++ -std=c++20 -Wall -o aoc_day01_p1 aoc_day01_p1.cc
//   or
// g++ -std=c++20 -Wall -o aoc_day01_p1 aoc_day01_p1.cc
//

// #include <algorithm> // std::find_first_of and std::find_last_of
#include <fstream>
#include <iostream>
#include <string>

size_t getFirstDigit(const std::string calab_line)
{
    if (calab_line.std::string::empty())
        return std::string::npos;
    // auto numbers = {0, 1, 2, 3, 4, 5, 6, 7, 8, 9};
    // size_t const result = std::find_first_of(calab_line.begin(), calab_line.end(), numbers.begin(), numbers.end());
    const size_t result = calab_line.find_first_of("0123456789");
    if (result == std::string::npos) {
        std::cerr << "ERROR: no 'first' digit found in line: " << calab_line << std::endl;
        return std::string::npos;
    }
    std::cout << "Found first number '" << calab_line.at(result) << "' in line: " << calab_line << std::endl;
    return result;
}

size_t getLastDigit(const std::string calab_line)
{
    if (calab_line.std::string::empty())
        return std::string::npos;
    // auto numbers = {0, 1, 2, 3, 4, 5, 6, 7, 8, 9};
    // size_t const result = std::find_first_of(calab_line.begin(), calab_line.end(), numbers.begin(), numbers.end());
    const size_t result = calab_line.find_last_of("0123456789");
    if (result == std::string::npos) {
        std::cerr << "ERROR: no 'last' digit found in line: " << calab_line << std::endl;
        return std::string::npos;
    }
    std::cout << "Found last number '" << calab_line.at(result) << "' in line: " << calab_line << std::endl;
    // return std::stoi(calab_line.substr(result));
    return result;
}

int combinedDigits(const size_t pos_digit_one, const size_t pos_digit_two, const std::string calab_line)
{
    if (pos_digit_one == std::string::npos or pos_digit_two == std::string::npos) {
        std::cerr << "ERROR: input position is not valid: '" << pos_digit_one << "' or '" << pos_digit_two << "',"
                  << std::endl;
        exit(1);
    }
    std::string combined_digits{};
    combined_digits.push_back(calab_line.at(pos_digit_one));
    combined_digits.push_back(calab_line.at(pos_digit_two));
    std::cout << "Combined digits: " << combined_digits << std::endl;
    return std::stoi(combined_digits);
}
///////////////////////////////////////////////////////////////////////////////
//                         MAIN ENTRY POINT                                  //
///////////////////////////////////////////////////////////////////////////////

int main(int argc, char *argv[])
{
    // puzzle input file stream
    std::ifstream input_file{};
    // actual filename to use - either test data or real puzzle data file
    std::string puzzle_data_file{};

    // Use command line option '-t' to execute with test data input. Defaults to actual puzzle input.
    if (argc <= 1) {
        puzzle_data_file = "./data/puzzle-input.txt";
    } else {
        puzzle_data_file = "./data/TEST-puzzle-input.txt";
    }

    input_file.open(puzzle_data_file, std::ios::in);

    if (not input_file.is_open()) {
        std::cerr << "Error opening puzzle date input file. Aborted." << std::endl;
        std::exit(1);
    }

    // variables to hold input data
    int line_number{0};
    int answer{0};
    std::string item{};

    // read puzzle input delimited by '\n' into 'item' from the file: item == 'BFFFBBFRRR'
    while (std::getline(input_file, item)) {
        line_number++;
        std::cout << std::endl << "Line: " << line_number << " is string: " << item << std::endl;
        answer = answer + combinedDigits(getFirstDigit(item), getLastDigit(item), item);
    }

    ///////////////////////////////////////////////////////////////////////////////
    std::cout << std::endl << "Advent Of Code 2023 :  Day 01 Part 01" << '\n' << '\n';
    std::cout << "  » Number of line entries analysed : '" << line_number << "'." << '\n';
    std::cout << "  » PUZZLE ANSWER: " << answer << '\n' << std::endl;

    input_file.close();
    std::exit(0);

    // Part 01 TEST RESULT: 142  Puzzle Answer: 54561
    // Part 02 Answer :
}
