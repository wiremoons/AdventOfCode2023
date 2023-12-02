#
#	Makefile for AdventOfCode2020 Day 07
#
#   Run and execute:
#   make && ./aoc_day08_p1 && ./aoc_day08_p2
#   !!
#
## CHANGE FOR YOUR NEW SOURCE FILE NAME & OUPUT FILENAME
DAY=01

# set source files and binary names for part 1 and 2
SRC_P1=aoc_day$(DAY)_p1.cc 
SRC_P2=aoc_day$(DAY)_p2.cc 
OUT_P1=aoc_day$(DAY)_p1
OUT_P2=aoc_day$(DAY)_p2

#
## set compiler to use:
# CC=clang++
CC=g++
# set default to add '.exe' to end of compiled output files  - will changed below as req!
EXE_END=.exe
#
## +++ BASELINE CFLAGS +++
CPP_FLAGS=-std=c++20 -Wall -Werror -pedantic -fsanitize=undefined
#
## +++ LIBRARY FLAGS: LIBFLAGS +++
LIBFLAGS=
#
## +++ SET DEFAULTS FOR WINDOWS ENVIRNOMENT +++
RM = del
#
# command gets 'Linux' 'Darwin' 'FreeBSD' from command line on these OS environments
uname_S := $(shell sh -c 'uname -s 2>/dev/null || echo not')
# command gets 'x86_64' ''  from command line on these OS environments
#uname_M := $(shell sh -c 'uname -m 2>/dev/null || echo not')
#
## +++ DETECT ENVIRONMENT +++
#
# Use make to see if we are on Linux and if 64 or 32 bits?
ifeq ($(uname_S),Linux)
	# using Linux - change 'del' to 'rm'
	RM = rm
	# unset this as Linux does not need '.exe' tagged to outputs
	EXE_END=
	# using Linux so change to any required libs
	LIBFLAGS=
endif
# Use make to see if we are on MAc OS X and if 64 or 32 bits?
ifeq ($(uname_S),Darwin)
	# using mccOS - change 'del' to 'rm'
	RM = rm
	# unset this as Mac OS X does not need '.exe' tagged to outputs
	EXE_END=
	# using macOS so change to any required libs
	LIBFLAGS=
endif
#
#
## +++ DEFAULT MAKE OUTPUT +++ :
## Set defaut 'make' rule to run if no argument is given
.PHONY: default
default: all ;

# source file alias for p1 and p2
#aoc_day$(DAY)_p1.cc: p1
#aoc_day$(DAY)_p2.cc: p2

# make both part 1 and 2
all: p1 p2

# make both part 1 and 2
debug: p1-debug p2-debug

# if: 'make p1' build just part 1
p1: $(SRC_P1)
	$(CC) $(CPP_FLAGS) -o $(OUT_P1)$(EXE_END) $(SRC_P1) $(LIBFLAGS)

# if: 'make p2' build just part 2
p2: $(SRC_P2)
	$(CC) $(CPP_FLAGS) -o $(OUT_P2)$(EXE_END) $(SRC_P2) $(LIBFLAGS)

# if: 'make p1-debug' build just part 1
p1-debug: $(SRC_P1)
	$(CC) $(CPP_FLAGS) -g -o $(OUT_P1)$(EXE_END) $(SRC_P1) $(LIBFLAGS)

# if: 'make p2-debug' build just part 2
p2-debug: $(SRC_P2)
	$(CC) $(CPP_FLAGS) -g -o $(OUT_P2)$(EXE_END) $(SRC_P2) $(LIBFLAGS)

# delete previous build binaries
clean:
	$(RM) -f $(OUT_P1)$(EXE_END) $(OUT_P2)$(EXE_END)
	$(RM) -Rf $(OUT_P1).dSYM/ $(OUT_P2).dSYM/

# run clang-format for each source file
format:
	$(shell sh -c 'clang-format -i $(SRC_P1)')
	$(shell sh -c 'clang-format -i $(SRC_P2)')

# display a help message explaining the options
help:
	@echo ""
	@echo "The following make command are available:"
	@echo ""
	@echo "  all     : build both part 1 and 2"
	@echo "  p1      : build just part 1"
	@echo "  p2      : build just part 2"
	@echo "  clean   : delete previous build binaries"
	@echo "  format  : run clang-format for both parts source files"
	@echo "  help    : displays this help message"
	@echo ""
	@echo "NB: default action is 'all'" 
	@echo ""

val:
	$(shell sh -c 'valgrind --leak-check=full --show-leak-kinds=all $(OUT_P1)$(EXE_END)')
	$(shell sh -c 'valgrind --leak-check=full --show-leak-kinds=all $(OUT_P2)$(EXE_END)')
