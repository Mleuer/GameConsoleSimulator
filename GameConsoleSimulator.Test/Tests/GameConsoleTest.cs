using C5;
using NUnit.Framework;
using FluentAssertions;
using GameConsoleSimulator.Models;

namespace GameConsoleSimulator.Test.Tests
{
    public static class GameConsoleTest
    {
        [Test]
        public static void ANewlyRegisteredUserShouldAppearInTheListOfUsers()
        {
            var console = new GenericGameConsole();
            var kyle = new User(Name: "Kyle", Password: "l;33tboi469");
            
            console.AddUser(kyle);

            Assert.True(console.Users.Contains(kyle));
        }

        [Test]
        public static void ARegisteredUserCanLogin()
        {
            var console = new GenericGameConsole();
            var dad = new User(Name: "Stephen", Password:"#123");
            
            console.AddUser(dad);
            bool loginSuccessful = console.Login(username: dad.Name, password: dad.Password);
            
            Assert.True(loginSuccessful);
            Assert.AreSame(expected: dad,console.CurrentUser);
        }
        
        
        [Test]
        public static void AnUnRegisteredUsersShouldNotBeAbleToLogIn()
        {
            var console = new GenericGameConsole();            
            var dad = new User(Name: "Stephen", Password: "#123");
            
            bool loginSuccessful = console.Login(username: dad.Name, password: dad.Password);
            
            Assert.False(loginSuccessful);
            Assert.Null(console.CurrentUser);
        }

        [Test]
        public static void TheCurrentUserShouldBeTheMostRecentToLogIn()
        {
            var console = new GenericGameConsole();
            var kyle = new User(Name: "Kyle", Password: "l;33tboi469");
            console.AddUser(kyle);
            console.Login(username: kyle.Name, password: kyle.Password);
            var caroline = new User(Name: "Caroline", Password: "hi");
            console.AddUser(caroline);
            
            console.Login(username: caroline.Name, password: caroline.Password);

            console.CurrentUser.Should().NotBe(kyle);
            console.CurrentUser.Should().Be(caroline);
        }
        
        [Test]
        public static void ANewlyInstalledGameShouldAppearInTheListOfInstalledGames()
        {
            GameConsole console = new GenericGameConsole();
            var superman64 = new Game { Title = "Superman 64" };
            var shadowOfTheColossus = new Game { Title = "Shadow of the Colossus" };
            var me2 = new Game { Title = "Mass Effect 2" };
            var games = new ArrayList<Game> { superman64, shadowOfTheColossus, me2 };

            foreach (var game in games)
            {
                console.InstallGame(game);
            }
            
            Assert.True(console.InstalledGames.Contains(superman64));
            Assert.True(console.InstalledGames.Contains(shadowOfTheColossus));
            Assert.True(console.InstalledGames.Contains(me2));
        }
        
        [Test]
        public static void AGameCanNotBePlayedIfItIsNotAlreadyInstalled()
        {
            var console = new GenericGameConsole();
            var me2 = new Game { Title = "Mass Effect 2" };
            
            console.Play(me2);
            
            Assert.Null(console.CurrentGame);
        }

        
        [Test]
        public static void TheGamePlayedShouldBeTheCurrentGame()
        {
            var console = new GenericGameConsole();
            var me2 = new Game { Title = "Mass Effect 2" };
            console.InstallGame(me2);
            
            console.Play(me2);
            
            console.CurrentGame.Should().Be(me2);
        }

        [Test]
        public static void QuitCurrentGameShouldSetTheCurrentGameToNull()
        {
            var console = new GenericGameConsole();
            var me2 = new Game { Title = "Mass Effect 2" };
            console.InstallGame(me2);
            console.Play(me2);
            
            console.QuitCurrentGame();
            
            Assert.Null(console.CurrentGame);
        }
                
        [Test]
        public static void AGameCanNotBePlayedIfItWasUninstalled()
        {
            var console = new GenericGameConsole();
            var me2 = new Game { Title = "Mass Effect 2" };
            console.InstallGame(me2);            
            console.Play(me2);

            console.UninstallGame(me2);
            
            Assert.Null(console.CurrentGame);    
        }

        [Test]

        public static void OnlyTheGameBeingUninstalledShouldBeStopped()
        {
            var console = new GenericGameConsole();
            var me2 = new Game { Title = "Mass Effect 2" };
            var apex = new Game { Title = "Apex Legends" };
            console.InstallGames(me2, apex);
            console.Play(apex);
            console.UninstallGame(me2);
            
            Assert.AreSame(apex, console.CurrentGame);
        }
    }
}