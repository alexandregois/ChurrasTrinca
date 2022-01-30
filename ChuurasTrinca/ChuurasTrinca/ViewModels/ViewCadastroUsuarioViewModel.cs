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
    public class ViewCadastroUsuarioViewModel : ViewModelBase
    {

        private INavigationService _navigationService;

        private string _nome;
        public string Nome
        {
            get => _nome;
            set => SetProperty(ref _nome, value);
        }

        private string _email;
        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }

        private string _senha;
        public string Senha
        {
            get => _senha;
            set => SetProperty(ref _senha, value);
        }
        private string _confirmarSenha;
        public string ConfirmarSenha
        {
            get => _confirmarSenha;
            set => SetProperty(ref _confirmarSenha, value);
        }


        public DelegateCommand SalvarCommand { get; set; }

        public ViewCadastroUsuarioViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            _navigationService = navigationService;
            SalvarCommand = new DelegateCommand(Salvar);
        }

        private void Salvar()
        {

            if (String.IsNullOrEmpty(Nome))
                UserDialogs.Instance.Toast("Favor digitar o nome.", TimeSpan.FromSeconds(10));

            if (String.IsNullOrEmpty(Email))
                UserDialogs.Instance.Toast("Favor digitar o e-mail.", TimeSpan.FromSeconds(10));

            if (String.IsNullOrEmpty(Senha))
                UserDialogs.Instance.Toast("Favor digitar a senha.", TimeSpan.FromSeconds(10));

            if (String.IsNullOrEmpty(ConfirmarSenha))
                UserDialogs.Instance.Toast("Favor confirmar a senha.", TimeSpan.FromSeconds(10));


            if (Senha != ConfirmarSenha)
            {
                UserDialogs.Instance.Toast("Senhas digitadas não conferem.", TimeSpan.FromSeconds(10));
            }

            try
            {
                var realmDB = Realm.GetInstance();
                var usuarios = realmDB.All<UsuarioDto>().ToList();
                var maxUsuarioId = 0;

                if (usuarios.Count != 0)
                {
                    maxUsuarioId = usuarios.Max(s => s.Id);
                }


                UsuarioDto usuario = new UsuarioDto()
                {
                    Id = maxUsuarioId + 1,
                    Nome = Nome,
                    Login = Email,
                    Senha = Senha
                };


                realmDB.Write(() =>
                {
                    realmDB.Add(usuario);
                });

                UserDialogs.Instance.Toast("Senhas digitadas não conferem.", TimeSpan.FromSeconds(10));


                LimparCampos();

            }
            catch (Exception)
            {
                UserDialogs.Instance.Toast("Ocorreu um erro. Tente novamente.", TimeSpan.FromSeconds(10));
            }

        }

        private void LimparCampos()
        {
            Nome = string.Empty;
            Email = string.Empty;
            Senha = string.Empty; 
            ConfirmarSenha = string.Empty;

        }
    }
}
