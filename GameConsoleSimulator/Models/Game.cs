using System;

namespace GameConsoleSimulator.Models
{
    public class Game : IComparable, IComparable<Game>
    {
        public String Title { get; set; }
        
        public int CompareTo(object obj)
        {
            if (obj.GetType() == typeof(Game))
            {
                return CompareTo(other: (Game) obj);
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        public int CompareTo(Game other)
        {
            return String.Compare(this.Title, other.Title, StringComparison.Ordinal);
        }
    }
}