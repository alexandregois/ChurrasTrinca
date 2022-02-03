using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChuurasTrinca.ViewModels
{
    public class ViewListarChurrascosViewModel : ViewModelBase
    {
        private INavigationService _navigationService;

        private string _descricao;
        public string Descricao
        {
            get => _descricao;
            set => SetProperty(ref _descricao, value);
        }

        private DateTime _data;
        public DateTime Data
        {
            get => _data;
            set => SetProperty(ref _data, value);
        }

        private decimal _valorPessoa;
        public decimal ValorPessoa
        {
            get => _valorPessoa;
            set => SetProperty(ref _valorPessoa, value);
        }

        private decimal _totalArrecadado;
        public decimal TotalArrecadado
        {
            get => _totalArrecadado;
            set => SetProperty(ref _totalArrecadado, value);
        }

        public ViewListarChurrascosViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            _navigationService = navigationService;

        }
    }
}
