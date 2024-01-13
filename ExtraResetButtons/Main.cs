using MelonLoader;
using System.Collections.Generic;
using UnityEngine;
using RUMBLE;
using RUMBLE.Players;
using RUMBLE.Players.Subsystems;
using TMPro;
using UnityEngine.InputSystem;
using RUMBLE.Interactions.InteractionBase;
using System;
using System.Security.AccessControl;
using UnityEngine.Events;
using RUMBLE.Environment;
using Photon.Pun;
using RUMBLE.MoveSystem;

namespace ExtraResetButtons
{
    public static class BuildInfo
    {
        public const string Name = "ExtraResetButtons"; // Name of the Mod.  (MUST BE SET)
        public const string Description = "a simple RUMBLE mod, adds more reset session buttons"; // Description for the Mod.  (Set as null if none)
        public const string Author = "elmish"; // Author of the Mod.  (MUST BE SET)
        public const string Company = null; // Company that made the Mod.  (Set as null if none)
        public const string Version = "1.0.1"; // Version of the Mod.  (MUST BE SET)
        public const string DownloadLink = null; // Download Link for the Mod.  (Set as null if none)
    }

    public class ExtraResetButtons : MelonMod
    {
        GameObject[] pools = new GameObject[5];

        private GameObject ResetSessionButton;
        private GameObject newResetSessionButton;

        private GameObject buttonDisplay;
        private GameObject buttonDisplayText;

        private GameObject originalButton;
        private GameObject gymButton1;
        private GameObject gymButton2;
        private GameObject keybindSwitcherButton;

        private GameObject regionText;
        private GameObject gymButtonText1;
        private GameObject gymButtonText2;
        private GameObject keybindSwitcherText1;
        private GameObject keybindSwitcherText2;

        InteractionButton button;
        RUMBLE.Environment.ParkInstance parkinstance;

        string[] poolPaths = new string[5];


