using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChuurasTrinca.ViewModels
{

    public class MainPageViewModel : ViewModelBase
    {
        private INavigationService _navigationService;

        public DelegateCommand CadastrarCommand { get; set; }
        public DelegateCommand LoginCommand { get; set; }

        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            _navigationService = navigationService;
            CadastrarCommand = new DelegateCommand(OnCadastrar);
            LoginCommand = new DelegateCommand(Login);
        }

        private void Login()
        {
            
        }

        private void OnCadastrar()
        {
            _navigationService.NavigateAsync("NavigationPage/ViewCadastroUsuario");
        }

    }
}
