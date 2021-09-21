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
            "accounts.account = '" + User.accountAuth + "' " +
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

        public string loadShopTemplate =
            "SELECT " +
            "shop_template.guid," +
            "shop_template.name as `Shop Name`" +
            "FROM " +
            "shop_template";

        public string loadMonsterTemplate =
            "SELECT " +
            "monster_template.model," +
            "monster_template.name as `Models Name`" +
            "FROM " +
            "monster_template";

        public string loadShopName =
            "SELECT " +
            "shop_template.guid," +
            "monster.spawn_delay," +
            "monster.spawn_distance," +
            "monster.respawn_time_min," +
            "monster.respawn_time_max," +
            "monster.respawn_id," +
            "monster.move_distance," +
            "monster.x1," +
            "monster.y1," +
            "monster.x2," +
            "monster.y2," +
            "monster.elemental_attribute," +
            "monster.direction," +
            "shop_template.pk_text," +
            "monster.disabled," +
            "world_template.name " +
            "AS " +
            "World," +
            "monster_template.name," +
            "shop_template.max_pk_level," +
            "monster.server " +
            "FROM " +
            "shop_template " +
            "INNER JOIN " +
            "monster " +
            "ON " +
            "shop_template.name = monster.npc_function " +
            "INNER JOIN " +
            "world_template " +
            "ON " +
            "monster.world = world_template.entry " +
            "INNER JOIN " +
            "monster_template " +
            "ON " +
            "monster.id = monster_template.model " +
            "WHERE " +
            "shop_template.name = '" + Shop.shopName + "'";

        public string saveModelsFavorite =
            "INSERT INTO " +
            "favorite_models " +
            "(guid, models) VALUES (" + Favorite.AccountGUID + ", " + Favorite.Models + ")";

        public string duplicateFavorite =
            "SELECT " +
            "favorite_models.models " +
            "FROM " +
            "favorite_models " +
            "WHERE " +
            "favorite_models.models = " + Favorite.Models + "";

        public string selectAccountAuth =
            "SELECT " +
            "accounts.guid " +
            "FROM accounts " +
            "WHERE " +
            "accounts.account = '" + User.accountAuth + "'";

        public string loadFavorite =
            "SELECT monster_template.name as `Favorite`,favorite_models.models " +
            "FROM " +
            "mu_editor_config.favorite_models " +
            "INNER JOIN " +
            "mu_game.monster_template " +
            "ON " +
            "favorite_models.models = monster_template.model " +
            "WHERE " +
            "favorite_models.guid = " + Favorite.AccountGUID + "";

        public string loadWorldName =
            "SELECT world_template.name " +
            "FROM " +
            "world_template";

        public string saveShop =
            "INSERT INTO shop_template (name, max_pk_level, pk_text, guid, flag, type, max_buy_count, max_buy_type) " +
            "VALUES " +
            "('" + Shop.shopName + "', " + Shop.pkLevel + ", '" + Shop.pkText + "', " + Shop.shopID + ", 0, 0, 0, 0); " +
            "INSERT INTO monster (server, guid, id, world, x1, y1, x2, y2, direction, spawn_delay, spawn_distance, respawn_time_min, respawn_time_max, respawn_id, move_distance, npc_function, elemental_attribute, disabled) " +
            "VALUES (" + Shop.server + ", " + Shop.monsterID + ", " + Shop.modelsID + ", " + Shop.worldID + ", " + Shop.x1 + ", " + Shop.y1 + ", " + Shop.x2 + ", " + Shop.y2 + ", " + Shop.direction + ", " + Shop.spawnDelay + ", " + Shop.spawnDistance + ", " + Shop.spawnTimeMin + ", " + Shop.spawnTimeMax + ", " + Shop.spawnId + ", " + Shop.moveDistance + ", '" + Shop.shopName + "', " + Shop.elementalAtt + ", " + Shop.disable + ")";

        public string loadServerCodeList =
            "SELECT " +
            "server_list.server " +
            "FROM " +
            "server_list";

        public string getWorldEntry =
            "SELECT " +
            "world_template.entry," +
            "world_template.name " +
            "FROM " +
            "world_template " +
            "WHERE " +
            "world_template.name = '" + Shop.worldName + "'";

        public string getLastGuidMonster =
            "SELECT MAX(guid) FROM monster";

        public string getLastGuidShop =
            "SELECT MAX(guid) FROM shop_template";

        public string getShopID =
            "SELECT " +
            "shop_template.guid " +
            "FROM " +
            "shop_template " +
            "WHERE " +
            "shop_template.name = '" + Shop.shopName + "'";

        public string getMonsterID =
            "SELECT monster.guid " +
            "FROM " +
            "monster " +
            "WHERE " +
            "monster.npc_function = '" + Shop.shopName + "'";

        public string deleteShop =
            "DELETE " +
            "FROM " +
            "monster " +
            "WHERE " +
            "guid = " + Shop.monsterID + "; " +
            "DELETE " +
            "FROM " +
            "shop_template " +
            "WHERE " +
            "guid = " + Shop.guid + ";";

        public string updateShop =
            "UPDATE " +
            "shop_template " +
            "SET " +
            "name = '" + Shop.shopName + "'," +
            "max_pk_level = " + Shop.pkLevel + "," +
            "pk_text = '" + Shop.pkText + "' " +
            "WHERE " +
            "guid = " + Shop.shopID + ";  " +
            "UPDATE " +
            "monster " +
            "SET " +
            "server = " + Shop.server + "," +
            "id = " + Shop.modelsID + "," +
            "world = " + Shop.worldID + "," +
            "x1 = " + Shop.x1 + "," +
            "y1 = " + Shop.y1 + "," +
            "x2 = " + Shop.x2 + "," +
            "y2 = " + Shop.y2 + "," +
            "direction = " + Shop.direction + "," +
            "spawn_delay = " + Shop.spawnDelay + "," +
            "spawn_distance = " + Shop.spawnDistance + "," +
            "respawn_time_min = " + Shop.spawnTimeMin + "," +
            "respawn_time_max = " + Shop.spawnTimeMax + "," +
            "respawn_id = " + Shop.spawnId + "," +
            "move_distance = " + Shop.moveDistance + "," +
            "npc_function = '" + Shop.shopName + "'," +
            "elemental_attribute = " + Shop.elementalAtt + "," +
            "disabled = " + Shop.disable + " " +
            "WHERE " +
            "guid = " + Shop.monsterID + ";";

        public string loadItemsShop =
            "SELECT " +
            "shop_items.type," +
            "shop_items.guid," +
            "item_template.name " +
            "FROM shop_items " +
            "INNER JOIN " +
            "item_template " +
            "ON " +
            "shop_items.type = item_template.i_type " +
            "AND " +
            "shop_items.`index` = item_template.i_index " +
            "INNER JOIN " +
            "shop_template " +
            "ON " +
            "shop_items.shop = shop_template.guid " +
            "WHERE " +
            "shop_template.guid = " + Shop.guid + "";

        public string loadItemCategory =
           "SELECT " +
           "item_template.i_index," +
           "item_template.i_type," +
           "item_template.name " +
           "FROM " +
           "item_template " +
           "WHERE " +
           "item_template.i_type = " + Item.typeItemCombo + "";

        public string loadItem =
            "SELECT " +
            "item_template.name," +
            "shop_items.level," +
            "shop_items.durability," +
            "shop_items.skill," +
            "shop_items.luck," +
            "shop_items.`option`," +
            "shop_items.excellent," +
            "shop_items.ancient," +
            "shop_items.socket_1," +
            "shop_items.socket_2," +
            "shop_items.socket_3," +
            "shop_items.socket_4," +
            "shop_items.socket_5," +
            "shop_items.price," +
            "shop_items.id " +
            "FROM shop_items " +
            "INNER JOIN " +
            "item_template " +
            "ON " +
            "shop_items.`index` = item_template.i_index " +
            "AND " +
            "shop_items.type = item_template.i_type " +
            "INNER JOIN " +
            "shop_template " +
            "ON " +
            "shop_items.shop = shop_template.guid " +
            "WHERE " +
            "shop_items.guid = " + Item.itemGUID + "";

        public string additemToNPC =
            "INSERT INTO shop_items (shop, type, `index`, level, durability, skill, luck, `option`, excellent, ancient, socket_1, socket_2, socket_3, socket_4, socket_5, price, id)" +
            " VALUES(" + Shop.guid + ", " + Item.typeItemSelect + ", " + Item.indexItemSelect + ", " + Item.level + ", " + Item.durability + ", " + Item.skill + ", " + Item.luck + ", " + Item.option + ", " + Item.excellent + ", " + Item.ancient + ", " + Item.socket_1 + ", " + Item.socket_2 + ", " + Item.socket_3 + ", " + Item.socket_4 + ", " + Item.socket_5 + ", " + Item.price + ", " + Item.id + ")";

        public string updateItemToNPC =
            "UPDATE " +
            "shop_items " +
            "SET " +
            "level = " + Item.level + "," +
            "durability = " + Item.durability + "," +
            "skill = " + Item.skill + "," +
            "luck = " + Item.luck + "," +
            "`option` = " + Item.option + "," +
            "excellent = " + Item.excellent + "," +
            "ancient = " + Item.ancient + "," +
            "socket_1 = " + Item.socket_1 + "," +
            "socket_2 = " + Item.socket_2 + "," +
            "socket_3 = " + Item.socket_3 + "," +
            "socket_4 = " + Item.socket_4 + "," +
            "socket_5 = " + Item.socket_5 + "," +
            "price = " + Item.price + "," +
            "id = " + Item.id + " " +
            "WHERE " +
            "guid = " + Item.itemGUID + "";

        public string deleteItemToNPC =
            "DELETE " +
            "FROM " +
            "shop_items " +
            "WHERE " +
            "guid = " + Item.itemGUID + "";

        public string addMonsterSpot =
            "INSERT INTO monster (server, guid, id, world, x1, y1, x2, y2, direction, spawn_delay, spawn_distance, respawn_time_min, respawn_time_max, respawn_id, move_distance, itembag, elemental_attribute, disabled)" +
            "VALUES(" + MonsterSpot.server + ", " + MonsterSpot.guid + ", " + MonsterSpot.id + ", " + MonsterSpot.worldEntry + ", " + MonsterSpot.x1 + ", " +
            "" + MonsterSpot.y1 + ", " + MonsterSpot.x2 + ", " + MonsterSpot.y2 + ", " +
            "" + MonsterSpot.direction + ", " + MonsterSpot.spawnDelay + ", " + MonsterSpot.spawnDelay + ", " +
            "" + MonsterSpot.spawnDistance + ", " + MonsterSpot.respawnTimeMin + ", " + MonsterSpot.respawnTimeMax + ", " +
            "" + MonsterSpot.moveDistance + ", '" + MonsterSpot.itemBag + "', " + MonsterSpot.elementalAtt + ", " + MonsterSpot.disable + ")";

        public string DeleteMonsterSpot =
            "DELETE " +
            "FROM " +
            "monster " +
            "WHERE " +
            "guid = " + MonsterSpot.guid + "";

        public string filterMonsterWorld =
            "SELECT " +
            "monster_template.name," +
            "world_template.name," +
            "monster.x1," +
            "monster.y1," +
            "monster.guid " +
            "FROM monster " +
            "INNER " +
            "JOIN world_template " +
            "ON " +
            "monster.world = world_template.entry " +
            "INNER JOIN " +
            "monster_template " +
            "ON " +
            "monster.id = monster_template.model " +
            "WHERE world_template.name = '" + MonsterSpot.worldName + "' " +
            "and monster.server = " + MonsterSpot.server + "";

        public string loadEventsDatagrid =
            "SELECT " +
            "event_manager.server," +
            "event_template.name AS Event," +
            "event_invasion_data.name," +
            "event_manager.duration," +
            "event_manager.notify_time," +
            "event_manager.hour," +
            "event_manager.minute," +
            "event_manager.guid " +
            "FROM " +
            "mu_game.event_manager " +
            "INNER JOIN " +
            "mu_game.event_invasion_data ON event_manager.invasion = event_invasion_data.invasion   " +
            "INNER JOIN " +
            "mu_editor_config.event_template ON event_manager.event = event_template.id";

        public string loadEventSelect =
            "SELECT " +
            "event_manager.server," +
            "event_template.name AS Event," +
            "event_invasion_data.name," +
            "event_manager.duration," +
            "event_manager.notify_time," +
            "event_manager.hour," +
            "event_manager.minute," +
            "event_manager.guid," +
            "event_manager.day_of_week," +
            "event_manager.day_of_month," +
            "event_manager.season_event," +
            "event_manager.exclusive_server " +
            "FROM " +
            "mu_game.event_manager " +
            "INNER JOIN mu_game.event_invasion_data ON event_manager.invasion = event_invasion_data.invasion " +
            "INNER JOIN mu_editor_config.event_template ON event_manager.event = event_template.id " +
            "WHERE " +
            "event_manager.guid = " + Events.guid + "";

        public string loadEventsCombo =
            "SELECT " +
            "event_template.id," +
            "event_template.name " +
            "FROM " +
            "event_template";
        public string loadIvasions =
            "SELECT " +
            "event_invasion_data.invasion," +
            "event_invasion_data.name " +
            "FROM " +
            "event_invasion_data";

        public string addEvents =
            "INSERT INTO event_manager (season_event, exclusive_server, server, event, invasion, duration, notify_time, hour, minute, day_of_week, day_of_month)" +
            "VALUES(" + Events.eventSeason + ", " + Events.serverExclusive + ", " + Events.server + ", " + Events.events + ", " + Events.invasion + ", " + Events.duration + ", " + Events.alerTime + ", " + Events.hour + ", " + Events.min + ", " + Events.dayWeek + ", " + Events.dayMouth + ")";

        public string updateEvents =
            "UPDATE event_manager SET " +
            "season_event = " + Events.eventSeason + "," +
            "exclusive_server = " + Events.serverExclusive + "," +
            "server = " + Events.server + "," +
            "event = " + Events.events + "," +
            "invasion = " + Events.invasion + "," +
            "duration = " + Events.duration + "," +
            "notify_time = " + Events.alerTime + "," +
            "hour = " + Events.hour + "," +
            "minute = " + Events.min + "," +
            "day_of_week = " + Events.dayWeek + "," +
            "day_of_month =" + Events.dayMouth + "";

        public string deleteEvents =
            "DELETE FROM " +
            "event_manager WHERE " +
            "guid = " + Events.guid + "";

        public string loadMiniMap =
            "SELECT " +
            "world_template.name," +
            "mini_map.x," +
            "mini_map.y," +
            "mini_map.text " +
            "FROM " +
            "mini_map INNER JOIN world_template ON mini_map.world = world_template.entry ";

        public string loadMiniMapSelected =
           "SELECT " +
            "world_template.name," +
            "icons_template.name AS Icon," +
            "mini_map.index," +
            "mini_map.x," +
            "mini_map.y," +
            "mini_map.text " +
            "FROM " +
            "mu_game.mini_map INNER JOIN mu_editor_config.icons_template ON mini_map.type = icons_template.type " +
            "INNER JOIN mu_game.world_template ON mini_map.world = world_template.entry " +
            "WHERE " +
            "mini_map.world = " + MiniMap.worldEntry + " " +
            "AND " +
            "mini_map.server = " + MiniMap.server + "";

        public string world =
            "SELECT " +
            "world_template.entry," +
            "world_template.name " +
            "FROM " +
            "world_template";

        public string loadIcons =
            "SELECT " +
            "icons_template.type," +
            "icons_template.name " +
            "FROM " +
            "icons_template";

        public string saveIcons =
            "INSERT INTO mini_map (world, `index`, `group`, type, x, y, text, server)" +
            "VALUES(" + MiniMap.worldEntry + ", " + MiniMap.id + ", 0, " + MiniMap.type + ", " + MiniMap.x + ", " + MiniMap.y + ", '" + MiniMap.text + "', " + MiniMap.server + ")";
        public string countMaxMinimap =
            "SELECT MAX(`index`) FROM mini_map;";

        public string updateIcons =
            "UPDATE " +
            "mini_map " +
            "SET world = " + MiniMap.worldEntry + "," +
            "type = " + MiniMap.type + "," +
            "x = " + MiniMap.x + "," +
            "y = " + MiniMap.y + "," +
            "text = '" + MiniMap.text + "'," +
            "server = " + MiniMap.server + " " +
            "WHERE " +
            "`index` = " + MiniMap.id + "";

        public string deleteIcons =
            "DELETE " +
            "FROM " +
            "mini_map " +
            "WHERE " +
            "`index` = " + MiniMap.id + "";
    }
}