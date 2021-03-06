using ChuurasTrinca.ViewModels;
using ChuurasTrinca.Views;
using Prism;
using Prism.Ioc;
using Realms;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;

namespace ChuurasTrinca
{
    public partial class App
    {
        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
            
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            //await NavigationService.NavigateAsync("NavigationPage/MainPage");

            await NavigationService.NavigateAsync("NavigationPage/ViewCadastroChurrasco");
            //await NavigationService.NavigateAsync("NavigationPage/ViewListarChurrascos");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<ViewCadastroUsuario, ViewCadastroUsuarioViewModel>();
            containerRegistry.RegisterForNavigation<ViewPrincipal, ViewPrincipalViewModel>();
            containerRegistry.RegisterForNavigation<ViewCadastroChurrasco, ViewCadastroChurrascoViewModel>();
            containerRegistry.RegisterForNavigation<ViewListarChurrascos, ViewListarChurrascosViewModel>();
        }
    }
}
