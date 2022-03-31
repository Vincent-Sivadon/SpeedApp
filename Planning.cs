using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SpeedApp
{
    public class Player
    {
        public string name;
        public int pause;
        public int poule;

        public Player(string name_, int poule_)
        {
            this.name = name_;
            this.pause = 0;
            this.poule = poule_;
        }
    }
    public class Match
    {
        public Player player1;
        public Player player2;
        public Match(Player p1, Player p2)
        {
            this.player1 = p1;
            this.player2 = p2;
        }
        public bool isEqual(Match m)
        {
            return (m.player1.name == player1.name && m.player2.name == player2.name) ||
                    (m.player1.name == player2.name && m.player2.name == player1.name);
        }
    }
    public class Terrain
    {
        public Match match;
        public Terrain(Match match_)
        {
            this.match = match_;
        }
    }

    internal class Planning
    {
        // Membres
        public List<Match> matches;
        public List<Player> players;
        public List<Terrain> terrains;
        private int nbPoules;
        private int nbTerrains;

        private void eraseMatch(Match m)
        {
            for (int i = 0; i < matches.Count(); i++)
                if (m.isEqual(matches[i]))
                    matches.RemoveAt(i);
        }

        public bool isPlaying(Player player)
        {
            foreach (Terrain terrain in terrains)
            {
                if (terrain.match == null) continue;
                if (player.name == terrain.match.player1.name ||
                    player.name == terrain.match.player2.name)
                    return true;
            }

            return false;
        }

        public void updatePauses()
        {
            IEnumerable<Player> playerPlaying = players.Where(player => isPlaying(player));
            IEnumerable<Player> playerNotPlaying = players.Where(player => !isPlaying(player));
            List<int> poulePlaying = new List<int>();

            foreach (Player player in playerPlaying)
            {
                player.pause = 0;
                poulePlaying.Add(player.poule);
            }

            foreach (Player player in playerNotPlaying)
            {
                if (poulePlaying.Contains(player.poule))
                    player.pause += 1;
                else
                    player.pause += 3;
            }
        }

        public Match findNewMatch(int terrainID)
        {
            return matches.OrderByDescending(r => r.player1.pause + r.player2.pause).FirstOrDefault();
        }

        public Match newMatch(int terrainID)
        {
            eraseMatch(terrains[terrainID].match);

            Match match = findNewMatch(terrainID);
            terrains[terrainID].match = match;

            updatePauses();

            return match;
        }

        private void GetPlayers(string filePath)
        {
            // Declaration
            // -----------
            players = new List<Player>();
            int pouleID = 0;
            nbPoules = 0;

            // Get all lines from file
            string[] lines = File.ReadAllLines(filePath);

            // Get data from lines
            foreach (string line in lines)
            {
                // If line = "Poule ID" ->
                // lineParts[0] = Poule and lineParts[1] = ID;
                string[] lineParts = line.Split(' ');

                if (lineParts[0] == "Poule")
                {
                    pouleID = int.Parse(lineParts[1]);
                    nbPoules++;
                }
                else if (line != String.Empty)
                {
                    Player player = new Player(lineParts[0], pouleID);
                    players.Add(player);
                }
            }
        }

        public void GetMatches()
        {
            // Declaration
            matches = new List<Match>();
            terrains = new List<Terrain>();

            // For each poule
            for (int pouleID = 0; pouleID < nbPoules; pouleID++)
            {
                // Get all players in Poule
                IEnumerable<Player> poulePlayer = players.Where(r => r.poule == pouleID);

                // Initialize terrains
                if (pouleID < nbTerrains)
                {
                    Match match = new Match(poulePlayer.First(), poulePlayer.ElementAt(1));
                    Terrain terrain = new Terrain(match);
                    terrains.Add(terrain);
                }

                // Add all unique pair of players in matches
                foreach (Player p1 in poulePlayer)
                    foreach (Player p2 in poulePlayer)
                    {
                        if (p1.name != p2.name)
                        {
                            Match match = new Match(p1, p2);
                            Match invMatch = new Match(p2, p1);
                            if (!matches.Contains(match) && !matches.Contains(invMatch))
                                if (!matches.Any(m => m.isEqual(match)))
                                    matches.Add(match);
                        }
                    }
            }
        }

        private void WriteMatch(Form1 form, Match m, int terrainID)
        {
            form.newPlayerLabel(m.player1.name, 0);
            form.newPlayerLabel(m.player2.name, 1);
        }

        public Planning(Form1 form, string filepath, int nbTer)
        {
            // Get data
            nbTerrains = nbTer;
            GetPlayers(filepath);
            GetMatches();

            // Initialisation
            updatePauses();
            for (int i = 0; i < nbTerrains; i++)
                WriteMatch(form, terrains[i].match, i);

            // Completing
            int initialNbMatches = matches.Count;
            int matchesToPlay = initialNbMatches - nbTerrains;
            for (int i = 0; i < matchesToPlay; i++)
            {
                int r = i % nbTerrains;
                Match m = newMatch(r);
                WriteMatch(form, m, r);
            }



        }
    }
}
