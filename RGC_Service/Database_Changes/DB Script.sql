
--------- Delete TABLE

AccessoryInfo , AccHead , AccLeadger , AdvanceInfo, CancelJob , MRSRDetails , MRSRMaster , tempMISALL

UsesAccesories , tbPettyCash , Category , Category_dms , Product_dms , tbBank , tbBankList , tbDeposit , tblReportMIS

tblReportMIS00 , tblReportMIS1 , tblReportMIS2 , tblSetBranch



---        TABLE Column name change


--TableName		Old Column Name				New Column Name

Branch 	=> 			Branch 		  				BranchName    
Ctype 	=> 			cType   					cTypeName    
Brand 	=> 			Brand   					BrandName  



------------------------ Delete Columne ------------------------------------------------

--TableName						Deleted Column Name				

ServiceDetails					ProductID ,Measure


------------------------ Add New Column ------------------------------------------------
Table Name						  Columne	
tbBill_FFC							TBFCID
tbl_RptTechnicianPerformance		TPID
tblDailyInOut						DIOID
tbTechPerformancSummary				TPSID
tbVATSetting						VatID
TempMIS_Report						MISRID
TempService							TSID

------------------------ Add Primary Key ------------------------------------------------

Table Name						  Columne	
Claiminfo							JobCode
Brand								BrdID
BrandModel							MdID
CashSales							MRNO
CustomerClaim						ClaimID
CustomerClaimOthers					ClaimID
Department							DeptName
EstimateRefused						EstRAID
LogUser								LID
NRDetails							ClaimID
NROthers							ClaimID
Pending								ClaimID
PendingOther						ClaimID
Product								Code
Personal							EmpCode
tbBill								BillNO
tbBill_FFC							TBFCID
tbGrade								ID
tbl_RptTechnicianPerformance		TPID
tblDailyInOut						DIOID
tbReminder							RAID
tbSMS								AID
tbSMSReceipentList					RAID
tbStoregeSET						SSID
tbTechPerformancSummary				TPSID
tbVATSetting						VatPer
TempMIS_Report						MISRID
TempService							TSID
TransferJob							TrID
ServiceItem							SrvID


-------- Changing DataType

TABLE Name				Old DataType			New DataType
CustomerClaim				Bigint					int
CustomerClaimOther			Bigint					int



-------- Job Receive Form Link TABLE
Field Name				TABLE Name				Column Bind

--Job No:					Caliminfo					JobCOde
Cust.Grade				tbGrade						cGrade		
Cust.Reference			tbGrade						cRemarks
Branch					ClaimInfo					Branch
Name					ClaimInfo					CustName
Address					ClaimInfo					CustAddress1
Phone					ClaimInfo					CustAddress2
Email					ClaimInfo					Email
ReceiveDate				ClaimInfo					ReceptDate
Del Dt(Approx)			ClaimInfo					AppDelDate
Receive by				ClaimInfo					ReceptBy
AssignDate				ClaimInfo					IsssueDate
Job Assign To			ClaimInfo					IssueTo
Category				ClaimInfo					ServiceType
Brand					ClaimInfo					Brand
Model					ClaimInfo					ModelNo
Serial No				ClaimInfo					SLNO
ESN No					ClaimInfo					ESN
Accessories 			ServiceItem					Item
ItemRemarks				ClaimInfo 					ItemRemarks
Returned Items			ClaimInfo 					ReturnedItems
Physical Condition		ClaimInfo 					PhyCond
JobType					ClaimInfo 					Wcondition
Date of Purchase		ClaimInfo 					Pdate
Previous Job			ClaimInfo 					LastJobNo
failureDescription		CustomerClaim				ClaimCode
Customer Complain		CustomerClaimOthers			ClaimCode


-------- For changing branch name to Id in ClaimInfo Table

update [RELService].[dbo].[ClaimInfo] set Branch = 113   where Branch = 'KALMILATA'
go
select * from Branch where BranchName = 'KALMILATA'





-- Add Store Procedure

go
create proc [dbo].[spGetIncrementValue]
(
@BranchName nvarchar(50),
@value int output
)
as
begin
select @value= max(substring(claiminfo.jobcode,charindex('-',claiminfo.jobcode,1)+1,100)) from claiminfo where claiminfo.Branch=@BranchName and charindex('/',jobcode,1)=0

select @value
end

go
--------

Create proc [dbo].[spGetCustomerclaim_By_Category_JobCode](
@category nvarchar(50)=null,
@JobCode nvarchar(50)=null)
as
begin

declare @cat nvarchar(50)
if(@JobCode is null or @JobCode='')
begin
set @cat=@category

end
else
begin
select @cat=ClaimInfo.ServiceType from ClaimInfo where ClaimInfo.JobCode=@JobCode
end

