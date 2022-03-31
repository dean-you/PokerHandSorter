# Poker Hand Sorter

A poker hand consists of a combination of five playing cards, ranked in the following ascending order:

| Rank | Combination | Description |
| --- | --- | --- |
| 1	| High card	| Highest value card |
|2	|Pair|	Two cards of same value
|3	|Two pairs|	Two different pairs
|4	|Three of a kind|	Three cards of the same value
|5	|Straight|	All five cards in consecutive value order
|5	|Flush|	All five cards having the same suit
|7	|Full house|	Three of a kind and a Pair
|8	|Four of a kind|	Four cards of the same value
|9	|Straight flush|	All five cards in consecutive value order, with the same suit
|10	|Royal Flush|	Ten, Jack, Queen, King and Ace in the same suit

The cards are valued in the order: 2, 3, 4, 5, 6, 7, 8, 9, 10, Jack, Queen, King, Ace*

* For this exercise, Ace is considered high only. (i.e. cannot be used as a low card below 2 in a straight).

Suits are:

Diamonds (D), Hearts (H), Spades (S), Clubs (C)

When multiple players have the same ranked hand then the rank made up of the highest value cards wins. For example, pair of kings beats a

pair of queens, and a straight with a high card of Jack beats a straight with high card of nine.

If two ranks tie, for example, if both players have a pair of Jacks, then highest cards in each hand are compared; if the highest cards tie then the

next highest cards are compared, and so on.

# Prerequisite

.Net 6

# How to run the application - Visual Studio 2022

1: Open solution file PokerHandSorter.sln in VS2022

2: Run the solution

# How to run the file - command line

1: Navigate to the folder PokerHandSorter\PokerHandSorter

2: dotnet build

3: dotnet run

# Output

Player 1: 263

Player 2: 237
