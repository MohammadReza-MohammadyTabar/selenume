using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace selenume
{
    interface ISelenium
    {
        
       bool Login(string Username, string Password);

       bool Logout();

       void Quit();

    }
}
