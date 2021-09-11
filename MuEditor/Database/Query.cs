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

        public string DuplicateAccount =
            "SELECT account " +
            "FROM " +
            "accounts " +
            "WHERE " +
            "accounts.account = '" + User.account + "'";

        public string LoadAllCharacter =
            "SELECT character_info.name " +
            "FROM " +
            "character_info";
    }
}