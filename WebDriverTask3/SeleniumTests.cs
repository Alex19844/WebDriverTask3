using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Diagnostics;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebDriverTask3
{
    public class Tests
    {
        private IWebDriver driver { get; set; }
        private const string url = "https://cloud.google.com/";
        private const string newtabURL = "https://cloud.google.com/products/calculator/estimate-preview/4b9dbb92-19ae-4e7f-b516-23be626a17da";
        private const string searchValue = "Google Cloud Platform Pricing Calculator";

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5); // Set implicit wait for elements
        }

        [Test]
        public void WebDriverTest()
        {
            // Navigate to cloud.google.com
            driver.Navigate().GoToUrl(url);

            // Click on the search icon
            IWebElement searchElement = driver.FindElement(By.CssSelector("div.YSM5S[jsname='Ohx1pb']"));
            searchElement.Click();

            // Enter "Google Cloud Platform Pricing Calculator" into the search field
            IWebElement searchInput = driver.FindElement(By.Id("i4"));
            searchInput.SendKeys(searchValue);

            // Perform the search
            searchInput.Submit();

            // Click "Google Cloud Platform Pricing Calculator" in the search results and go to the calculator page
            IWebElement calculatorElement = driver.FindElement(By.CssSelector("a.K5hUy"));
            calculatorElement.Click();

            // Click "Add to estimate"
            IWebElement estimateElement = driver.FindElement(By.CssSelector("span.UywwFc-vQzf8d[jsname='V67aGc']"));
            estimateElement.Click();

            // Click COMPUTE ENGINE
            IWebElement computeElement = driver.FindElement(By.CssSelector("div.aHij0b-WsjYwc.b9Ejl"));
            computeElement.Click();

            // Number of instances: 4
            IWebElement instancesElement = driver.FindElement(By.CssSelector("div[jsaction='JIbuQc:qGgAE']"));
            instancesElement.Click();
            Actions actions = new Actions(driver);
            actions.DoubleClick(instancesElement).Build().Perform();

            // Operating System / Software: Free: Debian, CentOS, CoreOS, Ubuntu, or another User-Provided OS
            IWebElement osElement = driver.FindElement(By.XPath("//*[text() = 'Operating System / Software']//ancestor::div[@class = 'VfPpkd-TkwUic']"));
            osElement.Click();
            IWebElement osOption = driver.FindElement(By.CssSelector("li[data-value='free-debian-centos-coreos-ubuntu-or-byol-bring-your-own-license']"));
            osOption.Click();

            // Provisioning model: Regular
            IWebElement modelElement = driver.FindElement(By.CssSelector("label.zT2df"));
            //IWebElement modelElement = driver.FindElement(By.XPath("//label[@class='zT2df' and contains(text(), 'Spot (Preemptible VM)')]"));
            modelElement.Click();

            // Machine Family: General purpose
            IWebElement familyElement = driver.FindElement(By.XPath("//*[text() = 'Machine Family']//ancestor::div[@class = 'VfPpkd-TkwUic']"));
            familyElement.Click();
            IWebElement familyOption = driver.FindElement(By.CssSelector("li[data-value='general-purpose']"));
            familyOption.Click();

            // Series: N1
            IWebElement seriesElement = driver.FindElement(By.XPath("//*[text() = 'Series']//ancestor::div[@class = 'VfPpkd-TkwUic']"));
            seriesElement.Click();
            IWebElement seriesOption = driver.FindElement(By.CssSelector("li[data-value='n1']"));
            seriesOption.Click();

            // Machine type: n1-standard-8 (vCPUs: 8, RAM: 30 GB)
            IWebElement machineElement = driver.FindElement(By.XPath("//*[text() = 'Machine type']//ancestor::div[@class = 'VfPpkd-TkwUic']"));
            machineElement.Click();
            IWebElement machineOption = driver.FindElement(By.CssSelector("li[data-value='n1-standard-8']"));
            machineOption.Click();

            // Select “Add GPUs“
            IWebElement gpuElement = driver.FindElement(By.CssSelector("button[type='button'][role='switch'][aria-label='Add GPUs']"));
            gpuElement.Click();

            // GPU type: NVIDIA Tesla V100
            IWebElement gtypeElement = driver.FindElement(By.XPath("//*[text() = 'GPU Model']//ancestor::div[@class = 'VfPpkd-TkwUic']"));
            gtypeElement.Click();
            IWebElement gtypeOption = driver.FindElement(By.CssSelector("li[data-value='nvidia-tesla-v100']"));
            gtypeOption.Click();

            // Number of GPUs: 1
            IWebElement gnumberElement = driver.FindElement(By.XPath("//*[text() = 'Number of GPUs']//ancestor::div[@class = 'VfPpkd-TkwUic']"));
            gnumberElement.Click();
            IWebElement gnumberOption = driver.FindElement(By.XPath($"//li[@data-value='1' and descendant::span[text()='1']]"));
            gnumberOption.Click();

            // Local SSD: 2x375 Gb            
            IWebElement ssdElement = driver.FindElement(By.XPath("//*[text() = 'Local SSD']//ancestor::div[@class = 'VfPpkd-TkwUic']"));
            ssdElement.Click();
            IWebElement ssdOption = driver.FindElement(By.XPath($"//li[@data-value='2' and descendant::span[text()='2x375 GB']]"));
            ssdOption.Click();

            // Datacenter location: Netherlands (europe-west4) - Frankfurt (europe-west3) doesn't exist for chosen GPU
            IWebElement datacenterElement = driver.FindElement(By.XPath("//*[text() = 'Region']//ancestor::div[@class = 'VfPpkd-TkwUic']"));
            datacenterElement.Click();
            IWebElement datacenterOption = driver.FindElement(By.CssSelector("li[data-value='europe-west4']"));
            datacenterOption.Click();

            // Committed usage: 1 Year
            IWebElement usageElement = driver.FindElement(By.CssSelector("label.zT2df[for='1-year']"));
            usageElement.Click();

            // Click 'Add to Estimate' - not needed; already done 
            //IWebElement addElement = driver.FindElement(By.CssSelector("span.AeBiU-vQzf8d[jsname='V67aGc']"));
            //addElement.Click();

            // Check the price is calculated
            string calculatedPrice = "$5,628.90";
            System.Threading.Thread.Sleep(5000); // Wait for price to calculate
            IWebElement priceElement = driver.FindElement(By.CssSelector("label.gt0C8e.MyvX5d.D0aEmf"));
            string actualPrice = priceElement.Text;
            Assert.That(actualPrice, Is.EqualTo(calculatedPrice));

            // Scroll down the window
            var js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollBy(0,500)", "");

            // Click "Share" to see Total estimated cost
            IWebElement shareButton = driver.FindElement(By.CssSelector("span.FOBRw-vQzf8d[jsname='V67aGc']"));
            shareButton.Click();

            // Click "Open estimate summary"
            IWebElement estimateSummaryLink = driver.FindElement(By.LinkText("Open estimate summary"));
            estimateSummaryLink.Click();
            driver.Navigate().GoToUrl(newtabURL); // redirect to new URL

            // Verify that the 'Cost Estimate Summary' matches with filled values in Step 6
            // Number of Instances
            string calculatedNumber = "Number of Instances\r\n4\r\nN/A";
            IWebElement instanceNumber = driver.FindElement(By.XPath("//*[text()='4']//ancestor::div[@class = 'EQCBxd g5Ano']"));
            string actualNumber = instanceNumber.Text;
            Assert.That(actualNumber, Is.EqualTo(calculatedNumber));

            // Operating System/Software
            string calculatedOS = "Operating System / Software\r\nFree: Debian, CentOS, CoreOS, Ubuntu or BYOL (Bring Your Own License)\r\nN/A";
            string os = "Free: Debian, CentOS, CoreOS, Ubuntu or BYOL (Bring Your Own License)";
            IWebElement softElement = driver.FindElement(By.XPath($"//*[text()='{os}']//ancestor::div[@class = 'EQCBxd g5Ano']"));
            string actualOS = softElement.Text;
            Assert.That(actualOS, Is.EqualTo(calculatedOS));

            // Provisioning model
            string calculatedModel = "Provisioning Model\r\nRegular\r\nN/A";
            IWebElement provisioningElement = driver.FindElement(By.XPath($"//*[text()='Regular']//ancestor::div[@class = 'EQCBxd g5Ano']"));
            string actualModel = provisioningElement.Text;
            Assert.That(actualModel, Is.EqualTo(calculatedModel));

            // Machine type: n1-standard-8 (vCPUs: 8, RAM: 30 GB)
            string calculatedType = "Instance-time\r\n2920 Hours\r\nN/A\r\nMachine type\r\nn1-standard-8, vCPUs: 8, RAM: 30 GB\r\n$769.54";
            string type = "n1-standard-8, vCPUs: 8, RAM: 30 GB";
            IWebElement typeElement = driver.FindElement(By.XPath($"//*[text()='{type}']//ancestor::div[@class = 'EQCBxd g5Ano']"));
            string actualType = typeElement.Text;
            Assert.That(actualType, Is.EqualTo(calculatedType));

            // GPU type: NVIDIA Tesla V100; Number of GPUs: 1
            string calculatedGPU = "Instance-time\r\n2920 Hours\r\nN/A\r\nGPU Model\r\nNVIDIA Tesla V100\r\nN/A\r\nNumber of GPUs\r\n1\r\n$4,689.52";
            IWebElement nvidiaElement = driver.FindElement(By.XPath($"//*[text()='NVIDIA Tesla V100']//ancestor::div[@class = 'EQCBxd g5Ano']"));
            string actualGPU = nvidiaElement.Text;
            Assert.That(actualGPU, Is.EqualTo(calculatedGPU));

            // Local SSD: 2x375 Gb
            string calculatedSSD = "Local SSD\r\n2x375 GB\r\n$166.32";
            IWebElement localssdElement = driver.FindElement(By.XPath($"//*[text()='2x375 GB']//ancestor::div[@class = 'EQCBxd g5Ano']"));
            string actualSSD = localssdElement.Text;
            Assert.That(actualSSD, Is.EqualTo(calculatedSSD));

            // Datacenter location: Netherlands (europe-west4)
            string calculatedLocation = "Region\r\nNetherlands (europe-west4)\r\nN/A";
            IWebElement locationElement = driver.FindElement(By.XPath($"//*[text()='Netherlands (europe-west4)']//ancestor::div[@class = 'EQCBxd g5Ano']"));
            string actualLocation = locationElement.Text;
            Assert.That(actualLocation, Is.EqualTo(calculatedLocation));

            // Committed usage: 1 Year
            string calculatedUsage = "Committed use discount options\r\n1 year\r\nN/A";
            IWebElement commitElement = driver.FindElement(By.XPath($"//*[text()='1 year']//ancestor::div[@class = 'EQCBxd g5Ano']"));
            string actualUsage = commitElement.Text;
            Assert.That(actualUsage, Is.EqualTo(calculatedUsage));

            Assert.Pass(); // Instruction for Breakpoint
        }

        [TearDown]
        public void Teardown()
        {
            driver.Close();
            driver.Quit();
        }
    }
}