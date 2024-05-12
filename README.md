# WebDriver. Task 3

Practical Task for Selenium WebDriver using NUnit framework.

## Task Description

Automate the following script:

1. Open https://cloud.google.com/.
2. Click on the icon at the top of the portal page and enter "Google Cloud Platform Pricing Calculator" into the search field.
3. Perform the search.
4. Click "Google Cloud Platform Pricing Calculator" in the search results and go to the calculator page.
5. Click COMPUTE ENGINE at the top of the page.
6. Fill out the form with the following data:
   * Number of instances: 4
   * What are these instances for?: leave blank
   * Operating System / Software: Free: Debian, CentOS, CoreOS, Ubuntu, or another User-Provided OS
   * Provisioning model: Regular
   * Machine Family: General purpose 
   * Series: N1 
   * Machine type: n1-standard-8 (vCPUs: 8, RAM: 30 GB)
   * Select “Add GPUs“
           * GPU type: NVIDIA Tesla V100
           * Number of GPUs: 1
   * Local SSD: 2x375 Gb
   * Datacenter location: Frankfurt (europe-west3)
   * Committed usage: 1 Year
Other options leave in the default state.
7. Click 'Add to Estimate'.
8. Check the price is calculated in the right section of the calculator. There is a line “Total Estimated Cost: USD ${amount} per 1 month” 
9. click "Share" to see Total estimated cost
10. click "Open estimate summary" to see Cost Estimate Summary, will be opened in separate tab browser.
11. verify that the 'Cost Estimate Summary' matches with filled values in Step 6.

 ## Task Implementation

 The "WebDriverTask3" project has been created. SeleniumTests.cs file has been added for tests.
 
 All functionality is implemented.
 
