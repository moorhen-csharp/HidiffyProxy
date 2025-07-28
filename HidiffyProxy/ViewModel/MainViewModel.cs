using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HidiffyProxy.Model;

namespace HidiffyProxy.ViewModel
{
    public enum ConnectionMode
    {
        Proxy,
        VPN
    }
    public partial class MainViewModel : ObservableObject
    {
        public MainViewModel()
        {
            SelectedMode = ConnectionMode.Proxy;
        }

        [ObservableProperty]
        private bool isSugarListVisible = true;

        [ObservableProperty]
        private bool isModalVisible;

        [ObservableProperty]
        private bool isBottomSheetVisible;

        [ObservableProperty]
        private bool isWarpEnabled;

        [ObservableProperty]
        private bool isTlsFragmentEnabled;

        [ObservableProperty]
        private ConnectionMode selectedMode = ConnectionMode.Proxy;

        public bool IsProxySelected => SelectedMode == ConnectionMode.Proxy;
        public bool IsVpnSelected => SelectedMode == ConnectionMode.VPN;
        public bool IsFoodListVisible => !IsSugarListVisible;

        private List<Profile> _profiles = new();
        public List<Profile> Profiles
        {
            get => _profiles;
            set => SetProperty(ref _profiles, value);
        }

        private Profile _activeProfile;
        public Profile ActiveProfile
        {
            get => _activeProfile;
            set => SetProperty(ref _activeProfile, value);
        }

        [RelayCommand]
        private void ShowModal()
        {
            IsModalVisible = true;
        }

        [RelayCommand]
        private void ShowBottomSheet()
        {
            IsBottomSheetVisible = true;
        }

        [RelayCommand]
        private void SelectProxy()
        {
            SelectedMode = ConnectionMode.Proxy;
            OnPropertyChanged(nameof(IsProxySelected));
            OnPropertyChanged(nameof(IsVpnSelected));
        }

        [RelayCommand]
        private void SelectVpn()
        {
            SelectedMode = ConnectionMode.VPN;
            OnPropertyChanged(nameof(IsProxySelected));
            OnPropertyChanged(nameof(IsVpnSelected));
        }

        [RelayCommand]
        private void NotFound()
        {
            Application.Current.MainPage.DisplayAlert("Ошибка", "Сервис ещё не запущен", "OK");
        }

        [RelayCommand]
        private void ShowSugarList()
        {
            IsSugarListVisible = true;
        }

        [RelayCommand]
        private void ShowFoodList()
        {
            IsSugarListVisible = false;
        }
    }
}
