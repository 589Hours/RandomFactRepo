using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RandomFactApp.Domain.Clients;

namespace RandomFactApp.ViewModels
{
    public partial class MainPageViewModel : ObservableObject
    {
        private readonly IRandomFactClient randomFactClient;

        [ObservableProperty] 
        public string factToShow;

        public MainPageViewModel(IRandomFactClient randomFactClient)
        {
            this.randomFactClient = randomFactClient;
        }

        [RelayCommand]
        public async Task GetNewRandomFact()
        {
            try
            {
                var receivedFact = await this.randomFactClient.RetrieveRandomFactAsync("en");
                this.FactToShow = receivedFact!.Fact;
            }
            catch (Exception ex)
            {
                this.FactToShow = "something went wrong";
            }


        }
    }
}
