using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Caprica
{
    public class Colony
    {



        public Planet Planet;

        int population { get { return popFarmers + popWorkers + popScientists; } }
        int popFarmers;
        int popWorkers;
        int popScientists;

        int flatProduction; // Normally zero, unless you get automated factories
        int productionPerWorker; // PlanetRichness/2 + 1

        //List<Building> BuiltBuildings;
        List<int> BuiltBuildingIndexes;
        List<int> BuildingBuiltTurn;

        public int TotalProductionPerTurn()
        {
            return flatProduction + productionPerWorker * popWorkers;
        }

        public void DoEndOfTurn()
        {
            // for each built building, call their end of turn update and
            // pass the value of the turn number it was built on
        }

        public int MaxPopulation()
        {
            int p = Config.GetInt("PLANET_MAX_POPULATION_" + Planet.PlanetSize.ToString());

            // Is our species Subterreranian, or have some other bonus to pop cap?
            //    Could be from a tech too, for example MoO2's "City"
            //    Could be from a building, like Biospheres
            //    Could be from a planet's special trait

            return p;
        }


    }
}
