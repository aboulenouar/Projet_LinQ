using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Projet_LinQ
{
    internal class Transform
    {           
        public static void TransformToJson()
        {
            List<string> players = File.ReadAllLines(@"../../../../data/csv/poe_data.csv").ToList();
            players.RemoveAt(0);

            var data = from line in players
                       let cleanLine = line.Split(',')
                       let player = new Player(int.Parse(cleanLine[0]), bool.Parse(cleanLine[1]), bool.Parse(cleanLine[2]), cleanLine[3], int.Parse(cleanLine[4]), cleanLine[5], cleanLine[6], long.Parse(cleanLine[7]), cleanLine[8], int.Parse(cleanLine[9]), cleanLine[10], cleanLine[11])
                       select player;

            var jsonData = new JObject(
                new JProperty("players", 
                    from player in data
                        select new JObject(
                            new JProperty("rank", player.rank),
                            new JProperty("dead", player.isDead),
                            new JProperty("online", player.isOnline),
                            new JProperty("name", player.characterName),
                            new JProperty("level", player.level),
                            new JProperty("class", player.characterClass),
                            new JProperty("id", player.id),
                            new JProperty("experience", player.experience),
                            new JProperty("account", player.accountName),
                            new JProperty("challenges", player.challenges),
                            new JProperty("twitch", player.twitch),
                            new JProperty("ladder", player.ladder)
                        )
                )
            );

            File.WriteAllText("../../../../data/json/players_out.json", jsonData.ToString());
            Console.WriteLine("Done !");
        }

        public static void TransformToXML()
        {

            List<string> players = File.ReadAllLines(@"../../../../data/csv/poe_data.csv").ToList();
            players.RemoveAt(0);

            var data = from line in players
                       let cleanLine = line.Split(',')
                       let player = new Player(int.Parse(cleanLine[0]), bool.Parse(cleanLine[1]), bool.Parse(cleanLine[2]), cleanLine[3], int.Parse(cleanLine[4]), cleanLine[5], cleanLine[6], long.Parse(cleanLine[7]), cleanLine[8], int.Parse(cleanLine[9]), cleanLine[10], cleanLine[11])
                       select player;

            var XMLdata = new XElement("players",
                from player in data
                select new XElement("player",
                    new XElement("rank", player.rank),
                    new XElement("dead", player.isDead),
                    new XElement("online", player.isOnline),
                    new XElement("name", player.characterName),
                    new XElement("level", player.level),
                    new XElement("class", player.characterClass),
                    new XElement("id", player.id),
                    new XElement("experience", player.experience),
                    new XElement("account", player.accountName),
                    new XElement("challenges", player.challenges),
                    new XElement("twitch", player.twitch),
                    new XElement("ladder", player.ladder)
                )
            );

            File.WriteAllText("../../../../data/xml/players_out.xml", XMLdata.ToString());
            Console.WriteLine("Done !");
        }
    }
}
