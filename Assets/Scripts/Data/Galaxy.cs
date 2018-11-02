using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Caprica
{
    public static class GalaxyConfig
    {
        // This gets filled out by some kind of "New Game" screen
        // and is used by the Generate function to tune the game parameters
        public static int NumPlayers = 8;
        public static int NumStars = 50;

        // Total width/height of the range of star positions in Unity world units
        public static int GalaxyWidth = 100;

        // Consider reading the defaults from a config file
    }

    public class Galaxy
    {
        public Galaxy()
        {
            StarSystems = new List<StarSystem>();
        }

        private List<StarSystem> StarSystems;

        public StarSystem GetStarSystem(int StarSystemId)
        {
            return StarSystems[StarSystemId];
        }

        public int GetNumStarSystems()
        {
            return StarSystems.Count;
        }

        public void Generate(  )
        {
            // First pass, just make some random stars for us.

            int galaxyWidth = GalaxyConfig.GalaxyWidth;

            for (int i = 0; i < GalaxyConfig.NumStars; i++)
            {
                StarSystem ss = new StarSystem();
                ss.Position = new Vector3(
                        Random.Range(-galaxyWidth / 2, galaxyWidth / 2),
                        Random.Range(-galaxyWidth / 2, galaxyWidth / 2),
                        0
                    );
                ss.Generate( /* Do we pass exactly what time of start system we want? */ );
                // Player starting stars are special
                // Do we want to vary star types based on distance from galactic center?

                StarSystems.Add(ss);
            }

            Debug.Log("Num Stars Generated: " + StarSystems.Count);
        }

        public void Load( /* Some kind of file handle? */ )
        {

        }

        public void Save( /* Some kind of file handle? */ )
        {

        }


    }

}