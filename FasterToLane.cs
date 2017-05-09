using System;

using EloBuddy.SDK;
using EloBuddy.SDK.Menu;
using SharpDX;
using EloBuddy;
using EloBuddy.SDK.Menu.Values;
using EloBuddy.SDK.Events;

namespace FasterToLane
{
    class Program
    {
        private static void Main(string[] args)
        {
            if (Game.MapId != GameMapId.SummonersRift) return;
            Loading.OnLoadingComplete += Loading_OnLoadingComplete;
            
        }
        public static Menu MenuFTL;
        private static int FountainMove;

        public static void Loading_OnLoadingComplete(EventArgs args)
        {
             
             MenuFTL = MainMenu.AddMenu("FasterToLane", "FasterToLane");
            MenuFTL.AddGroupLabel("Faster To Lane :");
            if (Game.MapId == GameMapId.SummonersRift)
            {
                MenuFTL.Add("AutoMoveFountainMovePos", new CheckBox("Auto Move Best Spot in Fountain"));
                MenuFTL.Add("FountainMovePos", new ComboBox("Player Lane", new[] { "Mid", "Top", "Bot" }, 1));
            }
            Game.OnUpdate += Game_OnUpdate;
            FasterToLane();
        }

 

        private static void Game_OnUpdate(EventArgs args)
        {
            FasterToLane();
        }

        public static void FasterToLane()
        {
            if (ObjectManager.Player.IsInFountainRange() && Core.GameTickCount - FountainMove >= 20000)
            {
                if (MenuFTL["AutoMoveFountainMovePos"].Cast<CheckBox>().CurrentValue)
                {
                    if (ObjectManager.Player.Team == GameObjectTeam.Order)
                    {
                        switch (MenuFTL["FountainMovePos"].Cast<ComboBox>().CurrentValue)
                        {
                            
                            case 0:
                                {
                                    Player.IssueOrder(GameObjectOrder.MoveTo, new Vector3(834.00f, 1300.00f, 105.60f));
                                    FountainMove = Core.GameTickCount;
                                    break;
                                }
                            case 1:
                                {
                                    Player.IssueOrder(GameObjectOrder.MoveTo, new Vector3(526.00f, 1352.00f, 103.02f));
                                    FountainMove = Core.GameTickCount;
                                    break;
                                }
                            case 2:
                                {
                                    Player.IssueOrder(GameObjectOrder.MoveTo, new Vector3(1370.00f, 538.00f, 99.85f));
                                    FountainMove = Core.GameTickCount;
                                    break;
                                }

                        }
                    }

                    if (ObjectManager.Player.Team == GameObjectTeam.Chaos)
                    {
                        switch (MenuFTL["FountainMovePos"].Cast<ComboBox>().CurrentValue)
                        {
                        
                            case 0:
                                {
                                    Player.IssueOrder(GameObjectOrder.MoveTo, new Vector3(13886.00f, 13602.00f, 119.23f));
                                    FountainMove = Core.GameTickCount;
                                    break;
                                }
                            case 1:
                                {
                                    Player.IssueOrder(GameObjectOrder.MoveTo, new Vector3(13408.00f, 14294.00f, 126.02f));
                                    FountainMove = Core.GameTickCount;
                                    break;
                                }
                            case 2:
                                {
                                    Player.IssueOrder(GameObjectOrder.MoveTo, new Vector3(14172.00f, 13384.00f, 91.65f));
                                    FountainMove = Core.GameTickCount;
                                    break;
                                }
                        }
                    }
                }
            }
        }
    }
}