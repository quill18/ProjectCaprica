using UnityEngine;
using System.Collections;

namespace Caprica
{
    public class Building
    {
        // Represents a constructed building on a planet?
        //     Maybe also gets used in the list of building template?

        public Building( string Name, int RequiredProduction, int UnlockedByTechId, BuildingEndOfTurnFunction endOfTurnFunction)
        {
            this.Name = Name;
            this.RequiredProduction = RequiredProduction;
            this.UnlockedByTechId = UnlockedByTechId;
            this.endOfTurnFunction = endOfTurnFunction;
        }

        string Name;
        int RequiredProduction;
        int UnlockedByTechId = -1;

        public delegate void BuildingEndOfTurnFunction(Colony colony, int currentGameTurn, int builtGameTurn);
        event BuildingEndOfTurnFunction endOfTurnFunction;

        public void DoEndOfTurn(Colony colony, int currentGameTurn, int builtGameTurn)
        {
            endOfTurnFunction(colony, currentGameTurn, builtGameTurn);
        }
    }




    static public class SetupBuildings
    {
        static SetupBuildings ()
        {
            // This function will instead read a config file with building
            // parameters + maybe LUA code for end of turn logic?

            AllBuildings = new Building[]
            {
                new Building( "Barracks", 100, -1, (c, turn, built) => { Debug.Log("Barracks Turn Processing!"); } ),
            };

        }

        static public Building[] AllBuildings;
    }

}