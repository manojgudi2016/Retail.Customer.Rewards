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


Here are the Tables designed for this reward program project.

public class Customer
    {
        [Column("CustomerId"), DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
        public Guid Id { get; set; }

        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }
    }
Customer Table
----------------
CustomerId	FirstName	MiddleName	LastName	Email	PhoneNumber
2C2538A5-55F3-4110-562A-08DA3F91A8D6	Manoj	NULL	Reddy	manojreddy@gmail.com	9876543210
B5BE058A-36B8-4E90-562B-08DA3F91A8D6	Customer2	NULL	Ln	customer2@gmail.com	9876543211
A25A8D9B-602B-4DEE-562C-08DA3F91A8D6	Customer3	NULL	Lastn	customer3@gmail.com	9876543212




public class Product
    {
        [Column("ProductId"), DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Category { get; set; }

        public decimal Price { get; set; }

    }
Products Tables
---------------------
ProductId	Name	Category	Price
E9536B07-B248-4E6D-5830-08DA3F91A8F4	WashingMachine	Electronics	600.00
E5EEABC8-FEA4-449B-5831-08DA3F91A8F4	Refrigerator	Electronics	1850.00
098008E1-AED5-479A-5832-08DA3F91A8F4	Laptop	Electronics	950.00
EFC5DCDE-047E-4D88-5833-08DA3F91A8F4	Wall Clock	HomeDecor	25.99




public class Transaction : Trackable
    {
        [Column("TransactionId"), DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
        public Guid Id { get; set; }

        [JsonIgnore]
        public virtual Retail.Customer.Rewards.Data.Entities.Customer Customer { get; set; }

        public Guid CustomerId { get; set; }


        [JsonIgnore]
        public virtual Retail.Customer.Rewards.Data.Entities.Product Product { get; set; }

        public Guid ProductId { get; set; }
    }
Transactions Table
---------------------------
TransactionId	CreatedAt	ModifiedAt	CreatedBy	ModifieddBy	CustomerId	ProductId
6634D391-4644-4245-9019-2375D9CFC7EE	2022-04-25 01:02:38.2333333	2022-04-25 01:02:38.2333333	2C2538A5-55F3-4110-562A-08DA3F91A8D6	2C2538A5-55F3-4110-562A-08DA3F91A8D6	2C2538A5-55F3-4110-562A-08DA3F91A8D6	E5EEABC8-FEA4-449B-5831-08DA3F91A8F4
42B94B07-A757-4D92-8364-A97967F94537	2022-02-22 00:58:19.4700000	2022-02-22 00:58:45.1600000	2C2538A5-55F3-4110-562A-08DA3F91A8D6	2C2538A5-55F3-4110-562A-08DA3F91A8D6	2C2538A5-55F3-4110-562A-08DA3F91A8D6	098008E1-AED5-479A-5832-08DA3F91A8F4
842F83AE-19B4-4FF5-97BF-EBD612A13F18	2022-05-26 23:38:59.9466667	2022-05-26 23:38:59.9466667	2C2538A5-55F3-4110-562A-08DA3F91A8D6	2C2538A5-55F3-4110-562A-08DA3F91A8D6	2C2538A5-55F3-4110-562A-08DA3F91A8D6	EFC5DCDE-047E-4D88-5833-08DA3F91A8F4
3A5283E1-B21C-4A8E-8697-FDD04B1EE26F	2022-05-26 23:39:35.5700000	2022-05-26 23:39:35.5700000	2C2538A5-55F3-4110-562A-08DA3F91A8D6	2C2538A5-55F3-4110-562A-08DA3F91A8D6	2C2538A5-55F3-4110-562A-08DA3F91A8D6	098008E1-AED5-479A-5832-08DA3F91A8F4




public class RewardThresholdLevel
    {
        [Column("ThresholdId"), DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
        public int Id { get; set; }

        public string Level { get; set; }

        public decimal Threshold { get; set; }

        public int RewardPoint { get; set; }

        public bool isActive { get; set; }
    }
    
    
    
    
Threshold Table
------------------
ThresholdId	Level	Threshold	RewardPoint	isActive
1	Level1	50.00	1	1
2	Level2	100.00	1	1


SQL Script with the data and the tables will be checked into the project.


The logic to calcuate the one month rewards and 3 month rewards will be dynamically driven from the API.

Test methods are written for 1 month and 3 month rewards calculation.

Currently the data holds for one customer but it can be extended by inserting data into the SQL tables.




![image](https://user-images.githubusercontent.com/17130151/171525977-8ea169f1-ab1c-43f3-8799-ab2f26c86eaa.png)

