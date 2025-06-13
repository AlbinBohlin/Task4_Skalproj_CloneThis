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

#nullable disable
        static string ValidateInput()
        {
            string input;
            try
            {
                input = Console.ReadLine();
                if (input.Length != 0) return input;
            }
            catch (Exception)
            {
                Console.Clear();

            }
            return "A not empty string";// the switch default will handle the rest
        }


        static string PrintData(IEnumerable queue, string msg)
        {
            return $"Mesage: {msg}\n Que: {PrintValues(queue)}";

            static string PrintValues(IEnumerable myCollection)
            {
                foreach (Object obj in myCollection)
                    Console.Write("    {0}", obj);
                Console.WriteLine();
                return "";
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
                Console.WriteLine(PrintData(theList, msg));

            }



        }

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

                string input = ValidateInput();

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
                Console.WriteLine(PrintData(theQueue, msg));

            }

        }

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

                string input = ValidateInput();

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
                Console.WriteLine(PrintData(theStack, msg));

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

            //string input = File.ReadAllText("CheckParanthesis.txt");
            string input = ValidateInput();
            
            char[] parenthesis = ['(', '[', '{', ')', ']', '}'];
            var brackets = input.Where(a => parenthesis.Contains(a));//Parse all brackets from string input

            QueueCheck(brackets);//Matcha

            static void QueueCheck(IEnumerable<Char> input )
            {
                Char[] opening = ['(', '[', '{'];
                
                Stack<Char> stack = [];//För nästlade paranteser

                foreach (char bracket in input)
                {
                    if (opening.Contains(bracket)) stack.Push(bracket);//om vi har inledande parantes, pusha stacken
                    else
                    {
                        try { Console.WriteLine(Match(stack.Pop(), bracket)); } //matcha inledande och slutande  True:False 
                        catch (Exception) { Console.WriteLine("False" + "Stack empty"); }//om slutande utan inledande
                    }
                }
                if (stack.Count > 0) Console.WriteLine("False, unclosed bracket");//om inledande utan slutande
                Console.WriteLine("");
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