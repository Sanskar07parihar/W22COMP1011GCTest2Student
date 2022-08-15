using InventoryManagement.Models;
using System.Configuration;

namespace InventoryManagement.UI
{
    public class Declarations
    {
        public static string API_URL { get { return ConfigurationManager.AppSettings["APIURL"]; } }
        public static User LoggedInUser { get; set; }
    }
}

public enum MenuOption
{
    None = 0,
    Home = 1,
    Inventory = 2,
    Users = 3,
    Settings = 4
}

public enum InOutType
{
    In = 0,
    Out = 1,
}
