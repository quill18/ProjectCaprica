using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Caprica
{
    public class PlanetGraphic
    {
        
    }

    public enum PlanetType { Asteroid, GasGiant, Continental, Gaian, Oceanic, Barren, Radiated, Toxic, Desert, Arid, Tundra }

    public enum PlanetSize { Tiny, Small, Medium, Large, Huge, COUNT }

    public enum PlanetRichness { VeryPoor, Poor, Abundant, Rich, VeryRich }

    public class Planet
    {
        public PlanetGraphic PlanetGraphic;

        public string Name;

        public readonly int PlanetIndex;

        public PlanetType PlanetType;

        public PlanetSize PlanetSize;

        public PlanetRichness PlanetRichness;

        // Planet Traits might become a class that can apply their own logic?
        public enum PlanetTrait { GoldDeposit, ArtifactWorld, Natives }

        List<PlanetTrait> PlanetTraits;

        public Colony Colony;
    }
}