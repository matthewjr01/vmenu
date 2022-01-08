﻿using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CitizenFX.Core;
//using MySql.Data.MySqlClient;
using static CitizenFX.Core.Native.API;
using System.IO;
using MySql.Data.MySqlClient;

namespace vMenuShared
{
    public class PermissionsManager //MADE NON STATIC
    {
      

        public enum Permission
        {
            // Global
            #region global
            Everything,
            DontKickMe,
            DontBanMe,
            NoClip,
            Staff,
            #endregion

            // Online Players
            #region online players
            OPMenu,
            OPAll,
            OPTeleport,
            OPWaypoint,
            OPSpectate,
            OPIdentifiers,
            OPSummon,
            OPKill,
            OPKick,
            OPPermBan,
            OPTempBan,
            OPUnban,
            OPViewBannedPlayers,
            OPSeePrivateMessages,
            #endregion

            // Player Options
            #region player options
            POMenu,
            POAll,
            POGod,
            POInvisible,
            POFastRun,
            POFastSwim,
            POSuperjump,
            PONoRagdoll,
            PONeverWanted,
            POSetWanted,
            POIgnored,
            POStayInVehicle,
            POMaxHealth,
            POMaxArmor,
            POCleanPlayer,
            PODryPlayer,
            POWetPlayer,
            POVehicleAutoPilotMenu,
            POFreeze,
            POScenarios,
            POUnlimitedStamina,
            #endregion

            // Vehicle Options
            #region vehicle options
            VOMenu,
            VOAll,
            VOGod,
            VOKeepClean,
            VORepair,
            VOWash,
            VOEngine,
            VOBikeSeatbelt,
            VOSpeedLimiter,
            VOChangePlate,
            VOMod,
            VOColors,
            VOLiveries,
            VOComponents,
            VODoors,
            VOWindows,
            VOFreeze,
            VOInvisible,
            VOTorqueMultiplier,
            VOPowerMultiplier,
            VOFlip,
            VOAlarm,
            VOCycleSeats,
            VOEngineAlwaysOn,
            VONoSiren,
            VONoHelmet,
            VOLights,
            VOFixOrDestroyTires,
            VODelete,
            VOUnderglow,
            VOFlashHighbeamsOnHonk,
            VODisableTurbulence,
            VOInfiniteFuel,
            VOFlares,
            VOPlaneBombs,
            #endregion

            // Vehicle Spawner
            #region vehicle spawner
            VSMenu,
            VSAll,
            VSDisableReplacePrevious,
            VSSpawnByName,
            VSAddon,
            VSCompacts,
            VSSedans,
            VSSUVs,
            VSCoupes,
            VSMuscle,
            VSSportsClassic,
            VSSports,
            VSSuper,
            VSMotorcycles,
            VSOffRoad,
            VSIndustrial,
            VSUtility,
            VSVans,
            VSCycles,
            VSBoats,
            VSHelicopters,
            VSPlanes,
            VSService,
            VSEmergency,
            VSMilitary,
            VSCommercial,
            VSTrains,
            VSOpenWheel,
            #endregion

            // Saved Vehicles
            #region saved vehicles
            SVMenu,
            SVAll,
            SVSpawn,
            #endregion

            // Personal Vehicle
            #region personal vehicle
            PVMenu,
            PVAll,
            PVToggleEngine,
            PVToggleLights,
            PVKickPassengers,
            PVLockDoors,
            PVDoors,
            PVSoundHorn,
            PVToggleAlarm,
            PVAddBlip,
            PVExclusiveDriver,
            #endregion

            // Player Appearance
            #region player appearance
            PAMenu,
            PAAll,
            PACustomize,
            PASpawnSaved,
            PASpawnNew,
            PAAddonPeds,
            #endregion

            // Time Options
            #region time options
            TOMenu,
            TOAll,
            TOFreezeTime,
            TOSetTime,
            #endregion

            // Weather Options
            #region weather options
            WOMenu,
            WOAll,
            WODynamic,
            WOBlackout,
            WOSetWeather,
            WORemoveClouds,
            WORandomizeClouds,
            #endregion

            // Weapon Options
            #region weapon options
            WPMenu,
            WPAll,
            WPGetAll,
            WPRemoveAll,
            WPUnlimitedAmmo,
            WPNoReload,
            WPSpawn,
            WPSpawnByName,
            WPSetAllAmmo,
            #endregion

