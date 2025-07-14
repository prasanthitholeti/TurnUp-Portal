using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V136.Browser;
using OpenQA.Selenium.Edge;
using System.Xml.Linq;

internal class Program
{
    private static void Main(string[] args)
    {
        //open Chrome Browser
        IWebDriver driver = new EdgeDriver();


        //open TurnUp login page
        driver.Navigate().GoToUrl("http://horse.industryconnect.io/Account/Login?ReturnUrl=%2f");

        //enter Username 
        IWebElement UsernameTextbox = driver.FindElement(By.Id("UserName"));
        UsernameTextbox.SendKeys("hari");

        //Enter Password
        IWebElement PasswordTextbox = driver.FindElement(By.Id("Password"));
        PasswordTextbox.SendKeys("123123");

        //click on login button
        IWebElement LoginButton = driver.FindElement(By.XPath("//*[@id=\"loginForm\"]/form/div[3]/input[1]"));
        LoginButton.Click();
        driver.Manage().Window.Maximize();

        //check if logged in successfully
        IWebElement HelloHariText = driver.FindElement(By.XPath("//*[@id=\"logoutForm\"]/ul/li"));


        if (HelloHariText.Text == "Hello hari!")
        {
            Console.WriteLine("logged in successfully test passed");
        }
        else
        {
            Console.WriteLine("login unsuccessful test failed");
        }

        //Create time record

        //Navigate to time and material page
        IWebElement admistrationtab = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul[1]/li[5]/a"));
        admistrationtab.Click();

        IWebElement timeAndMaterialOption = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul[1]/li[5]/ul/li[3]/a"));
        timeAndMaterialOption.Click();
        Thread.Sleep(1000);

        //Click on create new button
        IWebElement createNewTimeEntry = driver.FindElement(By.XPath("//*[@id=\"container\"]/p/a"));
        createNewTimeEntry.Click();

        //Select time from drop down
        IWebElement newTypeCodeListBox = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span"));
        newTypeCodeListBox.Click();

        IWebElement timeOption = driver.FindElement(By.XPath("//*[@id=\"TypeCode_listbox\"]/li[2]"));
        timeOption.Click();

        //Type code into code textbox
        IWebElement codeTextBox = driver.FindElement(By.Id("Code"));
        codeTextBox.SendKeys("Test Pro");

        //Type description into description textbox
        IWebElement descriptionTextBox = driver.FindElement(By.Id("Description"));
        descriptionTextBox.SendKeys("TestProResult");

        //Type price into price textbox
        IWebElement priceTextBoxOverlap = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
        priceTextBoxOverlap.Click();

        IWebElement priceTextBox = driver.FindElement(By.Id("Price"));
        priceTextBox.SendKeys("143");

        //Click on save button
        IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
        saveButton.Click();
        Thread.Sleep(3000);

        //Check if the Time entry is successful
        IWebElement goToLastPage = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
        goToLastPage.Click();

        IWebElement myLastCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));

        if (myLastCode.Text == "Test Pro")
        {
            Console.WriteLine("Entry Found Successfully");
        }
        else
        {
            Console.WriteLine("Entry Not Found");

        }

        //Edit Last Record
        IWebElement editLastRecordButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
        editLastRecordButton.Click();

        // Edit Code TextBox
        IWebElement editCodeTextBox = driver.FindElement(By.Id("Code"));
        editCodeTextBox.Clear();
        editCodeTextBox.SendKeys("Test Pro12");

        //Click on saveEditRecord
        IWebElement saveEditRecord = driver.FindElement(By.Id("SaveButton"));
        saveEditRecord.Click();
        Thread.Sleep(3000);

        //Check if the Time entry is successful
        IWebElement goToLastEditRecord = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
        goToLastEditRecord.Click();

        IWebElement myLastEditRecodeCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));

        if (myLastEditRecodeCode.Text == "Test Pro12")
        {
            Console.WriteLine("Edited Entry Found Successfully");
        }
        else
        {
            Console.WriteLine("Edited Entry Not Found");

        }

        //Delete last Record
        // IWebElement lastEntryRecord = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
        //  try
        // {
        //    lastEntryRecord.click();
        // }
        // catch (StaleElementReferenceException e)
        // {
        //    lastEntryRecord = driver.findElement(By.id("example"));
        //     element.click();
        // }

        IWebElement deleteLastEntryRecord = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
        deleteLastEntryRecord.Click();
        Thread.Sleep(2000);

        // Switch to the alert popup
        IAlert confirmationAlert = driver.SwitchTo().Alert();

        // Accept the confirmation popup (click "OK")
        confirmationAlert.Accept();
        Thread.Sleep(3000);

        bool lastRecordisDeleted = driver.FindElements(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]")).Count == 0;
        if (lastRecordisDeleted)
        {
            Console.WriteLine("Item successfully deleted.");
        }
        else
        {
            Console.WriteLine("Item deletion failed.");
        }


        // Alternatively, to dismiss the popup (click "Cancel"), use:
        // confirmationAlert.Dismiss();
        //Close Browser

        driver.Quit();
    } 


    }


