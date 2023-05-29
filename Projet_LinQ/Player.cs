using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_LinQ
{
    internal class Player
    {
        public int rank;
        public bool isDead;
        public bool isOnline;
        public string characterName;
        public int level;
        public string characterClass;
        public string id;
        public long experience;
        public string accountName;
        public int challenges;
        public string twitch;
        public string ladder;

        public Player(int rank, bool isDead, bool isOnline, string characterName, int level, string characterClass, string id, long experience, string accountName, int challenges, string twitch, string ladder)
        {
            this.rank = rank;
            this.isDead = isDead;
            this.isOnline = isOnline;
            this.characterName = characterName;
            this.level = level;
            this.characterClass = characterClass;
            this.id = id;
            this.experience = experience;
            this.accountName = accountName;
            this.challenges = challenges;
            this.twitch = twitch;
            this.ladder = ladder;
        }
    }
}
