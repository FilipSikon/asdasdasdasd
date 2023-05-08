using System;
using System.Collections.Generic;

namespace Slutprojekt.filip
{
    class Game
    {
        public int Number { get; set; }        public string Title { get; set; }
        public string Creator { get; set; }
        public int Year { get; set; }
        public bool Played { get; set; }

        //En egen samling av variabler för filmerna som innehåller titeln, regissören och året filmen släpptes samt
        //ifall användaren har sett filmen redan eller inte
        //construct
        public Game(int number, string title, string creator, int year, bool played)
        {
            Number = number;
            Title = title;
            Creator = creator;
            Year = year;
            Played = played;
        }
    }

    class GameLibrary
    {
        private List<Game> games;

        public GameLibrary()
        {
            games = new List<Game>();
        }

        //En funtkion för att lägga till filmerna som användaren vill ha (som inte hittas i databasen av spel)
        public void AddGame(Game game)
        {
            games.Add(game);
        }
        public void RemoveGame(int gameToRemove)
        {
            //Här kollar den igenom alla spel och varje film som har samma nummer som användaren skrev tas bort
            games.RemoveAll(x => x == games[gameToRemove - 1]);
        }
        public void ChangePlayStatus(int gameToChange, bool playStatus)
        {
            //Jag använder index (med -1 för att omvandla från mänsklig räkning till index) 
            //för att få fram spelet som användaren syftar på och ändra statusen
            games[gameToChange - 1].Played = playStatus;
        }

        public void ListGames()
        {
            //En funktion för att skriva ut informationen om alla filmer som personen lagt till i listan
            foreach (Game game in games)
            {
                Console.WriteLine(game.Number + ". Title: " + game.Title);
                Console.WriteLine("Creator: " + game.Creator);
                Console.WriteLine("Year: " + game.Year);
                Console.WriteLine("Played: " + game.Played);
                Console.WriteLine();
            }
        }
    }
}