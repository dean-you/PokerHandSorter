﻿// See https://aka.ms/new-console-template for more information
using PokerHandSorter;

var match = new Match();
match.Play();
Console.WriteLine($"Player 1: {match.Player1Score} hands");
Console.WriteLine($"Player 2: {match.Player2Score} hands");