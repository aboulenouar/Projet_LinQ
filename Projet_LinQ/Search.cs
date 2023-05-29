using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Projet_LinQ
{
    internal class Search
    {
        public static void SearchData() 
        {
            Console.Clear();
            Menu.Header();

            Console.WriteLine("-- Recherche simple\n");
            Console.WriteLine("Entrez le nom du personnage\n");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("> ");
            Console.ForegroundColor = ConsoleColor.White;

            string searchInput = Menu.GetStringInput();

            Ladder ladders = new Ladder();

            List<string> players = File.ReadAllLines(@"../../../../data/csv/poe_data.csv").ToList();
            players.RemoveAt(0);

            var data = from line in players
                       let cleanLine = line.Split(',')
                       let player = new Player(int.Parse(cleanLine[0]), bool.Parse(cleanLine[1]), bool.Parse(cleanLine[2]), cleanLine[3], int.Parse(cleanLine[4]), cleanLine[5], cleanLine[6], long.Parse(cleanLine[7]), cleanLine[8], int.Parse(cleanLine[9]), cleanLine[10], cleanLine[11])
                       where player.characterName.Contains(searchInput, StringComparison.InvariantCultureIgnoreCase)
                       select player;


            foreach(var ladder in ladders.Ladders)
            {
                Console.WriteLine($"\n\n=== Ladder : {ladder} ===\n");
                foreach(var player in data)
                {
                    if(player.ladder == ladder)
                    {
                        Console.WriteLine($"{player.rank} - {player.characterName} ({player.characterClass}) - Level: {player.level} - Challenges: {player.challenges}/40");
                    }
                }
            }
        }

        public static object GetPropertyValue(Player player, string propertyName)
        {
            switch (propertyName)
            {
                case "rank":
                    return player.rank;
                case "dead":
                    return player.isDead;
                case "online":
                    return player.isOnline;
                case "name":
                    return player.characterName;
                case "level":
                    return player.level;
                case "class":
                    return player.characterClass;
                case "id":
                    return player.id;
                case "experience":
                    return player.experience;
                case "account":
                    return player.accountName;
                case "challenges":
                    return player.challenges;
                case "twitch":
                    return player.twitch;
                case "ladder":
                    return player.ladder;
                default:
                    throw new Exception($"{propertyName}: Champ invalide");
            }
        }

        public static void AdvancedSearch(int source, string field, string term, bool sort, string order)
        {
            if (source == 1)
            {
                Ladder ladders = new Ladder();

                List<string> players = File.ReadAllLines(@"../../../../data/sources/poe_data.csv").ToList();
                players.RemoveAt(0);


                var data = players
                            .Select(line => line.Split(','))
                            .Select(cleanLine => new Player(
                                int.Parse(cleanLine[0]),
                                bool.Parse(cleanLine[1]),
                                bool.Parse(cleanLine[2]),
                                cleanLine[3],
                                int.Parse(cleanLine[4]),
                                cleanLine[5],
                                cleanLine[6],
                                long.Parse(cleanLine[7]),
                                cleanLine[8],
                                int.Parse(cleanLine[9]),
                                cleanLine[10],
                                cleanLine[11]))
                            .Where(player =>
                            {
                                if (int.TryParse(term, out int intTerm) && (field.Equals("rank") || field.Equals("level") || field.Equals("challenges")))
                                {
                                    return Convert.ToInt32(GetPropertyValue(player, field)) == intTerm;
                                }

                                if (bool.TryParse(term, out bool boolTerm) && (field.Equals("dead") || field.Equals("online")))
                                {
                                    return Convert.ToBoolean(GetPropertyValue(player, field)) == boolTerm;
                                }

                                if (long.TryParse(term, out long longTerm) && field.Equals("experience"))
                                {
                                    return Convert.ToDouble(GetPropertyValue(player, field)) == longTerm;

                                }
                                if (field.Equals("ladder"))
                                {
                                    return GetPropertyValue(player, field).ToString().Equals(term);
                                }
                                return GetPropertyValue(player, field).ToString().Contains(term, StringComparison.InvariantCultureIgnoreCase);
                            });

                if (sort)
                {
                    if (order.Equals("desc"))
                    {
                        data = data.OrderByDescending(player => GetPropertyValue(player, field));
                    }
                    else if (order.Equals("asc"))
                    {
                        data = data.OrderBy(player => GetPropertyValue(player, field));
                    }
                }


                foreach (var ladder in ladders.Ladders)
                {
                    Console.WriteLine($"\n\n=== Ladder : {ladder} ===\n");
                    foreach (var player in data)
                    {
                        if (player.ladder == ladder)
                        {
                            Console.WriteLine($"{player.rank} - {player.characterName} ({player.characterClass}) - Level: {player.level} - Challenges: {player.challenges}/40 - Account: {player.accountName} - Twitch: {player.twitch}");
                        }
                    }
                }
            }
            if (source == 2)
            {
                Ladder ladders = new Ladder();

                var players = JObject.Parse(File.ReadAllText(@"../../../../data/sources/poe_data.json"));

                var data = players["players"]
                    .Select(playerObject => new Player(
                        Convert.ToInt16(playerObject[nameof(Player.rank)]),
                        Convert.ToBoolean(playerObject["dead"]),
                        Convert.ToBoolean(playerObject["online"]),
                        playerObject["name"].ToString(),
                        Convert.ToInt16(playerObject[nameof(Player.level)]),
                        playerObject["class"].ToString(),
                        playerObject[nameof(Player.id)].ToString(),
                        Convert.ToInt64(playerObject[nameof(Player.experience)]),
                        playerObject["account"].ToString(),
                        Convert.ToInt16(playerObject[nameof(Player.challenges)]),
                        playerObject[nameof(Player.twitch)].ToString(),
                        playerObject[nameof(Player.ladder)].ToString()
                    )).Where(player => {
                        if (int.TryParse(term, out int intTerm) && (field.Equals("rank") || field.Equals("level") || field.Equals("challenges")))
                        {
                            return Convert.ToInt32(GetPropertyValue(player, field)) == intTerm;
                        }

                        if (bool.TryParse(term, out bool boolTerm) && (field.Equals("dead") || field.Equals("online")))
                        {
                            return Convert.ToBoolean(GetPropertyValue(player, field)) == boolTerm;
                        }

                        if (long.TryParse(term, out long longTerm) && field.Equals("experience"))
                        {
                            return Convert.ToDouble(GetPropertyValue(player, field)) == longTerm;

                        }
                        if (field.Equals("ladder"))
                        {
                            return GetPropertyValue(player, field).ToString().Equals(term);
                        }
                        return GetPropertyValue(player, field).ToString().Contains(term, StringComparison.InvariantCultureIgnoreCase);
                    });

                if (sort)
                {
                    if (order.Equals("desc"))
                    {
                        data = data.OrderByDescending(player => GetPropertyValue(player, field));
                    }
                    else if (order.Equals("asc"))
                    {
                        data = data.OrderBy(player => GetPropertyValue(player, field));
                    }
                }


                foreach (var ladder in ladders.Ladders)
                {
                    Console.WriteLine($"\n\n=== Ladder : {ladder} ===\n");
                    foreach (var player in data)
                    {
                        if (player.ladder == ladder)
                        {
                            Console.WriteLine($"{player.rank} - {player.characterName} ({player.characterClass}) - Level: {player.level} - Challenges: {player.challenges}/40 - Account: {player.accountName} - Twitch: {player.twitch}");
                        }
                    }
                }
            }
        }
    }
}
