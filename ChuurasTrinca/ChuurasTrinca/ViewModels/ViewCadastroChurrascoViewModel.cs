using Acr.UserDialogs;
using ChuurasTrinca.Models.RealmDto;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Realms;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChuurasTrinca.ViewModels
{
    public class ViewCadastroChurrascoViewModel : ViewModelBase
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

        private String _valorPessoaString;
        public String ValorPessoaString
        {
            get => _valorPessoaString;
            set => SetProperty(ref _valorPessoaString, value);
        }

        public DelegateCommand SalvarCommand { get; set; }


        public ViewCadastroChurrascoViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            _navigationService = navigationService;
            SalvarCommand = new DelegateCommand(Salvar);

            Data = DateTime.Now;
        }

        private void LimparCampos()
        {
            Descricao = string.Empty;
            Data = DateTime.Now;
            ValorPessoa = 0;

        }

        private void Salvar()
        {

            if (String.IsNullOrEmpty(Descricao))
            {
                UserDialogs.Instance.Toast("Favor digitar o nome.", TimeSpan.FromSeconds(10));
                return;
            }

            if (String.IsNullOrEmpty(ValorPessoaString))
            {
                UserDialogs.Instance.Toast("Favor informar um valor por pessoa.", TimeSpan.FromSeconds(10));
                return;
            }
            else
                ValorPessoa = Convert.ToDecimal(_valorPessoaString);




            try
            {
                var realmDB = Realm.GetInstance();
                var lista = realmDB.All<ChurrascoDto>().ToList();
                var maxId = 0;

                if (lista.Count != 0)
                {
                    maxId = lista.Max(s => s.Id);
                }


                ChurrascoDto item = new ChurrascoDto()
                {
                    Id = maxId + 1,
                    Descricao = Descricao,
                    DataChurrasco = Data,
                    ValorPessoa = ValorPessoa
                };


                realmDB.Write(() =>
                {
                    realmDB.Add(item);
                });

                UserDialogs.Instance.Toast("Churrasco cadastrado com sucesso.", TimeSpan.FromSeconds(10));


                LimparCampos();

            }
            catch (Exception)
            {
                UserDialogs.Instance.Toast("Ocorreu um erro. Tente novamente.", TimeSpan.FromSeconds(10));
            }

        }
    }
}
