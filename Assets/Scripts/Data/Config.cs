using UnityEngine;
using System.Collections;

namespace Caprica
{
    public static class Config
    {
        // Values are coded here for now, but the goal
        // will be to load in from a config file that is modable.

        public static int GetInt(string Parameter)
        {
            switch (Parameter)
            {
                case "PLANET_MAX_POPULATION_Tiny":
                    return 4;
                case "PLANET_MAX_POPULATION_Small":
                    return 6;
                case "PLANET_MAX_POPULATION_Medium":
                    return 10;
                case "PLANET_MAX_POPULATION_Large":
                    return 12;
                case "PLANET_MAX_POPULATION_Huge":
                    return 16;
                case "STAR_MAX_PLANETS":
                    return 6;
                case "STAR_ORBIT_DISTANCE":
                    return 1;
                default:
                    Debug.LogError("GetInt: No option for " + Parameter);
                    return 0;
            }
        }

        public static float GetFloat(string Parameter)
        {
            switch (Parameter)
            {
                case "STAR_ORBIT_DISTANCE":
                    return 1.0f;
                default:
                    Debug.LogError("GetFloat: No option for " + Parameter);
                    return 0;
            }
        }
    }
}