using System;
using System.Collections.Generic;
using TenmoClient.APIClients;
using TenmoClient.Data;

namespace TenmoClient
{
    public class UserInterface
    {
        private readonly ConsoleService consoleService = new ConsoleService();
        private readonly AuthService authService = new AuthService();
        private readonly AccountService accountService = new AccountService();
        private readonly UsersService usersService = new UsersService();
        private readonly TransferService transferService = new TransferService();

        private bool shouldExit = false;

        public void Start()
        {
            while (!shouldExit)
            {
                while (!authService.IsLoggedIn)
                {
                    ShowLogInMenu();
                }

                // If we got here, then the user is logged in. Go ahead and show the main menu
                ShowMainMenu();
            }
        }

        private void ShowLogInMenu()
        {
            bool done = false;
            while (!done)
            {
                Console.WriteLine("Welcome to TEnmo!");
                Console.WriteLine("1: Login");
                Console.WriteLine("2: Register");
                Console.Write("Please choose an option: ");

                if (!int.TryParse(Console.ReadLine(), out int loginRegister))
                {
                    Console.WriteLine("Invalid input. Please enter only a number.");
                }
                else if (loginRegister == 1)
                {
                    HandleUserLogin();
                    break;
                }
                else if (loginRegister == 2)
                {
                    HandleUserRegister();
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid selection.");
                }
            }
        }

        private void ShowMainMenu()
        {
            bool done = false;
            int menuSelection = -1;
            while (!done)
            {
                Console.WriteLine();
                Console.WriteLine("Welcome to TEnmo! Please make a selection: ");
                Console.WriteLine("1: View your current balance");
                Console.WriteLine("2: View your past transfers");
                Console.WriteLine("3: View your pending requests");
                Console.WriteLine("4: Send TE bucks");
                Console.WriteLine("5: Request TE bucks");
                Console.WriteLine("6: Log in as different user");
                Console.WriteLine("0: Exit");
                Console.WriteLine("---------");
                Console.Write("Please choose an option: ");

                if (!int.TryParse(Console.ReadLine(), out menuSelection))
                {
                    Console.WriteLine("Invalid input. Please enter only a number.");
                }
                else
                {
                    switch (menuSelection)
                    {
                        case 1:
                            ViewBalance();
                            break;
                        case 2:
                            ViewPastTransfers();
                            break;
                        case 3:
                            Console.WriteLine("NOT IMPLEMENTED!"); // TODO: Implement me
                            break;
                        case 4:
                            SendTEBucks();
                            break;
                        case 5:
                            Console.WriteLine("NOT IMPLEMENTED!"); // TODO: Implement me
                            break;
                        case 6:
                            Console.WriteLine();
                            UserService.SetLogin(new API_User()); //wipe out previous login info
                            authService.LogOut();
                            done = true;
                            break;
                        case 0:
                            Console.WriteLine("Goodbye!");
                            shouldExit = true;
                            return;
                        default:
                            Console.WriteLine("Please enter a valid option.");
                            break;
                    }
                }
            }
        }

        private void HandleUserRegister()
        {
            bool isRegistered = false;

            while (!isRegistered) //will keep looping until user is registered
            {
                LoginUser registerUser = consoleService.PromptForLogin();
                isRegistered = authService.Register(registerUser);
            }

            Console.WriteLine("");
            Console.WriteLine("Registration successful. You can now log in.");
        }

        private void HandleUserLogin()
        {
            while (!UserService.IsLoggedIn) //will keep looping until user is logged in
            {
                LoginUser loginUser = consoleService.PromptForLogin();
                API_User user = authService.Login(loginUser);
                if (user != null)
                {
                    UserService.SetLogin(user);
                }
            }
        }

        private void ViewBalance()
        {
            decimal currentBalance = accountService.GetBalance();
            Console.WriteLine("Your current balance is: " + currentBalance.ToString("C"));
            Console.WriteLine();
        }

