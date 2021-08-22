using MvvmLibary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordBind
{
    class ViewModel : BindableBase
    {
        private string password;

        public string Password
        {
            get { return password; }
            set { SetProperty(ref password, value); }
        }

        private string account;

        public string Account
        {
            get { return account; }
            set { SetProperty(ref account, value); }
        }

        private DelegateCommand loginCommand;

        public DelegateCommand LoginCommand => loginCommand ?? (loginCommand = new DelegateCommand(ExcuteLoginCommand));

        void ExcuteLoginCommand()
        {
            Console.WriteLine("Account:{0}", Account);
            Console.WriteLine("Password:{0}", Password);
        }
    }
}
