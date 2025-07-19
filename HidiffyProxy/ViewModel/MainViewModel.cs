using HidiffyProxy.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HidiffyProxy.ViewModel
{
    public enum ConnectionMode
    {
        Proxy,
        VPN
    }
    public class MainViewModel : BaseViewModel
    {
        private bool _isModalVisible;
        private bool isBottomSheetVisible;
        private bool isWarpEnabled;
        private bool isTlsFragmentEnabled;
        private ConnectionMode selectedMode;


        public MainViewModel()
        {
            ShowModalCommand = new Command(() => IsModalVisible = true);
            ShowBottomSheetCommand = new Command(() => IsBottomSheetVisible = true);

            SelectProxyCommand = new Command(() => SelectedMode = ConnectionMode.Proxy);
            SelectVpnCommand = new Command(() => SelectedMode = ConnectionMode.VPN);
            SelectedMode = ConnectionMode.Proxy;

            NotFound = new RelayCommand(ProxyNotFound);

            ShowSugarList = new RelayCommand(OnShowSugarList);
            ShowFoodList = new RelayCommand(OnShowFoodList);
        }

        public ConnectionMode SelectedMode
        {
            get => selectedMode;
            set
            {
                if (selectedMode != value)
                {
                    selectedMode = value;
                    OnPropertyChanged(nameof(SelectedMode));
                    OnPropertyChanged(nameof(IsProxySelected));
                    OnPropertyChanged(nameof(IsVpnSelected));
                }
            }
        }

        public void ProxyNotFound(object parametr)
        {
            Application.Current.MainPage.DisplayAlert("Ошибка", "Сервис ещё не запущен", "OK");
        }

        public bool IsProxySelected => SelectedMode == ConnectionMode.Proxy;
        public bool IsVpnSelected => SelectedMode == ConnectionMode.VPN;

        public bool IsModalVisible
        {
            get => _isModalVisible;
            set { _isModalVisible = value; OnPropertyChanged(); }
        }

        public bool IsBottomSheetVisible
        {
            get => isBottomSheetVisible;
            set
            {
                if (isBottomSheetVisible != value)
                {
                    isBottomSheetVisible = value;
                    OnPropertyChanged(nameof(IsBottomSheetVisible));
                }
            }
        }
        public bool IsWarpEnabled
        {
            get => isWarpEnabled;
            set
            {
                if (isWarpEnabled != value)
                {
                    isWarpEnabled = value;
                    OnPropertyChanged(nameof(IsWarpEnabled));
                }
            }
        }

        public bool IsTlsFragmentEnabled
        {
            get => isTlsFragmentEnabled;
            set
            {
                if (isTlsFragmentEnabled != value)
                {
                    isTlsFragmentEnabled = value;
                    OnPropertyChanged(nameof(IsTlsFragmentEnabled));
                }
            }
        }

        private void OnShowSugarList(object parameter)
        {
            IsSugarListVisible = true;

        }

        private void OnShowFoodList(object parameter)
        {
            IsSugarListVisible = false;

        }
        private bool _isSugarListVisible = true;

        public bool IsSugarListVisible
        {
            get => _isSugarListVisible;
            set
            {
                _isSugarListVisible = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(IsFoodListVisible));
            }
        }

        public bool IsFoodListVisible
        {
            get => !_isSugarListVisible;
        }

        public ICommand ShowModalCommand { get; }
        public ICommand ShowBottomSheetCommand { get; }
        public ICommand SelectProxyCommand { get; }
        public ICommand SelectVpnCommand { get; }


        public ICommand ShowSugarList { get; }
        public ICommand ShowFoodList { get; }
        public ICommand NotFound { get; }

    }
}
