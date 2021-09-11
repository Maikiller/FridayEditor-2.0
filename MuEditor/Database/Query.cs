using MuEditor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuEditor.Database
{
    internal class Query
    {
        public string authUser =
            "SELECT COUNT(*) " +
            "FROM " +
            "accounts " +
            "WHERE " +
            "accounts.account = '" + User.account + "' " +
            "AND " +
            "accounts.password = '" + User.password + "'";

        public string loadAccounts =
            "SELECT accounts.account," +
            "(case when (account_data.vip_status = -1) THEN 'no' ELSE 'yes' END) AS `VIP Status` " +
            "FROM mu_online_login.accounts " +
            "INNER JOIN " +
            "mu_online_characters.account_data ON accounts.guid = account_data.account_id";

        public string loadAccountName =
            "SELECT " +
            "accounts.guid," +
            "accounts.account," +
            "accounts.email," +
            "accounts.register," +
            "account_data.credits," +
            "account_data.current_ip," +
            "accounts.type_account," +
            "account_data.vip_status," +
            "account_data.vip_duration " +
            "FROM mu_online_login.accounts " +
            "INNER JOIN " +
            "mu_online_characters.account_data " +
            "ON " +
            "accounts.guid = account_data.account_id " +
            "WHERE " +
            "accounts.account = '" + User.account + "'";

        public string updateAccount =
            "UPDATE " +
            "mu_online_login.accounts " +
            "SET " +
            "account = '" + User.account + "'," +
            "email = '" + User.email + "'," +
            "type_account = " + User.typeAccount + " " +
            "WHERE mu_online_login.accounts.guid = " + User.guid + ";" +
            "UPDATE mu_online_characters.account_data " +
            "SET " +
            "credits = " + User.credits + "," +
            "vip_status = " + User.vipStatus + "," +
            "vip_duration = " + User.vipDuration + " " +
            "WHERE " +
            "mu_online_characters.account_data.account_id = " + User.guid + ";";

        public string duplicateAccount =
            "SELECT account " +
            "FROM " +
            "accounts " +
            "WHERE " +
            "accounts.account = '" + User.account + "'";

        public string loadAllCharacter =
            "SELECT character_info.name " +
            "FROM " +
            "character_info";

        public string loadCharacterName =
            "SELECT " +
            "character_info.guid," +
            "character_info.authority," +
            "character_info.race," +
            "character_info.name," +
            "character_info.level," +
            "character_info.level_master," +
            "character_info.level_majestic," +
            "character_info.experience," +
            "character_info.experience_master," +
            "character_info.experience_majestic," +
            "character_info.points," +
            "character_info.points_master," +
            "character_info.points_majestic," +
            "character_info.strength," +
            "character_info.agility," +
            "character_info.vitality," +
            "character_info.energy," +
            "character_info.leadership," +
            "character_info.money," +
            "character_info.add_fruit_points," +
            "character_info.dec_fruit_points," +
            "character_info.admin_flags," +
            "character_info.goblin_points," +
            "character_info.create_date," +
            "character_info.online " +
            "FROM character_info " +
            "WHERE character_info.name = '" + Character.name + "'";

        public string updateCharacterName =
            "UPDATE " +
            "character_info " +
            "SET " +
            "authority = " + Character.authority + "," +
            "race = " + Character.race + "," +
            "level = " + Character.level + "," +
            "level_master = " + Character.level_master + "," +
            "level_majestic = " + Character.level_majestic + "," +
            "experience = " + Character.experience + "," +
            "experience_master = " + Character.experience_master + "," +
            "experience_majestic = " + Character.experience_majestic + "," +
            "points = " + Character.points + "," +
            "points_master = " + Character.points_master + "," +
            "points_majestic = " + Character.points_majestic + "," +
            "strength = " + Character.strenght + "," +
            "agility = " + Character.agility + "," +
            "vitality = " + Character.vitality + "," +
            "energy = " + Character.energy + "," +
            "leadership = " + Character.leadership + "," +
            "money = " + Character.zen + "," +
            "add_fruit_points = " + Character.add_fruit_points + "," +
            "dec_fruit_points = " + Character.dec_fruit_points + "," +
            "admin_flags = " + Character.admin_flags + "," +
            "goblin_points = " + Character.goblin_points + " " +
            "WHERE " +
            "name = '" + Character.name + "'";
    }
}