using System;
using System.Globalization;
using System.Linq;


namespace Pig_Latin_Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            bool goOn = true;

            while (goOn == true)
            {
                Console.WriteLine("Please enter a word");
                string originalInput = Console.ReadLine();
                string input = originalInput.Trim();
                //Changed input to lower case in ProcessWord method

                string[] stringInput = input.Split(" ");
                char[] vowels = { 'a', 'e', 'i', 'o', 'u' };

                if (input == null || input == "")
                {
                    Console.WriteLine("Invalid input, try again");
                }
                else
                {
                    foreach (string word in stringInput)
                    {
                        ProcessWord(word, vowels);
                     
                    }

                    Console.WriteLine();
                }

                goOn = KeepAsking();
            }
        }
        public static void ProcessWord(string word, char[] vowels)
        {
            string lowerCase = word.ToLower();
            int index = lowerCase.IndexOfAny(vowels);

            if (index == -1)
            {
                Console.Write(word + " ");
            }
            else
            {
                string firstLetters = word.Substring(0, index);
                string restOfWord = word.Substring(index);
                string newWord = "";
                string vowelWord = "";

                bool upperCase = IsUppercase(word);
                bool titleCase = IsTitlecase(word);
                TextInfo ti = CultureInfo.CurrentCulture.TextInfo;
                bool endingPunctuation = IsEndingPunctuation(word);

                if (ContainsCharacters(word) == true)
                {
                    Console.Write(word + " ");
                }
                else if (index == 0)
                {
                    if (endingPunctuation)
                    {
                        vowelWord = word.Substring(0, word.Length - 1) + "way" + word[word.Length - 1];
                    }
                    else
                    {
                        vowelWord = word + "way";
                    }

                    if (upperCase)
                    {
                        vowelWord = vowelWord.ToUpper();
                    }
                    else if(titleCase)
                    {
                        vowelWord = ti.ToTitleCase(vowelWord);
                    }

                    Console.Write(vowelWord + " ");
                }
                else
                {
                    if (endingPunctuation)
                    {
                        newWord =
                            restOfWord.Substring(0, restOfWord.Length - 1) +
                            firstLetters +
                            "ay" +
                            restOfWord[restOfWord.Length - 1];
                    }
                    else
                    {
                        newWord = restOfWord + firstLetters + "ay";
                    }

                    if (upperCase)
                    {
                        newWord = newWord.ToUpper();
                    }
                    else if (titleCase)
                    {
                        newWord = ti.ToTitleCase(newWord);
                    }

                    Console.Write(newWord + " ");
                }
            }
        }
        public static bool ContainsCharacters(string userInput)
        {
            var list = new[] { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', '@', '#', '$', '%', '^', '&', '*', '+', '-', '/' };
            return list.Any(userInput.Contains);
        }
        public static bool IsUppercase(string originalInput)
        {
            for (int i = 0; i < originalInput.Length; i++)
            {
                if(!Char.IsUpper(originalInput[i]) && Char.IsLetter(originalInput[i]))
                {
                    return false;
                }

            }
            return true;
        }
        
        public static bool IsTitlecase(string originalInput)
        {
            if(Char.IsUpper(originalInput[0]) && Char.IsLetter(originalInput[0]))
            {
                return true;
            }
            return false;
        }
      public static bool IsEndingPunctuation(string originalInput)
        {
            if(Char.IsPunctuation(originalInput[originalInput.Length - 1]))
            {
                return true;
            }
            return false;
        }

        public static bool KeepAsking()
        {
            Console.WriteLine("Do you want to translate another word? y or n");
            string decision = Console.ReadLine().ToLower();

            if (decision == "y")
            {
                return true;
            }
            else if (decision == "n")
            {
                Console.WriteLine("Thank you for playing! Goodbye");
                return false;
            }
            else
            {
                Console.WriteLine("Invalid Input. Please try again!");
                return KeepAsking();
            }
        }
    }
}