            //Weapons Permissions
            #region weapon specific permissions
            WPAPPistol,
            WPAdvancedRifle,
            WPAssaultRifle,
            WPAssaultRifleMk2,
            WPAssaultSMG,
            WPAssaultShotgun,
            WPBZGas,
            WPBall,
            WPBat,
            WPBattleAxe,
            WPBottle,
            WPBullpupRifle,
            WPBullpupRifleMk2,
            WPBullpupShotgun,
            WPCarbineRifle,
            WPCarbineRifleMk2,
            WPCombatMG,
            WPCombatMGMk2,
            WPCombatPDW,
            WPCombatPistol,
            WPCompactGrenadeLauncher,
            WPCompactRifle,
            WPCrowbar,
            WPDagger,
            WPDoubleAction,
            WPDoubleBarrelShotgun,
            WPFireExtinguisher,
            WPFirework,
            WPFlare,
            WPFlareGun,
            WPFlashlight,
            WPGolfClub,
            WPGrenade,
            WPGrenadeLauncher,
            WPGrenadeLauncherSmoke,
            WPGusenberg,
            WPHammer,
            WPHatchet,
            WPHeavyPistol,
            WPHeavyShotgun,
            WPHeavySniper,
            WPHeavySniperMk2,
            WPHomingLauncher,
            WPKnife,
            WPKnuckleDuster,
            WPMG,
            WPMachete,
            WPMachinePistol,
            WPMarksmanPistol,
            WPMarksmanRifle,
            WPMarksmanRifleMk2,
            WPMicroSMG,
            WPMiniSMG,
            WPMinigun,
            WPMolotov,
            WPMusket,
            WPNightVision,
            WPNightstick,
            WPParachute,
            WPPetrolCan,
            WPPipeBomb,
            WPPistol,
            WPPistol50,
            WPPistolMk2,
            WPPoolCue,
            WPProximityMine,
            WPPumpShotgun,
            WPPumpShotgunMk2,
            WPRPG,
            WPRailgun,
            WPRevolver,
            WPRevolverMk2,
            WPSMG,
            WPSMGMk2,
            WPSNSPistol,
            WPSNSPistolMk2,
            WPSawnOffShotgun,
            WPSmokeGrenade,
            WPSniperRifle,
            WPSnowball,
            WPSpecialCarbine,
            WPSpecialCarbineMk2,
            WPStickyBomb,
            WPStunGun,
            WPSweeperShotgun,
            WPSwitchBlade,
            WPUnarmed,
            WPVintagePistol,
            WPWrench,
            WPPlasmaPistol, // xmas 2018 dlc (1604)
            WPPlasmaCarbine, // xmas 2018 dlc (1604)
            WPPlasmaMinigun, // xmas 2018 dlc (1604)
            WPStoneHatchet, // xmas 2018 dlc (1604)
            WPCeramicPistol, // xmas 2019 dlc (1868)
            WPNavyRevolver, // xmas 2019 dlc (1868)
            //WPHazardCan, // xmas 2019 dlc (1868) (Does not have label text)
            WPPericoPistol, // xmas 2020 dlc (2189)
            WPMilitaryRifle, // xmas 2020 dlc (2189)
            WPCombatShotgun, // xmas 2020 dlc (2189)
            #endregion

            // Weapon Loadouts Menu
            #region weapon loadouts
            WLMenu,
            WLAll,
            WLEquip,
            WLEquipOnRespawn,
            #endregion

            // Misc Settings
            #region misc settings
            MSAll,
            MSClearArea,
            MSTeleportToWp,
            MSTeleportToCoord,
            MSShowCoordinates,
            MSShowLocation,
            MSJoinQuitNotifs,
            MSDeathNotifs,
            MSNightVision,
            MSThermalVision,
            MSLocationBlips,
            MSPlayerBlips,
            MSOverheadNames,
            MSTeleportLocations,
            MSTeleportSaveLocation,
            MSConnectionMenu,
            MSRestoreAppearance,
            MSRestoreWeapons,
            MSDriftMode,
            MSEntitySpawner,
            #endregion

            // Voice Chat
            #region voice chat
            VCMenu,
            VCAll,
            VCEnable,
            VCShowSpeaker,
            VCStaffChannel,
            #endregion
        };