        private void SendTEBucks()
        {
            bool done = false;
            while (!done)
            {
                try
                {
                    Console.WriteLine("-------------------------------------------------");
                    Console.WriteLine("Users");
                    Console.WriteLine("ID          Name");
                    Console.WriteLine("-------------------------------------------------");
                    List<int> validUsers = GetUsersList();
                    Console.WriteLine("---------");
                    Console.Write("Enter ID of user you are sending to (0 to cancel): ");
                    int userId = int.Parse(Console.ReadLine());
                    if (userId == 0)
                    {
                        done = true;
                        break;
                    }
                    else if (validUsers.Contains(userId))
                    {
                        Console.Write("Enter amount: ");
                        decimal amount = decimal.Parse(Console.ReadLine());
                        if (amount > 0 && amount <= accountService.GetBalance())
                        {
                            TransferDetails createdTransfer = transferService.TransferTEBucks(userId, amount);
                            SuccessMessage(createdTransfer != null);
                        }
                        else if (amount <= 0)
                        {
                            Console.WriteLine("Please enter a transfer amount above 0.00");
                        }
                        else { Console.WriteLine("Insufficient funds for this transfer."); }
                    }
                    else
                    {
                        Console.WriteLine("Please enter valid Id.");
                    }
                } catch (FormatException ex)
                {
                    Console.WriteLine("Please enter a valid number amount.");
                    continue;
                }
            }
        }

        public List<int> GetUsersList()
        {
            List<API_User> users = usersService.GetUsers();
            List<int> validIds = new List<int>();
            foreach (API_User user in users)
            {
                if (user.UserId != UserService.UserId)
                {
                    Console.WriteLine(user.ToString());
                    validIds.Add(user.UserId);
                }
            }
            return validIds;
        }

        public void SuccessMessage(bool success)
        {
            if (success)
            {
                Console.WriteLine("Transfer was successful!");
            }
            else
            {
                Console.WriteLine("Transfer could not be completed.");
            }
        }

        public void ViewPastTransfers()
        {
            bool done = false;
            List<TransferDetails> pastTransfers = transferService.GetPastTransfers();
            int currentAccountId = accountService.GetCurrentAccountId();
            while (!done)
            {
                Console.WriteLine("-------------------------------------------------");
                Console.WriteLine("Transfers");
                Console.WriteLine("ID          From/To                        Amount");
                Console.WriteLine("-------------------------------------------------");
                for (int i = 0; i < pastTransfers.Count; i++)
                {
                    Console.Write($"{pastTransfers[i].TransferId}     ");
                    if (pastTransfers[i].RecipientId == currentAccountId)
                    {
                        API_User sender = usersService.GetUserByAccountId(pastTransfers[i].SenderId);
                        Console.Write(($"From: {sender.Username}").PadRight(30));
                    }
                    else
                    {
                        API_User recipient = usersService.GetUserByAccountId(pastTransfers[i].RecipientId);
                        Console.Write(($"  To: {recipient.Username}").PadRight(30));
            }
                    string formattedPrice = pastTransfers[i].TransferAmount.ToString("C");
                    Console.WriteLine(formattedPrice.PadLeft(10));
                }
                Console.WriteLine("---------");
                Console.Write("Please enter transfer ID to view details (0 to cancel): ");
                int transferId = int.Parse(Console.ReadLine());
                if (transferId != 0)
                {
                    DisplayTransferDetails(transferId, pastTransfers);
                }
                else
                {
                    done = true;
                    break;
                }
            }
        }

        public void DisplayTransferDetails(int transferId, List<TransferDetails> transferDetails)
        {
            foreach (TransferDetails transfer in transferDetails)
            {
                if (transferId == transfer.TransferId)
                {
                    Console.WriteLine();
                    Console.WriteLine("-------------------------------------------------");
                    Console.WriteLine("Transfer Details");
                    Console.WriteLine("-------------------------------------------------");
                    Console.WriteLine($"    ID: {transfer.TransferId.ToString()}");
                    Console.WriteLine($"  From: { usersService.GetUserByAccountId(transfer.SenderId).Username}");
                    Console.WriteLine($"    To: { usersService.GetUserByAccountId(transfer.RecipientId).Username}");
                    Console.WriteLine($"  Type: {transfer.Type}");
                    Console.WriteLine($"Status: {transfer.Status}");
                    Console.WriteLine($"Amount: {transfer.TransferAmount.ToString("c")}");
                    Console.WriteLine();
                    break;
                }
            }
        }
    }
}
