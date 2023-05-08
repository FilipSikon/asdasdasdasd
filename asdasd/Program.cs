using System;

namespace Slutprojekt.filip
{
    class Program
    {

        static void Main(string[] args)
        {
            //Här skapas spelbiblioteket
            GameLibrary library = new GameLibrary();

            //Deklarerar alla variabler som kommer användas

            //U-et framför dessa variabler är för att lättare kunna förstå vilka variabler som precis samlats från användaren
            //och vilka variabler som är fastställda i de olika elementsen
            int run = 1;
            string uTitle;
            int uYear;
            bool uPlayed;
            int gameAmount = 0;
            int gameNumber;
            string uCreator;
            int intInput;
            bool boolInput;
            int choice = 0;
            //En variabel för valet användaren gör

            //En switch-case för att det är lättare att hänga med i och mer organiserat än flertal if-statements
            while (run == 1)
            {
                Console.WriteLine();
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1. Add a game to your list");
                Console.WriteLine("2. Remove a game from your list");
                Console.WriteLine("3. Update whether or not you've played a game on the list");
                Console.WriteLine("4. List your games");
                Console.WriteLine("5. About the program");
                Console.WriteLine("6. Turn off the program");
                Console.WriteLine();
                //Alla int inputs som kommer samlas framöver är täckta i try-catch inuti while loopar
                //Detta så att användaren inte kraschar programmmet och måste skriva ett giltigt värde för att programmet ska fortsätta
                while (true)
                {
                    try
                    {
                        choice = int.Parse(Console.ReadLine());
                        break;
                    }
                    catch
                    {
                        Console.WriteLine("The value you enter can only be in whole numbers! Try again:");
                        Console.WriteLine();
                    }
                }
                switch (choice)
                {


                    case 1:
                        Console.WriteLine("Now you will be asked some questions about the game you want to add:");
                        Console.WriteLine("What is the title of the game?:");
                        Console.WriteLine();
                        uTitle = Console.ReadLine();
                        Console.WriteLine("Who is the Creator?:");
                        Console.WriteLine();
                        uCreator = Console.ReadLine();
                        while (true)
                        {
                            try
                            {
                                Console.WriteLine("What year was it released?:");
                                Console.WriteLine();
                                uYear = int.Parse(Console.ReadLine());
                                break;
                            }
                            catch
                            {
                                Console.WriteLine("The value you enter can only be in whole numbers! Try again:");
                                Console.WriteLine();
                            }
                        }
                        while (true)
                        {
                            try
                            {
                                Console.WriteLine("Have you played this game? (Answer only with 'true' or 'false'):");
                                uPlayed = bool.Parse(Console.ReadLine());
                                break;
                            }
                            catch
                            {
                                Console.WriteLine("The value you enter can only be in the words 'true' or 'false'! Try again");
                            }
                        }
                        //Jag lägger till en 1:a för att index börjar från noll men människor börjar räkna från ett
                        gameNumber = gameAmount + 1;
                        library.AddGame(new Game(gameNumber, uTitle, uCreator, uYear, uPlayed));
                        //gameAmount++; görs så att antalet spel uppdateras när användaren ändrat antalet filmer
                        gameAmount++;
                        choice = 0;
                        break;
                    case 2:
                        //I början av vissa funktioner så checkar programmet ifall användaren lagt till några spel än
                        //Annars skulle funktionen försöka köras och leda till errors eller onödig interaktion
                        if (gameAmount > 0)
                        {
                            Console.WriteLine("This is the games you have in your list:");
                            library.ListGames();
                            while (true)
                            {
                                try
                                {
                                    Console.WriteLine("What number is next to the game you would like to remove?:");
                                    intInput = int.Parse(Console.ReadLine());
                                    if (intInput > 0 && intInput <= gameAmount)
                                    {
                                        break;
                                    }
                                }
                                catch
                                {
                                    Console.WriteLine("The value you enter has to be a whole number from 1 and onwards! Try again");
                                }
                            }
                            library.RemoveGame(intInput);
                            //gameAmount--; görs så att antalet spel uppdateras när användaren ändrat antalet filmer
                            gameAmount--;
                            choice = 0;
                        }
                        else
                        {
                            Console.WriteLine("You don't have any games to remove.");
                        }
                        break;
                    case 3:
                        if (gameAmount > 0)
                        {
                            Console.WriteLine("This is the games you have in your list:");
                            library.ListGames();
                            while (true)
                            {
                                try
                                {
                                    Console.WriteLine("What number is next to the movie you would like to change the status of?:");
                                    intInput = int.Parse(Console.ReadLine());
                                    break;
                                }
                                catch
                                {
                                    Console.WriteLine("The value you enter has to be a whole number! Try again");
                                }
                            }
                            while (true)
                            {
                                try
                                {
                                    Console.WriteLine("Write 'true' if you have played this game and 'false' if you have not:");
                                    boolInput = bool.Parse(Console.ReadLine());
                                    break;
                                }
                                catch
                                {
                                    Console.WriteLine("The value you enter has to be 'true' or 'false' written exactly as shown! Try again");
                                }
                            }
                            //Efter värdena för numret på spelet och vare sig användaren har kollat på den eller inte samlas
                            //så används dom i funktionen för att ändra statusen i elementet
                            library.ChangePlayStatus(intInput, boolInput);
                            choice = 0;
                        }
                        else
                        {
                            Console.WriteLine("You don't have any games to change the status for.");
                        }
                        break;
                    case 4:
                        if (gameAmount > 0)
                        {
                         Console.WriteLine("You have {0} games in your library:", gameAmount);
                         Console.WriteLine();
                         library.ListGames();
                        }
                        else
                        {
                            Console.WriteLine("You haven't added any games yet.");
                        }
                        choice = 0;
                        break;
                    case 5:
                        Console.WriteLine();
                        Console.WriteLine("The purpose of this program is to gather the games you would like to play or have played before");
                        Console.WriteLine("It also makes it very easy to keep track of which games you have already played");
                        Console.WriteLine("The following are explanations of each option:");
                        Console.WriteLine("1. You can add a game by typing the name, creator, year of release, and whether or not you have played it");
                        Console.WriteLine("2. Removing a game from the list is incase you change your mind and no longer want to play that game anymore");
                        Console.WriteLine("3. This allows you to report incase you have played one of the games");
                        Console.WriteLine("4. This will list out all the games you have saved/stored and show you their names, creators, release years and whether you have played them");
                        Console.WriteLine();
                        choice = 0;
                        break;
                    case 6:
                        run = 0;
                        choice = 0;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}