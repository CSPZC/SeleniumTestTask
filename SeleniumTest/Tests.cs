using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Tests;

public class Tests
{
    [Test]
    public void ThisIsScriptNotTest()
    {
        IWebDriver driver = new ChromeDriver();
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        
        driver.Navigate().GoToUrl("https://www.livejournal.com/login.bml");
        driver.FindElement(By.Id("user")).SendKeys("syneltest");
        driver.FindElement(By.Id("lj_loginwidget_password")).SendKeys("123qweASD");
        driver.FindElement(By.Name("action:login")).Click();
        wait.Until(d => d.Url.Contains("livejournal.com"));
        driver.Navigate().GoToUrl("https://www.livejournal.com/post");
        driver.FindElement(By.XPath("/html/body/div[11]/div/div/div/div/div/button/span")).Click();
        wait.Until(d => d.FindElement(By.XPath("/html/body/div[1]/div/div/div[2]/textarea")) != null);

        driver.FindElement(By.XPath("/html/body/div[1]/div/div/div[2]/textarea"))
            .SendKeys("Nikita");
        driver.FindElement(By.XPath("/html/body/div[1]/div/div/div[3]/div[1]/div[2]/div/div/div/div"))
            .SendKeys("This is a test post created using Selenium in C#.");

        driver.FindElement(By.XPath("//button[.='Tune in and publish']")).Click();
        driver.FindElement(By.XPath("//button[.='Publish']")).Click();

        wait.Until(d => d.Url.Contains("/post"));
        
        driver.Quit();
    }
}