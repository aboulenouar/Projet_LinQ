using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_LinQ
{
    internal class Stats
    {
        public static void ClassStats()
        {
            Console.Clear();
            Menu.Header();

            Console.WriteLine("Statistiques de classe\n\n");

            Ladder ladders = new Ladder();

            List<string> players = File.ReadAllLines(@"../../../../data/csv/poe_data.csv").ToList();
            players.RemoveAt(0);

            var data = from line in players
                       let cleanLine = line.Split(',')
                       let player = new Player(int.Parse(cleanLine[0]), bool.Parse(cleanLine[1]), bool.Parse(cleanLine[2]), cleanLine[3], int.Parse(cleanLine[4]), cleanLine[5], cleanLine[6], long.Parse(cleanLine[7]), cleanLine[8], int.Parse(cleanLine[9]), cleanLine[10], cleanLine[11])
                       select player;

            foreach (var ladder in ladders.Ladders)
            {
                Dictionary<string, int> classCount = new Dictionary<string, int>();
                int totalPlayers = 0;
                Console.WriteLine($"\n\n=== Ladder : {ladder} ===\n");
                foreach (var player in data)
                {
                    if(player.ladder == ladder)
                    {
                        if(!classCount.ContainsKey(player.characterClass))
                        {
                            classCount.Add(player.characterClass, 1);
                        } else
                        {
                            classCount[player.characterClass]++;
                        }
                        totalPlayers++;
                    }
                }

                var sortedClassCount = from classEntry in classCount 
                                       orderby classEntry.Value descending 
                                       select classEntry;

                foreach (var characterClass in sortedClassCount)
                {
                    Console.WriteLine($"{characterClass.Key} : {characterClass.Value} ({Math.Round((float)characterClass.Value*100/totalPlayers, 2)}%)");
                }
            }
        }
    }
}
