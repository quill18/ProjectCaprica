using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Caprica
{
    public class StarSystemGraphic
    {
        // int?  string?  sprite? texture?  model
        // do we maintain animation data?
    }

    public class StarSystem
    {
        public StarSystem()
        {
            planets = new Planet[MAX_PLANETS];

        }

        public Vector3 Position;

        private const int MAX_PLANETS = 6;

        private Planet[] planets;


        const int MIN_STAR_TYPE = -2;    // Not pleased with this
        const int MAX_STAR_TYPE =  2;
        public int StarType { get; private set; }  // 0 = Yellow, positive = older, less rich, negative = younger, less hab

        public StarSystemGraphic StarSystemGraphic;

        public string Name;

        public Planet GetPlanet(int PlanetIndex)
        {
            return planets[PlanetIndex];
        }

        public void Generate( int starType = 0 /* Galactic age/richness info? Or maybe we get told what kind of star to generate?  Especially for player starting planets? */ )
        {
            this.StarType = starType;

            //GeneratePlanets();
        }

        public void Load( /* Some kind of file handle? */ )
        {

        }

        public void Save( /* Some kind of file handle? */ )
        {

        }

        public int GetStarTypeIndex()
        {
            // Weird hacky function to convert from -2...+2 range to a 0...4 range

            return StarType - MIN_STAR_TYPE;
        }

        private void GeneratePlanets()
        {
            // Generate 0 to Max planets, weighting planet class based on
            // StarType + distance from the Sun
        }
    }
}