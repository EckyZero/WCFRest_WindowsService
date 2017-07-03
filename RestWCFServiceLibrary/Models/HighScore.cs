﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace RestWCFServiceLibrary.Models
{
    [DataContract]
    public class HighScore
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int Score { get; set; }

        public HighScore(string name, int score)
        {
            this.Name = name;
            this.Score = score;
        }
    }
}