        public static Dictionary<Permission, bool> Permissions { get; private set; } = new Dictionary<Permission, bool>();
        public static bool ArePermissionsSetup { get; set; } = false;


#if SERVER
        /// <summary>
        /// Public function to check if a permission is allowed.
        /// </summary>
        /// <param name="permission"></param>
        /// <param name="source"></param>
        /// <param name="checkAnyway">if true, then the permissions will be checked even if they aren't setup yet.</param>
        /// <returns></returns>
        public static bool IsAllowed(Permission permission, Player source, int Plevel, bool checkAnyway = false) => IsAllowedServer(permission, source, Plevel);
#endif

#if CLIENT
        /// <summary>
        /// Public function to check if a permission is allowed.
        /// </summary>
        /// <param name="permission"></param>
        /// <param name="checkAnyway">if true, then the permissions will be checked even if they aren't setup yet.</param>
        /// <returns></returns>
        public static bool IsAllowed(Permission permission, bool checkAnyway = false) => IsAllowedClient(permission, checkAnyway);

        private static Dictionary<Permission, bool> allowedPerms = new Dictionary<Permission, bool>();
        /// <summary>
        /// Private function that handles client side permission requests.
        /// </summary>
        /// <param name="permission"></param>
        /// <returns></returns>
        private static bool IsAllowedClient(Permission permission, bool checkAnyway)
        {
            if (ArePermissionsSetup || checkAnyway)
            {
                bool staffPermissionAllowed = (
                    Permissions.ContainsKey(Permission.Staff) && Permissions[Permission.Staff]
                ) || (
                    Permissions.ContainsKey(Permission.Everything) && Permissions[Permission.Everything]
                );
                // Return false immediately if the staff only convar is set and the user is not a staff member.
                if (ConfigManager.GetSettingsBool(ConfigManager.Setting.vmenu_menu_staff_only) && !staffPermissionAllowed)
                {
                    return false;
                }

                if (allowedPerms.ContainsKey(permission) && allowedPerms[permission])
                    return true;
                else if (!allowedPerms.ContainsKey(permission))
                    allowedPerms[permission] = false;

                // Get a list of all permissions that are (parents) of the current permission, including the current permission.
                List<Permission> permissionsToCheck = GetPermissionAndParentPermissions(permission);

                // Check if any of those permissions is allowed, if so, return true.
                if (permissionsToCheck.Any(p => Permissions.ContainsKey(p) && Permissions[p]))
                {
                    allowedPerms[permission] = true;
                    return true;
                }
            }
            return false;
        }
#endif
#if SERVER
        /// <summary>
        /// Checks if the player is allowed that specific permission.
        /// </summary>
        /// <param name="permission"></param>
        /// <param name="source"></param>
        /// <returns></returns>
        private static bool IsAllowedServer(Permission permission, Player source, int Plevel)
        {
            string MysqlConnectionURL = "server=151.106.97.153;uid=u433204257_allison;pwd=Booboo3903@;database=u433204257_vmenu";
            //public static MySqlConnection conn = new MySqlConnection(MysqlConnectionURL);
            string VUSER_DB = "vuser";
            string VPERM_DB = "vperm";
            int UserLevel = 0;
            bool Perm_Allowed = false;
            int REBUILD_DB = 1;
            string Get_Level_QURY = "SELECT PL FROM vuser WHERE Handle = " + source.Handle;
            int PermLevel = 0;
           
            if (source == null)
            {
                return false;
            }
            //PERM IS
            //if (IsPlayerAceAllowed(source.Handle, GetAceName(permission)))
            // {
            //  return true;
            // }
            DBCHECKUL(permission);
            return true;

            async Task DBCHECkUSER()
            {
                Debug.Write("Getting DB CONNECTION");
                try
                {
                    MySqlConnection conn = new MySqlConnection(MysqlConnectionURL);
                    Debug.Write("CONNECTED TO DB");
                    string Statement = "SELECT COUNT(0) FROM vuser WHERE Identifier = " + source.Identifiers;
                    MySqlCommand command = new MySqlCommand(Statement, conn);
                    long count = (long)command.ExecuteScalar();
                    if (count >= 1)
                    {
                        return;
                    }
                    else
                    {
                        DBADDUSER();
                        return;
                    }
                    conn.Close();
                }
                catch (Exception ex)
                {
                    Debug.Write("DID NOT CONNECT TO DB ERROR::  " + ex);
                }
                return;
            }

            async Task DBADDUSER()
            {
                Debug.Write("Getting DB CONNECTION");
                try
                {

                    MySqlConnection conn = new MySqlConnection(MysqlConnectionURL);
                    Debug.Write("CONNECTED TO DB");
                    string Statement = "INSERT INTO vuser (Identifier, PL) VALUES (@ID, '0')";
                    MySqlCommand command = new MySqlCommand(Statement, conn);
                    command.Parameters.AddWithValue("@ID", source.Identifiers.ToString());
                    Debug.Write("ADDED PLAYER TO DB: " + source.Identifiers.ToString());
                    long t = (long) command.ExecuteScalar();
                    conn.Close();

                }
                catch (Exception ex)
                {
                    Debug.Write("DID NOT CONNECT TO DB ERROR::  " + ex);
                }
                return;
            }
            async Task DBCHECKUL(Permission perm)
            {
                Debug.Write("Getting DB CONNECTION");
                try
                {
                    MySqlConnection conn = new MySqlConnection(MysqlConnectionURL);
                    Debug.Write("CONNECTED TO DB");
                    conn.Open();
                    string Statement = "SELECT PL FROM " + VUSER_DB + " WHERE Identifier = " + source.Identifiers;
                    MySqlCommand command = new MySqlCommand(Statement, conn);
                    int Level = (int)command.ExecuteScalar();
                    UserLevel += Level;
                    conn.Close();
                }
                catch (Exception ex)
                {
                    Debug.Write("DID NOT CONNECT TO DB ERROR::  " + ex);
                }
                return;
            }

            async Task DBCHECkPERM(int LPermLevel, Permission perm)
            {
                Debug.Write("Getting DB CONNECTION");
                try
                {
                    MySqlConnection conn = new MySqlConnection(MysqlConnectionURL);
                    Debug.Write("CONNECTED TO DB");
                    string Statement = "SELECT COUNT(0) FROM " + VPERM_DB + " WHERE perm = " + perm.ToString() + " AND " + "PermLevel = " + LPermLevel;
                    MySqlCommand command = new MySqlCommand(Statement, conn);
                    long isPerm = (long)command.ExecuteScalar();
                    if (isPerm >= 1)
                    {
                        Perm_Allowed = true;
                    }
                    conn.Close();
                }
                catch (Exception ex)
                {
                    Debug.Write("DID NOT CONNECT TO DB ERROR::  " + ex);
                }
                return;
            }

            
        }

