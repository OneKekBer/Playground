using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Threading.Tasks;




namespace Project.auth
{

    public class Program()
    {
        public enum EnumInput
        {
            Password = 0,
            Login = 1,

        }

        public enum EnumActionsForUsers
        {
            TransferMoney = 0,
        }

        public enum EnumActions
        {
            LogIn = 0,
            ChangePassword = 1,
            Register = 2,
            LogedOut = 3,
            GetAllUsers = 4,
            GetAccountInfo = 5,
        }



        public static string Input(EnumInput type)
        {
            Console.WriteLine($"Please enter your {type}");
            string value = Console.ReadLine();
            return value;
        }


        public static class State
        {
            public static Account currentProfile;

        }



        public static class DataBase
        {
            //its ok while thats db contain only password and login 
            //but when in class Account i will add some new attributes, memory of List accounts will increasing and maybe bad!!!
            //or i am just braindead
            private static List<Account> accounts = new List<Account>();

            public static void GetAllAccounts()
            {
                int i = 0;
                foreach (var account in accounts)
                {
                    Console.WriteLine($"{i} : {account.Login}");
                    i++;
                }
            }

            public static void AddNewAccount(Account newAccount)
            {
                accounts.Add(newAccount);
            }


            public static bool IsLoginAlreadyUsed(string newLogin)
            {
                foreach (var account in accounts)
                {
                    if (account.Login == newLogin)
                    {
                        return true;
                    }
                }
                return false;
            }

            public static Account FindUserByLogin(string userLogin)
            {
                foreach (var account in accounts)
                {
                    if (account.Login == userLogin)
                    {
                        return account;
                    }
                }

                return null;
            }
        }



        public class Account // This class looks like copy/pasted from different language
        {
            public Guid Id { get; init; } = Guid.NewGuid();

            public string PasswordHash { get; private set; }

            public string Login { get; init; }

            public int Balance = 50;

            public Account(string login)
            {
                Login = login;
            }

            public void TransferMoneyTo(string searchingLogin, int transferMoney)
            {
                Account profile = DataBase.FindUserByLogin(searchingLogin);
            }

            public void UpdatePassword(string newPassword)
            {
                var newPasswordHash = GetPasswordHashString(newPassword);
                if (PasswordHash != newPasswordHash || PasswordHash == "")
                    PasswordHash = newPasswordHash;
            }

            private static string GetPasswordHashString(string value)
            {
                return Encoding.UTF8.GetString(SHA256.HashData(Encoding.UTF8.GetBytes(value)));
            }

            public bool ValidatePassword(string password)
            {
                var userInputPasswordHash = GetPasswordHashString(password);
                return PasswordHash == userInputPasswordHash;
            }
        }

        public

        static void ChooseAction(EnumActions userAction)
        {
            string loginUserInput;
            string passwordUserInput;

            switch (userAction)
            {
                case EnumActions.LogIn:

                    loginUserInput = Input(EnumInput.Login);

                    Account profile = DataBase.FindUserByLogin(loginUserInput);
                    if (profile == null)
                    {
                        Console.WriteLine($"There is no user with login {loginUserInput}");
                        break;
                    }

                    passwordUserInput = Input(EnumInput.Password);

                    bool isPasswordCorrect = profile.ValidatePassword(passwordUserInput);
                    if (!isPasswordCorrect)
                    {
                        Console.WriteLine("Unccorect password");
                        break;
                    }
                    State.currentProfile = profile;

                    Console.WriteLine($"Welcome {loginUserInput}");
                    break;


                case EnumActions.ChangePassword:
                    if (State.currentProfile == null)
                    {
                        Console.WriteLine("You need to be loggedin to change password");
                        break;
                    }


                    passwordUserInput = Input(EnumInput.Password);

                    State.currentProfile.UpdatePassword(passwordUserInput);

                    Console.WriteLine("Your password was changed");
                    break;


                case EnumActions.Register:
                    loginUserInput = Input(EnumInput.Login);
                    bool isLoginAlreadyUsed = DataBase.IsLoginAlreadyUsed(loginUserInput);
                    if (isLoginAlreadyUsed)
                    {
                        Console.WriteLine("This login already used");
                        break;
                    }
                    passwordUserInput = Input(EnumInput.Password);

                    Account user = new Account(loginUserInput);
                    user.UpdatePassword(passwordUserInput);


                    Console.WriteLine("You have been registered");

                    DataBase.AddNewAccount(user);

                    break;


                case EnumActions.LogedOut:
                    State.currentProfile = null;
                    Console.WriteLine("You have been loged out");
                    break;


                case EnumActions.GetAllUsers:
                    if (State.currentProfile == null)
                    {
                        Console.WriteLine("You need to be loged in");
                        break;
                    }
                    DataBase.GetAllAccounts();


                    break;


                case EnumActions.GetAccountInfo:
                    if (State.currentProfile == null)
                    {
                        Console.WriteLine("You need to be loged in");
                        break;
                    }
                    Console.WriteLine($"Login: {State.currentProfile.Login}");
                    Console.WriteLine($"Balance: {State.currentProfile.Balance}");
                    break;


                default:
                    Console.WriteLine("There is some error(");
                    break;
            }
        }

        public static void PrintActions()
        {
            Console.Write("choose action: ");
            int i = 0;
            foreach (EnumActions action in Enum.GetValues<EnumActions>()) // Could be decomposed (moved to a separate method like PrintActions()
            {

                Console.Write($"{i} : {action} / ");
                i += 1;

            }
            Console.WriteLine();


            string rawAction = Console.ReadLine();
            if (Enum.TryParse(rawAction, out EnumActions userAction))
            {
                ChooseAction(userAction);
            }
            else
            {
                Console.WriteLine("incorrect action");
            }
        }



        public static void Auth()
        {
            Console.WriteLine((int)EnumActions.Register);

            while (true)
            {

                PrintActions();
            }
        }




    }//class
}//namespace


