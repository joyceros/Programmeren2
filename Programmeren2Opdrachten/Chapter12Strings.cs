using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Programmeren2Opdrachten
{
	public class Chapter12Strings
	{

        //1 What is the value of each of the following expressions, Explain:
        //"C#"[1]                                       = #
        //"C#"[2]                                       = null
        //"Strings are sequences of characters."[5]     = g
        //"wonderful".Length                            = 9
        //"app" + "le"                                  = apple
        //"appl" + 'e'                                  = apple
        //"Mystery".Substring(4)                        = tery
        //"Mystery".Substring(4, 2)                     = te
        //"Mystery".IndexOf('y')                        = 1
        //"Mystery".IndexOf('z')                        = -1
        //"Mystery".IndexOf('y',3)                      = 6
        //"Mystery".IndexOf('y',3, 2)                   = -1
        //"apple".CompareTo("pineapple") > 0            = false
        //"pineapple".CompareTo("Peach") == 0           = false

        //2  Encapsulate:
        // First parameter is the string (fruit)
        // Second paramter is the char ('a')
        // The Code
       // string fruit = "banana";
       // int count = 0;
       //     foreach (char c in fruit)
       //     {
       //         if (c  == 'a')
       //            count += 1;
       //     }
        //Console.WriteLine(count);
            //in a method named count_letters, and generalize it so that it accepts the string and the letter as arguments. 
            //Make the method return the number of characters, rather than show the answer.






        [Test]
        public void TestExercise2()
        {
            Programmeren2Tests.Chapter12Test.TestExercise3(CountLetters);       
        }

        private int CountLetters(string s, char chr)
        {
            int sum = 0;
            foreach (char c in s)
            {
                if (c == chr)
                {
                    sum++;
                }
            }
            return sum;
        }
        

		//3 Now rewrite the count_letters (see above) method so that instead of traversing the string, 
		//it repeatedly calls the IndexOf method, with the optional third parameter to locate new occurrences of the letter being counted.
		[Test]
		public void TestExercise3()
		{
            Programmeren2Tests.Chapter12Test.TestExercise3(Exercise3);       
		}

        public static int Exercise3(string s, char chr) 
        {
            int result = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (IndexOf(s, chr, i) != -1)
                {
                    result++;
                    i = IndexOf(s, chr, i);
                }
            }
            return result;
        }
        

		public static int IndexOf(string str, char ch, int startPos)
		{
            for (int ix = startPos; ix < str.Length; ix++) 
            {
                if (str[ix] == ch)
                {
                    return ix;
                }
            }

			return -1;
		}

        public static int IndexOf(string str, string sub, int startPos)
        {
            int end = str.Length - sub.Length + 1;
            for (int ix = startPos; ix < end; ix++)
            {
                bool found = true;
                for (int si = 0; si < sub.Length; si++)
                {
                    if(str[ix+si] != sub[si])
                    {
                        found = false;
                        break;
                    }
                }
                if (found)
                {
                    return ix;
                }
            }

            return -1;
        }


        //4 How many times does “queen” occur in the Alice in Wonderland book? Write some code to count them.
		[Test]
		public void TestExercise4()
		{
            Programmeren2Tests.Chapter12Test.TestExercise4(Exercise4);
		}

        public static int Exercise4()
        {
            int count = 0;
            string content = LoadAliceInWonderland();
            string book = content.ToLower();
            string[] words = book.Split();


            foreach(string word in words)
            {
                if (word.Length >= 5)
                {
                    if (word.Substring(0, 5) == "queen")
                        count++;
                }
            }


            return count;





        }




        //load the book (from file) and return it as a string array
        public static string LoadAliceInWonderland()
		{
            string aliceFile = Path.Combine(Environment.CurrentDirectory, "bestanden\\alice_in_wonderland.txt");
            return File.ReadAllText(aliceFile);
		}



		//5. Use string formatting to produce a neat looking multiplication table like this:
        //        1   2   3   4   5   6   7   8   9  10  11  12
        //  :--------------------------------------------------
        // 1:     1   2   3   4   5   6   7   8   9  10  11  12
        // 2:     2   4   6   8  10  12  14  16  18  20  22  24
        // 3:     3   6   9  12  15  18  21  24  27  30  33  36
        // 4:     4   8  12  16  20  24  28  32  36  40  44  48
        // 5:     5  10  15  20  25  30  35  40  45  50  55  60
        // 6:     6  12  18  24  30  36  42  48  54  60  66  72
        // 7:     7  14  21  28  35  42  49  56  63  70  77  84
        // 8:     8  16  24  32  40  48  56  64  72  80  88  96
        // 9:     9  18  27  36  45  54  63  72  81  90  99 108
        //10:    10  20  30  40  50  60  70  80  90 100 110 120
        //11:    11  22  33  44  55  66  77  88  99 110 121 132
        //12:    12  24  36  48  60  72  84  96 108 120 132 144
		[Test]
		public static void MultiplicationTable()
		{
            //There is no test, 
            //use System.Diagnostics.Debug.WriteLine(...) instead of Console.WriteLine(...)

            //opmerking: je krijgt de output niet goed. Dit komt door het testframework (nunit). 
            //Dit wil zeggen (spaties en tab's kunnen wegvallen), hierdoor klopt de uitlijning niet meer. 
            //Ook al de string wel correct geformateerd is.
            //Met andere woorden maak iets wat er op lijkt! Of als je het perfect wil hebben moet je een console applicatie maken. 

            int a, b;
            for (a=1; a<=12; a++)
            {
                for (b = 1; b <= 12; b++)
                {
                    System.Diagnostics.Debug.WriteLine(a * b + "  ");
                }
                System.Diagnostics.Debug.WriteLine("  ");
            }

		}

		//6. Write a method that reverses its string argument, and satisfies these tests:
        //Remark: don't call any other methods!
		[Test]
		public void TestExercise6() 
        {
            Programmeren2Tests.Chapter12Test.TestExercise6(Exercise6);
		}

        public string Exercise6(string str)
        {
            
            return reverseString(str);

        }




        public string reverseString(string str)
        {
            char[] cArray = str.ToCharArray();
            string reverse = String.Empty;
            for (int i = cArray.Length - 1; i > -1; i--)
            {
                reverse += cArray[i];
            }
            return reverse;

        }



        //7. Write a method that mirrors its argument:
        //Assert.AreEqual(mirror("good"), "gooddoog");
        //Assert.AreEqual(mirror("C#"), "C##C");
        //Assert.AreEqual(mirror(""), "");
        //Assert.AreEqual(mirror("a"), "aa");
        // Dick: het laatste testgeval geeft een rare melding ..PSystem.Linq.Enumerable..
        // Dick: string.Reverse() geeft een Iterator ipv een omgekeerde string
        // Joris: nu aangepast
        //Remark: don't call any other methods!
        [Test]
		public void TestExercise7()
		{
            Programmeren2Tests.Chapter12Test.TestExercise7(Exercise7);
		}

		public static string Exercise7(string s)
		{
            char[] cArray = s.ToCharArray();
            string mirror = String.Empty;
            string reverse = String.Empty;
            for (int i = cArray.Length - 1; i > -1; i--)
            {
                reverse += cArray[i];
            }

            mirror = s + reverse;
            return mirror;
		}



		//8. Write a method that removes all occurrences of a given letter from a string:
		[Test]
        public void TestExercise8()
		{
            Programmeren2Tests.Chapter12Test.TestExercise8(Exercise8);
		}

        public static string Exercise8(char chr, string s)
		{
            string char1 = Convert.ToString(chr);
            string result = s.Replace (char1, String.Empty);
            return result;
		}


        //9. Write a method that recognizes palindromes. (Hint: use your reverse method to make this easy!):
		[Test]
		public void TestExercise9()
		{
			Assert.AreEqual(IsPalindrome("abba"), true);
			Assert.AreEqual(IsPalindrome("abab"), false);
			Assert.AreEqual(IsPalindrome("tenet"), true);
			Assert.AreEqual(IsPalindrome("banana"), false);
			Assert.AreEqual(IsPalindrome("straw warts"), true);
			Assert.AreEqual(IsPalindrome("a"), true);
			//A palindrome must consist of at least one character (after removing punctuation and white space).
			Assert.AreEqual(IsPalindrome(""), false, "A palindrome must consist of at least one character (after removing punctuation and white space).");    // Is an empty string a palindrome?  You decide.
		}

		public static bool IsPalindrome(string s)
		{
            if (s == "")
            {
                return false;
            }


            char[] cArray = s.ToCharArray();
            string reverse = String.Empty;
            for (int i = cArray.Length - 1; i > -1; i--)
            {
                reverse += cArray[i];
            }


            if (reverse == s)
            {
                return true;
            }
            else
            {
                return false;
            }




		}









		//Write a method that counts how many times a substring occurs in a string:
		[Test]
		public void TestExercise10()
		{
            Programmeren2Tests.Chapter12Test.TestExercise10(Exercise10);
		}

		public static int Exercise10(string sub, string str) 
        {
            int count = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (IndexOf(str, sub, i) != -1)
                {
                    count++;
                    i = IndexOf(str, sub, i);
                }
            }


            return count;
        }







        //11 Write a method that removes the first occurrence of a string from another string:
        [Test]
		public void TestExercise11()
		{
            Programmeren2Tests.Chapter12Test.TestExercise11(Exercise11);
		}

        public static string Exercise11(string first, string str)
        {
            int index = 0;
            for (int i = 0; i < str.Length; i++)
            {
                index = str.IndexOf(first, i);
                if (index == -1)
                {
                    continue;
                }
                else
                {
                    break;
                }
            }
            if (index == -1)
            {
                return str;
            }

            string result = str.Remove(index, first.Length);
            return result;

        }

		//12 Write a method that removes all occurrences of a string from another string:
		[Test]
		public void TestExercise12()
		{
            Programmeren2Tests.Chapter12Test.TestExercise12(Exercise12);
		}

        public static string Exercise12(string strToRemove, string str)
		{
            string result = str.Replace(strToRemove, String.Empty);
            return result;
        }
	}
}
