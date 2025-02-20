
-- ----------------------------
-- Table structure for Workdetails
-- ----------------------------
CREATE TABLE `billworkdetails` (
  `Billid` int(11) default NULL,
  `Workorderid` int(11) default NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;


-- ----------------------------
-- Table structure for workorderadvancedetails
-- ----------------------------
CREATE TABLE `workorderadvancedetails` (
  `Referencetypeid` int(15) default NULL,
  `Voucherid` int(15) default NULL,
  `Workorderid` int(15) default NULL,
  `Amount` int(15) default NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Table structure for workorderadvancemodedetails
-- ----------------------------
CREATE TABLE `workorderadvancemodedetails` (
  `Workorderid` int(15) default NULL,
  `Mode` int(5) default NULL,
  `Accountheadid` int(15) default NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Table structure for workorderalbumsizedetails
-- ----------------------------
CREATE TABLE `workorderalbumsizedetails` (
  `workorderid` int(20) default NULL,
  `sizeid` int(20) default NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Table structure for workorderdetails
-- ----------------------------
CREATE TABLE `workorderdetails` (
  `Wodetailid` int(11) NOT NULL default '0',
  `Wostatus` int(11) default NULL,
  `Departmentid` int(11) default NULL,
  `Wodate` date default NULL,
  `Wotime` float default NULL,
  `Cdate` date default NULL,
  `Ctime` float default NULL,
  `Staffid` int(11) default NULL,
  `Workorderid` int(11) default NULL,
  `workflowno` int(15) default NULL,
  `cstatus` int(11) default '0',
  `descr` varchar(225) default NULL,
  PRIMARY KEY  (`Wodetailid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Table structure for workordermaster
-- ----------------------------
CREATE TABLE `workordermaster` (
  `Workorderid` int(11) NOT NULL default '0',
  `Workorderno` varchar(300) default NULL,
  `Customerid` int(11) default NULL,
  `Worktypeid` int(11) default NULL,
  `Noofphoto` int(11) default NULL,
  `Wdate` date default NULL,
  `Wtime` varchar(255) default NULL,
  `Ddate` date default NULL,
  `Dtime` varchar(255) default NULL,
  `Workstatus` int(11) default NULL,
  `Type` int(11) default NULL,
  `Description` text,
  `Remarks` text,
  `Deliverytypeid` int(11) default NULL,
  `Cstatus` int(11) default NULL,
  `id` int(11) default NULL,
  `machineid` int(11) default NULL,
  `noofcopies` int(11) default NULL,
  `staffid` int(11) default NULL,
  `wno` int(25) default NULL,
  `SE_ID` int(5) default NULL,
  `Ordervia` varchar(100) default NULL,
  `Branchid` int(11) default NULL,
  PRIMARY KEY  (`Workorderid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Table structure for workordertaxdetails
-- ----------------------------
CREATE TABLE `workordertaxdetails` (
  `workorderid` int(15) default NULL,
  `taxid` int(20) default NULL,
  `amount` double(15,2) default NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Table structure for workordertimedetails
-- ----------------------------
CREATE TABLE `workordertimedetails` (
  `Workorderid` int(11) default NULL,
  `Totalhr` float default NULL,
  `ybdate` date default NULL,
  `ybtime` varchar(255) default NULL,
  `rbdate` date default NULL,
  `rbtime` varchar(255) default NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Table structure for transactiondetails
-- ----------------------------
CREATE TABLE `transactiondetails` (
  `Transactiondetailsid` int(11) NOT NULL default '0',
  `Voucherid` int(11) NOT NULL,
  `AccountHeadId` int(11) NOT NULL,
  `Narration` text NOT NULL,
  `amount` double(50,4) default NULL,
  `DrCr` varchar(255) NOT NULL,
  PRIMARY KEY  (`Transactiondetailsid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Table structure for transactionmain
-- ----------------------------
CREATE TABLE `transactionmain` (
  `Voucherid` int(11) NOT NULL,
  `Voucherno` varchar(255) NOT NULL,
  `Voucherdate` date NOT NULL,
  `BranchID` int(11) NOT NULL,
  `Mode` varchar(20) NOT NULL,
  `Tallyid` int(11) default NULL,
  PRIMARY KEY  (`Voucherid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Table structure for transactionstaffdetails
-- ----------------------------
CREATE TABLE `transactionstaffdetails` (
  `Transactionstaffid` int(20) NOT NULL default '0',
  `Voucherid` int(20) default NULL,
  `Staffid` int(20) default NULL,
  `Mode` int(5) default NULL,
  PRIMARY KEY  (`Transactionstaffid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Table structure for receiptmaster
-- ----------------------------
CREATE TABLE `receiptmaster` (
  `Receiptid` int(20) NOT NULL default '0',
  `Receiptno` int(50) default NULL,
  `Voucherid` int(20) default NULL,
  PRIMARY KEY  (`Receiptid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Table structure for worktype
-- ----------------------------
CREATE TABLE `worktype` (
  `Worktypeid` int(11) NOT NULL default '0',
  `Typename` varchar(255) default NULL,
  `commercialornot` int(5) default NULL,
  `discount` int(5) default NULL,
  PRIMARY KEY  (`Worktypeid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Table structure for albumsizedetails
-- ----------------------------
CREATE TABLE `albumsizedetails` (
  `sizeid` int(15) NOT NULL,
  `size` varchar(250) default NULL,
  PRIMARY KEY  (`sizeid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Table structure for areamaster
-- ----------------------------
CREATE TABLE `areamaster` (
  `AreaID` int(11) default NULL,
  `AreaName` varchar(255) default NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Table structure for customerreg
-- ----------------------------
CREATE TABLE `customerreg` (
  `Customerid` int(11) NOT NULL default '0',
  `Customername` varchar(1000) default NULL,
  `Studioname` varchar(1000) default NULL,
  `Address1` varchar(2500) default NULL,
  `Address2` varchar(2500) default NULL,
  `Address3` varchar(2500) default NULL,
  `STATE` varchar(2500) default NULL,
  `Phoneno` varchar(500) default NULL,
  `Mobile` varchar(500) default NULL,
  `Email` varchar(2500) default NULL,
  `Remarks` varchar(5000) default NULL,
  `Categoryid` int(11) default NULL,
  `RateType` varchar(25) default NULL,
  `Staffid` int(11) default NULL,
  `Discount` double(15,2) default NULL,
  `MODE` int(10) default NULL,
  `area` varchar(10) default NULL,
  `Regionid` int(10) default NULL,
  `Typeid` int(10) default NULL,
  `CustomerTypeid` int(10) default NULL,
  `Branchid` int(11) default NULL,
  `whatsappno` varchar(20) default NULL,
  PRIMARY KEY  (`Customerid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Table structure for deliverymaster
-- ----------------------------
CREATE TABLE `deliverymaster` (
  `Deliverytypeid` int(11) NOT NULL default '0',
  `Deliveryname` varchar(255) default NULL,
  `Remarks` varchar(255) default NULL,
  PRIMARY KEY  (`Deliverytypeid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Table structure for machinereg
-- ----------------------------
CREATE TABLE `machinereg` (
  `Machineid` int(11) NOT NULL default '0',
  `Machinename` varchar(255) default NULL,
  `Maxpaperwidth` float default NULL,
  `Maxpaperheight` float default NULL,
  `Imagepath` varchar(255) default NULL,
  PRIMARY KEY  (`Machineid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Table structure for mainheadreg
-- ----------------------------
CREATE TABLE `mainheadreg` (
  `Mainheadid` int(11) NOT NULL default '0',
  `Headname` varchar(255) default NULL,
  `Remarks` varchar(255) default NULL,
  `Discount` int(10) default NULL,
  `custom` int(5) default NULL,
  `remarkstatus` int(5) default '0',
  PRIMARY KEY  (`Mainheadid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Table structure for subheadconditionmaster
-- ----------------------------
CREATE TABLE `subheadconditionmaster` (
  `id` int(11) NOT NULL default '0',
  `Mainheadid` int(11) default NULL,
  `Maxpage` varchar(255) default NULL,
  `Extrarate` varchar(255) default NULL,
  `Mode` int(11) default NULL,
  PRIMARY KEY  (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Table structure for deliverymode
-- ----------------------------
CREATE TABLE `deliverymode` (
  `id` int(11) NOT NULL default '0',
  `Name` varchar(255) default NULL,
  PRIMARY KEY  (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Table structure for departmentmaster
-- ----------------------------
CREATE TABLE `departmentmaster` (
  `Departmentid` int(11) NOT NULL default '0',
  `Departmentname` varchar(255) default NULL,
  `Remarks` varchar(255) default NULL,
  `Status` int(11) default NULL,
  `slno` int(11) default NULL,
  `woeditstatus` int(11) default NULL,
  `Noofwork` int(11) default NULL,
  `webdisplay` int(5) default NULL,
  PRIMARY KEY  (`Departmentid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Table structure for referencetypemaster
-- ----------------------------
CREATE TABLE `referencetypemaster` (
  `Referencetypeid` int(11) NOT NULL,
  `referencetype` varchar(20) default NULL,
  PRIMARY KEY  (`Referencetypeid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Table structure for subheaddetails
-- ----------------------------
CREATE TABLE `subheaddetails` (
  `Subheadid` int(11) NOT NULL default '0',
  `Subhead` varchar(255) default NULL,
  `Mainheadid` int(11) default NULL,
  `Machineid` int(11) default NULL,
  `Professionalrate` double default NULL,
  `Ammaturerate` double default NULL,
  `Subheadrate` double default NULL,
  `Status` int(11) default NULL,
  `parentsubheadid` int(2) default NULL,
  `Efdate` date default NULL,
  `ratemode` int(4) default NULL,
  `details` varchar(10000) default NULL,
  `mode` int(10) default NULL,
  PRIMARY KEY  (`Subheadid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Table structure for taxmaster
-- ----------------------------
CREATE TABLE `taxmaster` (
  `Taxid` int(11) NOT NULL default '0',
  `Taxname` varchar(255) default NULL,
  `Taxper` varchar(255) default NULL,
  `wef` date default NULL,
  `mode` int(5) default NULL,
  PRIMARY KEY  (`Taxid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Table structure for referencedetailsmaster
-- ----------------------------
CREATE TABLE `referencedetailsmaster` (
  `referenceid` int(11) NOT NULL,
  `voucherid` varchar(100) NOT NULL,
  `referencetypeid` double(100,0) NOT NULL,
  `referenceno` varchar(100) default NULL,
  `amount` double(200,0) NOT NULL,
  `branchid` int(11) default NULL,
  `CUSTID` int(11) default NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Table structure for accountheadmaster
-- ----------------------------
CREATE TABLE accountheadmaster (
  Accountheadid int(11) NOT NULL,
  Groupid int(11) NOT NULL,
  Accountheadname varchar(255) NOT NULL,
  Type varchar(255) default NULL,
  TypeID int(11) NOT NULL,
  BranchId int(11) default NULL,
  PRIMARY KEY  (Accountheadid)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;