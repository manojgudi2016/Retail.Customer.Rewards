This solution is desinged on top of .Net Core 3.x version

It is a simple code first approach based on EF core.

Database is attached. To execute the test cases, the attached database should be attached to your local SQL server as it has some data.

For data visualization, a screenshot is attached for reference purpose.

It is not fully developed but, it has the logic to calucate reward points for all the customers (if data is feeded)

--There is lot of scope for improvement on this project
--Dataobjects should be replaced by DTOs in service layer
--Test cases can be mocked well
--Repository is currently not implemented but it should have been implemented that allows better testing too

Customer table holds data related to customers
Product table holds data related to Products 
Transaction table is the junction of Products and Customers

Rewards service has methods to calculate the logic for the rewards.
