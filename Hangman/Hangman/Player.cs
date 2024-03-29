﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    class Player
    {
        public string Name { get; private set; }

        private int score;
        public int Score
        {
            get { return score; }
            set
            {
                if (value > 0)
                {
                    score = value;
                }
            }
        }

        public List<char> GuessedLetters { get; } = new List<char>();
        
        public Player(string? name)
        {
            this.Name = name;
        }
    }
}
