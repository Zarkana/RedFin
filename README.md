### Description
An automated test that checks whether a redfin property search returns the correct results

### How to Run
1. Download repository and open the .sln in Visual Studio
2. You will need the following plugins if not already installed in Visual Studio (DotNetSeleniumExtras.PageObjects, DotNetSeleniumExtras.WaitHelpers, NUnit, NUnit3TestAdapter, Selenium.Chrome.WebDriver, Selenium.Support, Selenium.WebDriver)
3. Build solution and then run/debug the PropertyFilterTest
4. (Optional) Manually change the string params in the the PropertyFilterTest to reflect what options you want to select and also change the number params to validate against
5. (Optional) Provide tighter params to perform negative testing and confirm that test will fail for any entries outside the valid parameters

### How it Works
1. The automation first opens http://www.redfin.com
2. Enters "Huntington Beach" into the search box
3. Clicks search and traverses to https://www.redfin.com/city/9164/CA/Huntington-Beach
4. Enters a min price, max price, min beds, max beds, and lastly minimum baths
5. Applies the filters
6. Iterates through each page of results and scrapes all the values from each page
7. validate each list of values against the inputted parameters

### Implementation Details
1. Decided to use C# and Selenium as I have most recently used both to perform web automation
2. Decided to start on the home page and navigate to the property search page as I didn't know whether we could start on the property search URL
3. I didn't know whether we were supposed to handle cases where the results where more than 1 page worth of houses, and so I opted to just support the pagination and traverse each page
4. At the beginning I decided to create a BasePage and BaseTest to inherit from just in case I wanted to share functionality and also just for forward thinking sake
5. ~~I used "Thread.Sleep(1000)" a few times to deal with some stale element exceptions, I realize there is a more elegant way of handling this, but in the interest of time I decided to just do what worked consistently and will pursue more elegant solutions utilizing explicit waits in the future~~ Now uses explicit waits to wait until animations complete on page prior to scraping data
6. In cases where beds or baths were not provided in the listing I simply let it pass since the filter _should_ be allowing those results through

