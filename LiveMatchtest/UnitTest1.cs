using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Threading;

namespace LiveMatchtest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {

    
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("no-sandbox");


            ChromeDriver driver = new ChromeDriver(ChromeDriverService.CreateDefaultService(), options, TimeSpan.FromMinutes(5));

            driver.Manage().Timeouts().PageLoad.Add(TimeSpan.FromMinutes(5));


            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl("https://cricket.yahoo.net/fixtures-results/commentary/australia-vs-new-zealand-1st-odi-13th-march-2020-live-scores-aunz03132020190718");


            FunctionLibrary.waitForElement(driver, "//*[@class='si-data-wrap']/div[1]/span/em");


            string countrynameA = driver.FindElement(By.XPath("//*[@class='si-data-wrap']/div[1]/span/em")).Text;

            FunctionLibrary.waitForElement(driver, "//*[@class='si-data-wrap']/div[3]/span/em");

            string countrynameB = driver.FindElement(By.XPath("//*[@class='si-data-wrap']/div[3]/span/em")).Text;

            FunctionLibrary.waitForElement(driver, "//*[@class='si-status']");

            string status = driver.FindElement(By.XPath("//*[@class='si-status']")).Text;

            string smallstatus = status.ToLower();

           string countrynameBS = countrynameB.ToLower();

            string countrynameAS = countrynameA.ToLower();

