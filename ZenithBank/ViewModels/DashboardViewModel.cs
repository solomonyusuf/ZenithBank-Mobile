using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZenithBank.ViewModels
{
    public class DashboardViewModel 
    {       
        public string cardColor { get; set; }   

        public List<string> ImageCollection { get; set; }   

        public DashboardViewModel()
        {
            cardColor = SecureStorage.GetAsync("cardTheme").Result;
            ImageCollection = new List<string> { "logo.png", "wallet.png"};
        }
    }
}
