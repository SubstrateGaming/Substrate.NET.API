using System;

namespace TestTee
{
    public class Dot4GPlayer
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int Bombs { get; internal set; }

        public Dot4GPlayer(string name, string address)
        {
            Name = name;
            Address = address;
        }

        override
        public string ToString()
        {
            return $"{Name} - Bomb[{Bombs}]";  
        }
    }
}