            if(smallstatus.Contains(countrynameBS))
            {
                FunctionLibrary.waitForElement(driver, "//*[@class='si-data si-teamB si-active']//*[@class='si-ove']");

                FunctionLibrary.MouseOver(driver, "//*[@class='si-data si-teamB si-active']//*[@class='si-ove']");

                string ballcount = driver.FindElement(By.XPath("//*[@class='si-data si-teamB si-active']//*[@class='si-ove']")).Text;



                string count1 = (ballcount.Substring(1, 2));

                Console.WriteLine(count1);

                int c1 = Convert.ToInt32(count1);

                string count2 = ballcount.Substring(4, 1);

                string overcount = count1 + "." + count2;


                FunctionLibrary.ScrollToBottomMC(driver);

                Thread.Sleep(2000);

                int wides = driver.FindElements(By.XPath("//*[text()='wd']")).Count;
                int nballs = driver.FindElements(By.XPath("//*[text()='nb']")).Count;

                int wkts = driver.FindElements(By.XPath("//*[@class='si-box' and text()='W']")).Count;
                try
                {
                    for (int i = 0; i <= c1; i++)
                    {
                        for (int j = 1; j <= 6; j++)
                        {
                            String s = i + "." + j;

                            FunctionLibrary.waitForElement(driver, "//*[@class='si-overs'and text()='" + s + "']");


                            string overs = FunctionLibrary.ElementText(driver, "//*[@class='si-overs'and text()='" + s + "']");

                            //    Console.WriteLine(overs);


                            if (s.Equals(overs))
                            {

                                FunctionLibrary.waitForElement(driver, "//*[@class='si-overs'and text()='" + s + "']");

                                FunctionLibrary.MouseOver(driver, "//*[@class='si-overs'and text()='" + s + "']");
                                Console.WriteLine(s + " Ball passed");


                            }

                            if (s.Contains(overcount))
                            {

                                break;
                            }
                        }

                    }


                }

                catch
                {

                    Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();

                    ss.SaveAsFile(@".\Screenshot\\image123.png");
                }
                if (smallstatus.Contains("innings break"))
                {
                    driver.Navigate().GoToUrl("https://cricket.yahoo.net/fixtures-results/scorecard/australia-vs-new-zealand-1st-odi-13th-march-2020-live-scores-aunz03132020190718");


                    FunctionLibrary.waitForElement(driver, "//*[@class='si-dv-col si-rgt-cols']/span[3]/em");

                    FunctionLibrary.MouseOver(driver, "//*[@class='si-dv-col si-rgt-cols']/span[3]/em");

                    string NoBalls = driver.FindElement(By.XPath("//*[@class='si-dv-col si-rgt-cols']/span[3]/em")).Text;


                    int noball = Convert.ToInt32(NoBalls);

                    FunctionLibrary.waitForElement(driver, "//*[@class='si-dv-col si-rgt-cols']/span[4]/em");

                    FunctionLibrary.MouseOver(driver, "//*[@class='si-dv-col si-rgt-cols']/span[4]/em");

                    string widescount = driver.FindElement(By.XPath("//*[@class='si-dv-col si-rgt-cols']/span[4]/em")).Text;


                    int widecount = Convert.ToInt32(widescount);


                }
            }
            if (smallstatus.Contains(countrynameAS))
            {



                FunctionLibrary.waitForElement(driver, "//*[@class='si-data si-teamA si-active']//*[@class='si-ove']");

                FunctionLibrary.MouseOver(driver, "//*[@class='si-data si-teamA si-active']//*[@class='si-ove']");

                string ballcount = driver.FindElement(By.XPath("//*[@class='si-data si-teamA si-active']//*[@class='si-ove']")).Text;



                string count1 = (ballcount.Substring(1, 2));

                Console.WriteLine(count1);

                int c1 = Convert.ToInt32(count1);

                string count2 = ballcount.Substring(4, 1);

                string overcount = count1 + "." + count2;


                FunctionLibrary.ScrollToBottomMC(driver);

                Thread.Sleep(2000);

                int wides = driver.FindElements(By.XPath("//*[text()='wd']")).Count;
                int nballs = driver.FindElements(By.XPath("//*[text()='nb']")).Count;

                int wkts = driver.FindElements(By.XPath("//*[@class='si-box' and text()='W']")).Count;


                try
                {
                    for (int i = 0; i <= c1; i++)
                    {
                        for (int j = 1; j <= 6; j++)
                        {
                            String s = i + "." + j;

                            FunctionLibrary.waitForElement(driver, "//*[@class='si-overs'and text()='" + s + "']");


                            string overs = FunctionLibrary.ElementText(driver, "//*[@class='si-overs'and text()='" + s + "']");

                            //    Console.WriteLine(overs);


                            if (s.Equals(overs))
                            {

                                FunctionLibrary.waitForElement(driver, "//*[@class='si-overs'and text()='" + s + "']");

                                FunctionLibrary.MouseOver(driver, "//*[@class='si-overs'and text()='" + s + "']");
                                Console.WriteLine(s + " Ball passed");


                            }

                            if (s.Contains(overcount))
                            {

                                break;
                            }
                        }

                    }


                }

                catch
                {

                    Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();

                    ss.SaveAsFile(@".\Screenshot\\image123.png");
                }
                if (smallstatus.Contains("innings break"))
                {
                    driver.Navigate().GoToUrl("https://cricket.yahoo.net/fixtures-results/scorecard/bangladesh-vs-zimbabwe-2nd-t20i-11th-march-2020-live-scores-bazm03112020194190");


                    FunctionLibrary.waitForElement(driver, "//*[@class='si-dv-col si-rgt-cols']/span[3]/em");

                    FunctionLibrary.MouseOver(driver, "//*[@class='si-dv-col si-rgt-cols']/span[3]/em");

                    string NoBalls = driver.FindElement(By.XPath("//*[@class='si-dv-col si-rgt-cols']/span[3]/em")).Text;


                    int noball = Convert.ToInt32(NoBalls);

                    FunctionLibrary.waitForElement(driver, "//*[@class='si-dv-col si-rgt-cols']/span[4]/em");

                    FunctionLibrary.MouseOver(driver, "//*[@class='si-dv-col si-rgt-cols']/span[4]/em");

                    string widescount = driver.FindElement(By.XPath("//*[@class='si-dv-col si-rgt-cols']/span[4]/em")).Text;


                    int widecount = Convert.ToInt32(widescount);


                    if(widecount.Equals(wides))
                    {
                        Console.WriteLine("Wides passed" + widescount);
                    }

                    if(noball.Equals(nballs))
                    {

                        Console.WriteLine("No balls passed" + noball);
                    }

                }

            }

            
           

            
            
        }

   

    }
}