if(@JobCode='' or @JobCode is null)
begin
select claimlist.ClaimCode,claimlist.cType, claimlist.claim, cast('false' as bit) as IsSelected from ClaimList where cType=@cat
end
else
begin
select 
isnull(p.ClaimCode,cp.ClaimCode) as ClaimCode,isnull(p.cType,cp.cType) as cType,
isnull(p.claim,cp.claim) as Claim,ISNULL(p.IsSelected,0) as IsSelected from (
Select claimlist.ClaimCode,claimlist.cType, claimlist.claim, cast('true' as bit) as IsSelected from 
 (CustomerClaim inner join ClaimList on customerclaim.claimcode=claimlist.claim) inner join claiminfo 
on customerclaim.jobcode=claiminfo.jobcode where claiminfo.JobCode=@JobCode and ClaimList.cType=@cat
 ) as p right join (select * from ClaimList where cType=@cat) as cp on p.Claim=cp.Claim 
 end

end

---------

ALTER proc [dbo].[spGetAccessories_By_Category_JobCode](
@category nvarchar(50)=null,
@JobCode nvarchar(50)=null)
as
begin

declare @cat nvarchar(50)
if(@JobCode is null or @JobCode='')
begin
set @cat=@category

end
else
begin
select @cat=ClaimInfo.ServiceType from ClaimInfo where ClaimInfo.JobCode=@JobCode
end

if(@JobCode='' or @JobCode is null)
begin
select tblItemCap.ItemCode,tblItemCap.cType, tblItemCap.cItem, cast('false' as bit) as IsSelected from tblItemCap where cType=@cat
end
else
begin
select 
isnull(p.ItemCode,cp.ItemCode) as ItemCode,isnull(p.cType,cp.cType) as cType,

isnull(p.cItem,cp.cItem) as cItem,ISNULL(p.IsSelected,0) as IsSelected from (

Select tblItemCap.ItemCode,tblItemCap.cType, tblItemCap.cItem, cast('true' as bit) as IsSelected from 

 (tblItemCap inner join ServiceItem on tblItemCap.cItem=ServiceItem.Item) inner join claiminfo 

on ServiceItem.jobcode=claiminfo.jobcode where claiminfo.JobCode=@JobCode and tblItemCap.cType=@cat

 ) as p right join (select * from tblItemCap where tblItemCap.cType=@cat) as cp on p.cItem=cp.cItem 
 end

end

go
---------------------------------
create proc spAutoComplete
(
@JobCode nvarchar(50),
@Branch nvarchar(50),
@cflag int=null
)
as
begin
declare @tempJobCOde nvarchar(50)
set @tempJobCOde=@JobCode +'%'


if(@cflag=0)
begin
Select ClaimInfo.JobCode from ClaimInfo where Claiminfo.JobCode like @tempJobCOde and ClaimInfo.Branch=@Branch 
end
else
begin
Select ClaimInfo.JobCode from ClaimInfo where Claiminfo.JobCode like @tempJobCOde and ClaimInfo.Branch=@Branch and claiminfo.cflag=@cflag
end

end


------------------------------------
go
create proc spGetSingleClaiminfo
(
@JobCode nvarchar(50)

)
as
begin

Select * from ClaimInfo where ClaimInfo.JobCode=@JobCode
end



-------------------------------------

go
Create proc [dbo].[spPending_By_JobCode]
(
@JobCode nvarchar(50)

)
as
begin

Select * from Pending where Pending.JobCode=@JobCode
end

go
create proc [dbo].[spPendingOthers_By_JobCode]
(
@JobCode nvarchar(50)

)
as
begin

Select * from PendingOther where PendingOther.JobCode=@JobCode
end



--------------------------------------------------------------
go
create proc spGet_NR_By_JobCode(
@JobCode nvarchar(50)
)
as
begin
Select * from NRDetails where NRDetails.JobCode=@JobCode
end

go
-----------------------------------------------------------------------------------
create proc spGet_NROther_By_JobCode(
@JobCode nvarchar(50)
)
as
begin
Select * from NROthers where NROthers.JobCode=@JobCode
end


-------------------------------------------------------------------------------------------
go
create proc [dbo].[spDelete_NR_byJobCode](
@JobCode nvarchar(50)
)
as
begin
delete from NRDetails where NRDetails.JobCode=@JobCode
end
go
create proc [dbo].[spDelete_NROther_byJobCode](
@JobCode nvarchar(50)
)
as
begin
delete from NROthers where NROthers.JobCode=@JobCode
end

------------------- 14-07-2021 Store Precedure ----------------------
go
create proc spDelete_Pending_byJobCode
(
@JobCode nvarchar(50)
)
as
begin

Delete from Pending where Pending.JobCode=@jobCode

end

go

create proc spDelete_PendingOther_byJobCode
(
@JobCode nvarchar(50)
)
as
begin

Delete from PendingOther where PendingOther.JobCode=@jobCode

end