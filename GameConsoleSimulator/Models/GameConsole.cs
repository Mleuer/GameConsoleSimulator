using System;
using System.Collections.Generic;
using SFML.Graphics;
using GameConsoleSimulator.Util;

namespace GameConsoleSimulator.Models
{
    public abstract class GameConsole
    {
        public Size VideoResolution;
        protected RenderWindow Window;
        public abstract AVInterface VideoConnectorType { get; }
        public List<User> Users = new List<User>();
        public User CurrentUser { get; private set; } = null;
        public SortedSet<Game> InstalledGames = new SortedSet<Game>();
        public Game CurrentGame { get; private set; } = null;
        public bool Running { get; set; } = false;
        
        
        /// <summary>
        /// Registers user to use this console by adding them to the Users list
        /// </summary>
        /// <param name="user">The user to add</param>
        public void AddUser(User user)
        {
            this.Users.Add(user);
        }
        
        /// <summary>
        /// Logs the user onto the game console, and makes them the CurrentUser
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>True if the user logged in successfully, false if not</returns>
        public bool Login(String username, String password)
        {
            bool successfulLogin = false;
            
            foreach (var registeredUser in Users)    
            {
                if (username == registeredUser.Name)
                {
                    if (password == registeredUser.Password)
                    {
                        this.CurrentUser = registeredUser;
                        successfulLogin = true;
                        
                        return successfulLogin;
                    }
                }
            }

            return successfulLogin;
        }

        /// <summary>
        /// Adds a game to the console's list of installed games
        /// </summary>
        /// <param name="game">The Game to install</param>
        public void InstallGame(Game game)
        {
            game.Console = this;
            this.InstalledGames.Add(game);
        }

        public void InstallGames(params Game[] games)
        {
            foreach (var game in games)
            {
                this.InstallGame(game);
            }
        }
        
        /// <summary>
        /// Removes the given Game from the list of installed games, and quits it 
        /// if the game to uninstall is the CurrentGame. If this game isn't found
        /// among the list of installed games, it does nothing.
        /// </summary>
        /// <param name="game">The Game to uninstall</param>
        public void UninstallGame(Game game)
        {
            if (InstalledGames.Contains(game))
            {
                this.InstalledGames.Remove(game);
                game.Console = null;
                
                if (game == CurrentGame)
                {
                    this.QuitCurrentGame();
                }
            }
            
        }
        
        /// <summary>
        /// If the provided Game is installed on this console, the CurrentGame is set to the game
        /// given. Otherwise this does nothing.
        /// </summary>
        /// <param name="game"></param>
        public void Play(Game game)
        {
            if (InstalledGames.Contains(game))
            {
                this.CurrentGame = game;
                game.Play();
            }
        }
        
        /// <summary>
        /// Sets the CurrentGame to null
        /// </summary>
        public void QuitCurrentGame()
        {
            this.CurrentGame = null;
        }
        public abstract void DrawToMainDisplay(Drawable drawable, ulong framesToDisplayFor);
        
        /// <summary>
        /// Shows a welcome splash screen
        /// </summary>
        public abstract void RunStartupRoutine();
    }

    public enum AVInterface
    {
        HDMI,
        DisplayPort,
        Other
    }
}