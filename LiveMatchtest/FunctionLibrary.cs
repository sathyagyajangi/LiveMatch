using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using excel = Microsoft.Office.Interop.Excel;

namespace LiveMatchtest
{
    class FunctionLibrary
    {




        public static void clickAction(IWebDriver driver, string LocaterValue, string LocaterType)
        {
            if (LocaterType == "id")
            {
                driver.FindElement(By.Id(LocaterValue)).Click();
            }
            if (LocaterType == "xpath")
            {
                driver.FindElement(By.XPath(LocaterValue)).Click();
            }


        }

        public static void TypeAction(IWebDriver driver, string LocaterValue, string LocaterType, string Value)
        {
            if (LocaterType == "id")
            {
                driver.FindElement(By.Id(LocaterValue)).Clear();
                driver.FindElement(By.Id(LocaterValue)).SendKeys(Value);

            }
            if (LocaterType == "xpath")
            {
                driver.FindElement(By.XPath(LocaterValue)).Clear();
                driver.FindElement(By.XPath(LocaterValue)).SendKeys(Value);
            }
        }

        public static void MouseOver(IWebDriver driver, string LocaterValue)

        {
            FunctionLibrary.waitForElement(driver, LocaterValue);

            IWebElement element = driver.FindElement(By.XPath(LocaterValue));



            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(); ", element);

            Actions action = new Actions(driver);

            action.MoveToElement(element).Perform();


        }

        public static void CssMouseOver(IWebDriver driver, string LocaterValue)

        {
            IWebElement element = driver.FindElement(By.CssSelector(LocaterValue));

            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(); ", element);

            Actions action = new Actions(driver);

            action.MoveToElement(element).Perform();


        }


        public static void waitForElement(IWebDriver driver, string Locatervalue)

        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromMinutes(10));

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Locatervalue)));


        }

        public static void screenShot(IWebDriver driver)
        {

            string imgName = DateTime.Now.ToString("dd/MM/yyyy-HH-mm-ss");


            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();

            ss.SaveAsFile(@"C:\Users\Satyanarayan\source\repos\YahooSmokeTest\YahooSmokeTest\Screenshot\\" + imgName + ".png");

        }

       public static string ReadDataExcel(int S, int i, int j)
        {
            excel.Application xlapp = new excel.Application();

            excel.Workbook xlworkbook = xlapp.Workbooks.Open(@"D:\FindingBrokenImages\TestInput.xlsx");

            excel._Worksheet xlworksheet = xlworkbook.Sheets[S];

            excel.Range xlrange = xlworksheet.UsedRange;

            string data = xlrange.Cells[i][j].value2;

            return data;
         

        }

        public static void contextClick(IWebDriver driver, string LocaterValue)
        {
            IWebElement element = driver.FindElement(By.XPath(LocaterValue));

            Actions action = new Actions(driver);

            action.ContextClick(element).Perform();

            action.SendKeys(Keys.ArrowRight).Perform();

            action.SendKeys(Keys.Enter).Perform();



        }

        public static void CtrlClick(IWebDriver driver, string Locatervalue)
        {
            IWebElement element = driver.FindElement(By.XPath(Locatervalue));

            Actions action = new Actions(driver);

            action.MoveToElement(element);

            action.KeyDown(Keys.Control).Perform();

            action.Click().Perform();

        }

        public static string ElementText(IWebDriver driver, string locaterValue)
        {

            string text = driver.FindElement(By.XPath(locaterValue)).Text;


            return text;

        }


        public static  int  ballCount(IWebDriver driver,string LocaterVaue)
        {


            string ballcount=FunctionLibrary.ElementText(driver, LocaterVaue);


           


                string count1 = (ballcount.Substring(1, 2));

               

                string count2 = ballcount.Substring(4, 1);

            

                int Icount1 = Convert.ToInt32(count1);

                int Icount2 = Convert.ToInt32(count2);


             int  Bcount = Icount1 * 6 + Icount2;


            return Bcount;
            

            


        }
        public static void  ScrollToBottomMC(IWebDriver driver)

        {

            for (int i = 1; i <= 100; i++)
            {
                try
                {

                    string si = driver.FindElement(By.XPath("//*[@class='si-overs' and text()=0.1]")).Text;

                    if (si.Contains("(0.1)"))

                    {
                        FunctionLibrary.waitForElement(driver, "//*[@class='footer-link container']");
                        FunctionLibrary.MouseOver(driver, "//*[@class='footer-link container']");
                        break;

                    }
                }


                catch
                {
                    FunctionLibrary.waitForElement(driver, "//*[@class='footer-link container']");

                    IWebElement element = driver.FindElement(By.XPath("//*[@class='footer-link container']"));


                    FunctionLibrary.MouseOver(driver, "//*[@class='footer-link container']");

                }


            }


        }


        public static void OpenApplication(string Url)
        {

            ChromeOptions options = new ChromeOptions();
            options.AddArguments("no-sandbox");


            ChromeDriver driver = new ChromeDriver(ChromeDriverService.CreateDefaultService(), options, TimeSpan.FromMinutes(5));

            driver.Manage().Timeouts().PageLoad.Add(TimeSpan.FromMinutes(5));

            driver.Navigate().GoToUrl(Url);

            driver.Manage().Window.Maximize();

           

        }
        public static void DropDown(IWebDriver driver, String LocatorValue, String Value)
        {
            IWebElement element = driver.FindElement(By.XPath(LocatorValue));
            SelectElement sel = new SelectElement(element);
            sel.SelectByText(Value);
        }

        
    }
}
