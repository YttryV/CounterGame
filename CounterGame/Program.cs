namespace CounterGame
{
    internal class Program
    {
        Random countingMemberValue = new Random();

        public static void Main(string[] args)
        {
            int singleMemberLong = 2,
                membersAmount = 3,
                exampleSolve;
            var exampleSignPlusMinus = "none";
            var playerAnswer = "-999999";

            Program program = new Program();

            program.GameOpenText();

            while (true)
            {
                Console.WriteLine();
                program.GameInfoText();

                Console.WriteLine("How long the counting member need to be?\n(Write number from 1 to 3)");
                Console.ForegroundColor = ConsoleColor.Blue;
                singleMemberLong = Convert.ToInt32(Console.ReadLine());
                Console.ResetColor();

                Console.WriteLine("How many counting members need to be?\n(Write number from 1 to 5)");
                Console.ForegroundColor = ConsoleColor.Blue;
                membersAmount = Convert.ToInt32(Console.ReadLine());
                Console.ResetColor();

                while (exampleSignPlusMinus != "p" && exampleSignPlusMinus != "m")
                {
                    Console.WriteLine("You want to subtract or sum numbers?\n(Write \'p\' for PLUS and \'m\' for MINUS)");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    exampleSignPlusMinus = Console.ReadLine();
                    Console.ResetColor();
                    Console.WriteLine();
                }


                int[] members = new int[membersAmount];

                while (true)
                {
                    if (playerAnswer == "s")
                    {
                        playerAnswer = "-999999";
                        exampleSignPlusMinus = "none";
                        break;
                    }
                    members = program.MembersCreator(singleMemberLong, members);

                    exampleSolve = program.ExampleCreatorSolver(members, exampleSignPlusMinus);

                    Console.WriteLine("Write answer on:");
                    if (exampleSignPlusMinus == "p")
                    {
                        for (int i = 0; i < members.Length; i++)
                        {
                            Console.Write(members[i] + " + ");
                        }
                    }
                    else if (exampleSignPlusMinus == "m")
                    {
                        for (int i = 0; i < members.Length; i++)
                        {
                            Console.Write(members[i] + " - ");
                        }
                    }
                    Console.Write("\b\b= ?\n");
                    //Console.Write("\b\b= ? (" + exampleSolve + ")\n");

                    while (true)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        playerAnswer = Console.ReadLine();
                        Console.ResetColor();
                        if (playerAnswer == "s")
                        {
                            break;
                        }
                        else if (Convert.ToInt32(playerAnswer) == exampleSolve)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Answer Correct!\n");
                            Console.ResetColor();
                            break;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Answer Incorrect!");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Try again.");
                            Console.ResetColor();
                        }
                    }
                }
            }
        }

        int[] MembersCreator(int singleMemberLong, int[] members)
        {
            if (singleMemberLong == 1)
            {
                for (int i = 0; i < members.Length; i++)
                {
                    members[i] = countingMemberValue.Next(10);
                }
            }
            else if (singleMemberLong == 2)
            {
                for (int i = 0; i < members.Length; i++)
                {
                    members[i] = countingMemberValue.Next(10, 100);
                }
            }
            else if (singleMemberLong == 3)
            {
                for (int i = 0; i < members.Length; i++)
                {
                    members[i] = countingMemberValue.Next(100, 1000);
                }
            }

            return members;
        }

        int ExampleCreatorSolver(int[] members, String exampleSignPlusMinus)
        {
            int result = 0;
            if (exampleSignPlusMinus == "p")
            {
                for (int i = 0; i < members.Length; i++)
                {
                    result += members[i];
                }
            }
            else if (exampleSignPlusMinus == "m")
            {
                result = members[0];
                for (int i = 1; i < members.Length; i++)
                {
                    result -= members[i];
                }
            }
            else
            {
                result = -4999;
            }
            return result;
        }

        void GameOpenText()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nThe Counting Game!");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("The Counting Game!");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("The Counting Game!");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("The Counting Game!");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("The Counting Game!");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("The Counting Game!");
            Console.ResetColor();
        }

        void GameInfoText()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("If you want to change parameters, press \"s\" in any moment AFTER change parameters\n\n");
            Console.ResetColor();
        }
    }
}