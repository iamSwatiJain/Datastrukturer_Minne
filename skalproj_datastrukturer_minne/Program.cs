using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkalProj_Datastrukturer_Minne
{
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
                    + "\n4. Reverse String"
                    + "\n5. Check Paranthesis"
                    + "\n6. Examine Recursion"
                    + "\n7. Examine Iteration"
                    + "\n0. Exit the application");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()[0]; //Tries to set input to the first char in an input line
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
                        ReverseString();
                        break;
                    case '5':
                        CheckParanthesis();
                        break;
                    case '6':
                        ExamineRecursion();
                        break;
                    case '7':
                        ExamineIteration();
                        break;
                    /*
                     * Extend the menu to include the recursive 
                     * and iterative exercises.
                     */
                    case '0':
                        return;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4, 5)");
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
            */

            List<string> theList = new List<string>();

            while (true)
            {
                Console.WriteLine("ExamineList Help:");
                Console.WriteLine("+  Add to list");
                Console.WriteLine("-  Remove from list");
                Console.WriteLine("0  GO to main menu");
                Console.Write("Choose: ");

                string input = Console.ReadLine();
                char nav = input[0];
                string value = input.Substring(1);

                Console.WriteLine($"Current capacity [Before]: {theList.Capacity}");

                switch (nav)
                {
                    case '+':
                        theList.Add(value);
                        break;
                    case '-':
                        theList.Remove(value);
                        break;
                    case '0':
                        return;
                    default:
                        break;
                }

                Console.WriteLine($"Current capacity [After]: {theList.Capacity}");
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
            Queue<String> queue = new Queue<string>();

            while (true)
            {
                Console.WriteLine("ExamineQueue Help:");
                Console.WriteLine("+  To enqueue item");
                Console.WriteLine("-  To dequeue item");
                Console.WriteLine("0  GO to main menu");
                Console.Write("Choose: ");

                string input = Console.ReadLine();
                char nav = input[0];
                string value = input.Substring(1);

                switch (nav)
                {
                    case '+':
                        queue.Enqueue(value);
                        break;
                    case '-':
                        queue.Dequeue();
                        break;
                    case '0':
                        return;
                    default:
                        break;
                }

                Console.WriteLine($"The elements in the queue is/are:");
                foreach (var s in queue)
                {
                    Console.WriteLine(s);
                }
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
            Stack<String> stack = new Stack<string>();

            while (true)
            {
                Console.WriteLine("ExamineStack Help:");
                Console.WriteLine("+  To push item");
                Console.WriteLine("-  To pop item");
                Console.WriteLine("0  GO to main menu");
                Console.Write("Choose: ");

                string input = Console.ReadLine();
                char nav = input[0];
                string value = input.Substring(1);

                switch (nav)
                {
                    case '+':
                        stack.Push(value);
                        break;
                    case '-':
                        if (stack.Any())
                        {
                            stack.Pop();
                        }
                        break;
                    case '0':
                        return;
                    default:
                        break;
                }

                Console.WriteLine($"The elements in the stack is/are:");
                foreach (var s in stack)
                {
                    Console.WriteLine(s);
                }
            }
        }

        static void ReverseString()
        {

            Console.WriteLine("Enter a string to be reveresed:");

            var stack = new Stack<char>();

            String str = Console.ReadLine();
            foreach (var s in str)
            {
                stack.Push(s);
            }

            foreach (var s in stack)
            {
                Console.Write(s);
            }
            Console.WriteLine();
        }

        static void CheckParanthesis()
        {
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})]
             * Example of incorrect: (()]), [), {[()}]
             */
            Console.WriteLine("Enter a string with paranthesis:");
            String inputString = Console.ReadLine();

            Stack<char> stack = new Stack<char>();
            bool run = false;

            foreach (var character in inputString)
            {
                if (character=='(' || character == '[' || character == '{' || character == '<')
                {
                    stack.Push(character);
                }
                else if (character == ')' || character == ']' || character == '}' || character == '>')
                {
                    switch (character)
                    {
                        case ')':
                            if (stack.Peek() == '(')
                            {
                                stack.Pop();
                                run = true;
                            }   
                             else
                                run = false;
                            break;
                        case ']':
                            if (stack.Peek() == '[')
                            {
                                stack.Pop();
                                run = true;
                            }
                            else
                                run = false;
                            break;
                        case '}':
                            if (stack.Peek() == '{')
                            {
                                stack.Pop();
                                run = true;
                            }
                            else
                                run = false;
                            break;
                        case '>':
                            if (stack.Peek() == '<')
                            {
                                stack.Pop();
                                run = true;
                            }
                            else
                                run = false;
                            break;
                        default:
                            run = false;
                            break;
                    }

                    if (!run)
                    {
                        break;
                    }
                }
            }
            
            if (run)
                Console.WriteLine("\nYour input string is VALID.\n");
            else
                Console.WriteLine("\nYour input string is INVALID.\n");
        }

        static void ExamineRecursion()
        {
            Console.WriteLine("Enter the integer value of n to find nth odd and even number:");
            
            if (Int32.TryParse(Console.ReadLine(), out int n))
            {
                Console.WriteLine("The "+ n + "st/nd/rd/th odd number is " + RecursiveOdd(n));
                Console.WriteLine("The " + n + "st/nd/rd/th even number is " + RecursiveEven(n));
                Console.WriteLine("The " + n + "st/nd/rd/th fibonacci number is " + RecursiveFibonacciSequence(n));
            }
            else
                Console.WriteLine("You entered non-integer value for n.");
        }

        public static int RecursiveOdd(int n)
        {
            if (n == 0)
            {
                return 1;
            }
            return (RecursiveOdd(n - 1) + 2);
        }

        public static int RecursiveEven(int n)
        {
            if (n == 0)
            {
                return 0;
            }
            return (RecursiveEven(n - 1) + 2);
        }

        public static int RecursiveFibonacciSequence(int n)
        {
            var seq =0;

            if (n == 0 || n == 1)
                seq= n;
            else
            {
                seq = RecursiveFibonacciSequence(n - 1) + RecursiveFibonacciSequence(n - 2);
            }
            return seq;
        }

        static void ExamineIteration()
        {
            Console.WriteLine("Enter the integer value of n to find nth odd and even number:");

            if (Int32.TryParse(Console.ReadLine(), out int n))
            {
                Console.WriteLine("The " + n + "st/nd/rd/th odd number is " + IterativeOdd(n));
                Console.WriteLine("The " + n + "st/nd/rd/th even number is " + IterativeEven(n));
                Console.WriteLine("The " + n + "st/nd/rd/th fibonacci number is " + IterativeFibonacciSequence(n));
            }
            else
                Console.WriteLine("You entered non-integer value for n.");
        }

        public static int IterativeOdd(int n)
        {
            if (n == 0)
            {
                return 1;
            }

            int result = 1;

            for (int i=0; i<=n; i++)
            {
                result += 2;
            }
            return result;
        }

        public static int IterativeEven(int n)
        {
            if (n == 0)
            {
                return 1;
            }

            int result = 0;

            for (int i = 0; i <= n; i++)
            {
                result += 2;
            }
            return result;
        }

        public static int IterativeFibonacciSequence(int n)
        {
           int a = 0, b = 1, c = 0;

            if (n == 0 || n == 1 || n == 2)
                c = n;
            else
            {
                for (int i=2; i < n; i++)
                {
                    c = a + b;

                    Console.Write(" {0}", c);

                    a = b;

                    b = c;
                }

            }
            return c;
        }

    }
}
