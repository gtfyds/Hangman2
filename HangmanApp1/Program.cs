﻿using System;
using System.Diagnostics.PerformanceData;
using System.Runtime.InteropServices;

namespace HangmanApp1
{
    public static class Hangman
    {
        static void enteringWord() // Ben's part
        {
            string[] wordArray = {"Apple", "Banana", "Orange","Nice"};

            Random random = new Random();
            int randomNo = random.Next(3);
            string hangmanWord = wordArray[randomNo];

            string underscoredWord = new String('_', hangmanWord.Length);
            Console.WriteLine("Guess the word:\n" + underscoredWord);

            bool typo = true;
            string guessedWord = "";

            //User enters his guess
            while (typo == true)
            {
                Console.WriteLine("Please enter your guess:");
                guessedWord = Console.ReadLine().Trim();

                if (guessedWord.Length == 1)
                {
                    typo = false;
                }
                else if (guessedWord.Length < 1)
                {
                    Console.WriteLine("You did not enter anything");
                }
                else
                {
                    Console.WriteLine("You entered more than one character");
                }
            }
        }


        public static int[] CheckGuess(char a,string b)
        {
            int[] positions = new int[b.Length];
            bool contain = false;
            for (int i = 0; i < (b.Length); i++)
            {
                if (b[i] == a)
                {
                    positions[i] = 1;
                }
                else
                {
                    positions[i] = -1;
                }
                //positions[i] = b.IndexOf(a, i, i);
            }

            return positions;
        }

        public static string WordEntry()
        {
            Console.WriteLine(
                "     |/|\n" +
                "     |/|\n" +
                "     |/|\n" +
                "     |/|\n" +
                "     |/|\n" +
                "     |/|\n" +
                "     |/| /¯)\n" +
                "     |/|/ /\n" +
                "     |/| /\n" +
                "    (¯¯¯)\n" +
                "    (¯¯¯)\n" +
                "    (¯¯¯)\n" +
                "    (¯¯¯)\n" +
                "    (¯¯¯)\n" +
                "    /¯¯/\\ \n" +
                "   / ,^./\\ \n" +
                "  / /   \\/\\ \n" +
                " / /     \\/\\ \n" +
                "( (       )/)\n" +
                "| |       |/|\n" +
                "| |       |/|\n" +
                "| |       |/|\n" +
                "( (       )/)\n" +
                " \\ \\     / /\n" +
                "  \\ `---' /\n" +
                "   `-----'\n" +
                "888\n" +
                "888\n" +
                "888      source code: https://github.com/gtfyds/Hangman2.git\n" +
                "88888b.  8888b. 88888b.  .d88b. 88888b.d88b.  8888b. 88888b.\n" +
                "888  88b     88b888  88bd88P 88b888  888  88b     88b888  88b \n" +
                "888  888.d888888888  888888  888888  888  888.d888888888  888 \n" +
                "888  888888  888888  888Y88b 888888  888  888888  888888  888\n" +
                "888  888 Y888888888  888  Y88888888  888  888 Y888888888  888 \n" +
                "                             888\n" +
                "                        Y8b d88P\n" +
                "                          Y88P \n" +
                "By Oliver Blomfied, Oliver TJ, and Ben Wong");
                
            Console.WriteLine("Enter the word you would like someone to guess: ");
            return Console.ReadLine();
        }

        public static void DrawGame(char[] letters, string SecretWord, int hangmanstage)
        {
            switch (hangmanstage)
            {
                case 1:
                    Console.WriteLine("  +---+\n" +
                                      "  |   |\n" +
                                      "      |\n" +
                                      "      |\n" +
                                      "      |\n" +
                                      "      |\n" +
                                      "=========''', '''");
                    break;
                case 2:
                    Console.WriteLine("  +---+\n" +
                                      "  |   |\n" +
                                      "  0   |\n" +
                                      "      |\n" +
                                      "      |\n" +
                                      "      |\n" +
                                      "=========''', '''");
                    break;
                case 3:
                    Console.WriteLine("  +---+\n" +
                                      "  |   |\n" +
                                      "  0   |\n" +
                                      "  |   |\n" +
                                      "      |\n" +
                                      "      |\n" +
                                      "=========''', '''");
                    break;
                case 4:
                    Console.WriteLine("  +---+\n" +
                                      "  |   |\n" +
                                      "  0   |\n" +
                                      " /|   |\n" +
                                      "      |\n" +
                                      "      |\n" +
                                      "=========''', '''");
                    break;
                case 5:
                    Console.WriteLine("  +---+\n" +
                                      "  |   |\n" +
                                      "  0   |\n" +
                                      " /|\\  |\n" +
                                      "      |\n" +
                                      "      |\n" +
                                      "=========''', '''");
                    break;
                case 6:
                    Console.WriteLine("  +---+\n" +
                                      "  |   |\n" +
                                      "  0   |\n" +
                                      " /|\\  |\n" +
                                      " /    |\n" +
                                      "      |\n" +
                                      "=========''', '''");
                    break;
                case 7:
                    Console.WriteLine("  +---+\n" +
                                      "  |   |\n" +
                                      "  0   |\n" +
                                      " /|\\  |\n" +
                                      " / \\  |\n" +
                                      "      |\n" +
                                      "=========''', '''");
                    break;
                default:
                    Console.WriteLine("Default case");
                    break;
            }

            string output = "";
            for (int i = 0; i < letters.Length; i++)
            {
                if (letters[i] == Convert.ToChar("#"))
                {
                    output += "_";
                }
                else
                {
                    output += letters[i];
                }
                    
            }
            
            Console.WriteLine(output);
        }

        public static void GameLoop()
        {
           string word = WordEntry();
           //DrawGame(int[], word;
           //Console.WriteLine(word);
           int counter = word.Length;
           int hangmanprogress = 1;
           char[] characters = new char[word.Length];
           for(int i = 0; i < characters.Length; i++)
           {
               characters[i] = Convert.ToChar("#");
           }
           while (counter > 0 && hangmanprogress < 7)
           {
               
               Console.WriteLine("Enter your guess: ");
               char guess = Convert.ToChar(Console.ReadLine());
               int[] guessPositions = CheckGuess(guess, word);
               int amount = 0;
               for (int i = 0; i < (word.Length); i++)
               {
                   if (guessPositions[i] == 1)
                   {
                       amount++;
                       characters[i] = guess;
                   }
                   //Console.WriteLine(guessPositions[i]);
               }
               counter -= amount;
               if (amount > 0)
               {
                   Console.WriteLine("Good job you guessed correct!!!");
               }
               else
               {
                   Console.WriteLine("Unlucky you idiot!!!!");
                   hangmanprogress++;
               }

               DrawGame(characters, word, hangmanprogress);
               //DrawGame(guessPositions,word);
               Console.WriteLine(Convert.ToString(CheckGuess(guess, word)));
               /*if (Contains(guess, word) == -1)
               {
                   Console.WriteLine("You guessed the "+(ret+1)+" Character correctly");
               }
               else if (ret == -1)
               {
                   Console.WriteLine("You guessed incorrectly");
               }
               */
           }

           if (hangmanprogress == 7)
           {
               Console.WriteLine("You lose!!!!!!");
           }
           else
           {
               Console.WriteLine("Congrats you win!!!");
           }
        }

        public static void Main(string[] args)
        {
            // Ben           - enter the words and allow user to choose
            // Ollie TJ      - function that loops through the word to see where letters are
            // Ollie Blom    - Main while loop
            GameLoop();
        }
    }
}