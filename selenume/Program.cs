using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace selenume
{
    class Program
    {
        
        static void Main(string[] args)
        {
            int count=2;
            int c = 0;
            while (true)
            {
                
                Selenium sel = new Selenium();
                
                sel.vote(count);
                
                c++;
                if (c % 10 == 0)
                {
                    count++;
                }
            }
            



            //string Username ;
            //string Password ;
            //command: 
            // string cmd = Console.ReadLine();

            /*if (cmd.ToLower() == "login")
            {
                Console.WriteLine("UserName : ");
                Username = Console.ReadLine();
                Console.WriteLine("PassWord : ");
                Password = Console.ReadLine();

                
                if (sel.Login(Username, Password) == true)
                {

                    Console.WriteLine("Logged In !");
                    goto command;
                }


                else
                {
                    Console.WriteLine("falid !");
                    goto command;
                }
                    

            }*/

            /*if (cmd.ToLower() == "logout")
            {

                if (sel.Logout() == true)
                {

                    Console.WriteLine("Logged out !");
                    goto command;
                }


                else
                {
                    Console.WriteLine("falid !");
                    goto command;
                }
                
            }
            if (cmd.ToLower() == "quit") 
            {
                sel.Quit();
                
            }*/


        }
    }
}
