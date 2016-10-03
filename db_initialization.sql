CREATE SCHEMA `545pjcthskp`;

CREATE TABLE `545pjcthskp`.`user` (
  `userID` INT NOT NULL AUTO_INCREMENT COMMENT '',
  `username` VARCHAR(45) NOT NULL COMMENT '',
  `password` VARCHAR(45) NOT NULL COMMENT '',
  `address` VARCHAR(100) NULL COMMENT '',
  `phone` VARCHAR(45) NULL COMMENT '',
  `registerTime` DATETIME NOT NULL COMMENT '',
  PRIMARY KEY (`userID`)  COMMENT '');


CREATE TABLE `545pjcthskp`.`woker` (
  `workerID` INT NOT NULL COMMENT '',
  `type` VARCHAR(45) NOT NULL COMMENT '',
  `name` VARCHAR(45) NOT NULL COMMENT '',
  `companyID` INT NOT NULL COMMENT '',
  `SSN` INT NOT NULL COMMENT '',
  `image` VARCHAR(300) NULL COMMENT '',
  `availableTime` VARCHAR(45) NULL COMMENT '',
  `price` FLOAT NOT NULL COMMENT '',
  `nationality` VARCHAR(45) NULL COMMENT '',
  `introduction` VARCHAR(45) NULL COMMENT '',
  `fitness` VARCHAR(45) NULL COMMENT '',
  `gender` VARCHAR(45) NULL COMMENT '',
  `age` INT NULL COMMENT '',
  `hasMarried` INT NULL COMMENT '',
  `language` VARCHAR(45) NULL COMMENT '',
  `hasCertificate` INT NULL COMMENT '',
  `evaluation` VARCHAR(45) NULL COMMENT '',
  PRIMARY KEY (`workerID`)  COMMENT '');

CREATE TABLE `545pjcthskp`.`company` (
  `companyID` INT NOT NULL COMMENT '',
  `name` VARCHAR(45) NOT NULL COMMENT '',
  `foundTime` DATETIME NULL COMMENT '',
  `introduction` VARCHAR(300) NULL COMMENT '',
  PRIMARY KEY (`companyID`)  COMMENT '');

CREATE TABLE `545pjcthskp`.`order` (
  `orderID` INT NOT NULL AUTO_INCREMENT COMMENT '',
  `orderNumber` INT NOT NULL COMMENT '',
  `userID` INT NOT NULL COMMENT '',
  `workerID` INT NOT NULL COMMENT '',
  `orderState` VARCHAR(45) NOT NULL COMMENT '',
  `serviceAddress` VARCHAR(45) NOT NULL COMMENT '',
  `details` VARCHAR(45) NULL COMMENT '',
  `orderTime` DATETIME NOT NULL COMMENT '',
  `payment` FLOAT NOT NULL COMMENT '',
  `starDate` DATETIME NOT NULL COMMENT '',
  `endDate` DATETIME NOT NULL COMMENT '',
  PRIMARY KEY (`orderID`)  COMMENT '');

