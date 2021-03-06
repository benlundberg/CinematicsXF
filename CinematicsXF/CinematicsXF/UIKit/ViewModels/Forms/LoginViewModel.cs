﻿using CinematicsXF.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CinematicsXF
{
    public class LoginViewModel : BaseViewModel
    {
        public LoginViewModel()
        {
            Username = new ValidatableObject<string>(new List<IValidationRule<string>>
            {
                new IsNotNullOrEmptyRule<string>(Translate("Missing_Username"))
            });

            Password = new ValidatableObject<string>(new List<IValidationRule<string>>
            {
                new IsNotNullOrEmptyRule<string>(Translate("Missing_Password"))
            });
        }

        private ICommand forgotPasswordCommand;
        public ICommand ForgotPasswordCommand => forgotPasswordCommand ?? (forgotPasswordCommand = new Command(async () =>
        {
            await Navigation.PushModalAsync(new RecoverPasswordPage { BindingContext = new RecoverPasswordViewModel { Navigation = this.Navigation } });
        }));

        private ICommand loginCommand;
        public ICommand LoginCommand => loginCommand ?? (loginCommand = new Command(async () =>
        {
            if (IsBusy)
            {
                return;
            }

            if (!Username.Validate())
            {
                ShowAlert(Username.Error, Translate("Gen_Login"));
                return;
            }

            if (!Password.Validate())
            {
                ShowAlert(Password.Error, Translate("Gen_Login"));
                return;
            }

            try
            {
                IsBusy = true;

                await Task.Delay(TimeSpan.FromSeconds(2));
            }
            catch (Exception ex)
            {
                Logger.LogException(ex, GetType().ToString(), sendToService: false);
                ShowAlert(ex.Message, "Exception");
            }
            finally
            {
                IsBusy = false;
            }
        }));

        public ValidatableObject<string> Username { get; set; }
        public ValidatableObject<string> Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
