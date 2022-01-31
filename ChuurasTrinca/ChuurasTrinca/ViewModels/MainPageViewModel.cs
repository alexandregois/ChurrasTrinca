using Acr.UserDialogs;
using ChuurasTrinca.Models.RealmDto;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Realms;
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

        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            _navigationService = navigationService;
            CadastrarCommand = new DelegateCommand(OnCadastrar);
            LoginCommand = new DelegateCommand(Login);
        }

        private void Login()
        {

            if (String.IsNullOrEmpty(Email))
            {
                UserDialogs.Instance.Toast("Favor digitar o e-mail.", TimeSpan.FromSeconds(10));
                return;
            }

            if (String.IsNullOrEmpty(Senha))
            { 
                UserDialogs.Instance.Toast("Favor digitar a senha.", TimeSpan.FromSeconds(10));
                return;
            }

            try
            {
                var realmDB = Realm.GetInstance();
                //var selectedUsuario = realmDB.All<UsuarioDto>().First(u => u.Login == Email && u.Senha == Senha);

                var listUsuario = realmDB.All<UsuarioDto>().ToList();

                //var selectedUsuario = realmDB.All<UsuarioDto>().First(u => u.Login == Email);

                if (listUsuario != null)
                {
                    var selectedUsuario = listUsuario.First(u => u.Login == Email && u.Senha == Senha);
                    if (selectedUsuario != null)
                    {
                        _navigationService.NavigateAsync("NavigationPage/ViewPrincipal");
                    }
                    else
                        UserDialogs.Instance.Toast("Usuário não encontrado ou login e senha incorretos.", TimeSpan.FromSeconds(10));
                }
                else
                    UserDialogs.Instance.Toast("Não há usuários cadastrados.", TimeSpan.FromSeconds(10));

            }
            catch (Exception ex)
            {

                UserDialogs.Instance.Toast("Ocorreu um erro. Tente novamente.", TimeSpan.FromSeconds(10));
            }
           

        }

        private void OnCadastrar()
        {
            _navigationService.NavigateAsync("NavigationPage/ViewCadastroUsuario");
        }

    }
}
