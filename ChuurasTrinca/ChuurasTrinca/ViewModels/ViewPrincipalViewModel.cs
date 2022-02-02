using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChuurasTrinca.ViewModels
{
    public class ViewPrincipalViewModel : ViewModelBase
    {
        private INavigationService _navigationService;

        public DelegateCommand CadastrarChurrascoCommand { get; set; }
        public DelegateCommand ListarChurrascosCommand { get; set; }

        public ViewPrincipalViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            CadastrarChurrascoCommand = new DelegateCommand(CadastrarChurrasco);
            ListarChurrascosCommand = new DelegateCommand(ListarChurrascos);
        }

        private void ListarChurrascos()
        {
            _navigationService.NavigateAsync("NavigationPage/ViewListarChurrascos");
        }

        private void CadastrarChurrasco()
        {
            _navigationService.NavigateAsync("NavigationPage/ViewCadastroChurrasco");
        }
    }
}
