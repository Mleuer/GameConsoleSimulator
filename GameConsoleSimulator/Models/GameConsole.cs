using System;
using System.Collections.Generic;
using GameConsoleSimulator.Util;

namespace GameConsoleSimulator.Models
{
    public abstract class GameConsole
    {
        public Size DefaultVideoResolution;
        public abstract AVInterface VideoConnectorType { get; }
        public List<User> Users = new List<User>();
        public User CurrentUser { get; private set; } = null;
        public SortedSet<Game> InstalledGames = new SortedSet<Game>();
        public Game CurrentGame { get; private set; } = null;
        
        /// <summary>
        /// Registers user to use this console by adding them to the Users list
        /// </summary>
        /// <param name="user">The user to add</param>
        public void AddUser(User user)
        {
            throw new Exception("AddUser() doesn't do anything yet!");
        }
        
        /// <summary>
        /// Logs the user onto the game console, and makes them the CurrentUser
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>True if the user logged in successfully, false if not</returns>
        public bool Login(String username, String password)
        {
            throw new Exception("Login() doesn't do anything yet!");            
        }
        
        /// <summary>
        /// Adds a game to the console's list of installed games
        /// </summary>
        /// <param name="game">The Game to install</param>
        public void InstallGame(Game game)
        {
            throw new Exception("InstallGame() doesn't do anything yet!");
        }
        
        /// <summary>
        /// Removes the given Game from the list of installed games, and quits it 
        /// if the game to uninstall is the CurrentGame. If this game isn't found
        /// among the list of installed games, it does nothing.
        /// </summary>
        /// <param name="game">The Game to uninstall</param>
        public void UninstallGame(Game game)
        {
            throw new Exception("UninstallGame() doesn't do anything yet!");
        }
        
        /// <summary>
        /// If the provided Game is installed on this console, the CurrentGame is set to the game
        /// given. Otherwise this does nothing.
        /// </summary>
        /// <param name="game"></param>
        public void Play(Game game)
        {
            throw new Exception("Play() doesn't do anything yet!");
        }
        
        /// <summary>
        /// Sets the CurrentGame to null
        /// </summary>
        public void QuitCurrentGame()
        {
            throw new Exception("QuitCurrentGame() doesn't do anything yet!");
        }

        /// <summary>
        /// Shows a welcome splash screen
        /// </summary>
        public abstract void ShowWelcomeScreen();
    }

    public enum AVInterface
    {
        HDMI,
        DisplayPort,
        Other
    }
}