        void PoolStructures()
        {
            try
            {
                for (int i = 0; i < pools.Length; i++)
                {
                    pools[i] = GameObject.Find(poolPaths[i]).gameObject;
                }
            }
            catch { }
        }
        public void DestroyStructures()
        {
            for (int i = 0; i < pools.Length; i++) // thanks butterlilly
            {
                for (int x = 0; x < pools[i].transform.childCount; x++)
                {
                    GameObject structure = pools[i].transform.GetChild(x).gameObject;
                    if (structure.activeSelf)
                    {
                        structure.GetComponent<Structure>().Kill(Vector3.zero, false, false, true);
                    }
                }
            }
        }
        private void SetupPark()
        {
            parkinstance = GameObject.Find("________________LOGIC__________________ /Park Instance").GetComponent<ParkInstance>();
            ResetSessionButton = GameObject.Find("________________LOGIC__________________ /Heinhouwser products/Parkboard (Park)/Primary Display/Park/Minigame Start button/InteractionButton");
            newResetSessionButton = UnityEngine.Object.Instantiate(ResetSessionButton);
            newResetSessionButton.transform.position = new Vector3(-12.62f, -4.86f, 6.39f);
            newResetSessionButton.transform.rotation = Quaternion.Euler(90, 125, 0);
            newResetSessionButton.transform.GetChild(0).gameObject.GetComponent<InteractionButton>().onPressed.AddListener(new System.Action(() =>
            {
                DestroyStructures();
                parkinstance.RPC_CleanScene();
            }));

            buttonDisplay = UnityEngine.Object.Instantiate(GameObject.Find("________________LOGIC__________________ /Park Toys/MatchCounter/Scoreboard/ResetScoreBoard"));
            buttonDisplay.transform.position = new Vector3(-12.738f, -4.99f, 6.221f);
            buttonDisplay.transform.rotation = Quaternion.Euler(90, 35, 0);

            buttonDisplayText = UnityEngine.Object.Instantiate(GameObject.Find("________________LOGIC__________________ /Heinhouwser products/Parkboard (Park)/Primary Display/Park/Minigame Start button/TextandIcons/NameCanvas"));
            buttonDisplayText.transform.position = new Vector3(-12.68f, -4.955f, 6.279f);
            buttonDisplayText.transform.rotation = Quaternion.Euler(0, 305, 0);
            buttonDisplayText.transform.localScale = Vector3.one * 0.7f;
            MelonLogger.Msg("successfully completed ExtraResetButtons Park setup");
        }
        private void SetupGym()
        {
            originalButton = GameObject.Find("------------TUTORIAL------------/Static tutorials/RUMBLE Starter Guide/Next Page Button/InteractionButton");
            gymButton1 = UnityEngine.Object.Instantiate(originalButton);
            gymButton1.transform.position = new Vector3(4.4542f, -2.0399f, -10.106f);
            gymButton1.transform.rotation = Quaternion.Euler(270, 350, 0);
            gymButton1.transform.name = "Howard Area Destroy structures button";
            gymButton1.transform.GetChild(0).gameObject.GetComponent<InteractionButton>().onPressed.AddListener(new System.Action(() =>
            {
                DestroyStructures();
            }));

            gymButton2 = UnityEngine.Object.Instantiate(originalButton);
            gymButton2.transform.position = new Vector3(-41.8807f, 4.6797f, 2.3603f);
            gymButton2.transform.rotation = Quaternion.Euler(90, 130, 0);
            gymButton2.transform.name = "Training Area Destroy structures button";
            gymButton2.transform.GetChild(0).gameObject.GetComponent<InteractionButton>().onPressed.AddListener(new System.Action(() =>
            {
                DestroyStructures();
            }));

            keybindSwitcherButton = UnityEngine.Object.Instantiate(originalButton); // to be used

            regionText = GameObject.Find("--------------LOGIC--------------/Heinhouser products/MatchConsole/RankRelaxControls/Texts/Title Text");
            gymButtonText1 = UnityEngine.Object.Instantiate(regionText);
            gymButtonText1.transform.position = new Vector3(4.4592f, -2.1949f, -10.1115f);
            gymButtonText1.transform.rotation = Quaternion.Euler(0, 350, 0);
            gymButtonText1.GetComponent<TextMeshPro>().text = "Destroy Structures";
            gymButtonText1.transform.name = "Howard Area Destroy structures text";

            gymButtonText2 = UnityEngine.Object.Instantiate(regionText);
            gymButtonText2.transform.position = new Vector3(-41.8807f, 4.5497f, 2.3603f);
            gymButtonText2.transform.rotation = Quaternion.Euler(0, 310, 0);
            gymButtonText2.GetComponent<TextMeshPro>().text = "Destroy Structures";
            gymButtonText2.transform.name = "Training Area Destroy structures text";


            MelonLogger.Msg("successfully completed ExtraResetButtons Gym setup");
        }

        public override void OnLateInitializeMelon() // again thanks butteredlilly
        {
            base.OnLateInitializeMelon();
            poolPaths[0] = "Game Instance/Pre-Initializable/PoolManager/Pool: Pillar (RUMBLE.MoveSystem.Structure)";
            poolPaths[1] = "Game Instance/Pre-Initializable/PoolManager/Pool: Wall (RUMBLE.MoveSystem.Structure)";
            poolPaths[2] = "Game Instance/Pre-Initializable/PoolManager/Pool: Disc (RUMBLE.MoveSystem.Structure)";
            poolPaths[3] = "Game Instance/Pre-Initializable/PoolManager/Pool: RockCube (RUMBLE.MoveSystem.Structure)";
            poolPaths[4] = "Game Instance/Pre-Initializable/PoolManager/Pool: Ball (RUMBLE.MoveSystem.Structure)";
        }

        public override void OnSceneWasLoaded(int buildindex, string sceneName)
        {
            if (sceneName != "" && sceneName != "Loader") { PoolStructures(); }
            if (sceneName == "Park") { SetupPark(); }
            else if (sceneName == "Gym") { SetupGym(); }
        }
    }
}