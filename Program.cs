namespace Part5_IfStatements._1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Stages();
            Console.ReadLine();
            Console.Clear();
            Hurricane();
            Console.ReadLine();
            Console.Clear();
            GambleDice();

        }
        public static void Stages()
        {
            //Part 1 Stages
            Console.WriteLine("Hi, what is your age?");
            bool sucess = Int32.TryParse(Console.ReadLine(), out int age1);
            if (sucess){
                if (age1 > 18){
                    Console.WriteLine("You are an Adult");
                }
                else if(age1 <= 0){
                    Console.WriteLine("Error that is not a valid age");
                }
                else if (age1 <= 5){
                    Console.WriteLine("You are a Toddler");
                }
                else if (age1 <= 10){
                    Console.WriteLine("You are a Child");
                }
                else if (age1 <= 12){
                    Console.WriteLine("You are a preteen");
                }
                else if (age1 > 12){
                    Console.WriteLine("You are a Teen");
                }
                else{
                    Console.WriteLine("Error");
                }
            }
            else{
                Console.WriteLine("Error");
            }
        }
        public static void Hurricane()
        {
            //Hurricanes
            
            Console.WriteLine("Please enter the hurricane category:");

            if (Int32.TryParse(Console.ReadLine(), out int category)){
                switch (category)
                {
                    case < 1:
                        Console.WriteLine("error this is not a valid category number");
                        break;
                    case 1:
                        Console.WriteLine("The Hurricane is 74-95 mph, 64-82 kt, 119-153 km/hr.");
                        break;
                    case 2:
                        Console.WriteLine("The Hurricane is 96-110 mph, 83-95 kt, 154-177 km/hr.");
                        break;
                    case 3:
                        Console.WriteLine("The Hurricane is 111-130 mph, 96-113 kt, 178-209 km/hr.");
                        break;
                    case 4:
                        Console.WriteLine("The Hurricane is 131-155 mph, 114-135 kt, 210-249 km/hr.");
                        break;
                    case 5:
                        Console.WriteLine("The Hurricane is greater than 155 mph, 135 kt, 249 km/hr.");
                        break;
                    case > 5:
                        Console.WriteLine("error this is higher than category 5");
                        break;

                }
            }
            else{
                Console.WriteLine("error this is not a numeric value.");
            }
               

        }
        public static void GambleDice()
        {
            Random rand = new Random();
            double bankAcc = 100.00;
            bool continueToRun = true;
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.WriteLine("Welcome to Cheese Casino, the fair casino where you bet on dice rolls, please enjoy your stay.\n");

            while (continueToRun)
            {
                Console.WriteLine($"You currently have ${bankAcc} in your bank account. How much would you like to bet?");
                if (Double.TryParse(Console.ReadLine(), out double betAmount)){
                    if (betAmount < 0){
                        Console.WriteLine("Your bet is a negative number so we will just set it to 0 instead.");
                        betAmount = 0;
                    }
                    else if (betAmount > bankAcc){
                        Console.WriteLine($"You bet more money than your total bank account so we will just change it to ${bankAcc}");
                        betAmount = bankAcc;
                    }
                    int betNumber = 2;
                    bankAcc = bankAcc - betAmount;
                    Console.WriteLine("What would you like to bet on?");
                    Console.WriteLine("'Doubles' : Win double your bet");
                    Console.WriteLine("'Not Doubles' : Win half your bet");
                    Console.WriteLine("'Even Sum' : Win your bet");
                    Console.WriteLine("'Odd Sum' : Win your bet");
                    Console.WriteLine("'Specific' : Specify a number and if you succeed get triple your bet");
                    string betType = Console.ReadLine().ToLower().Trim();
                    betType = betType.Replace(" ", "");
                    if (betType == "specific"){
                        Console.WriteLine("What number would you like to bet on from 2-12");
                        Int32.TryParse(Console.ReadLine(), out betNumber);
                        while (betNumber <= 1 || betNumber > 12){
                            Console.WriteLine("You did not bet a valid number please pick from 2-12");
                            Int32.TryParse(Console.ReadLine(), out betNumber);
                        }
                    }
                    else if (betType != "oddsum" && betType != "notdoubles" && betType != "evensum" && betType != "doubles"){
                        bool loop = false;
                        while (loop == false)
                        {
                            Console.WriteLine("You did not enter a valid option please choose again");
                            betType = Console.ReadLine().ToLower();
                            betType = betType.Replace(" ", "");
                            if (betType == "specific"){
                                Console.WriteLine("What number would you like to bet on from 2-12");
                                Int32.TryParse(Console.ReadLine(), out betNumber);
                                while (betNumber <= 1 || betNumber > 12)
                                {
                                    Console.WriteLine("You did not bet a valid number please pick from 2-12");
                                    Int32.TryParse(Console.ReadLine(), out betNumber);
                                }
                                loop = true;
                            }
                            else if (betType == "oddsum" || betType == "notdoubles" || betType == "evensum" || betType == "doubles"){
                                loop = true;
                            }
                        }
                    }

                    //Below code is an ascii art for rolling dice.
                    Console.WriteLine("  ____\r\n /\\' .\\    _____\r\n/: \\___\\  / .  /\\\r\n\\' / . / /____/..\\\r\n \\/___/  \\'  '\\  /\r\n          \\'__'\\/");
                    int dice1 = rand.Next(1, 7); int dice2 = rand.Next(1, 7);
                    int y = Console.CursorTop; int x = Console.CursorLeft;
                    DiceDrawing(dice1);
                    Console.SetCursorPosition(x + 8, y);
                    DiceDrawing(dice2);
                    Console.WriteLine($"\n {dice1} + {dice2} = {dice1 + dice2}");
                    Console.WriteLine("\n");
                    int diceSum = dice1 + dice2;
                    if (betType == "doubles" && dice1 == dice2){
                        betAmount = betAmount * 3;
                        bankAcc += betAmount;

                        Console.WriteLine($"You bet Doubles and won double your bet, your current balance is: ${bankAcc}");
                    }
                    else if (betType == "evensum" && diceSum % 2 == 0){
                        betAmount = betAmount * 2;
                        bankAcc += betAmount;

                        Console.WriteLine($"You bet Even Sum and won your bet, your current balance is: ${bankAcc}");
                    }
                    else if (betType == "oddsum" && diceSum % 2 != 0){
                        betAmount = betAmount * 2;
                        bankAcc += betAmount;

                        Console.WriteLine($"You bet Odd Sum and won your bet, your current balance is: ${bankAcc}");
                    }
                    else if (betType == "notdoubles" && dice1 != dice2){
                        betAmount = betAmount * 1.5;
                        bankAcc += betAmount;

                        Console.WriteLine($"You bet Not Doubles and won your bet, your current balance is: ${bankAcc}");
                    }
                    else if (betType == "specific" && betNumber == diceSum){
                        betAmount = betAmount * 4;
                        bankAcc += betAmount;
                        Console.WriteLine($"You bet Specific and won your bet, your current balance is: ${bankAcc}");
                    }
                    else{
                        Console.WriteLine($"You lost your bet, your current balance is: ${bankAcc}");
                    }

                }
                else{
                    Console.WriteLine("Error this is not a numeric ammount to bet");
                }
                if (bankAcc == 0){
                    Console.WriteLine("You went bankrupt so we are kicking you out.");
                    continueToRun = false;
                    Console.ReadLine();
                }
                else{
                    Console.WriteLine("Would you like to play again? 'Y' or 'N'");

                    string continueQuestion = Console.ReadLine();
                    continueQuestion = continueQuestion.ToUpper().Trim();
                    if (continueQuestion == "Y"){
                        Console.Clear();
                    }
                    else{
                        continueToRun = false;
                    }
                }


            }

        }
        public static void DiceDrawing(int dice)
        {
            int y = Console.CursorTop; int x = Console.CursorLeft;
            if (dice == 1){
                Console.SetCursorPosition(x, y + 1); Console.Write("_____");
                Console.SetCursorPosition(x, y + 2); Console.Write("|   |");
                Console.SetCursorPosition(x, y + 3); Console.Write("| o |");
                Console.SetCursorPosition(x, y + 4); Console.Write("|   |");
                Console.SetCursorPosition(x, y + 5); Console.Write("-----");
            }
            else if (dice == 2){
                Console.SetCursorPosition(x, y + 1); Console.Write("_____");
                Console.SetCursorPosition(x, y + 2); Console.Write("|o  |");
                Console.SetCursorPosition(x, y + 3); Console.Write("|   |");
                Console.SetCursorPosition(x, y + 4); Console.Write("|  o|");
                Console.SetCursorPosition(x, y + 5); Console.Write("-----");
            }
            else if (dice == 3){
                Console.SetCursorPosition(x, y + 1); Console.Write("_____");
                Console.SetCursorPosition(x, y + 2); Console.Write("|o  |");
                Console.SetCursorPosition(x, y + 3); Console.Write("| o |");
                Console.SetCursorPosition(x, y + 4); Console.Write("|  o|");
                Console.SetCursorPosition(x, y + 5); Console.Write("-----");
            }
            else if (dice == 4){
                Console.SetCursorPosition(x, y + 1); Console.Write("_____");
                Console.SetCursorPosition(x, y + 2); Console.Write("|o o|");
                Console.SetCursorPosition(x, y + 3); Console.Write("|   |");
                Console.SetCursorPosition(x, y + 4); Console.Write("|o o|");
                Console.SetCursorPosition(x, y + 5); Console.Write("-----");
            }
            else if (dice == 5){
                Console.SetCursorPosition(x, y + 1); Console.Write("_____");
                Console.SetCursorPosition(x, y + 2); Console.Write("|o o|");
                Console.SetCursorPosition(x, y + 3); Console.Write("| o |");
                Console.SetCursorPosition(x, y + 4); Console.Write("|o o|");
                Console.SetCursorPosition(x, y + 5); Console.Write("-----");
            }
            else if (dice == 6){
                Console.SetCursorPosition(x, y + 1); Console.Write("_____");
                Console.SetCursorPosition(x, y + 2); Console.Write("|o o|");
                Console.SetCursorPosition(x, y + 3); Console.Write("|o o|");
                Console.SetCursorPosition(x, y + 4); Console.Write("|o o|");
                Console.SetCursorPosition(x, y + 5); Console.Write("-----");
            }

        }

    }
}