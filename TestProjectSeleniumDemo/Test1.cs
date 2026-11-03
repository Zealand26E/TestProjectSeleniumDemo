using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace TestProjectSeleniumDemo
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        public void TestMethodButtonExists()
        {
            //Arrange

            FirefoxOptions options = new FirefoxOptions();
            options.AddArguments("--headless=new");
            IWebDriver driver = new FirefoxDriver(options);

            driver.Navigate().GoToUrl(@"http://127.0.0.1:5501");

            //Act
            IWebElement button = driver.FindElement(By.Id("testButton1"));
            var buttonText = button.Text;

            //Assert
            Assert.AreEqual("Click Me", buttonText);

            driver.Quit();
        }

        [TestMethod]
        public void TestMethodButtonNotExists()
        {
            //Arrange

            //FirefoxOptions options = new FirefoxOptions();
            //options.AddArguments("--headless=new");

            IWebDriver driver = new FirefoxDriver();
            driver.Navigate().GoToUrl(@"http://127.0.0.1:5501");

            //Act

            Assert.Throws<NoSuchElementException>(() =>
            {
                IWebElement button = driver.FindElement(By.Id("testButton2"));
            });

            driver.Quit();
        }




    }
}
