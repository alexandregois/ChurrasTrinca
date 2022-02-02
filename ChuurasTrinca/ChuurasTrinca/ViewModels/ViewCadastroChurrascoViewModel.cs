using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChuurasTrinca.ViewModels
{
    public class ViewCadastroChurrascoViewModel : ViewModelBase
    {
        private INavigationService _navigationService;

        public ViewCadastroChurrascoViewModel(INavigationService navigationService)
            : base(navigationService)
        {

        }
    }
}
