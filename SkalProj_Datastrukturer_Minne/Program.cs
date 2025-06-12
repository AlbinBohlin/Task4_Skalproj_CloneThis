namespace SkalProj_Datastrukturer_Minne
{
    using System.Collections;
    using System.Linq;
    using System.Text;

    class Program
    {
        /// <summary>
        /// The main method, vill handle the menues for the program
        /// </summary>
        /// <param name="args"></param>
        /// 


        static string ValidateInput()
        {
            string input;
            try
            {
                input = Console.ReadLine();
                if (input.Length != 0) return input;
                return "Wrong";

            }
            catch (Exception) //If the input line is empty, we ask the users for some input.
            {
                Console.Clear();
                return "gg";
            }
        }

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

                string input = ValidateInput();

                switch (input[0])
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

            List<string> theList = [];
            Console.WriteLine("+... Adds\n-... Removes\n0 Return to main");

            while (true)
            {

                string? input = ValidateInput();

                string msg;
                switch (input[0])
                {
                    case '+':
                        theList.Add(input[1..]);
                        msg = $"Added \"{input[1..]}\"";
                        break;
                    case '-': msg = theList.Remove(input[1..]) ? $"Removed first instance of \"{input[1..]}\"" : $"Failed to remove \"{input[1..]}\""; break;
                    case '0': msg = "Returning to MainMenu"; Console.WriteLine(msg); return;
                    default: msg = "Must have +,-,0 as first char in string"; break;
                }
                Console.WriteLine(PrintListData(theList, msg));

            }

            static string PrintListData(List<string> list, string msg)
            {
                return $"Mesage: {msg}\nListLength: {list.Count}\tSize: {list.Capacity}";
            }

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

            Queue<string> theQueue = [];
            Console.WriteLine("+... Enques string\n- Deque string\n0 Return to main");

            while (true)
            {

                string? input = ValidateInput();

                string msg;
                switch (input[0])
                {
                    case '+':
                        theQueue.Enqueue(input[1..]);
                        msg = $"Added \"{input[1..]}\" to End of Queue";
                        break;
                    case '-':
                        try
                        {
                            msg = $"Removed first in queue: \"{theQueue.Dequeue()}\"";
                        }
                        catch (InvalidOperationException) { msg = "Queue empty"; }
                        break;
                    case '0': msg = "Returning to MainMenu"; Console.WriteLine(msg); return;
                    default: msg = "Must have +,-,0 as first char in string"; break;
                }
                Console.WriteLine(PrintListData(theQueue, msg));

            }

            static string PrintListData(Queue<string> list, string msg)
            {
                return $"Mesage: {msg}\n Que: {PrintValues(list)}";
            }

            static string PrintValues(IEnumerable myCollection)
            {
                foreach (Object obj in myCollection)
                    Console.Write("    {0}", obj);
                Console.WriteLine();
                return "";
            }



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


            Stack<string> theStack = [];
            Console.WriteLine("+... Push string\n- Pop string\n0 Return to main");

            while (true)
            {

                string? input = ValidateInput();

                string msg;
                switch (input[0])
                {
                    case '+':
                        theStack.Push(input[1..]);
                        msg = $"Added \"{input[1..]}\" to top of stack";
                        break;
                    case '-':
                        try
                        {
                            msg = $"Removed top of stack: \"{theStack.Pop()}\"";
                        }
                        catch (InvalidOperationException) { msg = "Stack empty"; }
                        break;
                    case '0': msg = "Returning to MainMenu"; Console.WriteLine(msg); return;
                    default: msg = "Must have +,-,0 as first char in string"; break;
                }
                Console.WriteLine(PrintListData(theStack, msg));

            }

            static string PrintListData(Stack<string> stack, string msg)
            {
                return $"Mesage: {msg}\n Que: {PrintValues(stack)}";
            }

            static string PrintValues(IEnumerable myCollection)
            {
                foreach (Object obj in myCollection)
                    Console.Write("    {0}", obj);
                Console.WriteLine();
                return "";
            }

        }
#nullable disable
        static void CheckParanthesis()
        {
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */

            /*En Queue hade löst detta väldigt bekvämt, men jag fick för mig att skriva en rekursiv metod istället. Blev lite bökigt, jag är rostig ännu..*/

            //börja med input.. vi tar exemplet från ovan och jobbar med..
            string? input = File.ReadAllText("CheckParanthesis.txt");
            //string input = Console.ReadLine();

            Console.WriteLine("input: " + input + "\nChecking input...");
            //parsa ut intressant substräng, de tecken vi bryr oss om: (,[,{,),],}
            char[] parenthesis = ['(', '[', '{', ')', ']', '}'];

            int start = input.IndexOfAny(parenthesis);// -1 if none
            try
            {
                input = input[start..];//Empty string or no parenthesis
            }
            catch (Exception) {/* hanteras senare */}


            Console.WriteLine(QueueCheck(input));
            Console.WriteLine("RecursiveCheck");
            Console.WriteLine(CheckRecursive(input, parenthesis, 0, new StringBuilder()));//Utvärdera input


            static string QueueCheck(string input)
            {
                Console.WriteLine("QueueCheck");
                char[] parenthesis = ['(', '[', '{', ')', ']', '}'];
                Queue<char> check = [];
                int indexNext = 0;
                //parse input, populate queue

                do
                {
                    input = input[indexNext..];//Jump to next
                    check.Enqueue(input[0]);
                    input = input[1..];//purge
                    indexNext = input.IndexOfAny(parenthesis);//find next or -1 for 
                } while (indexNext >= 0);

                Stack<Char> stack = [];//För nästlade paranteser
                foreach (char bracket in check)
                {
                    if (parenthesis[..3].Contains(bracket)) stack.Push(bracket);//om vi har inledande parantes, push på stack
                    else { try { Console.WriteLine(Match(stack.Pop(), bracket)); } catch (Exception) { Console.WriteLine("False" + "Stack empty"); } }
                }
                return "";
            }//Lade till en enkel funktion som utnytjar queue och stack..

            static string CheckRecursive(string input, char[] parenthesis, int depth, StringBuilder result)
            {
                //sluta om vi hittar en som stänger
                if (input.Length != 0 && parenthesis[3..].Contains(input.First()))
                {
                    result.Append(input.First());
                    depth--;
                    input = input[1..];
                    try
                    {
                        input = input[input.IndexOfAny(parenthesis)..];
                    }
                    catch (Exception) { /*Final closing parenthesis problem*/ }
                    if (depth == 0)
                    { //Har vi funnit korrekt sluten grupp av paranteser eller inledande stängande fel

                        for (int i = 0; i < result.Length / 2; i++)
                        {
                            if (!Match(result[i], result[result.Length - 1 - i]))
                            {
                                Console.WriteLine("Error: " + result.ToString());
                                result.Clear();
                                return CheckRecursive(input, parenthesis, 0, result);//Hittat fel, fortsätt
                            }
                        }
                        Console.WriteLine("Ok: " + result.ToString());//Hittat korrekt grupp
                        result.Clear();

                    }
                    else if (depth < 0)
                    {
                        Console.WriteLine("Error, Leading close: " + result.ToString()); //inledande stängade parantesfel
                        result.Clear();
                        return CheckRecursive(input, parenthesis, 0, result);//Fortsätt
                    }
                    return CheckRecursive(input, parenthesis, depth, result);//Fortsätt efter korrekt
                }
                try
                {
                    result.Append(input.First());
                    input = input[1..];
                    input = input[input.IndexOfAny(parenthesis)..];
                }
                catch (Exception e)
                {
                    //Antingen färdig eller en eller fler ostängda inledande paranteser.
                    if (result.Length > 1) Console.WriteLine("Error with unclosed parenthesis: " + result.ToString());
                    return "\n-------All done----------\n";
                }
                //annars upprepa processen
                depth++;//Räkna inledande paranteser i följd.
                return CheckRecursive(input, parenthesis, depth, result);
            }



            static bool Match(char left, char right)
            {
                switch (left)
                {
                    case '(': return right.Equals(')');
                    case '[': return right.Equals(']');
                    case '{': return right.Equals('}');
                    default: return false;
                }
            }



        }

    }


}