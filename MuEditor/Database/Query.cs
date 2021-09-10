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
    }
}