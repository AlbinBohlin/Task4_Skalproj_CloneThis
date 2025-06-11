namespace SkalProj_Datastrukturer_Minne
{
    using System.Linq;
    using System.Text;

    class Program
    {
        /// <summary>
        /// The main method, vill handle the menues for the program
        /// </summary>
        /// <param name="args"></param>
        static void Main()
        {

            while (true)
            {
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParenthesis"
                    + "\n0. Exit the application");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()![0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                switch (input)
                {
                    case '1':
                        ExamineList();
                        break;
                    case '2':
                        ExamineQueue();
                        break;
                    case '3':
                        ExamineStack();
                        break;
                    case '4':
                        CheckParanthesis();
                        break;
                    /*
                     * Extend the menu to include the recursive 
                     * and iterative exercises.
                     */
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                        break;
                }
            }
        }

        /// <summary>
        /// Examines the datastructure List
        /// </summary>
        static void ExamineList()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch statement with cases '+' and '-'
             * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
             * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
             * In both cases, look at the count and capacity of the list
             * As a default case, tell them to use only + or -
             * Below you can see some inspirational code to begin working.
            */

            //List<string> theList = new List<string>();
            //string input = Console.ReadLine();
            //char nav = input[0];
            //string value = input.substring(1);

            //switch(nav){...}
        }

        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        static void ExamineQueue()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch with cases to enqueue items or dequeue items
             * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
            */
        }

        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
        static void ExamineStack()
        {
            /*
             * Loop this method until the user inputs something to exit to main menue.
             * Create a switch with cases to push or pop items
             * Make sure to look at the stack after pushing and and poping to see how it behaves
            */
        }

        static void CheckParanthesis()
        {
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */


            /*This is a classic use-case of recursion. Yey! Blir nästan nostalgisk.
             Det passar utmärkt att använda en stack för att hålla reda på paranteserna men rekursion är roligare.*/

            //börja med input.. vi tar exemplet från ovan och jobbar med..
            string? input = File.ReadAllText("CheckParanthesis.txt");
            Console.WriteLine("Checking input...");
            //parsa ut intressant substräng, de tecken vi bryr oss om: (,[,{,),],}
            char[] parenthesis = ['(', '[', '{', ')', ']', '}'];
            string starters = "({[";
            string enders = ")]}";

            do
            {
                //kontrollera att det inte börjar med en slutande parantes
                int start = input.IndexOfAny(parenthesis);// -1 if none
                Console.WriteLine(input.Substring(start, input.Length - start));//blev denna pga intellisense.. 
                if (enders.Contains(input.First()))//om fel direkt
                {
                    Console.WriteLine("Error: " + input.First());
                    input = input.Substring(1);//kasta det felet
                }
            } while (!starters.Contains(input.First()));//repetera om inte redan rätt.




            //nästla en metod som kör sig själv rekursivt.
            static string Checkparenthesis(string? input, string enders, string starters, int start, StringBuilder result)
            {




                //sluta om vi hittar en som stänger
                if (enders.Contains(input.First())) { result.Append(input.First());  return input.Substring(1); }

                result.Append(input.First());

                //annars upprepa processen
                CheckParanthesis()

            }





        }

    }
}

