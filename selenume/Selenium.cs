using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OpenQA.Selenium.Support.UI;

namespace selenume
{
    class Selenium 
    {
        private IWebDriver driver;

        public string s;
        private string Username;
        private string Password;
        private List<Item> items;
        public void LoadJson()
        {
            using (StreamReader r = new StreamReader("C:\\Users\\MAXELL\\Desktop\\Free_Proxy_List.json"))
            {
                string json = r.ReadToEnd(); 
                
                items = JsonConvert.DeserializeObject<List<Item>>(json);
            }
        }

        public class Item
        {
            /*public string ip;
            public string port;*/
            public string ipPort;

        }

        public void getjso()
        {
            //string path = @"C:\Users\MAXELL\Desktop\Free_Proxy_List.json";

            var URL = new UriBuilder("http://pubproxy.com/api/proxy?format=txt");

            var client = new WebClient();

            //client.Headers.Add("Accepts", "application/json");
            s = client.DownloadString(URL.ToString());
            //client.DownloadFile(URL.ToString(), path);
            /*var detail = JObject.Parse(s);
            Console.WriteLine(string.Concat("hi",detail["price"]));*/

        }
        public bool vote(int count )
        {
            getjso();
            ChromeOptions options = new ChromeOptions();
            var proxy = new OpenQA.Selenium.Proxy();
            proxy.HttpProxy=
            proxy.SslProxy = s;

            proxy.Kind = ProxyKind.Manual;
            proxy.IsAutoDetect = false;
            
              
            options.Proxy = proxy;
            //options.AddArgument("ignore-certificate-errors");


            
            //Set the proxy to the Chrome options
            
            driver = new ChromeDriver(@"C:\Program Files (x86)",options);
            
            try
            {
                
                driver.Navigate().GoToUrl("https://tools.pinpoll.com/embed/181255/");
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript("window.scrollBy(0,document.body.scrollHeight)");

                //IJavaScriptExecutor js2 = (IJavaScriptExecutor)driver;
                //js2.ExecuteScript(@"document.getElementById(""answer_522955"").click();");
                Thread.Sleep(10000);
                IWebElement ele = driver.FindElement(By.Id("answer_522955"));
                ele.Click();
                Thread.Sleep(5000);
                Quit();
                
                return true;
            }
            catch
            {
                Quit();
                return false;
            }
        }
        public bool Login(string Username, string Password)
        {
            driver = new ChromeDriver(@"C:\Program Files (x86)");
            try
            {
                driver.Navigate().GoToUrl("https://www.instagram.com/");
                IWebElement ele = driver.FindElement(By.Name("username"));
                ele.SendKeys(Username);
                IWebElement ele2 = driver.FindElement(By.Name("password"));
                ele2.SendKeys(Password);
                ele2.Submit();
                return true;
            }
            catch
            {
                return false;
            }
            
            
        }

        

        public bool Logout()
        {
            try
            {
                IWebElement ele3 = driver.FindElement(By.ClassName("_6q-tv"));
                ele3.Click();
                Thread.Sleep(5000);
                ele3 = driver.FindElement(By.XPath("/html/body/div[1]/section/nav/div[2]/div/div/div[3]/div/div[5]/div[2]/div[2]/div[2]/div[2]/div/div/div/div/div/div"));
                ele3.Click();
                return true;
            }
            catch
            {
                return false;
            }
            
        }

        public void Quit()
        {
            driver.Close();
        }

       
    }
}
