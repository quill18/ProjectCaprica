using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

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

            GeneratePlanets();
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

            // The StarType might also influence the likelihood of number
            // of planets

            float planetChance = 0.50f;

            for (int i = 0; i < MAX_PLANETS; i++)
            {
                if(UnityEngine.Random.Range(0f, 1f) <= planetChance)
                {
                    // Make a planet!
                    Planet planet = new Planet();
                    planet.Name = GeneratePlanetName(i);

                    int size_max = (int)PlanetSize.COUNT;

                    planet.PlanetSize = (PlanetSize)Enum.GetValues(typeof(PlanetSize)).GetValue(UnityEngine.Random.Range(0, size_max));
                }
            }
        }

        string GeneratePlanetName(int pos)
        {
            // TODO: Make awesome
            return Name + " " + (pos + 1).ToString();
        }

        PlanetType GeneratePlanetType(int pos)
        {
            // Tweak this based on star type and galaxy settings
            float goldilocksRange = 0.5f;

            float distance = (float)pos / (float)MAX_PLANETS;
            float distanceSquared = distance*distance;

            float gasGiantWeight = Mathf.Lerp(0f, 1f, distanceSquared);
            float goldilocksWeight = Mathf.Lerp(1f, 0f, 2f * Mathf.Abs(goldilocksRange - distance ) );
            float asteroidWeight = 1.0f;

            // Cool suns should have goldilocks closer to the sun
            // Hot suns should have it further

            float allWeights = gasGiantWeight + goldilocksWeight + asteroidWeight;

            float r = UnityEngine.Random.Range(0, allWeights);

            if( r < gasGiantWeight )
            {
                //TODO
                return PlanetType.GasGiant;
            }
            r -= gasGiantWeight;

            if ( r < goldilocksWeight)
            {
                // TODO
                return PlanetType.Continental;
            }
            r -= goldilocksWeight;

            // If we get here, it's because we rolled in the asteroid weight
            return PlanetType.Asteroid;
        }
    }
}