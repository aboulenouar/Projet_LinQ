using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Projet_LinQ
{
    internal class Menu
    {
        static readonly string[] allFields = { "rank", "dead", "online", "name", "level", "class", "id", "experience", "account", "challenges", "twitch", "ladder" };
        public static void Header()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("###############################################################");
            Console.WriteLine("#####                                                     #####");
            Console.WriteLine("####                 Path of Exile Players                 ####");
            Console.WriteLine("#####                                                     #####");
            Console.WriteLine("###############################################################\n\n\n\n\n");
        }
        private static int GetChoice(int[] possibleChoices)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("> ");
            Console.ForegroundColor = ConsoleColor.White;

            string choiceString = Console.ReadLine();
            int choice = 0;
            int result = 0;

            while (!int.TryParse(choiceString, out choice) || !possibleChoices.Contains(choice))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Entrée invalide. Veuillez réessayer");
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.Write("> ");
                Console.ForegroundColor = ConsoleColor.White;
                choiceString = Console.ReadLine();
            }
            return choice;
        }

        public static string GetStringInput()
        {
            return Console.ReadLine();
        }

        private static void TransformDataMenu()
        {
            Console.Clear();
            Header();

            Console.WriteLine("-- Transformation des données\n");
            Console.WriteLine("Sélectionnez un format de sortie: \n");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("1. ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("JSON\n");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("2. ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("XML\n\n");

            int choice = GetChoice(new int[] { 1, 2 });

            switch (choice)
            {
                case 1:
                    Transform.TransformToJson();
                    break;
                case 2:
                    Transform.TransformToXML();
                    break;
            }
        }

        private static string FieldSearchMenu()
        {
            Console.Clear();
            Header();

            Console.WriteLine("-- Recherche avancée\n");
            Console.WriteLine("Rechercher sur quel champ ?\n");
            int select = 0;
            List<int> choices = new List<int>();
            foreach(var field in allFields)
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.Write($"{select + 1}. ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"{field}\n");
                choices.Add(select + 1);
                select++;
            }
            Console.WriteLine("\n");

            int fieldChoice = GetChoice(choices.ToArray());
            string selectedField = allFields[fieldChoice - 1];

            return selectedField;
        }

        private static string RankFieldMenu()
        {
            Console.WriteLine("-- Champ Rank\n");
            Console.WriteLine("Entrez le rank du joueur désiré\n\n");

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("> ");
            Console.ForegroundColor = ConsoleColor.White;

            var rank = GetStringInput();

            while (!int.TryParse(rank, out int m))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Entrée invalide. Veuillez entrer un nombre entier\n\n");
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.Write("> ");
                Console.ForegroundColor = ConsoleColor.White;
                rank = GetStringInput();
            }
            return rank;
        }
        private static string DeadFieldMenu()
        {
            Console.WriteLine("-- Champ Dead\n");
            Console.WriteLine("Cherchez vous un personnage mort ?\n\n");

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("1. ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Oui\n");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("2. ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Non\n\n");

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("> ");
            Console.ForegroundColor = ConsoleColor.White;

            int choice = GetChoice(new int[] { 1, 2 });
            string returnValue = "";

            switch (choice)
            {
                case 1:
                    returnValue = "true";
                    break;
                case 2:
                    returnValue = "false";
                    break;
            }
            return returnValue;
        }
        private static string OnlineFieldMenu()
        {
            Console.WriteLine("-- Champ Online\n");
            Console.WriteLine("Cherchez vous un personnage en ligne (au moment de la snapshot) ?\n\n");

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("1. ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Oui\n");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("2. ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Non\n\n");

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("> ");
            Console.ForegroundColor = ConsoleColor.White;

            int choice = GetChoice(new int[] { 1, 2 });
            string returnValue = "";

            switch (choice)
            {
                case 1:
                    returnValue = "true";
                    break;
                case 2:
                    returnValue = "false";
                    break;
            }
            return returnValue;
        }
        private static string NameFieldMenu()
        {
            Console.WriteLine("-- Champ Nom\n");
            Console.WriteLine("Entrez le nom du personnage recherché\n\n");

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("> ");
            Console.ForegroundColor = ConsoleColor.White;

            var name = GetStringInput();

            return name;
        }
        private static string LevelFieldMenu()
        {
            Console.WriteLine("-- Champ Level\n");
            Console.WriteLine("Entrez le niveau du joueur désiré\n\n");

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("> ");
            Console.ForegroundColor = ConsoleColor.White;

            var level = GetStringInput();

            while (!int.TryParse(level, out int m))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Entrée invalide. Veuillez entrer un nombre entier\n\n");
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.Write("> ");
                Console.ForegroundColor = ConsoleColor.White;
                level = GetStringInput();
            }
            return level;
        }
        private static string ClassFieldMenu()
        {
            Console.WriteLine("-- Champ Classe\n");
            Console.WriteLine("Quelle classe souhaitez vous rechercher ?\n\n");

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("1. ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Deadeye\n");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("2. ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Pathfinder\n");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("3. ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Raider\n");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("4. ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Juggernaut\n");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("5. ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Chieftain\n");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("6. ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Berserker\n");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("7. ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Champion\n");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("8. ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Gladiator\n");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("9. ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Slayer\n");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("10. ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Assassin\n");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("11. ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Saboteur\n");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("12. ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Trickster\n");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("13. ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Inquisitor\n");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("14. ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Hierophant\n");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("15. ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Guardian\n");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("16. ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Necromancer\n");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("17. ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Elementalist\n");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("18. ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Occultist\n");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("19. ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Ascendant\n\n");


            int choice = GetChoice(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19 });
            string returnValue = "";

            switch (choice)
            {
                case 1:
                    returnValue = "Deadeye";
                    break;
                case 2:
                    returnValue = "Pathfinder";
                    break;
                case 3:
                    returnValue = "Raider";
                    break;
                case 4:
                    returnValue = "Juggernaut";
                    break;
                case 5:
                    returnValue = "Chieftain";
                    break;
                case 6:
                    returnValue = "Berserker";
                    break;
                case 7:
                    returnValue = "Champion";
                    break;
                case 8:
                    returnValue = "Gladiator";
                    break;
                case 9:
                    returnValue = "Slayer";
                    break;
                case 10:
                    returnValue = "Assassin";
                    break;
                case 11:
                    returnValue = "Saboteur";
                    break;
                case 12:
                    returnValue = "Trickster";
                    break;
                case 13:
                    returnValue = "Inquisitor";
                    break;
                case 14:
                    returnValue = "Hierophant";
                    break;
                case 15:
                    returnValue = "Guardian";
                    break;
                case 16:
                    returnValue = "Necromancer";
                    break;
                case 17:
                    returnValue = "Elementalist";
                    break;
                case 18:
                    returnValue = "Occultist";
                    break;
                case 19:
                    returnValue = "Ascendant";
                    break;

            }
            return returnValue;
        }
        private static string IdFieldMenu()
        {
            Console.WriteLine("-- Champ ID\n");
            Console.WriteLine("Entrez l'ID du personnage recherché\n\n");

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("> ");
            Console.ForegroundColor = ConsoleColor.White;

            var id = GetStringInput();

            return id;
        }
        private static string ExperienceFieldMenu()
        {
            Console.WriteLine("-- Champ Experience\n");
            Console.WriteLine("Entrez l'experience niveau du joueur désiré\n\n");

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("> ");
            Console.ForegroundColor = ConsoleColor.White;

            var exp = GetStringInput();

            while (!long.TryParse(exp, out long m))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Entrée invalide. Veuillez entrer un nombre entier\n\n");
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.Write("> ");
                Console.ForegroundColor = ConsoleColor.White;
                exp = GetStringInput();
            }
            return exp;
        }
        private static string AccountFieldMenu()
        {
            Console.WriteLine("-- Champ Compte\n");
            Console.WriteLine("Entrez le nom du compte du joueur recherché\n\n");

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("> ");
            Console.ForegroundColor = ConsoleColor.White;

            var account = GetStringInput();

            return account;
        }
        private static string ChallengesFieldMenu()
        {
            Console.WriteLine("-- Champ Challenges\n");
            Console.WriteLine("Entrez le nombre de challenges complétés du joueur désiré (max 40)\n\n");

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("> ");
            Console.ForegroundColor = ConsoleColor.White;

            var challenges = GetStringInput();

            while (!int.TryParse(challenges, out int m) || m>40)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Entrée invalide. Veuillez entrer un nombre entier\n\n");
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.Write("> ");
                Console.ForegroundColor = ConsoleColor.White;
                challenges = GetStringInput();
            }
            return challenges;
        }
        private static string TwitchFieldMenu()
        {
            Console.WriteLine("-- Champ Twitch\n");
            Console.WriteLine("Entrez le nom du compte twitch du joueur recherché\n\n");

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("> ");
            Console.ForegroundColor = ConsoleColor.White;

            var twitch = GetStringInput();

            return twitch;
        }
        private static string LadderFieldMenu()
        {
            Console.WriteLine("-- Champ Ladder\n");
            Console.WriteLine("Sur quel ladder souhaitez vous rechercher ?\n\n");

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("1. ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Harbinger\n");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("2. ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Harbinger SSF\n");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("3. ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Harbinger HC\n");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("4. ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Harbinger HC SSF\n\n");

            int choice = GetChoice(new int[] { 1, 2, 3, 4 });
            string returnValue = "";

            switch (choice)
            {
                case 1:
                    returnValue = "Harbinger";
                    break;
                case 2:
                    returnValue = "SSF Harbinger";                
                    break;
                case 3:
                    returnValue = "Hardcore Harbinger";
                    break;
                case 4:
                    returnValue = "SSF Harbinger HC";
                    break;
            }
            return returnValue;
        }

        private static (bool, string) SortMenu()
        {
            Console.WriteLine("-- Tri de la recherche\n");
            Console.WriteLine("Souhaitez vous trier les résultats de la recherche ?\n");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("1. ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Ordre ascendant\n");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("2. ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Ordre descendant\n");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("3. ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Ne pas trier\n\n");

            int choice = GetChoice(new int[] { 1, 2, 3 });

            bool sort = false;
            string order = "";

            switch(choice)
            {
                case 1:
                    sort = true;
                    order = "asc";
                    break;
                case 2:
                    sort = true;
                    order = "desc";
                    break;
                case 3:
                    sort = false;
                    break;
            }

            return (sort, order);
        }

        private static void AdvancedSearchMenu()
        {
            Console.Clear();
            Header();

            Console.WriteLine("-- Recherche avancée\n");
            Console.WriteLine("Sélectionnez une source : \n");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("1. ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("CSV\n");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("2. ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("JSON\n\n");

            int source = GetChoice(new int[] { 1, 2 });

            string field = FieldSearchMenu();
            var term = "";
            bool sort = false;
            string order = "";

            switch(field)
            {
                case "rank":
                    term = RankFieldMenu();
                    break;
                case "dead":
                    term = DeadFieldMenu();
                    break;
                case "online":
                    term = OnlineFieldMenu();
                    break;
                case "name":
                    term = NameFieldMenu();
                    (sort, order) = SortMenu();
                    break;
                case "level":
                    term = LevelFieldMenu();
                    break;
                case "class":
                    term = ClassFieldMenu();
                    break;
                case "id":
                    term = IdFieldMenu();
                    (sort, order) = SortMenu();
                    break;
                case "experience":
                    term = ExperienceFieldMenu();
                    break;
                case "account":
                    term = AccountFieldMenu();
                    (sort, order) = SortMenu();
                    break;
                case "challenges":
                    term = ChallengesFieldMenu();
                    break;
                case "twitch":
                    term = TwitchFieldMenu();
                    (sort, order) = SortMenu();
                    break;
                case "ladder":
                    term = LadderFieldMenu();
                    break;

             
            }
            Search.AdvancedSearch(source, field, term, sort, order);
        }

        private static void StatsMenu()
        {
            Console.Clear();
            Header();

            Console.WriteLine("-- Statistiques\n");
            Console.WriteLine("Sélectionnez une action : \n");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("1. ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Classe\n\n");

            int choice = GetChoice(new int[] { 1 });

            switch (choice)
            {
                case 1:
                    Stats.ClassStats();
                    break;
            }


        }

        private static void BasicMenuSelect(int choice)
        {
            switch(choice)
            {
                case 1:
                    TransformDataMenu();
                    break;
                case 2:
                    Search.SearchData();
                    break;
                case 3:
                    AdvancedSearchMenu();
                    break;
                case 4:
                    StatsMenu();
                    break;
            }
        }

        public static bool AskForRestart()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("\n\n\n1. ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Retourner au menu\n");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("2. ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Terminer l'application\n");

            int choice = GetChoice(new int[] { 1, 2 });

            return(choice == 1);
        }

        public static void DisplayMenu()
        {
            Header();

            Console.WriteLine("Sélectionnez une action via leur numéro :\n");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("1. ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Transformer les données\n");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("2. ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Recherche simple\n");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("3. ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Recherche avancée\n");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("4. ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Statistiques\n\n");

            int choice = GetChoice(new int[] {1, 2, 3, 4});
            Console.WriteLine(choice);

            BasicMenuSelect(choice);

            if(AskForRestart())
            {
                Console.Clear();
                DisplayMenu();
            }
        }
    }
}