        private static async Task DBADDPERM(string Perm)
        {
            string MysqlConnectionURL = "server=151.106.97.153;uid=u433204257_allison;pwd=Booboo3903@;database=u433204257_vmenu";
            Debug.Write("Getting DB CONNECTION");
            MySqlConnection conn = new MySqlConnection(MysqlConnectionURL);
            try
            {
                        await conn.OpenAsync();
                        Debug.Write("CONNECTED TO DB");
                        string Statement = "INSERT INTO vperm (perm) VALUES (@perm)";
                        MySqlCommand command = new MySqlCommand(Statement, conn);
                        command.Parameters.AddWithValue("@perm", Perm);
                        Debug.Write("ADDED PERM TO DB: " + Perm);
                //command.Transaction.Commit(command);
                        conn.Close();
            }
            catch (Exception ex)
            {
                Debug.Write("DID NOT CONNECT TO DB ERROR::  " + ex);

            }
            return;
        }




#endif

        private static Dictionary<Permission, List<Permission>> parentPermissions = new Dictionary<Permission, List<Permission>>();

        /// <summary>
        /// Gets the current permission and all parent permissions.
        /// </summary>
        /// <param name="permission"></param>
        /// <returns></returns>
        public static List<Permission> GetPermissionAndParentPermissions(Permission permission)
        {
            if (parentPermissions.ContainsKey(permission))
            {
                return parentPermissions[permission];
            }
            else
            {
                var list = new List<Permission>() { Permission.Everything, permission };
                string permStr = permission.ToString();

                // if the first 2 characters are both uppercase
                if (permStr.Substring(0, 2).ToUpper() == permStr.Substring(0, 2))
                {
                    if (!(permStr.Substring(2) == "All" || permStr.Substring(2) == "Menu"))
                    {
                        list.AddRange(Enum.GetValues(typeof(Permission)).Cast<Permission>().Where(a => a.ToString() == permStr.Substring(0, 2) + "All"));
                    }
                }
                //else // it's one of the .Everything, .DontKickMe, DontBanMe, NoClip, Staff, etc perms that are not menu specific.
                //{
                //    // do nothing
                //}
                parentPermissions[permission] = list;
                return list;
            }
        }

#if SERVER
        /// <summary>
        /// Sets the permissions for a specific player (checks server side, sends event to client side).
        /// </summary>
        /// <param name="player"></param>
        public static void SetPermissionsForPlayer([FromSource]Player player, int Plevel)
        {
            if (player == null)
            {
                return;
            }

            Dictionary<Permission, bool> perms = new Dictionary<Permission, bool>();

            // If enabled in the permissions.cfg (disabled by default) then this will give me (only me) the option to trigger some debug commands and 
            // try out menu options. This only works if I'm in-game on your server, and you have enabled server debugging mode, this way I will never
            // be able to do something without you actually allowing it.
            

            if (!ConfigManager.GetSettingsBool(ConfigManager.Setting.vmenu_use_permissions))
            {
                foreach (var p in Enum.GetValues(typeof(Permission)))
                {
                    Permission permission = (Permission)p;
                    switch (permission)
                    {
                        // don't allow any of the following permissions if perms are ignored.
                        case Permission.Everything:
                        case Permission.OPAll:
                        case Permission.OPKick:
                        case Permission.OPKill:
                        case Permission.OPPermBan:
                        case Permission.OPTempBan:
                        case Permission.OPUnban:
                        case Permission.OPIdentifiers:
                        case Permission.OPViewBannedPlayers:
                            break;
                        // do allow the rest
                        default:
                            perms.Add(permission, true);
                            break;
                    }
                }
            }
            else
            {
                // Loop through all permissions and check if they're allowed.
                foreach (var p in Enum.GetValues(typeof(Permission)))
                {
                    Permission permission = (Permission)p;
                    if (!perms.ContainsKey(permission))
                        
                        perms.Add(permission, IsAllowed(permission, player, Plevel)); // triggers IsAllowedServer
                }
            }

            // Send the permissions to the client.
            player.TriggerEvent("vMenu:SetPermissions", Newtonsoft.Json.JsonConvert.SerializeObject(perms));

            // Also tell the client to do the addons setup.
            player.TriggerEvent("vMenu:SetAddons");
            player.TriggerEvent("vMenu:UpdateTeleportLocations", Newtonsoft.Json.JsonConvert.SerializeObject(ConfigManager.GetTeleportLocationsData()));
        }
#endif
#if CLIENT
        /// <summary>
        /// Sets the permission (client side event handler).
        /// </summary>
        /// <param name="permissions"></param>
        public static void SetPermissions(string permissions)
        {
            Permissions = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<Permission, bool>>(permissions);
            // if debug logging.
            if (GetResourceMetadata(GetCurrentResourceName(), "client_debug_mode", 0) == "true")
            {
                Debug.WriteLine("[vMenu] [Permissions] " + Newtonsoft.Json.JsonConvert.SerializeObject(Permissions, Newtonsoft.Json.Formatting.None));
            }
        }
#endif
#if SERVER
        /// <summary>
        /// Gets the full permission ace name for the specific <see cref="Permission"/> enum.
        /// </summary>
        /// <param name="permission"></param>
        /// <returns></returns>
        private static string GetAceName(Permission permission)
        {
            string name = permission.ToString();

            string prefix = "vMenu.";

            switch (name.Substring(0, 2))
            {
                case "OP":
                    prefix += "OnlinePlayers";
                    break;
                case "PO":
                    prefix += "PlayerOptions";
                    break;
                case "VO":
                    prefix += "VehicleOptions";
                    break;
                case "VS":
                    prefix += "VehicleSpawner";
                    break;
                case "SV":
                    prefix += "SavedVehicles";
                    break;
                case "PV":
                    prefix += "PersonalVehicle";
                    break;
                case "PA":
                    prefix += "PlayerAppearance";
                    break;
                case "TO":
                    prefix += "TimeOptions";
                    break;
                case "WO":
                    prefix += "WeatherOptions";
                    break;
                case "WP":
                    prefix += "WeaponOptions";
                    break;
                case "WL":
                    prefix += "WeaponLoadouts";
                    break;
                case "MS":
                    prefix += "MiscSettings";
                    break;
                case "VC":
                    prefix += "VoiceChat";
                    break;
                default:
                    return prefix + name;
            }

            return prefix + "." + name.Substring(2);
        }
#endif
    }
}