ALTER TABLE `545pjcthskp`.`order` 
ADD INDEX `userID_idx` (`userID` ASC)  COMMENT '',
ADD INDEX `workerID_idx` (`workerID` ASC)  COMMENT '';
ALTER TABLE `545pjcthskp`.`order` 
ADD CONSTRAINT `userID`
  FOREIGN KEY (`userID`)
  REFERENCES `545pjcthskp`.`user` (`userID`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION,
ADD CONSTRAINT `workerID`
  FOREIGN KEY (`workerID`)
  REFERENCES `545pjcthskp`.`woker` (`workerID`)
  ON DELETE RESTRICT
  ON UPDATE RESTRICT;

ALTER TABLE `545pjcthskp`.`woker` 
ADD INDEX `companyID_idx` (`companyID` ASC)  COMMENT '';
ALTER TABLE `545pjcthskp`.`woker` 
ADD CONSTRAINT `companyID`
  FOREIGN KEY (`companyID`)
  REFERENCES `545pjcthskp`.`company` (`companyID`)
  ON DELETE RESTRICT
  ON UPDATE RESTRICT;

INSERT INTO `545pjcthskp`.`user` (`userID`, `username`, `password`, `address`, `phone`, `registerTime`) VALUES ('1', 'salianu', 'bty8life', '1717 market street, seattle, ', '2062347892', '2010/10/20');
INSERT INTO `545pjcthskp`.`user` (`userID`, `username`, `password`, `address`, `phone`, `registerTime`) VALUES ('2', 'bowenrock', '911217', '\"7432 Ivy Lane \nGlen Ellyn, seatac 60137\"', '20612345678', '2011/8/23');
INSERT INTO `545pjcthskp`.`user` (`userID`, `username`, `password`, `address`, `phone`, `registerTime`) VALUES ('3', 'bjqiang8', '913269', '\"3177 8th Street West \nPoint Pleasant Beach, lynnwood 08742\"', '2534567890', '2006/7/4');
INSERT INTO `545pjcthskp`.`user` (`userID`, `username`, `password`, `address`, `phone`, `registerTime`) VALUES ('4', 'szh', '68297730zsz', '\"8922 Creek Road \nFort Worth, lakewood 76110\"', '2536127788', '2014/12/1');
INSERT INTO `545pjcthskp`.`user` (`userID`, `username`, `password`, `address`, `phone`, `registerTime`) VALUES ('5', 'tb45592', 'zwd19911217', '1717 commerse street, aubern', '2534043371', '2001/1/3');
INSERT INTO `545pjcthskp`.`user` (`userID`, `username`, `password`, `address`, `phone`, `registerTime`) VALUES ('6', 'abouterwave', 'guapo', '\"483 Lafayette Street \nGermantown, federal way 20874\"', '2025550129', '1998/12/20');
INSERT INTO `545pjcthskp`.`user` (`userID`, `username`, `password`, `address`, `phone`, `registerTime`) VALUES ('7', 'danella', 'guapa', '\"957 13th Street \nPhillipsburg, burien 08865\"', '2023450156', '1997/1/2');
INSERT INTO `545pjcthskp`.`user` (`userID`, `username`, `password`, `address`, `phone`, `registerTime`) VALUES ('8', 'nycfree', 'alto', '\"73 Ashley Court \nOxford, kirkland 3865\"', '2790218543', '2008/9/30');
INSERT INTO `545pjcthskp`.`user` (`userID`, `username`, `password`, `address`, `phone`, `registerTime`) VALUES ('9', 'jocapo', 'alta', '\"725 Smith Street \nCircle Pines,  tacoma 55014\"', '3985782345', '2004/11/21');
INSERT INTO `545pjcthskp`.`user` (`userID`, `username`, `password`, `address`, `phone`, `registerTime`) VALUES ('10', 'pounboxp', 'latinaughs', '\"792 Brandywine Drive \nVienna, university place 22180\"', '5550129824', '2001/2/3');


INSERT INTO `545pjcthskp`.`company` (`companyID`, `name`, `foundTime`, `introduction`) VALUES ('1', 'West Seattle Housekeeping', '1991-10-25', 'Small, local, eco-friendly, woman-owned housekeeping service based in and serving West Seattle.');
INSERT INTO `545pjcthskp`.`company` (`companyID`, `name`, `foundTime`, `introduction`) VALUES ('2', 'Molly Maid Seattle Eastside', '1998-05-06', 'All services are 100% guaranteed. Your satisfaction is our number one goal; if for any reason you aren\'t happy with our professional maid services, we will come back and clean the specific areas that didn\'t meet your expectations.');
INSERT INTO `545pjcthskp`.`company` (`companyID`, `name`, `foundTime`, `introduction`) VALUES ('3', 'Fivestar-Housekeeping', '2001-02-07', 'Five Star Housekeeping specialize on have the costumers happy, that is our first goal, and how we can have them happy? ');
INSERT INTO `545pjcthskp`.`company` (`companyID`, `name`, `foundTime`, `introduction`) VALUES ('4', 'Lovely Housekeeping', '2010-09-01', 'Lovely House did a very thorough cleaning of our apartment and several other apartments that we managed.');
INSERT INTO `545pjcthskp`.`company` (`companyID`, `name`, `foundTime`, `introduction`) VALUES ('5', 'The Maids', '1999-01-01', 'You\'ll be surprised at the free time you\'ll gain allowing you to explore the city with home cleaning services from The Maids. ');
INSERT INTO `545pjcthskp`.`company` (`companyID`, `name`, `foundTime`, `introduction`) VALUES ('6', 'THA House Cleaning and Housekeeping', '2013-02-02', 'The THA crew has all right tools to make your home clean,sparkling and refreshed.  ');
INSERT INTO `545pjcthskp`.`company` (`companyID`, `name`, `foundTime`, `introduction`) VALUES ('7', 'Green Wagon Cleaning, LLC', '2010-10-02', 'Green Wagon Cleaning has acquired Green Glove Cleaning! We are adding 3 new employees and 24 fabulous clients to our roster! We are very excited for this growth opportunity!');
INSERT INTO `545pjcthskp`.`company` (`companyID`, `name`, `foundTime`,`introduction`) VALUES ('8', 'Adrianne\'s Housekeeping', '2013-09-06', 'You can say \"so long\" to dirt and grime when you hire the cleaning service professionals from Adrianne\'s Housekeeping. ');
INSERT INTO `545pjcthskp`.`company` (`companyID`, `name`, `foundTime`, `introduction`) VALUES ('9', 'Simply Clean', '1997-10-05', 'Simply Clean has been a premier Seattle cleaning company since 2009, servicing all of King County for over 5 years. And while we’ve only been in Seattle since ’09, our experience in house cleaning extends much farther back. ');
INSERT INTO `545pjcthskp`.`company` (`companyID`, `name`, `foundTime`, `introduction`) VALUES ('10', 'Dana\'s Housekeeping', '2003-03-03', 'Let us help you find the perfect professional housekeeper.');




INSERT INTO `545pjcthskp`.`woker` (`workerID`, `type`, `name`, `companyID`, `SSN`, `image`, `availableTime`, `price`, `nationality`, `introduction`, `fitness`, `gender`, `age`, `hasMarried`, `language`, `hasCertificate`, `evaluation`) VALUES ('1', ' Housekeeper', 'Adelaide', '3', '876374812', '\image\head1.jpg', '9:00-13:00', '15', 'China', 'Hi, everyone', 'Good', 'Female', '27', '1', 'Chinese, English', '1', '5');
INSERT INTO `545pjcthskp`.`woker` (`workerID`, `type`, `name`, `companyID`, `SSN`, `image`, `availableTime`, `price`, `nationality`, `introduction`, `fitness`, `gender`, `age`, `hasMarried`, `language`, `hasCertificate`, `evaluation`) VALUES ('2', ' Housekeeper', 'Carmen', '2', '183747284', '\image\head2.jpg', '13:00-22:00', '35', 'USA', 'Hi, everyone', 'Good', 'Female', '37', '1', 'English', '1', '5');
INSERT INTO `545pjcthskp`.`woker` (`workerID`, `type`, `name`, `companyID`, `SSN`, `image`, `availableTime`, `price`, `nationality`, `introduction`, `fitness`, `gender`, `age`, `hasMarried`, `language`, `hasCertificate`, `evaluation`) VALUES ('3', ' Tutor', 'Carole', '4', '123435465', '\image\head3.jpg', '16:00-22:00', '22', 'USA', 'Hi, everyone', 'Good', 'Female', '42', '1', 'English', '1', '5');
INSERT INTO `545pjcthskp`.`woker` (`workerID`, `type`, `name`, `companyID`, `SSN`, `image`, `availableTime`, `price`, `nationality`, `introduction`, `fitness`, `gender`, `age`, `hasMarried`, `language`, `hasCertificate`, `evaluation`) VALUES ('4', ' Babysiter', 'Daphne', '7', '674536543', '\image\head4.jpg', '5:00-10:00', '40', 'Philippines', 'Hi, everyone', 'Good', 'Female', '41', '1', 'English, Philipino', '1', '4');
INSERT INTO `545pjcthskp`.`woker` (`workerID`, `type`, `name`, `companyID`, `SSN`, `image`, `availableTime`, `price`, `nationality`, `introduction`, `fitness`, `gender`, `age`, `hasMarried`, `language`, `hasCertificate`, `evaluation`) VALUES ('5', ' Tutor', 'Ellen', '7', '783920341', '\image\head5.jpg', '7:00-14:00', '60', 'Philippines ', 'Hi, everyone', 'Good', 'Female', '35', '0', 'English,Philipino', '1', '3');
INSERT INTO `545pjcthskp`.`woker` (`workerID`, `type`, `name`, `companyID`, `SSN`, `image`, `availableTime`, `price`, `nationality`, `introduction`, `fitness`, `gender`, `age`, `hasMarried`, `language`, `hasCertificate`, `evaluation`) VALUES ('6', ' Housekeeper', 'Felicia', '9', '234637543', '\image\head6.jpg', '8:00-17:00', '38', 'China', 'Hi, everyone', 'Good', 'Female', '39', '1', 'English,Chinese', '0', '4');
INSERT INTO `545pjcthskp`.`woker` (`workerID`, `type`, `name`, `companyID`, `SSN`, `image`, `availableTime`, `price`, `nationality`, `introduction`, `fitness`, `gender`, `age`, `hasMarried`, `language`, `hasCertificate`, `evaluation`) VALUES ('7', ' Tutor', 'Hilda', '8', '123332778', '\image\head7.jpg', '8:00-17:00', '18', 'USA', 'Hi, everyone', 'Good', 'Female', '36', '1', 'English', '1', '5');
INSERT INTO `545pjcthskp`.`woker` (`workerID`, `type`, `name`, `companyID`, `SSN`, `image`, `availableTime`, `price`, `nationality`, `introduction`, `fitness`, `gender`, `age`, `hasMarried`, `language`, `hasCertificate`, `evaluation`) VALUES ('8', ' Housekeeper', 'Katherine', '3', '888955676', '\image\head8.jpg', '9:00-17:00', '26', 'India', 'Hi, everyone', 'Good', 'Female', '29', '0', 'Indian,English', '0', '5');
INSERT INTO `545pjcthskp`.`woker` (`workerID`, `type`, `name`, `companyID`, `SSN`, `image`, `availableTime`, `price`, `nationality`, `introduction`, `fitness`, `gender`, `age`, `hasMarried`, `language`, `hasCertificate`, `evaluation`) VALUES ('9', ' Babysiter ', 'Leona', '1', '334587692', '\image\head9.jpg', '9:00-17:00', '32', 'USA', 'Hi, everyone', 'Good', 'Female', '37', '1', 'English', '0', '4');
INSERT INTO `545pjcthskp`.`woker` (`workerID`, `type`, `name`, `companyID`, `SSN`, `image`, `availableTime`, `price`, `nationality`, `introduction`, `fitness`, `gender`, `age`, `hasMarried`, `language`, `hasCertificate`, `evaluation`) VALUES ('10', ' Babysiter', 'Madeline', '5', '190009835', '\image\head10.jpg', '12:00-17:00', '29', 'USA', 'Hi, everyone', 'Good', 'Female', '29', '1', 'English', '1', '5');

INSERT INTO `545pjcthskp`.`order` (`orderID`, `orderNumber`, `userID`, `workerID`, `orderState`, `serviceAddress`, `orderTime`, `payment`, `starDate`, `endDate`) VALUES ('1', '10000', '6', '5', 'Paid', '\"483 Lafayette Street ', '2015-11-20', '50', '2015-11-20', '2015-11-21');
INSERT INTO `545pjcthskp`.`order` (`orderID`, `orderNumber`, `userID`, `workerID`, `orderState`, `serviceAddress`, `orderTime`, `payment`, `starDate`, `endDate`) VALUES ('2', '10001', '6', '7', 'Paid', '\"483 Lafayette Street ', '2015-11-20', '38', '2015-11-20', '2015-11-20');
INSERT INTO `545pjcthskp`.`order` (`orderID`, `orderNumber`, `userID`, `workerID`, `orderState`, `serviceAddress`, `orderTime`, `payment`, `starDate`, `endDate`) VALUES ('3', '10002', '4', '5', 'Paid', '\"8922 Creek Road ', '2015-11-20', '20', '2015-11-20', '2015-11-20');
INSERT INTO `545pjcthskp`.`order` (`orderID`, `orderNumber`, `userID`, `workerID`, `orderState`, `serviceAddress`, `orderTime`, `payment`, `starDate`, `endDate`) VALUES ('4', '10003', '3', '2', 'Paid', ' \"3177 8th Street West ', '2015-11-23', '21', '2015-11-23', '2015-11-23');
INSERT INTO `545pjcthskp`.`order` (`orderID`, `orderNumber`, `userID`, `workerID`, `orderState`, `serviceAddress`, `orderTime`, `payment`, `starDate`, `endDate`) VALUES ('5', '10004', '8', '5', 'Paid', '\"73 Ashley Court ', '2015-11-23', '29', '2015-11-23', '2015-11-24');
INSERT INTO `545pjcthskp`.`order` (`orderID`, `orderNumber`, `userID`, `workerID`, `orderState`, `serviceAddress`, `orderTime`, `payment`, `starDate`, `endDate`) VALUES ('6', '10005', '8', '4', 'Paid', '\"73 Ashley Court ', '2015-11-18', '30', '2015-11-19', '2015-11-10');
INSERT INTO `545pjcthskp`.`order` (`orderID`, `orderNumber`, `userID`, `workerID`, `orderState`, `serviceAddress`, `orderTime`, `payment`, `starDate`, `endDate`) VALUES ('7', '10006', '7', '3', 'NotPaid', '\"957 13th Street ', '2015-11-18', '18', '2015-11-19', '2015-11-10');
INSERT INTO `545pjcthskp`.`order` (`orderID`, `orderNumber`, `userID`, `workerID`, `orderState`, `serviceAddress`, `orderTime`, `payment`, `starDate`, `endDate`) VALUES ('8', '10007', '1', '8', 'NotPaid', '1717 market street, seattle, ', '2015-11-18', '18', '2015-11-18', '2015-11-18');
INSERT INTO `545pjcthskp`.`order` (`orderID`, `orderNumber`, `userID`, `workerID`, `orderState`, `serviceAddress`, `orderTime`, `payment`, `starDate`, `endDate`) VALUES ('9', '10008', '2', '9', 'Finished', '\"7432 Ivy Lane ', '2015-11-26', '18', '2015-11-26', '2015-11-26');
INSERT INTO `545pjcthskp`.`order` (`orderID`, `orderNumber`, `userID`, `workerID`, `orderState`, `serviceAddress`, `orderTime`, `payment`, `starDate`, `endDate`) VALUES ('10', '10009', '2', '1', 'Finished', '\"7432 Ivy Lane ', '2015-11-26', '21', '2015-11-26', '2015-11-26');
