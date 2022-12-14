USE [Shell]
GO
/****** Object:  StoredProcedure [dbo].[AccontMotion]    Script Date: 04/27/2014 08:57:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AccontMotion]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[AccontMotion]
GO
/****** Object:  StoredProcedure [dbo].[CalcSalary]    Script Date: 04/27/2014 08:57:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CalcSalary]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CalcSalary]
GO
/****** Object:  StoredProcedure [dbo].[GetBankCash2]    Script Date: 04/27/2014 08:57:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetBankCash2]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetBankCash2]
GO
/****** Object:  StoredProcedure [dbo].[GetDeletedSales]    Script Date: 04/27/2014 08:57:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetDeletedSales]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetDeletedSales]
GO
/****** Object:  UserDefinedFunction [dbo].[GetCostPrice]    Script Date: 04/27/2014 08:57:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetCostPrice]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[GetCostPrice]
GO
/****** Object:  UserDefinedFunction [dbo].[GetEmpDirectBonus]    Script Date: 04/27/2014 08:57:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetEmpDirectBonus]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[GetEmpDirectBonus]
GO
/****** Object:  UserDefinedFunction [dbo].[GetEmpDirectCut]    Script Date: 04/27/2014 08:57:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetEmpDirectCut]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[GetEmpDirectCut]
GO
/****** Object:  UserDefinedFunction [dbo].[Bal0]    Script Date: 04/27/2014 08:57:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Bal0]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[Bal0]
GO
/****** Object:  StoredProcedure [dbo].[CloseAttendance]    Script Date: 04/27/2014 08:57:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CloseAttendance]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CloseAttendance]
GO
/****** Object:  StoredProcedure [dbo].[CustomersSearch]    Script Date: 04/27/2014 08:57:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CustomersSearch]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CustomersSearch]
GO
/****** Object:  StoredProcedure [dbo].[GetCustomerCompanies]    Script Date: 04/27/2014 08:57:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetCustomerCompanies]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetCustomerCompanies]
GO
/****** Object:  StoredProcedure [dbo].[GetCustomerData]    Script Date: 04/27/2014 08:57:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetCustomerData]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetCustomerData]
GO
/****** Object:  StoredProcedure [dbo].[GetIncomeRPT]    Script Date: 04/27/2014 08:57:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetIncomeRPT]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetIncomeRPT]
GO
/****** Object:  StoredProcedure [dbo].[GetItemCard]    Script Date: 04/27/2014 08:57:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetItemCard]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetItemCard]
GO
/****** Object:  StoredProcedure [dbo].[GetItems]    Script Date: 04/27/2014 08:57:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetItems]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetItems]
GO
/****** Object:  StoredProcedure [dbo].[GetItemsSales]    Script Date: 04/27/2014 08:57:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetItemsSales]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetItemsSales]
GO
/****** Object:  StoredProcedure [dbo].[GetOutcomeRPT]    Script Date: 04/27/2014 08:57:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetOutcomeRPT]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetOutcomeRPT]
GO
/****** Object:  StoredProcedure [dbo].[GetMessages]    Script Date: 04/27/2014 08:57:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetMessages]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetMessages]
GO
/****** Object:  StoredProcedure [dbo].[GetSalaryHistory]    Script Date: 04/27/2014 08:57:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetSalaryHistory]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetSalaryHistory]
GO
/****** Object:  StoredProcedure [dbo].[GetSalaryHistoryAllTax]    Script Date: 04/27/2014 08:57:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetSalaryHistoryAllTax]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetSalaryHistoryAllTax]
GO
/****** Object:  StoredProcedure [dbo].[GetSalaryHistoryNotShifts]    Script Date: 04/27/2014 08:57:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetSalaryHistoryNotShifts]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetSalaryHistoryNotShifts]
GO
/****** Object:  StoredProcedure [dbo].[GetSalaryHistoryShifts]    Script Date: 04/27/2014 08:57:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetSalaryHistoryShifts]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetSalaryHistoryShifts]
GO
/****** Object:  StoredProcedure [dbo].[GetSales]    Script Date: 04/27/2014 08:57:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetSales]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetSales]
GO
/****** Object:  StoredProcedure [dbo].[GetSalesRPT]    Script Date: 04/27/2014 08:57:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetSalesRPT]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetSalesRPT]
GO
/****** Object:  StoredProcedure [dbo].[GetStoreBal]    Script Date: 04/27/2014 08:57:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetStoreBal]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetStoreBal]
GO
/****** Object:  StoredProcedure [dbo].[GetStoreBal2]    Script Date: 04/27/2014 08:57:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetStoreBal2]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetStoreBal2]
GO
/****** Object:  StoredProcedure [dbo].[GetStoreItemSalesRPT]    Script Date: 04/27/2014 08:57:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetStoreItemSalesRPT]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetStoreItemSalesRPT]
GO
/****** Object:  StoredProcedure [dbo].[PrintBarcode]    Script Date: 04/27/2014 08:57:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PrintBarcode]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[PrintBarcode]
GO
/****** Object:  StoredProcedure [dbo].[PrintBarcodeFromSalesDetails]    Script Date: 04/27/2014 08:57:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PrintBarcodeFromSalesDetails]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[PrintBarcodeFromSalesDetails]
GO
/****** Object:  UserDefinedFunction [dbo].[GetStoreName]    Script Date: 04/27/2014 08:57:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetStoreName]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[GetStoreName]
GO
/****** Object:  UserDefinedFunction [dbo].[GetSubAccName]    Script Date: 04/27/2014 08:57:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetSubAccName]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[GetSubAccName]
GO
/****** Object:  UserDefinedFunction [dbo].[GetSubAccNameLink]    Script Date: 04/27/2014 08:57:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetSubAccNameLink]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[GetSubAccNameLink]
GO
/****** Object:  UserDefinedFunction [dbo].[GetSubJobName]    Script Date: 04/27/2014 08:57:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetSubJobName]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[GetSubJobName]
GO
/****** Object:  UserDefinedFunction [dbo].[getsum]    Script Date: 04/27/2014 08:57:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[getsum]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[getsum]
GO
/****** Object:  UserDefinedFunction [dbo].[getsumDeleted]    Script Date: 04/27/2014 08:57:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[getsumDeleted]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[getsumDeleted]
GO
/****** Object:  UserDefinedFunction [dbo].[GetSuppPersonName]    Script Date: 04/27/2014 08:57:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetSuppPersonName]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[GetSuppPersonName]
GO
/****** Object:  UserDefinedFunction [dbo].[GetTaxAcc]    Script Date: 04/27/2014 08:57:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetTaxAcc]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[GetTaxAcc]
GO
/****** Object:  StoredProcedure [dbo].[GetToIdPrice]    Script Date: 04/27/2014 08:57:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetToIdPrice]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetToIdPrice]
GO
/****** Object:  UserDefinedFunction [dbo].[GetTownName]    Script Date: 04/27/2014 08:57:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetTownName]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[GetTownName]
GO
/****** Object:  UserDefinedFunction [dbo].[GetTypeName]    Script Date: 04/27/2014 08:57:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetTypeName]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[GetTypeName]
GO
/****** Object:  UserDefinedFunction [dbo].[IsWeekHoliday]    Script Date: 04/27/2014 08:57:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[IsWeekHoliday]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[IsWeekHoliday]
GO
/****** Object:  UserDefinedFunction [dbo].[GetStoreItemBal]    Script Date: 04/27/2014 08:57:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetStoreItemBal]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[GetStoreItemBal]
GO
/****** Object:  UserDefinedFunction [dbo].[GetStoreItemSales]    Script Date: 04/27/2014 08:57:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetStoreItemSales]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[GetStoreItemSales]
GO
/****** Object:  UserDefinedFunction [dbo].[GetSellerName]    Script Date: 04/27/2014 08:57:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetSellerName]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[GetSellerName]
GO
/****** Object:  StoredProcedure [dbo].[AttendanceLogDelete]    Script Date: 04/27/2014 08:57:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AttendanceLogDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[AttendanceLogDelete]
GO
/****** Object:  UserDefinedFunction [dbo].[GetServicePerc]    Script Date: 04/27/2014 08:57:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetServicePerc]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[GetServicePerc]
GO
/****** Object:  UserDefinedFunction [dbo].[GetSalesItems]    Script Date: 04/27/2014 08:57:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetSalesItems]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[GetSalesItems]
GO
/****** Object:  UserDefinedFunction [dbo].[GetMinValuePerPerson]    Script Date: 04/27/2014 08:57:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetMinValuePerPerson]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[GetMinValuePerPerson]
GO
/****** Object:  StoredProcedure [dbo].[GetMSG]    Script Date: 04/27/2014 08:57:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetMSG]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetMSG]
GO
/****** Object:  StoredProcedure [dbo].[GenerateInvoice]    Script Date: 04/27/2014 08:57:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GenerateInvoice]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GenerateInvoice]
GO
/****** Object:  UserDefinedFunction [dbo].[GetOutComeTypeName]    Script Date: 04/27/2014 08:57:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetOutComeTypeName]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[GetOutComeTypeName]
GO
/****** Object:  UserDefinedFunction [dbo].[GetReligionName]    Script Date: 04/27/2014 08:57:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetReligionName]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[GetReligionName]
GO
/****** Object:  UserDefinedFunction [dbo].[GetSafeAccNo]    Script Date: 04/27/2014 08:57:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetSafeAccNo]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[GetSafeAccNo]
GO
/****** Object:  UserDefinedFunction [dbo].[GetMainAccName]    Script Date: 04/27/2014 08:57:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetMainAccName]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[GetMainAccName]
GO
/****** Object:  UserDefinedFunction [dbo].[GetMainAccNoLink]    Script Date: 04/27/2014 08:57:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetMainAccNoLink]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[GetMainAccNoLink]
GO
/****** Object:  UserDefinedFunction [dbo].[GetMainJobName]    Script Date: 04/27/2014 08:57:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetMainJobName]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[GetMainJobName]
GO
/****** Object:  UserDefinedFunction [dbo].[GetItemUnitName]    Script Date: 04/27/2014 08:57:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetItemUnitName]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[GetItemUnitName]
GO
/****** Object:  UserDefinedFunction [dbo].[GetItemUnitQty---not used]    Script Date: 04/27/2014 08:57:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetItemUnitQty---not used]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[GetItemUnitQty---not used]
GO
/****** Object:  UserDefinedFunction [dbo].[GetItemPurchasePrice]    Script Date: 04/27/2014 08:57:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetItemPurchasePrice]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[GetItemPurchasePrice]
GO
/****** Object:  UserDefinedFunction [dbo].[GetCustomerName]    Script Date: 04/27/2014 08:57:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetCustomerName]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[GetCustomerName]
GO
/****** Object:  StoredProcedure [dbo].[GetDeficitAndIncrease]    Script Date: 04/27/2014 08:57:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetDeficitAndIncrease]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetDeficitAndIncrease]
GO
/****** Object:  UserDefinedFunction [dbo].[GetEmpIsHasAttendance]    Script Date: 04/27/2014 08:57:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetEmpIsHasAttendance]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[GetEmpIsHasAttendance]
GO
/****** Object:  UserDefinedFunction [dbo].[GetEmpLate]    Script Date: 04/27/2014 08:57:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetEmpLate]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[GetEmpLate]
GO
/****** Object:  UserDefinedFunction [dbo].[GetEmpLeaveBal]    Script Date: 04/27/2014 08:57:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetEmpLeaveBal]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[GetEmpLeaveBal]
GO
/****** Object:  UserDefinedFunction [dbo].[GetEmpLeaveBal2]    Script Date: 04/27/2014 08:57:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetEmpLeaveBal2]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[GetEmpLeaveBal2]
GO
/****** Object:  UserDefinedFunction [dbo].[GetEmpLeaveRequests]    Script Date: 04/27/2014 08:57:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetEmpLeaveRequests]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[GetEmpLeaveRequests]
GO
/****** Object:  UserDefinedFunction [dbo].[GetEmpLoans]    Script Date: 04/27/2014 08:57:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetEmpLoans]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[GetEmpLoans]
GO
/****** Object:  UserDefinedFunction [dbo].[GetEmpName]    Script Date: 04/27/2014 08:57:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetEmpName]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[GetEmpName]
GO
/****** Object:  UserDefinedFunction [dbo].[GetEmpOverTime]    Script Date: 04/27/2014 08:57:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetEmpOverTime]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[GetEmpOverTime]
GO
/****** Object:  UserDefinedFunction [dbo].[GetEmpTaxAccNo]    Script Date: 04/27/2014 08:57:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetEmpTaxAccNo]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[GetEmpTaxAccNo]
GO
/****** Object:  UserDefinedFunction [dbo].[GetEnName]    Script Date: 04/27/2014 08:57:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetEnName]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[GetEnName]
GO
/****** Object:  UserDefinedFunction [dbo].[GetGroupName]    Script Date: 04/27/2014 08:57:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetGroupName]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[GetGroupName]
GO
/****** Object:  StoredProcedure [dbo].[CloseShift]    Script Date: 04/27/2014 08:57:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CloseShift]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CloseShift]
GO
/****** Object:  StoredProcedure [dbo].[AddCustomer]    Script Date: 04/27/2014 08:57:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AddCustomer]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[AddCustomer]
GO
/****** Object:  UserDefinedFunction [dbo].[GetEmpEnName]    Script Date: 04/27/2014 08:57:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetEmpEnName]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[GetEmpEnName]
GO
/****** Object:  UserDefinedFunction [dbo].[GetEmpHourValue]    Script Date: 04/27/2014 08:57:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetEmpHourValue]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[GetEmpHourValue]
GO
/****** Object:  UserDefinedFunction [dbo].[GetCountryName]    Script Date: 04/27/2014 08:57:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetCountryName]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[GetCountryName]
GO
/****** Object:  StoredProcedure [dbo].[GetCurrent]    Script Date: 04/27/2014 08:57:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetCurrent]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetCurrent]
GO
/****** Object:  StoredProcedure [dbo].[Exec_Backup]    Script Date: 04/27/2014 08:57:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Exec_Backup]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Exec_Backup]
GO
/****** Object:  UserDefinedFunction [dbo].[GetDelivaryCost]    Script Date: 04/27/2014 08:57:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetDelivaryCost]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[GetDelivaryCost]
GO
/****** Object:  UserDefinedFunction [dbo].[GetDepartmentName]    Script Date: 04/27/2014 08:57:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetDepartmentName]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[GetDepartmentName]
GO
/****** Object:  UserDefinedFunction [dbo].[GetEmpAbsence]    Script Date: 04/27/2014 08:57:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetEmpAbsence]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[GetEmpAbsence]
GO
/****** Object:  UserDefinedFunction [dbo].[GetEmpArName]    Script Date: 04/27/2014 08:57:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetEmpArName]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[GetEmpArName]
GO
/****** Object:  UserDefinedFunction [dbo].[GetEmpDayValue]    Script Date: 04/27/2014 08:57:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetEmpDayValue]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[GetEmpDayValue]
GO
/****** Object:  UserDefinedFunction [dbo].[GetEmpDepartmentId]    Script Date: 04/27/2014 08:57:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetEmpDepartmentId]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[GetEmpDepartmentId]
GO
/****** Object:  StoredProcedure [dbo].[GetCancleSerialId]    Script Date: 04/27/2014 08:57:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetCancleSerialId]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetCancleSerialId]
GO
/****** Object:  UserDefinedFunction [dbo].[GetCityName]    Script Date: 04/27/2014 08:57:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetCityName]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[GetCityName]
GO
/****** Object:  UserDefinedFunction [dbo].[GetCompanyName]    Script Date: 04/27/2014 08:57:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetCompanyName]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[GetCompanyName]
GO
/****** Object:  UserDefinedFunction [dbo].[GetCostCenterName]    Script Date: 04/27/2014 08:57:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetCostCenterName]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[GetCostCenterName]
GO
/****** Object:  UserDefinedFunction [dbo].[GetAreaName]    Script Date: 04/27/2014 08:57:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetAreaName]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[GetAreaName]
GO
/****** Object:  StoredProcedure [dbo].[GetAttendance]    Script Date: 04/27/2014 08:57:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetAttendance]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetAttendance]
GO
/****** Object:  StoredProcedure [dbo].[GetAttendanceLog]    Script Date: 04/27/2014 08:57:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetAttendanceLog]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetAttendanceLog]
GO
/****** Object:  UserDefinedFunction [dbo].[GetBal0]    Script Date: 04/27/2014 08:57:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetBal0]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[GetBal0]
GO
/****** Object:  UserDefinedFunction [dbo].[GetBankAccNo]    Script Date: 04/27/2014 08:57:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetBankAccNo]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[GetBankAccNo]
GO
/****** Object:  StoredProcedure [dbo].[BeforeDeleteSales]    Script Date: 04/27/2014 08:57:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BeforeDeleteSales]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[BeforeDeleteSales]
GO
/****** Object:  StoredProcedure [dbo].[bk]    Script Date: 04/27/2014 08:57:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[bk]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[bk]
GO
/****** Object:  UserDefinedFunction [dbo].[GetAccName]    Script Date: 04/27/2014 08:57:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetAccName]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[GetAccName]
GO
/****** Object:  UserDefinedFunction [dbo].[GetAccTypeName]    Script Date: 04/27/2014 08:57:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetAccTypeName]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[GetAccTypeName]
GO
/****** Object:  StoredProcedure [dbo].[GetAllBal]    Script Date: 04/27/2014 08:57:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetAllBal]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetAllBal]
GO
/****** Object:  StoredProcedure [dbo].[sla]    Script Date: 04/27/2014 08:57:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sla]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sla]
GO
/****** Object:  StoredProcedure [dbo].[LA]    Script Date: 04/27/2014 08:57:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LA]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[LA]
GO
/****** Object:  StoredProcedure [dbo].[LoadGroups]    Script Date: 04/27/2014 08:57:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LoadGroups]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[LoadGroups]
GO
/****** Object:  StoredProcedure [dbo].[LoadGroups2]    Script Date: 04/27/2014 08:57:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LoadGroups2]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[LoadGroups2]
GO
/****** Object:  StoredProcedure [dbo].[LoadTypes]    Script Date: 04/27/2014 08:57:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LoadTypes]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[LoadTypes]
GO
/****** Object:  StoredProcedure [dbo].[LoadTypes2]    Script Date: 04/27/2014 08:57:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LoadTypes2]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[LoadTypes2]
GO
/****** Object:  UserDefinedFunction [dbo].[MonthDays]    Script Date: 04/27/2014 08:57:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MonthDays]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[MonthDays]
GO
/****** Object:  StoredProcedure [dbo].[TestLogin]    Script Date: 04/27/2014 08:57:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TestLogin]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[TestLogin]
GO
/****** Object:  StoredProcedure [dbo].[UpdateItemPurchasePrice]    Script Date: 04/27/2014 08:57:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UpdateItemPurchasePrice]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[UpdateItemPurchasePrice]
GO
/****** Object:  StoredProcedure [dbo].[WeekFirstDay]    Script Date: 04/27/2014 08:57:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[WeekFirstDay]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[WeekFirstDay]
GO
/****** Object:  UserDefinedFunction [dbo].[ToStrDate]    Script Date: 04/27/2014 08:57:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ToStrDate]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[ToStrDate]
GO
/****** Object:  UserDefinedFunction [dbo].[ToStrTime]    Script Date: 04/27/2014 08:57:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ToStrTime]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[ToStrTime]
GO
/****** Object:  UserDefinedFunction [dbo].[MyGetDate]    Script Date: 04/27/2014 08:57:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MyGetDate]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[MyGetDate]
GO
/****** Object:  UserDefinedFunction [dbo].[MyRound]    Script Date: 04/27/2014 08:57:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MyRound]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[MyRound]
GO
/****** Object:  StoredProcedure [dbo].[sp]    Script Date: 04/27/2014 08:57:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp]
GO
/****** Object:  StoredProcedure [dbo].[StopPro]    Script Date: 04/27/2014 08:57:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[StopPro]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[StopPro]
GO
/****** Object:  UserDefinedFunction [dbo].[Tafkeet]    Script Date: 04/27/2014 08:57:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Tafkeet]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[Tafkeet]
GO
/****** Object:  StoredProcedure [dbo].[GetAllDaysInMonth]    Script Date: 04/27/2014 08:57:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetAllDaysInMonth]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetAllDaysInMonth]
GO
/****** Object:  StoredProcedure [dbo].[executeSql]    Script Date: 04/27/2014 08:57:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[executeSql]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[executeSql]
GO
/****** Object:  UserDefinedFunction [dbo].[FillZero]    Script Date: 04/27/2014 08:57:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FillZero]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[FillZero]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_RemoveTashkeel]    Script Date: 04/27/2014 08:57:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_RemoveTashkeel]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fn_RemoveTashkeel]
GO
/****** Object:  UserDefinedFunction [dbo].[fnSplitString]    Script Date: 04/27/2014 08:57:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fnSplitString]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fnSplitString]
GO
/****** Object:  StoredProcedure [dbo].[AddMyGetDate]    Script Date: 04/27/2014 08:57:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AddMyGetDate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[AddMyGetDate]
GO
/****** Object:  UserDefinedFunction [dbo].[DaysInMonth]    Script Date: 04/27/2014 08:57:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DaysInMonth]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[DaysInMonth]
GO
/****** Object:  StoredProcedure [dbo].[EncreaseMaxSize]    Script Date: 04/27/2014 08:57:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EncreaseMaxSize]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[EncreaseMaxSize]
GO
/****** Object:  UserDefinedFunction [dbo].[Get_Checksum]    Script Date: 04/27/2014 08:57:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Get_Checksum]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[Get_Checksum]
GO
/****** Object:  StoredProcedure [dbo].[PrintTbl]    Script Date: 04/27/2014 08:57:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PrintTbl]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[PrintTbl]
GO
/****** Object:  StoredProcedure [dbo].[PrintTbl2]    Script Date: 04/27/2014 08:57:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PrintTbl2]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[PrintTbl2]
GO
/****** Object:  StoredProcedure [dbo].[sh]    Script Date: 04/27/2014 08:57:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sh]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sh]
GO
/****** Object:  StoredProcedure [dbo].[Shrink]    Script Date: 04/27/2014 08:57:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Shrink]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Shrink]
GO
/****** Object:  StoredProcedure [dbo].[Shrink]    Script Date: 04/27/2014 08:57:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Shrink]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE proc [dbo].[Shrink]
--with encryption
as

declare @db_name nvarchar(1000)=db_name()

exec (''alter database [''+@db_name+''] set recovery simple
dbcc shrinkdatabase ([''+@db_name+''])
alter database [''+@db_name+''] set recovery full'')
' 
END
GO
/****** Object:  StoredProcedure [dbo].[sh]    Script Date: 04/27/2014 08:57:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sh]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE proc [dbo].[sh]
--with encryption
as

declare @db_name nvarchar(1000)=db_name()

exec (''alter database [''+@db_name+''] set recovery simple
dbcc shrinkdatabase ([''+@db_name+''])
alter database [''+@db_name+''] set recovery full'')
' 
END
GO
/****** Object:  StoredProcedure [dbo].[PrintTbl2]    Script Date: 04/27/2014 08:57:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PrintTbl2]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE proc [dbo].[PrintTbl2] 
(
@tbl varchar(100),
@maintbl varchar(100),
@mainfield varchar(100)
)
as
create table #tbl(MainId int,MainName nvarchar(4000),Id int,Name nvarchar(4000))
insert #tbl
exec (''select ''+@maintbl+''.Id,''+@maintbl+''.Name,''+@tbl+''.Id,''+@tbl+''.Name from ''+@maintbl+'' left join ''+@tbl+'' on(''+@maintbl+''.Id=''+@tbl+''.''+@mainfield+'') order by ''+@maintbl+''.Id,''+@tbl+''.Id'')

select * from #tbl
drop table #tbl
' 
END
GO
/****** Object:  StoredProcedure [dbo].[PrintTbl]    Script Date: 04/27/2014 08:57:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PrintTbl]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE proc [dbo].[PrintTbl] 
(
@tbl varchar(100)
)
as
create table #tbl(Id int,Name varchar(4000))
insert #tbl
exec (''select Id,Name from ''+@tbl+'' Order by Id'')

select * from #tbl
drop table #tbl
' 
END
GO
/****** Object:  UserDefinedFunction [dbo].[Get_Checksum]    Script Date: 04/27/2014 08:57:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Get_Checksum]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'CREATE FUNCTION [dbo].[Get_Checksum]
(
    @DatabaseName      varchar(100),
    @TableName         varchar(100)
)
RETURNS FLOAT
--with encryption
AS
BEGIN

 Declare @SQL        nvarchar(4000)
 Declare @ColumnName varchar(100)
 Declare @i          int
 Declare @Checksum   float
 Declare @intColumns table (idRecord int identity(1,1), ColumnName varchar(255))
 Declare @CS         table (MyCheckSum bigint)

 Set @SQL = 
        ''Insert Into @IntColumns(ColumnName)'' + Char(13) + 
        ''Select Column_Name'' + Char(13) +
        ''From   '' + @DatabaseName + ''.Information_Schema.Columns (NOLOCK)'' + Char(13) +
        ''Where  Table_Name = '''''' + @TableName + '''''''' + Char(13) +
        ''       and Data_Type = ''''int'''''' 

 -- print @SQL

 exec sp_executeSql @SQL

 Set @SQL = 
        ''Insert Into @CS(MyChecksum)'' + Char(13) + 
        ''Select ''

 Set @i = 1

 While Exists(
       Select 1
       From   @IntColumns
       Where  IdRecord = @i)
 begin
       Select @ColumnName = ColumnName
       From   @IntColumns
       Where  IdRecord = @i

       Set @SQL = @SQL + Char(13) + 
            CASE WHEN @i = 1 THEN 
                 ''    Sum(Cast(IsNull('' + @ColumnName + '',0) as bigint))''
                 ELSE
                 ''    + Sum(Cast(IsNull('' + @ColumnName + '',0) as bigint))''
            END

       Set @i = @i + 1
 end

 Set @SQL = @SQL + Char(13) + 
      ''From '' + @DatabaseName + ''..'' + @TableName + '' (NOLOCK)''

 -- print @SQL

 exec sp_executeSql @SQL

 Set @Checksum = (Select Top 1 MyChecksum From @CS)

 Return isnull(@Checksum,0)

END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[EncreaseMaxSize]    Script Date: 04/27/2014 08:57:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EncreaseMaxSize]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE proc [dbo].[EncreaseMaxSize]
@max int=10000
--with encryption
as

declare @db_name nvarchar(1000)=db_name()
declare @file_name nvarchar(1000)=(select top 1 name from sys.database_files where type=0)
declare @SQL nvarchar(1000)

set @SQL=''USE master
ALTER DATABASE [''+@db_name+''] MODIFY FILE(NAME = ''+@file_name+'',maxSIZE = ''+cast(@max as nvarchar(100))+'' MB)''
exec (@SQL)

set @file_name=(select top 1 name from sys.database_files where type=1)

set @SQL=''USE master
ALTER DATABASE [''+@db_name+''] MODIFY FILE(NAME = ''+@file_name+'',maxSIZE = ''+cast(@max as nvarchar(100))+'' MB)''

exec (@SQL)
' 
END
GO
/****** Object:  UserDefinedFunction [dbo].[DaysInMonth]    Script Date: 04/27/2014 08:57:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DaysInMonth]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'CREATE FUNCTION [dbo].[DaysInMonth]
(
@MONTH int,@YEAR int
)
returns int
--with encryption
as
begin

declare @Days int
if @MONTH in(1,3,5,7,8,10,12)
select @Days=31
else if @MONTH in(4,6,9,11)
select @Days=30
else if @YEAR%4=0
select @Days=29
else 
select @Days=28

return @Days

end
' 
END
GO
/****** Object:  StoredProcedure [dbo].[AddMyGetDate]    Script Date: 04/27/2014 08:57:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AddMyGetDate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE proc [dbo].[AddMyGetDate](@tbl nvarchar(1000))
--with encryption
as
exec(''alter table ''+@tbl+'' ADD  UserName int'')
exec(''alter table ''+@tbl+'' ADD  MyGetDate datetime'')
exec(''alter table ''+@tbl+'' ADD  CONSTRAINT [DF_''+@tbl+''_MyGetDate]  DEFAULT (getdate()) FOR [MyGetDate]'')
' 
END
GO
/****** Object:  UserDefinedFunction [dbo].[fnSplitString]    Script Date: 04/27/2014 08:57:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fnSplitString]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'CREATE FUNCTION [dbo].[fnSplitString] 
( 
    @string NVARCHAR(MAX), 
    @delimiter CHAR(1) ,
    @Index int
) 
RETURNS nvarchar(max)
BEGIN 
declare @output TABLE(string NVARCHAR(MAX),Line int identity ) 
    DECLARE @start INT, @end INT 
    SELECT @start = 1, @end = CHARINDEX(@delimiter, @string) 
    WHILE @start < LEN(@string) + 1 BEGIN 
        IF @end = 0  
            SET @end = LEN(@string) + 1
       
        INSERT INTO @output (string)  
        VALUES(SUBSTRING(@string, @start, @end - @start)) 
        SET @start = @end + 1 
        SET @end = CHARINDEX(@delimiter, @string, @start)
        
    END 
    RETURN (select string from @output where Line=@Index)
END
' 
END
GO
/****** Object:  UserDefinedFunction [dbo].[fn_RemoveTashkeel]    Script Date: 04/27/2014 08:57:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_RemoveTashkeel]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'CREATE FUNCTION [dbo].[fn_RemoveTashkeel] (@InputString nvarchar(2300) )

RETURNS nvarchar(2300) 

--with encryption
AS

BEGIN

  DECLARE @OutputString nvarchar(2300)

  SET @OutputString=@InputString

  SET @OutputString=REPLACE(@OutputString,''ْ'','''')
  SET @OutputString=REPLACE(@OutputString,''ْ'','''')
  SET @OutputString=REPLACE(@OutputString,''ْ'','''')
  SET @OutputString=REPLACE(@OutputString,''ْ'','''')
  SET @OutputString=REPLACE(@OutputString,''ْ'','''')
  SET @OutputString=REPLACE(@OutputString,''ٍ'','''')
  SET @OutputString=REPLACE(@OutputString,''ِ'','''')
  SET @OutputString=REPLACE(@OutputString,''ٌ'','''')
  SET @OutputString=REPLACE(@OutputString,''ُ'','''')
  SET @OutputString=REPLACE(@OutputString,''ً'','''')
  SET @OutputString=REPLACE(@OutputString,'''','''')
  SET @OutputString=REPLACE(@OutputString,''ّ'','''')


  RETURN(@OutputString)

END
' 
END
GO
/****** Object:  UserDefinedFunction [dbo].[FillZero]    Script Date: 04/27/2014 08:57:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FillZero]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'CREATE FUNCTION [dbo].[FillZero](@str nvarchar(4000),@Length int)
returns nvarchar(1000)
--with encryption
as
begin

select @str=replace(@str,'' '','''')
select @str=replace(@str,''	'','''')
declare @x int=@Length-len(@str)
select @x=0 where @x<0
select @str=REPLICATE(''0'',@x)+@str

return @str
end
' 
END
GO
/****** Object:  StoredProcedure [dbo].[executeSql]    Script Date: 04/27/2014 08:57:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[executeSql]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE proc [dbo].[executeSql](@sql varchar(1000))
--with encryption
as
exec @sql
' 
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllDaysInMonth]    Script Date: 04/27/2014 08:57:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetAllDaysInMonth]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE proc [dbo].[GetAllDaysInMonth]
(
@Year int,
@Month int
)
--with encryption
as

declare @tbl table (DayDate datetime)

declare @today datetime=cast((cast(@year as nvarchar(4))+''-''+cast(@month as nvarchar(2))+''-01'') as datetime)

while MONTH(@today)=@Month
begin
insert @tbl select @today
set @today+=1
end

select ROW_NUMBER()over (order by DayDate) Line,DATENAME(WEEKDAY,DayDate) ''Day'',DayDate ''Date'' from @tbl
' 
END
GO
/****** Object:  UserDefinedFunction [dbo].[Tafkeet]    Script Date: 04/27/2014 08:57:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Tafkeet]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'CREATE FUNCTION [dbo].[Tafkeet]
(@val float)
returns nvarchar(4000)
--with encryption
as
begin
declare @str nvarchar(100)=cast(@val as nvarchar(100))
select @str=REPLICATE(''0'',15-LEN(@str))+@str

declare @s1 nvarchar(1000),@s2 nvarchar(1000),@s3 nvarchar(1000),@s4 nvarchar(1000),@s5 nvarchar(1000),@s6 nvarchar(1000),@s7 nvarchar(1000),@s8 nvarchar(1000),@s9 nvarchar(1000),@s10 nvarchar(1000),@s11 nvarchar(1000),@s12 nvarchar(1000),@s13 nvarchar(1000),@s14 nvarchar(1000),@s15 nvarchar(1000),@s16 nvarchar(1000),@s17 nvarchar(1000),@s18 nvarchar(1000),@s19 nvarchar(1000)

select @s1=case SUBSTRING(@str,1,1)  when ''1'' then ''مائة'' when ''2'' then ''مائتان'' when ''3'' then ''ثلاثمائة'' when ''4'' then ''أربعمائة'' when ''5'' then ''خمسمائة'' when ''6'' then ''ستمائة'' when ''7'' then ''سبعمائة'' when ''8'' then ''ثمانمائة'' when ''9'' then ''تسعمائة'' else '''' end
select @s2=case SUBSTRING(@str,2,1)  when ''1'' then ''عشرة'' when ''2'' then ''عشرون'' when ''3'' then ''ثلاثون'' when ''4'' then ''أربعون'' when ''5'' then ''خمسون'' when ''6'' then ''ستون'' when ''7'' then ''سبعون'' when ''8'' then ''ثمانون'' when ''9'' then ''تسعون'' else '''' end
select @s3=case SUBSTRING(@str,3,1)  when ''1'' then ''واحد'' when ''2'' then ''اثنان'' when ''3'' then ''ثلاثة'' when ''4'' then ''أربعة'' when ''5'' then ''خمسة'' when ''6'' then ''ستة'' when ''7'' then ''سبعة'' when ''8'' then ''ثمانية'' when ''9'' then ''تسعة'' else '''' end

select @s4=case SUBSTRING(@str,4,1)  when ''1'' then ''مائة'' when ''2'' then ''مائتان'' when ''3'' then ''ثلاثمائة'' when ''4'' then ''أربعمائة'' when ''5'' then ''خمسمائة'' when ''6'' then ''ستمائة'' when ''7'' then ''سبعمائة'' when ''8'' then ''ثمانمائة'' when ''9'' then ''تسعمائة'' else '''' end
select @s5=case SUBSTRING(@str,5,1)  when ''1'' then ''عشرة'' when ''2'' then ''عشرون'' when ''3'' then ''ثلاثون'' when ''4'' then ''أربعون'' when ''5'' then ''خمسون'' when ''6'' then ''ستون'' when ''7'' then ''سبعون'' when ''8'' then ''ثمانون'' when ''9'' then ''تسعون'' else '''' end
select @s6=case SUBSTRING(@str,6,1)  when ''1'' then ''واحد'' when ''2'' then ''اثنان'' when ''3'' then ''ثلاثة'' when ''4'' then ''أربعة'' when ''5'' then ''خمسة'' when ''6'' then ''ستة'' when ''7'' then ''سبعة'' when ''8'' then ''ثمانية'' when ''9'' then ''تسعة'' else '''' end

select @s7=case SUBSTRING(@str,7,1)  when ''1'' then ''مائة'' when ''2'' then ''مائتان'' when ''3'' then ''ثلاثمائة'' when ''4'' then ''أربعمائة'' when ''5'' then ''خمسمائة'' when ''6'' then ''ستمائة'' when ''7'' then ''سبعمائة'' when ''8'' then ''ثمانمائة'' when ''9'' then ''تسعمائة'' else '''' end
select @s8=case SUBSTRING(@str,8,1)  when ''1'' then ''عشرة'' when ''2'' then ''عشرون'' when ''3'' then ''ثلاثون'' when ''4'' then ''أربعون'' when ''5'' then ''خمسون'' when ''6'' then ''ستون'' when ''7'' then ''سبعون'' when ''8'' then ''ثمانون'' when ''9'' then ''تسعون'' else '''' end
select @s9=case SUBSTRING(@str,9,1)  when ''1'' then ''واحد'' when ''2'' then ''اثنان'' when ''3'' then ''ثلاثة'' when ''4'' then ''أربعة'' when ''5'' then ''خمسة'' when ''6'' then ''ستة'' when ''7'' then ''سبعة'' when ''8'' then ''ثمانية'' when ''9'' then ''تسعة'' else '''' end

select @s10=case SUBSTRING(@str,10,1)  when ''1'' then ''مائة'' when ''2'' then ''مائتان'' when ''3'' then ''ثلاثمائة'' when ''4'' then ''أربعمائة'' when ''5'' then ''خمسمائة'' when ''6'' then ''ستمائة'' when ''7'' then ''سبعمائة'' when ''8'' then ''ثمانمائة'' when ''9'' then ''تسعمائة'' else '''' end
select @s11=case SUBSTRING(@str,11,1)  when ''1'' then ''عشرة'' when ''2'' then ''عشرون'' when ''3'' then ''ثلاثون'' when ''4'' then ''أربعون'' when ''5'' then ''خمسون'' when ''6'' then ''ستون'' when ''7'' then ''سبعون'' when ''8'' then ''ثمانون'' when ''9'' then ''تسعون'' else '''' end
select @s12=case SUBSTRING(@str,12,1)  when ''1'' then ''واحد'' when ''2'' then ''اثنان'' when ''3'' then ''ثلاثة'' when ''4'' then ''أربعة'' when ''5'' then ''خمسة'' when ''6'' then ''ستة'' when ''7'' then ''سبعة'' when ''8'' then ''ثمانية'' when ''9'' then ''تسعة'' else '''' end

select @s14=case SUBSTRING(@str,14,1)  when ''1'' then ''عشرة'' when ''2'' then ''عشرون'' when ''3'' then ''ثلاثون'' when ''4'' then ''أربعون'' when ''5'' then ''خمسون'' when ''6'' then ''ستون'' when ''7'' then ''سبعون'' when ''8'' then ''ثمانون'' when ''9'' then ''تسعون'' else '''' end
select @s15=case SUBSTRING(@str,15,1)  when ''1'' then ''واحد'' when ''2'' then ''اثنان'' when ''3'' then ''ثلاثة'' when ''4'' then ''أربعة'' when ''5'' then ''خمسة'' when ''6'' then ''ستة'' when ''7'' then ''سبعة'' when ''8'' then ''ثمانية'' when ''9'' then ''تسعة'' else '''' end


select @str=@s1
select @str=@str+(case when @str<>'''' and @s3<>'''' then '' و '' else '''' end)+@s3
select @str=@str+(case when @str<>'''' and @s2<>'''' then '' و '' else '''' end)+@s2
select @str=@str+(case when @s1+@s2+@s3<>'''' then '' مليار '' else '''' end)

select @str=@str+(case when @str<>'''' and @s4<>'''' then '' و '' else '''' end)+@s4
select @str=@str+(case when @str<>'''' and @s6<>'''' then '' و '' else '''' end)+@s6
select @str=@str+(case when @str<>'''' and @s5<>'''' then '' و '' else '''' end)+@s5
select @str=@str+(case when @s4+@s5+@s6<>'''' then '' مليون '' else '''' end)

select @str=@str+(case when @str<>'''' and @s7<>'''' then '' و '' else '''' end)+@s7
select @str=@str+(case when @str<>'''' and @s9<>'''' then '' و '' else '''' end)+@s9
select @str=@str+(case when @str<>'''' and @s8<>'''' then '' و '' else '''' end)+@s8
select @str=@str+(case when @s7+@s8+@s9<>'''' then '' ألف '' else '''' end)

select @str=@str+(case when @str<>'''' and @s10<>'''' then '' و '' else '''' end)+@s10
select @str=@str+(case when @str<>'''' and @s12<>'''' then '' و '' else '''' end)+@s12
select @str=@str+(case when @str<>'''' and @s11<>'''' then '' و '' else '''' end)+@s11

select @str=@str+(case when @str<>'''' then (case when cast(@val as int) between 3 and 10 then '' جنيهات '' else '' جنيها '' end) else '''' end)

select @str=@str+(case when @str<>'''' and @s15<>'''' then '' و '' else '''' end)+@s15
select @str=@str+(case when @str<>'''' and @s14<>'''' then '' و '' else '''' end)+@s14

select @str=@str+(case when @s15+@s14<>'''' then (case when @val-cast(@val as int) between .03 and .1 then '' قروش '' else '' قرشا '' end) else '''' end)

select @str=REPLACE(@str,''واحد و عشرة'',''أحد عشر'')
select @str=REPLACE(@str,''اثنان و عشرة'',''اثنا عشر'')
select @str=REPLACE(@str,''ثلاثة و عشرة'',''ثلاثة عشر'')
select @str=REPLACE(@str,''أربعة و عشرة'',''أربعة عشر'')
select @str=REPLACE(@str,''خمسة و عشرة'',''خمسة عشر'')
select @str=REPLACE(@str,''ستة و عشرة'',''ستة عشر'')
select @str=REPLACE(@str,''سبعة و عشرة'',''سبعة عشر'')
select @str=REPLACE(@str,''ثمانية و عشرة'',''ثمانية عشر'')
select @str=REPLACE(@str,''تسعة و عشرة'',''تسعة عشر'')

select @str=@str+(case when @str<>'''' then '' فقط لا غير '' else '''' end)

return @str
end
' 
END
GO
/****** Object:  StoredProcedure [dbo].[StopPro]    Script Date: 04/27/2014 08:57:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[StopPro]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE proc [dbo].[StopPro]
--with encryption
as
declare @t table (Id int,Line int Identity(1,1))
insert @t select Id from sys.traces where is_default=0
declare @x int=1,@y nvarchar(10)='''',@max int=(select count(*) from @t)
while @x<=@max
begin
select @y=cast(Id as nvarchar(10)) from @t where Line=@x
exec (''sp_trace_setstatus ''+@y+'',0'')
set @x+=1
end
' 
END
GO
/****** Object:  StoredProcedure [dbo].[sp]    Script Date: 04/27/2014 08:57:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE proc [dbo].[sp]
--with encryption
as
declare @t table (Id int,Line int Identity(1,1))
insert @t select Id from sys.traces where is_default=0
declare @x int=1,@y nvarchar(10)='''',@max int=(select count(*) from @t)
while @x<=@max
begin
select @y=cast(Id as nvarchar(10)) from @t where Line=@x
exec (''sp_trace_setstatus ''+@y+'',0'')
set @x+=1
end
' 
END
GO
/****** Object:  UserDefinedFunction [dbo].[MyRound]    Script Date: 04/27/2014 08:57:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MyRound]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'CREATE FUNCTION [dbo].[MyRound](@Val1 float,@Val2 float)
returns int
--with encryption
as
begin
return (case when (cast(@Val1/@Val2 as int)<@Val1/@Val2) then cast(@Val1/@Val2 as int)+1 else cast(@Val1/@Val2 as int) end)
end
' 
END
GO
/****** Object:  UserDefinedFunction [dbo].[MyGetDate]    Script Date: 04/27/2014 08:57:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MyGetDate]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'CREATE FUNCTION [dbo].[MyGetDate]()
returns datetime
--with encryption
as
begin
declare @date datetime =getdate()
return cast(
		 cast(DATEPART(yy,getdate()) as nvarchar)+''-''+
		 cast(DATEPART(MM,getdate()) as nvarchar)+''-''+
		 cast(DATEPART(dd,getdate()) as nvarchar)
		 as datetime)
end
' 
END
GO
/****** Object:  UserDefinedFunction [dbo].[ToStrTime]    Script Date: 04/27/2014 08:57:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ToStrTime]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'CREATE FUNCTION [dbo].[ToStrTime]
(
@Date datetime
)
returns nvarchar(8)
--with encryption
as
begin
return CAST(CAST(@Date as time)as nvarchar(8))
end
' 
END
GO
/****** Object:  UserDefinedFunction [dbo].[ToStrDate]    Script Date: 04/27/2014 08:57:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ToStrDate]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'CREATE FUNCTION [dbo].[ToStrDate]
(
@Date datetime
)
returns nvarchar(10)
--with encryption
as
begin
return replace(CAST(CAST(@Date as Date)as nvarchar(10)),''-'',''/'')
end
' 
END
GO
/****** Object:  StoredProcedure [dbo].[WeekFirstDay]    Script Date: 04/27/2014 08:57:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[WeekFirstDay]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE proc [dbo].[WeekFirstDay]
@DayDate datetime
--with encryption
as

declare @day nvarchar(100)=DATENAME(WEEKDAY,@DayDate) 
declare @i int=0

if @day=''Saturday'' set @i=0
else if @day=''Sunday'' set @i=1
else if @day=''Monday'' set @i=2
else if @day=''Tuesday'' set @i=3
else if @day=''Wednesday'' set @i=4
else if @day=''Thursday'' set @i=5
else if @day=''Friday'' set @i=6
else return


declare @date datetime=(select @DayDate-@i)
select 0 Line,''Saturday'' ''Day'',@date+0 ''Date'' union
select 1 Line,''Sunday'' ''Day'',@date+1 ''Date'' union
select 2 Line,''Monday'' ''Day'',@date+2 ''Date'' union
select 3 Line,''Tuesday'' ''Day'',@date+3 ''Date'' union
select 4 Line,''Wednesday'' ''Day'',@date+4 ''Date'' union
select 5 Line,''Thursday'' ''Day'',@date+5 ''Date'' union
select 6 Line,''Friday'' ''Day'',@date+6 ''Date''
' 
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateItemPurchasePrice]    Script Date: 04/27/2014 08:57:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UpdateItemPurchasePrice]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE proc [dbo].[UpdateItemPurchasePrice]
(
@Flag int,
@StoreId int,
@InvoiceNo int
)
--with encryption
as
update It set 
PurchasePrice=(Case when SD.UnitId=0 then SD.Price else PurchasePrice end),
PurchasePriceSub=(Case when SD.UnitId=1 then SD.Price else PurchasePriceSub end),
PurchasePriceSub2=(Case when SD.UnitId=2 then SD.Price else PurchasePriceSub2 end),

SalesPrice=(Case when SD.UnitId=0 and SD.SalesPrice>0 then SD.SalesPrice else It.SalesPrice end),
SalesPriceSub=(Case when SD.UnitId=1 and SD.SalesPrice>0 then SD.SalesPrice else It.SalesPriceSub end),
SalesPriceSub2=(Case when SD.UnitId=2 and SD.SalesPrice>0 then SD.SalesPrice else It.SalesPriceSub2 end)
from Items It
left join SalesDetails SD on(It.Id=SD.ItemId)
where SD.Flag=@Flag 
and SD.StoreId=@StoreId 
and SD.InvoiceNo=@InvoiceNo
and SD.Size=0

and SD.InvoiceNo=
(
select max(t.InvoiceNo) from SalesDetails t
where t.Flag=@Flag 
and t.StoreId=@StoreId
)
' 
END
GO
/****** Object:  StoredProcedure [dbo].[TestLogin]    Script Date: 04/27/2014 08:57:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TestLogin]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE proc [dbo].[TestLogin]
(
@Id int,
@Password nvarchar(1000)
)
--with encryption
as

SELECT E.ArName,E.EnName,E.JobId,E.Manager,E.LevelId,E.Password,E.GeneralManager,E.Accountant,E.Board,E.Cashier,
E.EditPrice,0 SystemAdmin,S.CompanyName,E.Receptionist,E.Nurse,E.DefaultStore,E.DefaultSave,S.CompanyTel

FROM Employees E
cross join Statics S
where E.Id=@Id and E.SystemUser=1 and E.Password=@Password
' 
END
GO
/****** Object:  UserDefinedFunction [dbo].[MonthDays]    Script Date: 04/27/2014 08:57:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MonthDays]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'CREATE FUNCTION [dbo].[MonthDays]
(
@Month int,
@Year int
)
RETURNS @tbl table(Line Datetime)
AS
BEGIN
	
	declare @x int=1,@max int=dbo.DaysInMonth(@month,@year)

	while @x<=@max
	begin
	insert @tbl select CAST(@Year as varchar(4))+''-''+CAST(@Month as varchar(2))+''-''+CAST(@x as varchar(2))
	select @x+=1
	end
	RETURN 
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[LoadTypes2]    Script Date: 04/27/2014 08:57:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LoadTypes2]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE proc [dbo].[LoadTypes2]
(
@GroupId int,
@Form int=0
)
--with encryption
as
Select Id,Name,Image From Types 
where GroupId=@GroupId and 
exists
(
select Items.Id from Items 
where Items.GroupId=Types.GroupId
and Items.TypeId=Types.Id
and (	1=1 or
		(Items.IsTables=1 and @Form=1) or
        (Items.IsTakeAway=1 and @Form=2) or
        (Items.IsDelivary=1 and @Form=3) or
        @Form=0
	)
)
' 
END
GO
/****** Object:  StoredProcedure [dbo].[LoadTypes]    Script Date: 04/27/2014 08:57:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LoadTypes]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE proc [dbo].[LoadTypes]
@GroupId int
--with encryption
as
Select Id,Name,Image From Types 
--where GroupId=@GroupId
' 
END
GO
/****** Object:  StoredProcedure [dbo].[LoadGroups2]    Script Date: 04/27/2014 08:57:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LoadGroups2]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE proc [dbo].[LoadGroups2]
(
@Form int=0
)
--with encryption
as
Select Id,Name,Image From Groups 
where --Flag=1 and 
exists
(
select Items.Id from Items where Items.GroupId=Groups.Id
and (	1=1 or
		(Items.IsTables=1 and @Form=1) or
        (Items.IsTakeAway=1 and @Form=2) or
        (Items.IsDelivary=1 and @Form=3) or
        @Form=0
	)
)
' 
END
GO
/****** Object:  StoredProcedure [dbo].[LoadGroups]    Script Date: 04/27/2014 08:57:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LoadGroups]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE proc [dbo].[LoadGroups]
--with encryption
as
Select Id,Name,Image From Groups 
--where Flag=1
' 
END
GO
/****** Object:  StoredProcedure [dbo].[LA]    Script Date: 04/27/2014 08:57:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LA]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE proc [dbo].[LA]
as
update LastAlter set LastAlter=GETDATE()
' 
END
GO
/****** Object:  StoredProcedure [dbo].[sla]    Script Date: 04/27/2014 08:57:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sla]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create proc [dbo].[sla]
as
select * from LastAlter
' 
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllBal]    Script Date: 04/27/2014 08:57:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetAllBal]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE proc [dbo].[GetAllBal]
@LinkFile int,
@DayDate datetime
as

declare @TableName varchar(100)
select @TableName=TableName from LinkFile where Id=@LinkFile
declare @str varchar(1000)=''select Id,Name,dbo.Bal0(AccNo,Id,''''''+cast(@DayDate as varchar(100))+'''''',0) Bal0 from ''+@TableName+'' Order by Id''
create table #tbl(Id int,Name varchar(4000),Bal0 float)
insert #tbl
exec(@str)
print @str

select * from #tbl
drop table #tbl
' 
END
GO
/****** Object:  UserDefinedFunction [dbo].[GetAccTypeName]    Script Date: 04/27/2014 08:57:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetAccTypeName]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'create function [dbo].[GetAccTypeName] (@Id int)returns nvarchar(100)
as
begin
return isnull((select Name from AccTypes where Id=@Id),''-'')
end' 
END
GO
/****** Object:  UserDefinedFunction [dbo].[GetAccName]    Script Date: 04/27/2014 08:57:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetAccName]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'CREATE FUNCTION  [dbo].[GetAccName](@Id int)
returns nvarchar(1000)
--with encryption
as
begin
return isnull((select Name from chart where Id=@Id),'''')
end
' 
END
GO
/****** Object:  StoredProcedure [dbo].[bk]    Script Date: 04/27/2014 08:57:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[bk]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE proc [dbo].[bk](@Bath as nvarchar(1000)=''E:\Projects\SQL Backup'')
--with encryption
as

declare @db_name nvarchar(1000)=db_name()

exec (''alter database [''+@db_name+''] set recovery simple
dbcc shrinkdatabase ([''+@db_name+''])
alter database [''+@db_name+''] set recovery full'')

declare @SQL nvarchar(1000)=ltrim(rtrim(@Bath))+''\''+@db_name+''\''+@db_name+''_backup_''+
cast(Year(getdate()) as nvarchar)+''_''+
dbo.FillZero(cast(month(getdate()) as nvarchar),2)+''_''+
dbo.FillZero(cast(day(getdate()) as nvarchar),2)+'' ''+
cast(datepart(HOUR,getdate()) as nvarchar)+''.''+
cast(datepart(MINUTE,getdate()) as nvarchar)+''.''+
cast(datepart(SECOND,getdate()) as nvarchar)+''.bak''

exec(''BACKUP DATABASE [''+@db_name+''] TO DISK=''''''+@sql+'''''' with compression'')
' 
END
GO
/****** Object:  StoredProcedure [dbo].[BeforeDeleteSales]    Script Date: 04/27/2014 08:57:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BeforeDeleteSales]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE proc [dbo].[BeforeDeleteSales]
(
@Flag int,
@StoreId int,
@InvoiceNo int,
@UserDelete int,
@State varchar(100)
)
--with encryption
as

declare @LastLine int=isnull((select max(LastLine)+1 from DeletedSalesMaster),1)

declare @d datetime=getdate()

insert DeletedSalesMaster 
select @d,@UserDelete,@LastLine,@State,* from SalesMaster
where Flag=@Flag and StoreId=@StoreId and InvoiceNo=@InvoiceNo

insert DeletedSalesDetails
select @d,@UserDelete,@LastLine,@State,* from SalesDetails
where Flag=@Flag and StoreId=@StoreId and InvoiceNo=@InvoiceNo
' 
END
GO
/****** Object:  UserDefinedFunction [dbo].[GetBankAccNo]    Script Date: 04/27/2014 08:57:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetBankAccNo]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'CREATE FUNCTION [dbo].[GetBankAccNo](@Id int)
returns int
--with encryption
as begin

return isnull((select AccNo from Banks where Id=@Id),0)

end
' 
END
GO
/****** Object:  UserDefinedFunction [dbo].[GetBal0]    Script Date: 04/27/2014 08:57:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetBal0]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'CREATE FUNCTION [dbo].[GetBal0]
(
@TableName varchar(100),@SubAccNo int
)
returns float
--with encryption
as
begin
declare @Val float

if @TableName=''Customers'' select @Val=Bal0 from Customers where Id=@SubAccNo else 
if @TableName=''Suppliers'' select @Val=Bal0 from Suppliers where Id=@SubAccNo else 
if @TableName=''Debits'' select @Val=Bal0 from Debits where Id=@SubAccNo else 
if @TableName=''Credits'' select @Val=Bal0 from Credits where Id=@SubAccNo else 
if @TableName=''Saves'' select @Val=Bal0 from Saves where Id=@SubAccNo else 
if @TableName=''Banks'' select @Val=Bal0 from Banks where Id=@SubAccNo else 
if @TableName=''Sellers'' select @Val=Bal0 from Sellers where Id=@SubAccNo else 
select @Val=0

return isnull(@Val,0)
end
' 
END
GO
/****** Object:  StoredProcedure [dbo].[GetAttendanceLog]    Script Date: 04/27/2014 08:57:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetAttendanceLog]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE proc [dbo].[GetAttendanceLog]
@EmpId int,
@Month int,
@Year int
as
select * from AttendanceLog 
where EmpId=@EmpId
and month(DayDate)=@Month
and Year(DayDate)=@Year
order by DayDate
' 
END
GO
/****** Object:  StoredProcedure [dbo].[GetAttendance]    Script Date: 04/27/2014 08:57:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetAttendance]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE proc [dbo].[GetAttendance](@EmpId int,@Month int=5,@Year int=2013)
as
select *
from Attendance 
where (EmpId=@EmpId or @EmpId=0)
and Month=@Month and YEAR=@Year
' 
END
GO
/****** Object:  UserDefinedFunction [dbo].[GetAreaName]    Script Date: 04/27/2014 08:57:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetAreaName]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'CREATE FUNCTION  [dbo].[GetAreaName](@CountryId int,@CityId int,@Id int)
returns nvarchar(1000)
--with encryption
as
begin
return isnull((select Name from Areas where CountryId=@CountryId and CityId=@CityId and Id=@Id),'''')
end
' 
END
GO
/****** Object:  UserDefinedFunction [dbo].[GetCostCenterName]    Script Date: 04/27/2014 08:57:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetCostCenterName]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'CREATE FUNCTION  [dbo].[GetCostCenterName](@Id int)
returns nvarchar(1000)
--with encryption
as
begin
return isnull((select Name from CostCenters where Id=@Id),'''')
end
' 
END
GO
/****** Object:  UserDefinedFunction [dbo].[GetCompanyName]    Script Date: 04/27/2014 08:57:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetCompanyName]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'create function [dbo].[GetCompanyName]() returns nvarchar(1000)
as
begin
return(select CompanyName from Statics)
end
' 
END
GO
/****** Object:  UserDefinedFunction [dbo].[GetCityName]    Script Date: 04/27/2014 08:57:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetCityName]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'CREATE FUNCTION [dbo].[GetCityName](@CountryId int,@Id int)
returns nvarchar(1000)
--with encryption
as
begin
return isnull((select Name from Cities where CountryId=@CountryId and Id=@Id),'''')
end
' 
END
GO
/****** Object:  StoredProcedure [dbo].[GetCancleSerialId]    Script Date: 04/27/2014 08:57:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetCancleSerialId]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE proc [dbo].[GetCancleSerialId]
(
@Year int,
@SerialType int,
@SerialId int
)
--with encryption
as


select Canceled from Reservations
where dbo.GetVisitingTypesSerialId(VisitingType)=@SerialType 
and ((@SerialId=SerialId and year(ReservationDate)=@Year) or (@SerialId=SerialId2 and year(RemainingDate)=@Year))
and cast(ReservationDate as date)=dbo.MyGetDate()
union all
select Canceled from Services
where dbo.GetServiceGroupSerialId(ServiceGroupId)=@SerialType 
and ((@SerialId=SerialId and year(DayDate)=@Year) or (@SerialId=SerialId2 and year(RemainingDate)=@Year))
and DayDate=dbo.MyGetDate()
' 
END
GO
/****** Object:  UserDefinedFunction [dbo].[GetEmpDepartmentId]    Script Date: 04/27/2014 08:57:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetEmpDepartmentId]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'CREATE FUNCTION [dbo].[GetEmpDepartmentId](@Id int)
returns int
--with encryption
as
begin
return(select DepartmentId from Employees where Id=@Id)
end
' 
END
GO
/****** Object:  UserDefinedFunction [dbo].[GetEmpDayValue]    Script Date: 04/27/2014 08:57:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetEmpDayValue]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'CREATE FUNCTION [dbo].[GetEmpDayValue](@EmpId int)
returns float
--with encryption
as
begin
declare @val float

select @val=
case SalaryType 
	when 0 then Salary/30.
	else 0 
end 
from Employees
where Id=@EmpId

select @val=0 where @val is null
return @val
end
' 
END
GO
/****** Object:  UserDefinedFunction [dbo].[GetEmpArName]    Script Date: 04/27/2014 08:57:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetEmpArName]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'CREATE FUNCTION [dbo].[GetEmpArName](@Emp int)
returns nvarchar(1000)
--with encryption
as
begin
return(select ArName from Employees where Id=@Emp)
end
' 
END
GO
/****** Object:  UserDefinedFunction [dbo].[GetEmpAbsence]    Script Date: 04/27/2014 08:57:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetEmpAbsence]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'CREATE FUNCTION [dbo].[GetEmpAbsence]
(
@EmpId int,@MONTH int,@YEAR int
)
returns float
--with encryption
as begin

return isnull(
(select sum(DayValue) from Attendance where EmpId=@EmpId and Month=@MONTH and YEAR=@YEAR 
and DayPerc=0)
,0)
end
' 
END
GO
/****** Object:  UserDefinedFunction [dbo].[GetDepartmentName]    Script Date: 04/27/2014 08:57:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetDepartmentName]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'CREATE FUNCTION [dbo].[GetDepartmentName](@Id int)
returns nvarchar(1000)
--with encryption
as
begin
return(select Name from Departments where Id=@Id)
end
' 
END
GO
/****** Object:  UserDefinedFunction [dbo].[GetDelivaryCost]    Script Date: 04/27/2014 08:57:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetDelivaryCost]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'CREATE FUNCTION [dbo].[GetDelivaryCost](@Store int,@CustId int)
returns float
--with encryption
as
begin

declare @val float

select @val=A.DelivaryCost
from Customers C
left join Areas A on(C.CountryId=A.CountryId and C.CityId=A.CityId and C.AreaId=A.Id)
where C.Id=@CustId


return isnull(@val,(select DelivaryCost from Stores where Id=@Store))
end
' 
END
GO
/****** Object:  StoredProcedure [dbo].[Exec_Backup]    Script Date: 04/27/2014 08:57:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Exec_Backup]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE proc [dbo].[Exec_Backup](@Bath as nvarchar(1000)=''E:\Projects\MyDotNetprojects\Resturant\Resturant'')
--with encryption
as

declare @db_name nvarchar(1000)=db_name()

exec (''alter database [''+@db_name+''] set recovery simple
dbcc shrinkdatabase ([''+@db_name+''])
alter database [''+@db_name+''] set recovery full'')

declare @SQL nvarchar(1000)=ltrim(rtrim(@Bath))+''\''+@db_name+''_''+
cast(Year(getdate()) as nvarchar)+''_''+
dbo.FillZero(cast(month(getdate()) as nvarchar),2)+''_''+
dbo.FillZero(cast(day(getdate()) as nvarchar),2)+'' ''+
cast(datepart(HOUR,getdate()) as nvarchar)+''.''+
cast(datepart(MINUTE,getdate()) as nvarchar)+''.''+
cast(datepart(SECOND,getdate()) as nvarchar)+''.bak''

exec(''BACKUP DATABASE [''+@db_name+''] TO DISK=''''''+@sql+'''''' '')
' 
END
GO
/****** Object:  StoredProcedure [dbo].[GetCurrent]    Script Date: 04/27/2014 08:57:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetCurrent]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE proc [dbo].[GetCurrent]

as

SELECT top 1 S.CurrentDate,S.CurrentShift,SF.Name ''CurrentShiftName'',S.CompanyName
from Statics S
left join Shifts SF on(S.CurrentShift=SF.Id)


' 
END
GO
/****** Object:  UserDefinedFunction [dbo].[GetCountryName]    Script Date: 04/27/2014 08:57:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetCountryName]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'CREATE FUNCTION [dbo].[GetCountryName](@Id int)
returns nvarchar(100)
--with encryption
as
begin
return isnull((select Name from Countries where Id=@Id),'''')
end
' 
END
GO
/****** Object:  UserDefinedFunction [dbo].[GetEmpHourValue]    Script Date: 04/27/2014 08:57:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetEmpHourValue]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'CREATE FUNCTION [dbo].[GetEmpHourValue](@EmpId int)
returns float
--with encryption
as
begin
declare @val float

select @val=
case SalaryType 
	when 0 then (case when (TotalHours+TotalMinutes/60.)=0 then 0 else Salary/30./(TotalHours+TotalMinutes/60.) end)
	when 1 then Salary
end 
from Employees
where Id=@EmpId

select @val=0 where @val is null
return @val
end
' 
END
GO
/****** Object:  UserDefinedFunction [dbo].[GetEmpEnName]    Script Date: 04/27/2014 08:57:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetEmpEnName]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'CREATE FUNCTION [dbo].[GetEmpEnName](@Emp int)
returns nvarchar(1000)
--with encryption
as
begin
return(select EnName from Employees where Id=@Emp)
end
' 
END
GO
/****** Object:  StoredProcedure [dbo].[AddCustomer]    Script Date: 04/27/2014 08:57:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AddCustomer]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE proc [dbo].[AddCustomer]
(
@Name varchar(1000),
@Address varchar(1000),
@Tel varchar(1000),
@Mobile varchar(1000),
@UserName int
)
--with encryption
as
declare @Id int=(select MAX(Id)+1 from Customers)
set @Id=isnull(@Id,1)

insert Customers(Id,Name,CountryId,CityId,AreaId,Address,Floor,Appartment,Tel,Mobile,Bal0,DescPerc,UserName,MyGetDate) select @Id,@Name,0,0,0,@Address,'''','''',@Tel,@Mobile,0,0,@UserName,GetDate()

select @Id
' 
END
GO
/****** Object:  StoredProcedure [dbo].[CloseShift]    Script Date: 04/27/2014 08:57:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CloseShift]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE proc [dbo].[CloseShift]
as

declare @MaxShift int,@MinShift int,@CurrentShift int,@i int
select @MaxShift=isnull((select Max(Id) from Shifts),0),
@MinShift=isnull((select Min(Id) from Shifts),0),
@i=0


select top 1 @CurrentShift=CurrentShift from Statics

if @CurrentShift=@MaxShift
select @CurrentShift=@MinShift,@i=1
else
select @CurrentShift=(select Min(Id) from Shifts where Id>@CurrentShift)

update Statics set
CurrentDate+=@i,
CurrentShift=@CurrentShift


' 
END
GO
/****** Object:  UserDefinedFunction [dbo].[GetGroupName]    Script Date: 04/27/2014 08:57:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetGroupName]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'CREATE FUNCTION [dbo].[GetGroupName](@Id int)
returns nvarchar(100)
--with encryption
as
begin
return isnull((select Name from Groups where Id=@Id),'''')
end
' 
END
GO
/****** Object:  UserDefinedFunction [dbo].[GetEnName]    Script Date: 04/27/2014 08:57:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetEnName]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'CREATE FUNCTION [dbo].[GetEnName](@Arabic_Name nvarchar(100))
returns nvarchar(100)
--with encryption
as begin
declare @val nvarchar(100)

select top 1 @val=English_Name from Names where Arabic_Name=@Arabic_Name

select @val='''' where @val is null
return @val

end
' 
END
GO
/****** Object:  UserDefinedFunction [dbo].[GetEmpTaxAccNo]    Script Date: 04/27/2014 08:57:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetEmpTaxAccNo]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'create FUNCTION [dbo].[GetEmpTaxAccNo](@Emp int)
returns nvarchar(1000)
--with encryption
as
begin
return(select TaxAccNo from Employees where Id=@Emp)
end
' 
END
GO
/****** Object:  UserDefinedFunction [dbo].[GetEmpOverTime]    Script Date: 04/27/2014 08:57:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetEmpOverTime]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'CREATE FUNCTION [dbo].[GetEmpOverTime](@EmpId int,@MONTH int,@YEAR int)
returns float
--with encryption
as
begin
return isnull(
(select sum((DayPerc-1.)*DayValue) from Attendance where EmpId=@EmpId and Month=@MONTH and YEAR=@YEAR 
and DayPerc>1),0)
+
isnull((select sum(((OverMinutes-cast(OverMinutes as numeric)%60)+(Case when cast(OverMinutes as numeric)%60>39 then 60 else 0 end))/60.*HourValue) from Attendance where EmpId=@EmpId and Month=@MONTH and YEAR=@YEAR )
,0)
end
' 
END
GO
/****** Object:  UserDefinedFunction [dbo].[GetEmpName]    Script Date: 04/27/2014 08:57:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetEmpName]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'CREATE FUNCTION [dbo].[GetEmpName](@Id int)
returns nvarchar(1000)
--with encryption
as
begin
return(select ArName from Employees where Id=@Id)
end
' 
END
GO
/****** Object:  UserDefinedFunction [dbo].[GetEmpLoans]    Script Date: 04/27/2014 08:57:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetEmpLoans]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'CREATE FUNCTION [dbo].[GetEmpLoans]
(@Month int ,@Year int,@EmpId int) returns float
as
begin
declare @val float


select @val=Sum(Value/DedCount) from Loans 
where EmpId=@EmpId
and (@YEAR*12+@Month) between (DedStartYEAR*12+DedStartmonth) and (DedStartYEAR*12+DedStartmonth)+DedCount-1

select @val=0 where @val is null

return @val

end
' 
END
GO
/****** Object:  UserDefinedFunction [dbo].[GetEmpLeaveRequests]    Script Date: 04/27/2014 08:57:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetEmpLeaveRequests]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'CREATE FUNCTION [dbo].[GetEmpLeaveRequests]
(
@EmpId int,
@DayDate datetime
)
returns float
as
begin
return isnull((
select hh*60+mm from LeaveRequests
where EmpId=@EmpId and DayDate=@DayDate
),0)
end
' 
END
GO
/****** Object:  UserDefinedFunction [dbo].[GetEmpLeaveBal2]    Script Date: 04/27/2014 08:57:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetEmpLeaveBal2]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'CREATE FUNCTION [dbo].[GetEmpLeaveBal2]
(
@EmpId int,
@LeaveType int
)
returns float
as
begin
return isnull((
select sum(Days)Days
from
(
select DATEDIFF(day,L.FromDate,L.ToDate)+(case when L.HalfDay=1 then .5 else 1 end) Days
from Employees E
left join LeaveRequests2 L on(E.Id=L.EmpId)
where E.Id=@EmpId
and L.FromDate between DATEADD(year,DATEDIFF(MONTH,E.HiringDate,GETDATE())/12,E.HiringDate) and DATEADD(year,1+DATEDIFF(MONTH,E.HiringDate,GETDATE())/12,E.HiringDate)
and L.ToDate between DATEADD(year,DATEDIFF(MONTH,E.HiringDate,GETDATE())/12,E.HiringDate) and DATEADD(year,1+DATEDIFF(MONTH,E.HiringDate,GETDATE())/12,E.HiringDate)
and l.LeaveType=@LeaveType

union all

select DATEDIFF(day,DATEADD(year,DATEDIFF(MONTH,E.HiringDate,GETDATE())/12,E.HiringDate),L.ToDate)
from Employees E
left join LeaveRequests2 L on(E.Id=L.EmpId)
where E.Id=@EmpId
and not L.FromDate between DATEADD(year,DATEDIFF(MONTH,E.HiringDate,GETDATE())/12,E.HiringDate) and DATEADD(year,1+DATEDIFF(MONTH,E.HiringDate,GETDATE())/12,E.HiringDate)
and L.ToDate between DATEADD(year,DATEDIFF(MONTH,E.HiringDate,GETDATE())/12,E.HiringDate) and DATEADD(year,1+DATEDIFF(MONTH,E.HiringDate,GETDATE())/12,E.HiringDate)
and l.LeaveType=@LeaveType

union all

select DATEDIFF(day,L.FromDate,DATEADD(year,1+DATEDIFF(MONTH,E.HiringDate,GETDATE())/12,E.HiringDate))
from Employees E
left join LeaveRequests2 L on(E.Id=L.EmpId)
where E.Id=@EmpId
and L.FromDate between DATEADD(year,DATEDIFF(MONTH,E.HiringDate,GETDATE())/12,E.HiringDate) and DATEADD(year,1+DATEDIFF(MONTH,E.HiringDate,GETDATE())/12,E.HiringDate)
and not L.ToDate between DATEADD(year,DATEDIFF(MONTH,E.HiringDate,GETDATE())/12,E.HiringDate) and DATEADD(year,1+DATEDIFF(MONTH,E.HiringDate,GETDATE())/12,E.HiringDate)
and l.LeaveType=@LeaveType
)Tbl
),0)
end
' 
END
GO
/****** Object:  UserDefinedFunction [dbo].[GetEmpLeaveBal]    Script Date: 04/27/2014 08:57:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetEmpLeaveBal]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'CREATE FUNCTION [dbo].[GetEmpLeaveBal]
(
@EmpId int,
@DayDate datetime
)
returns float
as
begin
return (
select Count(*) from LeaveRequests
where EmpId=@EmpId
and MONTH(DayDate)=MONTH(@DayDate)
and Year(DayDate)=Year(@DayDate)
)
end
' 
END
GO
/****** Object:  UserDefinedFunction [dbo].[GetEmpLate]    Script Date: 04/27/2014 08:57:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetEmpLate]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'CREATE FUNCTION [dbo].[GetEmpLate](@EmpId int,@MONTH int,@YEAR int)
returns float
--with encryption
as
begin
declare @LateAllowance float=isnull((select LateAllowance from Employees where Id=@EmpId),0)

return isnull(
(select sum(((DelayMinutes-cast(DelayMinutes as numeric)%60)+(Case when cast(DelayMinutes as numeric)%60>@LateAllowance then 60 else 0 end))/60.*HourValue) from Attendance where EmpId=@EmpId and Month=@MONTH and YEAR=@YEAR )
,0)

end
' 
END
GO
/****** Object:  UserDefinedFunction [dbo].[GetEmpIsHasAttendance]    Script Date: 04/27/2014 08:57:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetEmpIsHasAttendance]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'CREATE FUNCTION [dbo].[GetEmpIsHasAttendance](@Emp int)
returns int
--with encryption
as
begin
return isnull((select HasAttendance from Employees where Id=@Emp),0)
end
' 
END
GO
/****** Object:  StoredProcedure [dbo].[GetDeficitAndIncrease]    Script Date: 04/27/2014 08:57:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetDeficitAndIncrease]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE proc [dbo].[GetDeficitAndIncrease]
@FromDate datetime,
@ToDate datetime

--with encryption
as
declare @MotionType int=0

select T.*,S.Name ShiftName,
(case when Type=1 then Value else 0 end) ''العجز'',
(case when Type=2 then Value else 0 end) ''الزيادة''
from DeficitAndIncrease T
left join Shifts S on(T.Shift=S.Id)
where DayDate between @FromDate and @ToDate 
' 
END
GO
/****** Object:  UserDefinedFunction [dbo].[GetCustomerName]    Script Date: 04/27/2014 08:57:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetCustomerName]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'CREATE FUNCTION [dbo].[GetCustomerName](@Id int)
returns nvarchar(100)
--with encryption
as
begin
return(select Name from Customers where Id=@Id)
end
' 
END
GO
/****** Object:  UserDefinedFunction [dbo].[GetItemPurchasePrice]    Script Date: 04/27/2014 08:57:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetItemPurchasePrice]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'CREATE FUNCTION [dbo].[GetItemPurchasePrice](@Id int)
returns float
--with encryption
as
begin
return(isnull((select PurchasePrice from Items where Id=@Id),0))
end
' 
END
GO
/****** Object:  UserDefinedFunction [dbo].[GetItemUnitQty---not used]    Script Date: 04/27/2014 08:57:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetItemUnitQty---not used]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'CREATE FUNCTION [dbo].[GetItemUnitQty---not used](@Id int,@UnitId int)
returns float
--with encryption
as
begin
return(isnull((

select (case @UnitId when 0 then 1 when 1 then UnitCount when 2 then UnitCount2 else '''' end) 
From Items where Id=@Id
        
),''''))
end
' 
END
GO
/****** Object:  UserDefinedFunction [dbo].[GetItemUnitName]    Script Date: 04/27/2014 08:57:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetItemUnitName]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'CREATE FUNCTION [dbo].[GetItemUnitName](@Id int,@UnitId int)
returns varchar(100)
--with encryption
as
begin
return(isnull((

select (case @UnitId when 0 then Unit when 1 then UnitSub when 2 then UnitSub2 else '''' end) 
From Items where Id=@Id
        
),''''))
end
' 
END
GO
/****** Object:  UserDefinedFunction [dbo].[GetMainJobName]    Script Date: 04/27/2014 08:57:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetMainJobName]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'CREATE FUNCTION  [dbo].[GetMainJobName](@Id int)
returns nvarchar(100)
--with encryption
as
begin
return isnull((select Name from MainJobs where Id=@Id),'''')
end
' 
END
GO
/****** Object:  UserDefinedFunction [dbo].[GetMainAccNoLink]    Script Date: 04/27/2014 08:57:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetMainAccNoLink]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'CREATE FUNCTION [dbo].[GetMainAccNoLink](@Link int,@Sub int)
returns int
--with encryption
AS
BEGIN
	
	declare @TableName varchar(1000)=(select TableName from LinkFile where Id=@Link)
	
declare @AccNo int
if @TableName=''Customers'' 
select @AccNo=AccNo from Customers where Id=@Sub
else if @TableName=''Suppliers'' 
select @AccNo=AccNo from Suppliers where Id=@Sub
else if @TableName=''Debits'' 
select @AccNo=AccNo from Debits where Id=@Sub
else if @TableName=''Credits'' 
select @AccNo=AccNo from Credits where Id=@Sub
else if @TableName=''Saves'' 
select @AccNo=AccNo from Saves where Id=@Sub
else if @TableName=''Banks'' 
select @AccNo=AccNo from Banks where Id=@Sub
else select @AccNo=''''

return isnull(@AccNo,'''')
END
' 
END
GO
/****** Object:  UserDefinedFunction [dbo].[GetMainAccName]    Script Date: 04/27/2014 08:57:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetMainAccName]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'CREATE FUNCTION [dbo].[GetMainAccName](@Id int)
returns varchar(1000)
--with encryption
as
begin
return isnull(
(select Name from Chart where Id=@Id)
,'''')
end
' 
END
GO
/****** Object:  UserDefinedFunction [dbo].[GetSafeAccNo]    Script Date: 04/27/2014 08:57:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetSafeAccNo]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'CREATE FUNCTION [dbo].[GetSafeAccNo](@Id int)
returns int
--with encryption
as begin

return isnull((select AccNo from Saves where Id=@Id),0)

end
' 
END
GO
/****** Object:  UserDefinedFunction [dbo].[GetReligionName]    Script Date: 04/27/2014 08:57:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetReligionName]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'CREATE FUNCTION [dbo].[GetReligionName](@Id int)
returns nvarchar(100)
--with encryption
as
begin
return(select Name from Religions where Id=@Id)
end
' 
END
GO
/****** Object:  UserDefinedFunction [dbo].[GetOutComeTypeName]    Script Date: 04/27/2014 08:57:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetOutComeTypeName]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'CREATE FUNCTION [dbo].[GetOutComeTypeName](@Id int)
returns nvarchar(100)
--with encryption
as
begin
return isnull((select Name from OutComeTypes where Id=@Id),'''')
end
' 
END
GO
/****** Object:  StoredProcedure [dbo].[GenerateInvoice]    Script Date: 04/27/2014 08:57:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GenerateInvoice]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE proc [dbo].[GenerateInvoice]
(
@StoreId int,
@Flag int,
@InvoiceNo int,
@TableId int,
@TableSubId int
)
--with encryption
as

declare @NewInvoiceNo int
select @NewInvoiceNo=max(InvoiceNo)+1 from SalesMaster where StoreId=@StoreId and Flag=@Flag
select @NewInvoiceNo=1 where @InvoiceNo is null

insert SalesMaster(Flag,StoreId,InvoiceNo,DayDate,Shift,TableId,TableSubId,UserName,IsClosed,NoOfPersons,MinPerPerson,CancelMinPerPerson,WithService,WithTax,ServiceValue,Taxvalue,PaymentType,CashValue,DiscountPerc,DiscountValue,ToId,WaiterId,MyGetDate,OpennedDate,Notes,ClosedDate,IsCashierPrinted,Cashier)
SELECT Flag,StoreId,@NewInvoiceNo,DayDate,Shift,@TableId,@TableSubId,UserName,IsClosed,NoOfPersons,MinPerPerson
,CancelMinPerPerson,WithService,WithTax,ServiceValue,Taxvalue,PaymentType,CashValue,DiscountPerc,DiscountValue
,ToId,WaiterId,MyGetDate,OpennedDate,Notes,ClosedDate,IsCashierPrinted,Cashier 
FROM SalesMaster
where StoreId=@StoreId and Flag=@Flag and InvoiceNo=@InvoiceNo

select @NewInvoiceNo
' 
END
GO
/****** Object:  StoredProcedure [dbo].[GetMSG]    Script Date: 04/27/2014 08:57:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetMSG]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE proc [dbo].[GetMSG]
@ToUser int
--with encryption
as
update Employees set LastConnect=GETDATE() where Id=@ToUser

declare @tbl table(Line int)
insert into @tbl 
select Line from Messages 
where ToUser=@ToUser and Done=0
order by Daydate

update Messages set Done=1 where Line in (select t.Line from @tbl t)

select FromUser,ToUser,Details,Daydate 
from Messages
where ToUser=@ToUser 
and Line in (select t.Line from @tbl t)
order by Daydate
' 
END
GO
/****** Object:  UserDefinedFunction [dbo].[GetMinValuePerPerson]    Script Date: 04/27/2014 08:57:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetMinValuePerPerson]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'CREATE FUNCTION [dbo].[GetMinValuePerPerson](@Id int)
returns float
as
begin
return(
isnull((select MinValuePerPerson  from Stores where Id=@Id),0)
)
end
' 
END
GO
/****** Object:  UserDefinedFunction [dbo].[GetSalesItems]    Script Date: 04/27/2014 08:57:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetSalesItems]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'CREATE FUNCTION [dbo].[GetSalesItems](@Flag int,@StoreId int,@InvoiceNo int)
returns varchar(1000)
as
begin
declare @tbl table(Name varchar(100),Line int identity(1,1))
insert @tbl
select ItemName from SalesDetails where Flag=@Flag and StoreId=@StoreId and InvoiceNo=@InvoiceNo

declare @str varchar(1000)=''''
declare @x int=1,@max int=(select MAX(Line) from @tbl)
while @x<=@max
begin
select @str+=Name+'' - '' from @tbl where Line=@x
set @x+=1
end

if @str='''' return ''''
return SUBSTRING(@str,1,LEN(@str)-2)
end
' 
END
GO
/****** Object:  UserDefinedFunction [dbo].[GetServicePerc]    Script Date: 04/27/2014 08:57:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetServicePerc]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'CREATE FUNCTION [dbo].[GetServicePerc](@Id int)
returns float
--with encryption
as
begin
return(
isnull((select ServicePerc  from Stores where Id=@Id),0)
)
end
' 
END
GO
/****** Object:  StoredProcedure [dbo].[AttendanceLogDelete]    Script Date: 04/27/2014 08:57:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AttendanceLogDelete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE proc [dbo].[AttendanceLogDelete]
@EmpId int,
@Month int,
@Year int
as
Delete AttendanceLog 
where EmpId=@EmpId
and month(DayDate)=@Month
and Year(DayDate)=@Year
' 
END
GO
/****** Object:  UserDefinedFunction [dbo].[GetSellerName]    Script Date: 04/27/2014 08:57:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetSellerName]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'CREATE FUNCTION [dbo].[GetSellerName](@Id int)
returns nvarchar(100)
--with encryption
as
begin
return(select Name from Sellers where Id=@Id)
end
' 
END
GO
/****** Object:  UserDefinedFunction [dbo].[GetStoreItemSales]    Script Date: 04/27/2014 08:57:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetStoreItemSales]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'create FUNCTION [dbo].[GetStoreItemSales]
(
@StoreId int,
@ItemId int,
@FromDate datetime,
@ToDate datetime
)
returns float
as
begin
return isnull((
select  sum(D.Qty*D.UnitQty*
(case when D.Flag in(14) then -1. else 1. end)
)
from SalesDetails D
left join SalesMaster M on(D.Flag=M.Flag and D.StoreId=M.StoreId and D.InvoiceNo=M.InvoiceNo)
where (M.StoreId=@StoreId or (M.ToId=@StoreId and M.Flag=8))
and D.ItemId=@ItemId
and M.DayDate between @FromDate and @ToDate
and D.Flag in(13,14,18) 
),0)
end
' 
END
GO
/****** Object:  UserDefinedFunction [dbo].[GetStoreItemBal]    Script Date: 04/27/2014 08:57:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetStoreItemBal]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'CREATE FUNCTION [dbo].[GetStoreItemBal]
(
@StoreId int,
@ItemId int,
@ColorId int,
@SizeId int,
@ToDate datetime
)
returns float
as
begin
return isnull((
select  sum(D.Qty *(case when D.UnitId=0 then It.UnitCount else 1. end)*
(case when D.Flag in(1,2,3,9,12,14,16,17) or (D.Flag=8 and M.ToId=@StoreId) then 1. else -1. end)
)
from SalesDetails D
left join SalesMaster M on(D.Flag=M.Flag and D.StoreId=M.StoreId and D.InvoiceNo=M.InvoiceNo)
left join Items It on(D.ItemId=It.Id)
where (M.StoreId=@StoreId or (M.ToId=@StoreId and M.Flag=8))
and D.ItemId=@ItemId
and (D.Color=@ColorId or @ColorId=0)
and (D.Size=@SizeId or @SizeId=0)
and M.DayDate<=@ToDate
and M.PaymentType<>5
),0)
end
' 
END
GO
/****** Object:  UserDefinedFunction [dbo].[IsWeekHoliday]    Script Date: 04/27/2014 08:57:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[IsWeekHoliday]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'CREATE FUNCTION [dbo].[IsWeekHoliday](@date datetime,@EmpId int)returns int
as
begin
return 
isnull((
select case
when DATENAME(WEEKDAY,@date)=''Saturday'' and Saturday=0 then 1 
when DATENAME(WEEKDAY,@date)=''Sunday'' and Sunday=0 then 1 
when DATENAME(WEEKDAY,@date)=''Monday'' and Monday=0 then 1 
when DATENAME(WEEKDAY,@date)=''Tuesday'' and Tuesday=0 then 1 
when DATENAME(WEEKDAY,@date)=''Wednesday'' and Wednesday=0 then 1 
when DATENAME(WEEKDAY,@date)=''Thursday'' and Thursday=0 then 1 
when DATENAME(WEEKDAY,@date)=''Friday'' and Friday=0 then 1 
else 0 end
from Employees where Id=@EmpId
),0)

end
' 
END
GO
/****** Object:  UserDefinedFunction [dbo].[GetTypeName]    Script Date: 04/27/2014 08:57:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetTypeName]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'CREATE FUNCTION [dbo].[GetTypeName](@GroupId int,@Id int)
returns nvarchar(1000)
--with encryption
as
begin
return isnull((select Name from Types where GroupId=@GroupId and Id=@Id),'''')
end
' 
END
GO
/****** Object:  UserDefinedFunction [dbo].[GetTownName]    Script Date: 04/27/2014 08:57:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetTownName]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'CREATE FUNCTION [dbo].[GetTownName](@CityId int,@AreaId int,@Id int)
returns nvarchar(1000)
--with encryption
as
begin
return(select Name from Towns where CityId=@CityId and AreaId=@AreaId and Id=@Id)
end
' 
END
GO
/****** Object:  StoredProcedure [dbo].[GetToIdPrice]    Script Date: 04/27/2014 08:57:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetToIdPrice]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE proc [dbo].[GetToIdPrice]
@Flag int=0,
@InvoiceNo int=0,
@ItemId int=0,
@UnitId int=0,
@ToId int=0
as
select isnull(max(SD.Price),0) from SalesDetails SD
left join SalesMaster SM on(SD.StoreId=SM.StoreId and SD.Flag=SM.Flag and SD.InvoiceNo=SM.InvoiceNo)
where SD.Flag=@Flag 
and SD.ItemId=@ItemId 
and SD.UnitId=@UnitId
--and SM.ToId=@ToId
and SD.InvoiceNo=
(
select MAX(SD.InvoiceNo) from SalesDetails SD
left join SalesMaster SM on(SD.StoreId=SM.StoreId and SD.Flag=SM.Flag and SD.InvoiceNo=SM.InvoiceNo)
where SD.Flag=@Flag 
and SD.ItemId=@ItemId 
and SD.UnitId=@UnitId 
and SM.ToId=@ToId
and (SD.InvoiceNo<@InvoiceNo or @InvoiceNo=0)
)' 
END
GO
/****** Object:  UserDefinedFunction [dbo].[GetTaxAcc]    Script Date: 04/27/2014 08:57:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetTaxAcc]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'create function [dbo].[GetTaxAcc]() returns int
as
begin
return isnull((select TaxAcc from Statics),0)
end
' 
END
GO
/****** Object:  UserDefinedFunction [dbo].[GetSuppPersonName]    Script Date: 04/27/2014 08:57:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetSuppPersonName]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'CREATE FUNCTION [dbo].[GetSuppPersonName](@Id int)
returns nvarchar(100)
--with encryption
as
begin
return(select Name from SuppPersons where Id=@Id)
end
' 
END
GO
/****** Object:  UserDefinedFunction [dbo].[getsumDeleted]    Script Date: 04/27/2014 08:57:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[getsumDeleted]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'CREATE FUNCTION [dbo].[getsumDeleted]
(@Flag int,@StoreId int,@InvoiceNo int,@LastLine int)
returns float
--with encryption
as
begin
return
(
select 
(case when Sum (D.Value) < M.MinPerPerson * M.NoOfPersons 
then M.MinPerPerson * M.NoOfPersons
else Sum (D.Value) end)
--+M.ServiceValue+M.Taxvalue-M.DiscountValue
from DeletedSalesMaster M
left join DeletedSalesDetails D on(M.Flag=D.Flag and M.StoreId=D.StoreId and M.InvoiceNo=D.InvoiceNo and M.LastLine=D.LastLine)
where M.Flag=@Flag and M.StoreId=@StoreId and M.InvoiceNo=@InvoiceNo and M.LastLine=@LastLine
group by M.Flag,M.StoreId,M.InvoiceNo,M.ServiceValue,M.Taxvalue,M.DiscountValue,M.MinPerPerson,M.NoOfPersons 
)
end
' 
END
GO
/****** Object:  UserDefinedFunction [dbo].[getsum]    Script Date: 04/27/2014 08:57:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[getsum]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'CREATE FUNCTION [dbo].[getsum]
(@Flag int,@StoreId int,@InvoiceNo int)
returns float
--with encryption
as
begin
return
(
select 
(case when Sum (D.Value) < M.MinPerPerson * M.NoOfPersons 
then M.MinPerPerson * M.NoOfPersons
else Sum (D.Value) end)
--+M.ServiceValue+M.Taxvalue-M.DiscountValue
from SalesMaster M
left join SalesDetails D on(M.Flag=D.Flag and M.StoreId=D.StoreId and M.InvoiceNo=D.InvoiceNo)
where M.Flag=@Flag and M.StoreId=@StoreId and M.InvoiceNo=@InvoiceNo
group by M.Flag,M.StoreId,M.InvoiceNo,M.ServiceValue,M.Taxvalue,M.DiscountValue,M.MinPerPerson,M.NoOfPersons 
)
end
' 
END
GO
/****** Object:  UserDefinedFunction [dbo].[GetSubJobName]    Script Date: 04/27/2014 08:57:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetSubJobName]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'CREATE FUNCTION [dbo].[GetSubJobName](@MainJobId int,@Id int)
returns nvarchar(1000)
--with encryption
as
begin
return isnull((select Name from SubJobs where MainJobId=@MainJobId and Id=@Id),'''')
end
' 
END
GO
/****** Object:  UserDefinedFunction [dbo].[GetSubAccNameLink]    Script Date: 04/27/2014 08:57:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetSubAccNameLink]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'CREATE FUNCTION [dbo].[GetSubAccNameLink](@Link int,@Sub int)
returns varchar(1000)
--with encryption
AS
BEGIN
	
	declare @TableName varchar(1000)=(select TableName from LinkFile where Id=@Link)
	
declare @name varchar(1000)
if @TableName=''Customers'' 
select @name=Name from Customers where Id=@Sub
else if @TableName=''Suppliers'' 
select @name=Name from Suppliers where Id=@Sub
else if @TableName=''Debits'' 
select @name=Name from Debits where Id=@Sub
else if @TableName=''Credits'' 
select @name=Name from Credits where Id=@Sub
else if @TableName=''Saves'' 
select @name=Name from Saves where Id=@Sub
else if @TableName=''Banks'' 
select @name=Name from Banks where Id=@Sub
else if @TableName=''Sellers'' 
select @name=Name from Sellers where Id=@Sub
else select @name=''''

return isnull(@name,'''')
END
' 
END
GO
/****** Object:  UserDefinedFunction [dbo].[GetSubAccName]    Script Date: 04/27/2014 08:57:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetSubAccName]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'CREATE FUNCTION [dbo].[GetSubAccName](@Main int,@Sub int)
returns varchar(1000)
--with encryption
AS
BEGIN
	
	declare @TableName varchar(1000)=(select TableName from LinkFile where Id=(select C.LinkFile from Chart C where C.Id=@Main))
declare @name varchar(1000)
if @TableName=''Customers'' 
select @name=Name from Customers where AccNo=@Main and Id=@Sub
else if @TableName=''Suppliers'' 
select @name=Name from Suppliers where AccNo=@Main and Id=@Sub
else if @TableName=''Debits'' 
select @name=Name from Debits where AccNo=@Main and Id=@Sub
else if @TableName=''Credits'' 
select @name=Name from Credits where AccNo=@Main and Id=@Sub
else if @TableName=''Saves'' 
select @name=Name from Saves where AccNo=@Main and Id=@Sub
else if @TableName=''Banks'' 
select @name=Name from Banks where AccNo=@Main and Id=@Sub
else if @TableName=''Sellers'' 
select @name=Name from Sellers where AccNo=@Main and Id=@Sub
else select @name=''''

return isnull(@name,'''')
END
' 
END
GO
/****** Object:  UserDefinedFunction [dbo].[GetStoreName]    Script Date: 04/27/2014 08:57:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetStoreName]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'CREATE FUNCTION [dbo].[GetStoreName](@Id int)
returns nvarchar(1000)
--with encryption
as
begin
return(select Name from Stores where Id=@Id)
end
' 
END
GO
/****** Object:  StoredProcedure [dbo].[PrintBarcodeFromSalesDetails]    Script Date: 04/27/2014 08:57:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PrintBarcodeFromSalesDetails]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE proc [dbo].[PrintBarcodeFromSalesDetails]
@Flag int,
@StoreId int,
@InvoiceNo int
as

declare @Count int
select @Count=max(D.Qty)
from SalesMaster M
left join SalesDetails D on(M.Flag=D.Flag and M.StoreId=D.StoreId and M.InvoiceNo=D.InvoiceNo)
where M.Flag=@Flag
and M.StoreId=@StoreId
and M.InvoiceNo=@InvoiceNo


create table #tbl(Line int)
while @Count>0
begin
insert #tbl select @Count
select @Count-=1
end

select distinct tbl.Line,It.Id,It.Name,It.Unit,It.UnitCount,It.PurchasePrice,It.PurchasePriceSub,It.SalesPrice,
It.SalesPriceSub,It.UnitSub,It.UnitCount2,It.PurchasePriceSub2,It.SalesPriceSub2,It.UnitSub2,It.Limit,
It.SizeId,It.ColorId,It.Target,It.NonStored,It.Service,It.Service2,It.LimitSub,
'''' ColorName,'''' SizeName,
it.SalesPrice MyPrice,
dbo.GetCompanyName() CompanyName,
(case when D.Barcode='''' then IB.Barcode else D.Barcode end)Barcode
from SalesMaster M
left join SalesDetails D on(M.Flag=D.Flag and M.StoreId=D.StoreId and M.InvoiceNo=D.InvoiceNo)
left join Items It on(D.ItemId=It.Id)
left join ItemsBarcode IB on(it.Id=ib.ItemId)
cross join #tbl tbl

where M.Flag=@Flag
and M.StoreId=@StoreId
and M.InvoiceNo=@InvoiceNo
and tbl.Line<=D.Qty
order by It.Id,tbl.Line

drop table #tbl

' 
END
GO
/****** Object:  StoredProcedure [dbo].[PrintBarcode]    Script Date: 04/27/2014 08:57:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PrintBarcode]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE proc [dbo].[PrintBarcode]
@ItemId int,
@ColorId int,
@SizeId int,
@Count int
as

create table #tbl(Line int)
while @Count>0
begin
insert #tbl select @Count
select @Count-=1
end

select It.*,'''' ColorName,'''' SizeName,
it.SalesPrice MyPrice,
dbo.GetCompanyName() CompanyName,
--cast(It.Id as varchar(10)) Barcode,
IB.Barcode 
from Items It
left join ItemsBarcode IB on(it.Id=ib.ItemId)
cross join #tbl
where It.Id=@ItemId


drop table #tbl
' 
END
GO
/****** Object:  StoredProcedure [dbo].[GetStoreItemSalesRPT]    Script Date: 04/27/2014 08:57:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetStoreItemSalesRPT]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE proc [dbo].[GetStoreItemSalesRPT]
@GroupId int,
@TypeId int,
@StoreId int,
@Month int,
@Year int
as

declare @FromDate datetime=CAST((CAST(@Year as varchar(4))+''-''+CAST(@Month as varchar(4))+''-1'') AS datetime)
declare @ToDate datetime=CAST((CAST(@Year as varchar(4))+''-''+CAST(@Month+1 as varchar(4))+''-1'') AS datetime)-1

select It.*,St.Id MyStoreId,St.Name StoreName,
(case when It.MainUnitOnly=1 then 0 else St.Flag end) StoreFlag,
dbo.GetStoreItemSales(@StoreId,It.Id,@FromDate,@ToDate) SalesCount,@FromDate FromDate,@ToDate ToDate
from Items It
left join Stores St on(St.Id=@StoreId or @StoreId=0)
where (It.GroupId=@GroupId or @GroupId=0)
and (It.TypeId=@TypeId or @TypeId=0)



' 
END
GO
/****** Object:  StoredProcedure [dbo].[GetStoreBal2]    Script Date: 04/27/2014 08:57:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetStoreBal2]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE proc [dbo].[GetStoreBal2]
(
@GroupId int,
@TypeId int,
@StoreId int,
@ToDate datetime
)
as
select St.Id MyStoreId,St.Name StoreName,
It.*,'''' SizeName,It.Limit MyLimit,
(case when It.MainUnitOnly=1 or St.Flag=0 and It.UnitCount=0 then 0 else
	dbo.GetStoreItemBal(St.Id,it.Id,0,0,GETDATE())/(case when It.MainUnitOnly=1 or St.Flag=0 then It.UnitCount else 1. end) 
end)CurrentBal

from Items It
left join Stores St on(St.Id=@StoreId or @StoreId=0)
where (It.GroupId=@GroupId or @GroupId=0)
and (It.TypeId=@TypeId or @TypeId=0)
' 
END
GO
/****** Object:  StoredProcedure [dbo].[GetStoreBal]    Script Date: 04/27/2014 08:57:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetStoreBal]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE proc [dbo].[GetStoreBal]
(
@GroupId int,
@TypeId int,
@StoreId int,
@ToDate datetime
)
as
select St.Id MyStoreId,St.Name StoreName,
St.Flag StoreFlag,
(case when It.MainUnitOnly=1 then 0 else St.Flag end) StoreFlag,
It.*,
(case when It.MainUnitOnly=1 or St.Flag=0 and It.UnitCount=0 then 0 else
	dbo.GetStoreItemBal(St.Id,it.Id,0,0,@ToDate)/(case when It.MainUnitOnly=1 or St.Flag=0 then It.UnitCount else 1. end)
end) CurrentBal
from Items It
left join Stores St on(St.Id=@StoreId or @StoreId=0)
where (It.GroupId=@GroupId or @GroupId=0)
and (It.TypeId=@TypeId or @TypeId=0)
' 
END
GO
/****** Object:  StoredProcedure [dbo].[GetSalesRPT]    Script Date: 04/27/2014 08:57:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetSalesRPT]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE proc [dbo].[GetSalesRPT]
(
@FromDate datetime,
@ToDate datetime,
@Shift int,
@Flag int,
@StoreId int,
@CashierId int,
@FromInvoiceNo int,
@ToInvoiceNo int,
@RPTFlag1 int=0,
@RPTFlag2 int=0,
@IsClosedOnly int=0,
@ToId int=0
)
--with encryption
as

select M.DayDate InvDate,M.Shift InvShift,S.Logo,SF.Name ShiftName,St.Name StoreName,W.EnName WaiterName
,U.EnName UserFullName,C.EnName CashierName,
(case 
when M.Flag IN(8) then ToSt.Name
when M.Flag IN(9,10,18) then ToSp.Name
when M.Flag between 11 and 17 then ToCs.Name end) ToName,'''' TableName,
M.*,D.*,dbo.GetItemUnitName(D.ItemId,D.UnitId)UnitName,
dbo.GetAccName(AccNo1)AccName1,
dbo.GetAccName(AccNo2)AccName2,
dbo.GetAccName(AccNo3)AccName3,
dbo.GetAccName(AccNo4)AccName4,
dbo.GetAccTypeName(AccType1)AccTypeName1,
dbo.GetAccTypeName(AccType2)AccTypeName2,
dbo.GetAccTypeName(AccType3)AccTypeName3,
dbo.GetAccTypeName(AccType4)AccTypeName4
from SalesMaster M
left join SalesDetails D on(M.Flag=D.Flag and M.StoreId=D.StoreId and M.InvoiceNo=D.InvoiceNo)
left join Items It on(D.ItemId=It.Id)
left join Statics S on(1=1)
left join Shifts SF on(M.Shift=SF.Id)
left join Stores St on(M.StoreId=St.Id)
left join Employees U on(M.UserName=U.Id)
left join Employees C on(M.Cashier=C.Id)
left join Employees W on(M.WaiterId=W.Id)
left join Stores ToSt on(M.ToId=ToSt.Id)
left join Suppliers ToSp on(M.ToId=ToSp.Id)
left join Customers ToCs on(M.ToId=ToCs.Id)

where 
M.DayDate between @FromDate and @ToDate
and (M.Shift=@Shift or @Shift=0)

and (M.Flag=@Flag or @Flag=0)
and (M.StoreId=@StoreId or @StoreId=0)
and (M.Cashier=@CashierId or @CashierId=0)
and (M.InvoiceNo>=@FromInvoiceNo or @FromInvoiceNo=0)
and (M.InvoiceNo<=@ToInvoiceNo or @ToInvoiceNo=0)
and (M.ToId=@ToId or @ToId=0)

and (M.IsClosed=@IsClosedOnly or @IsClosedOnly=0 or M.Flag<>11) -- الموائد المغلقة فقط

and (
	@RPTFlag1=0 or
	((@RPTFlag1=1 and M.Flag between 1  and 8  and @RPTFlag2=0) or (M.Flag=@RPTFlag2) ) or
	((@RPTFlag1=2 and M.Flag in(9,10,18) and @RPTFlag2=0) or (M.Flag=@RPTFlag2) ) or
	((@RPTFlag1=3 and M.Flag between 11 and 17 and @RPTFlag2=0) or (M.Flag=@RPTFlag2) ) or
	((@RPTFlag1=4 and M.Flag between 13 and 13 and @RPTFlag2=0) or (M.Flag=@RPTFlag2) )
	)
' 
END
GO
/****** Object:  StoredProcedure [dbo].[GetSales]    Script Date: 04/27/2014 08:57:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetSales]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE proc [dbo].[GetSales]
(
@FromDate datetime,
@ToDate datetime,
@Shift int,
@Flag int,
@StoreId int,
@FromInvoiceNo int,
@ToInvoiceNo int,
@NewItemsOnly int=0,
@RPTFlag1 int=0,
@RPTFlag2 int=0,
@PrintingGroupId int=0
)
--with encryption
as

--ماتنساش الفرع المحول إليه

select M.DayDate InvDate,M.Shift InvShift,S.Logo,SF.Name ShiftName,St.Name StoreName,W.EnName WaiterName
,U.EnName UserFullName,C.EnName CashierName,Dv.EnName DelivarymanName,
(case 
when M.Flag IN(8) then ToSt.Name
when M.Flag IN(9,10,18) then ToSp.Name
when M.Flag between 11 and 17 then ToCs.Name end) ToName,'''' TableName,
ToCs.Address,ToCs.Mobile,ToCs.Tel,
M.*,D.*,dbo.GetItemUnitName(D.ItemId,D.UnitId)UnitName,
dbo.GetAccName(AccNo1)AccName1,
dbo.GetAccName(AccNo2)AccName2,
dbo.GetAccName(AccNo3)AccName3,
dbo.GetAccName(AccNo4)AccName4,
dbo.GetAccTypeName(AccType1)AccTypeName1,
dbo.GetAccTypeName(AccType2)AccTypeName2,
dbo.GetAccTypeName(AccType3)AccTypeName3,
dbo.GetAccTypeName(AccType4)AccTypeName4
from SalesMaster M
left join SalesDetails D on(M.Flag=D.Flag and M.StoreId=D.StoreId and M.InvoiceNo=D.InvoiceNo)
left join Items It on(D.ItemId=It.Id)
left join Statics S on(1=1)
left join Shifts SF on(M.Shift=SF.Id)
left join Stores St on(M.StoreId=St.Id)
left join Employees U on(M.UserName=U.Id)
left join Employees C on(M.Cashier=C.Id)
left join Employees W on(M.WaiterId=W.Id)
left join Employees Dv on(M.DeliverymanId=Dv.Id)
left join Stores ToSt on(M.ToId=ToSt.Id)
left join Suppliers ToSp on(M.ToId=ToSp.Id)
left join Customers ToCs on(M.ToId=ToCs.Id)

where 
M.DayDate between @FromDate and @ToDate
and (M.Shift=@Shift or @Shift=0)

and (M.Flag=@Flag or @Flag=0)
and (M.StoreId=@StoreId or @StoreId=0)
and (M.InvoiceNo>=@FromInvoiceNo or @FromInvoiceNo=0)
and (M.InvoiceNo<=@ToInvoiceNo or @ToInvoiceNo=0)

and (D.IsPrinted=0 or @NewItemsOnly=0)
and (It.PrintingGroupId=@PrintingGroupId or @PrintingGroupId=0)

and (
	@RPTFlag1=0 or
	((@RPTFlag1=1 and M.Flag between 1  and 8  and @RPTFlag2=0) or (M.Flag=@RPTFlag2) ) or
	((@RPTFlag1=2 and M.Flag in(9,10,18) and @RPTFlag2=0) or (M.Flag=@RPTFlag2) ) or
	((@RPTFlag1=3 and M.Flag between 11 and 17 and @RPTFlag2=0) or (M.Flag=@RPTFlag2) )
	)



/*

union all



--الفرع المحول إليه

select M.DayDate InvDate,M.Shift InvShift,S.Logo,SF.Name ShiftName,St.Name StoreName,W.EnName WaiterName
,U.EnName UserFullName,C.EnName CashierName,'''' DelivarymanName,
(case 
when M.Flag IN(8) then ToSt.Name
when M.Flag IN(9,10) then ToSp.Name
when M.Flag between 11 and 16 then ToCs.Name end) ToName,Tb.Name TableName,
M.*,D.*,dbo.GetItemUnitName(D.ItemId,D.UnitId)UnitName
from SalesMaster M
left join SalesDetails D on(M.Flag=D.Flag and M.StoreId=D.StoreId and M.InvoiceNo=D.InvoiceNo)
left join Statics S on(1=1)
left join Shifts SF on(M.Shift=SF.Id)
left join Stores St on(M.StoreId=St.Id)
left join Employees U on(M.UserName=U.Id)
left join Employees C on(M.Cashier=C.Id)
left join Employees W on(M.WaiterId=W.Id)
left join Stores ToSt on(M.ToId=ToSt.Id)
left join Suppliers ToSp on(M.ToId=ToSp.Id)
left join Customers ToCs on(M.ToId=ToCs.Id)
left join Tables Tb on(Tb.StoreId=M.StoreId and Tb.Id=M.TableId)
where 
M.DayDate between @FromDate and @ToDate
and (M.Shift=@Shift or @Shift=0)

and (M.Flag=8)
and (@Flag=0)
and (M.ToId=@StoreId or @StoreId=0)
and (@FromInvoiceNo=0)
and (@ToInvoiceNo=0)
and (@NewItemsOnly=0)

and ((@RPTFlag1=1 and M.Flag between 1  and 8  and @RPTFlag2=0) or (M.Flag=@RPTFlag2) )

*/





------===================================================================
if @NewItemsOnly=1
update D set IsPrinted=1
from SalesDetails D
left join Items It on(D.ItemId=It.Id)

where  (D.Flag=@Flag or @Flag=0)
and (D.StoreId=@StoreId or @StoreId=0)
and (D.InvoiceNo>=@FromInvoiceNo or @FromInvoiceNo=0)
and (D.InvoiceNo<=@ToInvoiceNo or @ToInvoiceNo=0)
and (It.PrintingGroupId=@PrintingGroupId or @PrintingGroupId=0)
and (D.IsPrinted=0 or @NewItemsOnly=0)

------===================================================================
if @NewItemsOnly=0
update SalesMaster set IsCashierPrinted=1
where  (Flag=@Flag or @Flag=0)
and (StoreId=@StoreId or @StoreId=0)
and (InvoiceNo>=@FromInvoiceNo or @FromInvoiceNo=0)
and (InvoiceNo<=@ToInvoiceNo or @ToInvoiceNo=0)

and (IsCashierPrinted=0 or @NewItemsOnly=0)
' 
END
GO
/****** Object:  StoredProcedure [dbo].[GetSalaryHistoryShifts]    Script Date: 04/27/2014 08:57:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetSalaryHistoryShifts]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE proc [dbo].[GetSalaryHistoryShifts]
(
@Month int,
@Year int
)
--with encryption
as
select *,dbo.GetEmpName(EmpId) ''EmpName'',
dbo.GetDepartmentName(dbo.GetEmpDepartmentId(EmpId)) ''DepartmentName'' 
from SalaryHistory
where ShiftsOnly=1 and MONTH=@Month and Year=@Year
' 
END
GO
/****** Object:  StoredProcedure [dbo].[GetSalaryHistoryNotShifts]    Script Date: 04/27/2014 08:57:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetSalaryHistoryNotShifts]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE proc [dbo].[GetSalaryHistoryNotShifts]
(
@Month int,
@Year int
)
--with encryption
as
select *,dbo.GetEmpName(EmpId) ''EmpName'',
dbo.GetDepartmentName(dbo.GetEmpDepartmentId(EmpId)) ''DepartmentName'' 
from SalaryHistory
where ShiftsOnly=0 and MONTH=@Month and Year=@Year
and Doctor=1
' 
END
GO
/****** Object:  StoredProcedure [dbo].[GetSalaryHistoryAllTax]    Script Date: 04/27/2014 08:57:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetSalaryHistoryAllTax]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE proc [dbo].[GetSalaryHistoryAllTax]
(
@Period int,
@Year int
)
--with encryption
as
select *,dbo.GetEmpName(EmpId) ''EmpName'',
dbo.GetDepartmentName(dbo.GetEmpDepartmentId(EmpId)) ''DepartmentName'' ,
dbo.GetEmpTaxAccNo(EmpId)TaxAccNo
from SalaryHistory
where ((ShiftsOnly=0 and Doctor=1) or ShiftsOnly=1) 
and Year=@Year
and (
	(MONTH in(1,2,3) and @Period=1) or
	(MONTH in(4,5,6) and @Period=2) or
	(MONTH in(7,8,9) and @Period=3) or
	(MONTH in(10,11,12) and @Period=4)
	)
' 
END
GO
/****** Object:  StoredProcedure [dbo].[GetSalaryHistory]    Script Date: 04/27/2014 08:57:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetSalaryHistory]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE proc [dbo].[GetSalaryHistory]
(
@EmpId int,
@Month int,
@Year int
)
--with encryption
as
select *,dbo.GetEmpName(EmpId) ''EmpName'',
dbo.GetDepartmentName(dbo.GetEmpDepartmentId(EmpId)) ''DepartmentName'',
dbo.GetMainJobName(MainJobId) ''MainJobName'',
dbo.GetSubJobName(MainJobId,SubJobId) ''SubJobName''
from SalaryHistory
where (EmpId=@EmpId or @EmpId=0)
and IsSalary=1
and MONTH=@Month and Year=@Year
' 
END
GO
/****** Object:  StoredProcedure [dbo].[GetMessages]    Script Date: 04/27/2014 08:57:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetMessages]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE proc [dbo].[GetMessages]
(
@Emp int,
@Emp2 int,
@FromDate datetime,
@ToDate datetime
)
--with encryption
as
select FromUser,dbo.GetEmpName(FromUser) ''FromUserName'',
ToUser,dbo.GetEmpName(ToUser) ''ToUserName'',
Details,Daydate,
(case when FromUser>ToUser then FromUser else ToUser end) ''GroupBy'',
(case when FromUser>ToUser then ToUser else FromUser end) ''GroupBy2''
from Messages
where (FromUser=@Emp or @Emp=0)
and (ToUser=@Emp2 or @Emp2=0)
and Daydate between @FromDate and @ToDate+1
order by Daydate
' 
END
GO
/****** Object:  StoredProcedure [dbo].[GetOutcomeRPT]    Script Date: 04/27/2014 08:57:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetOutcomeRPT]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE proc [dbo].[GetOutcomeRPT]
(
@FromDate datetime,
@ToDate datetime,
@MainAccNo int,
@SubAccNo int,
@FromInvoiceNo int,
@ToInvoiceNo int
)
--with encryption
as

select M.*,
dbo.GetMainAccName(M.MainAccNo) MainAccName,
dbo.GetSubAccName(M.MainAccNo,M.SubAccNo) SubAccName
from OutCome M
where 
M.DayDate between @FromDate and @ToDate
and (M.MainAccNo=@MainAccNo or @MainAccNo=0)
and (M.SubAccNo=@SubAccNo or @SubAccNo=0)
and (M.InvoiceNo>=@FromInvoiceNo or @FromInvoiceNo=0)
and (M.InvoiceNo<=@ToInvoiceNo or @ToInvoiceNo=0)

and Canceled=0
' 
END
GO
/****** Object:  StoredProcedure [dbo].[GetItemsSales]    Script Date: 04/27/2014 08:57:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetItemsSales]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE proc [dbo].[GetItemsSales]
(
@FromDate datetime,
@ToDate datetime,
@Shift int,
@Flag int,
@StoreId int,
@ItemId int=0,
@GroupId int=0,
@TypeId int=0
)
--with encryption
as

select M.DayDate InvDate,M.Shift InvShift,SF.Name ShiftName,St.Name StoreName,W.EnName WaiterName
,U.EnName UserFullName,C.EnName CashierName,
(case 
when M.Flag IN(8) then ToSt.Name
when M.Flag IN(9,10,18) then ToSp.Name
when M.Flag IN(15,16,17) then ToCs.Name end) ToName,'''' TableName,
M.*,D.*,dbo.GetItemUnitName(D.ItemId,D.UnitId)UnitName,
dbo.GetAccName(AccNo1)AccName1,
dbo.GetAccName(AccNo2)AccName2,
dbo.GetAccName(AccNo3)AccName3,
dbo.GetAccName(AccNo4)AccName4,
dbo.GetAccTypeName(AccType1)AccTypeName1,
dbo.GetAccTypeName(AccType2)AccTypeName2,
dbo.GetAccTypeName(AccType3)AccTypeName3,
dbo.GetAccTypeName(AccType4)AccTypeName4
from SalesMaster M
left join SalesDetails D on(M.Flag=D.Flag and M.StoreId=D.StoreId and M.InvoiceNo=D.InvoiceNo)
left join Items It on(D.ItemId=It.Id)
left join Shifts SF on(M.Shift=SF.Id)
left join Stores St on(M.StoreId=St.Id)
left join Employees U on(M.UserName=U.Id)
left join Employees C on(M.Cashier=C.Id)
left join Employees W on(M.WaiterId=W.Id)
left join Stores ToSt on(M.ToId=ToSt.Id)
left join Suppliers ToSp on(M.ToId=ToSp.Id)
left join Customers ToCs on(M.ToId=ToCs.Id)

where 
M.DayDate between @FromDate and @ToDate
and (M.Shift=@Shift or @Shift=0)
and (It.GroupId=@GroupId or @GroupId=0)
and (It.TypeId=@TypeId or @TypeId=0)
and (M.StoreId=@StoreId or @StoreId=0)
and (M.Flag between 11 and 18 or M.Flag=@Flag)
and (D.ItemId=@ItemId or @ItemId=0)
' 
END
GO
/****** Object:  StoredProcedure [dbo].[GetItems]    Script Date: 04/27/2014 08:57:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetItems]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE proc [dbo].[GetItems]
@GroupId int,
@TypeId int,
@FromId int,
@ToId int
as
select *,
dbo.GetGroupName(GroupId)GroupName,
dbo.GetTypeName(GroupId,TypeId)TypeName
from items
where (GroupId=@GroupId or @GroupId=0)
and (TypeId=@TypeId or @TypeId=0)
and (Id>=@FromId or @FromId=0)
and (Id<=@ToId or @ToId=0)
' 
END
GO
/****** Object:  StoredProcedure [dbo].[GetItemCard]    Script Date: 04/27/2014 08:57:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetItemCard]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE proc [dbo].[GetItemCard]
(
@StoreId int,
@ItemId int,
@ColorId int,
@SizeId int,
@ToDate datetime
)
as

select (case when M.StoreId=@StoreId then M.StoreId else M.ToId end) MyStoreId,
(case when M.StoreId=@StoreId then St.Name else tost.Name end) MyStoreName,
M.DayDate M_DayDate,M.Shift M_Shift,D.*,M.ToId,
dbo.GetItemUnitName(D.ItemId,(case when It.MainUnitOnly=1 then 0 when M.Flag=8 and M.ToId=@StoreId then ToSt.Flag else St.Flag end))MainUnitName,
dbo.GetItemUnitName(D.ItemId,D.UnitId)UnitName,
(case 
when M.Flag IN(8) then (case when M.ToId=@StoreId then St.Name else ToSt.Name end)
when M.Flag IN(9,10,18) then ToSp.Name
when M.Flag between 11 and 17 then ToCs.Name 
else ''-'' end) ToName,
(case when It.MainUnitOnly=1 then 0 when M.Flag=8 and M.ToId=@StoreId then ToSt.Flag else St.Flag end) StoreFlag,
It.UnitCount
from SalesDetails D
left join SalesMaster M on(D.Flag=M.Flag and D.StoreId=M.StoreId and D.InvoiceNo=M.InvoiceNo)
left join Items It on(D.ItemId=It.Id)
left join Stores St on(M.StoreId=St.Id)
left join Stores ToSt on(M.ToId=ToSt.Id)
left join Suppliers ToSp on(M.ToId=ToSp.Id)
left join Customers ToCs on(M.ToId=ToCs.Id)
where (M.StoreId=@StoreId or (M.ToId=@StoreId and M.Flag=8))
and D.ItemId=@ItemId
and (D.Color=@ColorId or @ColorId=0)
and (D.Size=@SizeId or @SizeId=0)
and M.DayDate<=@ToDate
' 
END
GO
/****** Object:  StoredProcedure [dbo].[GetIncomeRPT]    Script Date: 04/27/2014 08:57:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetIncomeRPT]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE proc [dbo].[GetIncomeRPT]
(
@FromDate datetime,
@ToDate datetime,
@MainAccNo int,
@SubAccNo int,
@FromInvoiceNo int,
@ToInvoiceNo int
)
--with encryption
as

select M.*,
dbo.GetMainAccName(M.MainAccNo) MainAccName,
isnull(dbo.GetSubAccName(M.MainAccNo,M.SubAccNo),''-'') SubAccName
from Income M
where 
M.DayDate between @FromDate and @ToDate
and (M.MainAccNo=@MainAccNo or @MainAccNo=0)
and (M.SubAccNo=@SubAccNo or @SubAccNo=0)
and (M.InvoiceNo>=@FromInvoiceNo or @FromInvoiceNo=0)
and (M.InvoiceNo<=@ToInvoiceNo or @ToInvoiceNo=0)

and Canceled=0
' 
END
GO
/****** Object:  StoredProcedure [dbo].[GetCustomerData]    Script Date: 04/27/2014 08:57:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetCustomerData]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE proc [dbo].[GetCustomerData](@Id int)
--with encryption
as
select
''الدولة: ''+dbo.GetCountryName(CountryId),
''المحافظة: ''+dbo.GetCityName(CountryId,CityId),
''المنطقة: ''+dbo.GetAreaName(CountryId,CityId,AreaId),
''العنوان: ''+Address,
''الدور: ''+Floor,
''الشقة: ''+Appartment,
''التليفون: ''+Tel,
''الموبايل: ''+Mobile,DescPerc
from Customers
where Id=@Id
' 
END
GO
/****** Object:  StoredProcedure [dbo].[GetCustomerCompanies]    Script Date: 04/27/2014 08:57:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetCustomerCompanies]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE proc [dbo].[GetCustomerCompanies]
@CompanyId int,
@CustId int
as
select *,dbo.GetCustomerName(CustId)CustomerName from CustomerCompanies
where (Id=@CompanyId or @CompanyId=0)
and	(CustId=@CustId or @CustId=0)
' 
END
GO
/****** Object:  StoredProcedure [dbo].[CustomersSearch]    Script Date: 04/27/2014 08:57:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CustomersSearch]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
create proc [dbo].[CustomersSearch]
--with encryption
as
select cast(Id as nvarchar(100)),Name,Tel,Mobile,Address,AccNo,dbo.GetAccName(AccNo)AccName
from Customers

' 
END
GO
/****** Object:  StoredProcedure [dbo].[CloseAttendance]    Script Date: 04/27/2014 08:57:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CloseAttendance]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE proc [dbo].[CloseAttendance]
@Month int,
@Year int
--with encryption
as

delete Attendance where MONTH(DayDate)=@Month and Year(DayDate)=@Year

insert Attendance(EmpId,DayDate,LoginDateTime,LogOutDateTime,State,StateName,StateShortName,DayPerc)
select EmpId,cast(DayDate as date),
min(Case when State=0 then DayDate else null end),
max(Case when State=1 then DayDate else null end),
0 State,'''' StateName,'''' StateShortName,1
from AttendanceLog
where MONTH(DayDate)=@Month and Year(DayDate)=@Year
group by EmpId,cast(DayDate as date)


insert Attendance(EmpId,DayDate,LoginDateTime,LogOutDateTime,State,StateName,StateShortName,DayPerc)
select Id,M.Line,null,null,
0 State,'''' StateName,'''' StateShortName,1
from Employees E
cross apply dbo.MonthDays(@Month,@Year) M
where not exists
(
select * from Attendance at
where MONTH(DayDate)=@Month and Year(DayDate)=@Year
and at.EmpId=E.Id and at.DayDate=M.Line
)
and E.HasAttendance=1 and (E.TotalHours+E.TotalMinutes)>0

update at
set MONTH=@Month,Year=@Year,Day=Day(at.DayDate),
hh=isnull(datepart(HOUR,LogOutDateTime-LoginDateTime),0),
mm=isnull(datepart(MINUTE,LogOutDateTime-LoginDateTime),0),
DelayMinutes=0,
OverMinutes=0
from Attendance at
where MONTH(at.DayDate)=@Month and Year(at.DayDate)=@Year

update at
set HourValue=isnull(E.Salary/30./(E.TotalHours+E.TotalMinutes/60.),0),
DayValue=isnull(E.Salary/30.,0),
IsFixedHours=E.IsFixedHours,TotalHours=E.TotalHours,TotalMinutes=E.TotalMinutes
from Attendance at
left join Employees E on E.Id=at.EmpId
where MONTH(at.DayDate)=@Month and Year(at.DayDate)=@Year


update at
set State=11,StateName=o.Name,StateShortName=''ج'',
DayPerc*=(case when LoginDateTime is not null and LogOutDateTime is not null then E.HolidayWorkValue else 1. end)
from Attendance at
left join Employees E on E.Id=at.EmpId
left join OfficialHolidays o
on at.DayDate between o.FromDate and o.ToDate
where MONTH(at.DayDate)=@Month and Year(at.DayDate)=@Year and State=0
and o.Id is not null                

update at
set State=12,
StateName=(case Lr.LeaveType when 1 then ''سنوية'' when 2 then ''عارضة'' when 3 then ''مرضى'' when 4 then ''بدون مرتب'' when 5 then ''مأمورية'' end),
StateShortName=(case Lr.LeaveType when 1 then ''س'' when 2 then ''ع'' when 3 then ''م'' when 4 then ''ر'' when 5 then ''و'' end),
DayPerc*=(case Lr.LeaveType when 4 then 0 else 1. end)
from Attendance at
left join LeaveRequests2 LR 
on at.EmpId=LR.EmpId and at.DayDate between LR.FromDate and LR.ToDate
where MONTH(at.DayDate)=@Month and Year(at.DayDate)=@Year and State=0
and lr.Id is not null                

update at
set State=13,StateName=''أجازة أسبوعية'',StateShortName=''ج.س'',
DayPerc*=(case when LoginDateTime is not null and LogOutDateTime is not null then E.HolidayWorkValue else 1. end)
from Attendance at
left join Employees E on E.Id=at.EmpId
where MONTH(at.DayDate)=@Month and Year(at.DayDate)=@Year and State=0
and dbo.IsWeekHoliday(at.DayDate,at.EmpId)=1

update at
set State=14,
StateName=''إذن'',
StateShortName=''ذ''
from Attendance at
left join LeaveRequests LR on LR.DayDate=at.DayDate and at.EmpId=LR.EmpId
where MONTH(at.DayDate)=@Month and Year(at.DayDate)=@Year and State=0
and lr.Id is not null                

--update Attendance 
--set State='''',StateName='''',StateShortName=''''
--where MONTH(DayDate)=@Month and Year(DayDate)=@Year and State=0
--and

update Attendance 
set State=10,StateName=''غياب'',StateShortName=''غ'',DayPerc=0
where MONTH(DayDate)=@Month and Year(DayDate)=@Year and State=0
and (LoginDateTime is null or LogOutDateTime is null)


update at
set DelayMinutes=(at.TotalHours*60+at.TotalMinutes)-(at.hh*60+at.mm)-E.LateAllowance-dbo.GetEmpLeaveRequests(at.EmpId,at.DayDate)
from Attendance at
left join Employees E on E.Id=at.EmpId
where MONTH(at.DayDate)=@Month and Year(at.DayDate)=@Year and State in(0,14)

update at
set OverMinutes=(at.hh*60+at.mm)-(at.TotalHours*60+at.TotalMinutes)
from Attendance at
left join Employees E on E.Id=at.EmpId
where MONTH(at.DayDate)=@Month and Year(at.DayDate)=@Year and State=0

update at set DelayMinutes=0 from Attendance at
where MONTH(at.DayDate)=@Month and Year(at.DayDate)=@Year and State=0 and DelayMinutes<0

update at set OverMinutes=0 from Attendance at
where MONTH(at.DayDate)=@Month and Year(at.DayDate)=@Year and State=0 and OverMinutes<0


update Attendance 
set State='''',StateName=''حضور'',StateShortName=''ح'',DayPerc=1
where MONTH(DayDate)=@Month and Year(DayDate)=@Year and State=0
' 
END
GO
/****** Object:  UserDefinedFunction [dbo].[Bal0]    Script Date: 04/27/2014 08:57:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Bal0]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'CREATE FUNCTION [dbo].[Bal0]
(
@MainAccNo int,
@SubAccNo int,
@FromDate datetime,
@Flag int
)
returns float
--with encryption
as
begin

declare @Detailed int=0

declare @S_AccNo int,@R_S_AccNo int,@P_AccNo int,@R_P_AccNo int
select top 1 @S_AccNo=S_AccNo,@R_S_AccNo=R_S_AccNo,@P_AccNo=P_AccNo,@R_P_AccNo=R_P_AccNo from Statics

declare @LinkFile int,@MotionType int
select @LinkFile=LinkFile,@MotionType=MotionType from Chart where Id=@MainAccNo
select @LinkFile=ISNULL(@LinkFile,0)

declare @TableName varchar(100)
select @TableName=TableName from LinkFile where Id=@LinkFile
select @TableName=ISNULL(@TableName,'''')

declare @Db float=0,@Cr float=0
if @MotionType=0 select @Db=1. 
if @MotionType=1 select @Cr=1.

declare @MotionValue float
if @MotionType=0 select @MotionValue=1. 
if @MotionType=1 select @MotionValue=-1.

declare @Bal0 float=dbo.GetBal0(@TableName,@SubAccNo)

declare @tbl table(Db float,Cr float)
insert @tbl

select 
(case when (@Bal0>0 and @Db=1) or (@Bal0<0 and @Cr=1) then abs(@Bal0) else 0 end) Db,
(case when (@Bal0>0 and @Cr=1) or (@Bal0<0 and @Db=1) then abs(@Bal0) else 0 end) Cr

union all

select 
ED.Debit Db,
ED.Credit Cr
from EntryDt ED
left join Entry E on(ED.InvoiceNo=E.InvoiceNo)
where E.DayDate <=@FromDate 
and MainAccNo=@MainAccNo 
and (SubAccNo=@SubAccNo or @SubAccNo=0 or SubAccNo=0)

union all

select 
(Case when Flag in(1,3) then 0 else 1. end)*Value Db,
(Case when Flag in(1,3) then 1. else 0 end)*Value Cr
from BankCash
where DayDate <=@FromDate 
and MainAccNo=@MainAccNo 
and (SubAccNo=@SubAccNo or @SubAccNo=0 or SubAccNo=0)
and Canceled=0

union all

select 
(Case when Flag in(1,3) then 1. else 0 end)*Value Db,
(Case when Flag in(1,3) then 0 else 1. end)*Value Cr
from BankCash
where DayDate <=@FromDate 
and (
	(dbo.GetSafeAccNo(BankId)=@MainAccNo and Flag in(1,2) and @LinkFile=5) or
	(dbo.GetBankAccNo(BankId)=@MainAccNo and Flag in(3,4) and @LinkFile=6)
	)
and BankId=@SubAccNo
and Canceled=0

union all

select 
(Case when Flag in(1,3) then 1. else 0 end)*Value Db,
(Case when Flag in(1,3) then 0 else 1. end)*Value Cr
from BankCash2
where DayDate <=@FromDate 
and (
	(dbo.GetSafeAccNo(BankId)=@MainAccNo and Flag in(1,2) and @LinkFile=5) or
	(dbo.GetBankAccNo(BankId)=@MainAccNo and Flag in(3,4) and @LinkFile=6)
	)
and BankId=@SubAccNo
and Canceled=0

union all

--===========================================================================
--===========================================================================








select 
(case when Flag in(11,13,15,10,18) then TotalAfterDiscount else 0 end) Db,
(case when Flag in(12,14,16,9,17) then TotalAfterDiscount else 0 end) Cr
from SalesMaster
where DayDate <=@FromDate 
and ToId=@SubAccNo
and (
	(@LinkFile=1 and Flag in(11,13,15,12,14,16,17)) or
	(@LinkFile=2 and Flag in(9,10,18)) 
	)
and @Detailed=0
--===========================================================================


--===========================================================================


--===========================================================================النقدى والفيزا

union all


select 
(Case when SaveId=@SubAccNo and @LinkFile=5 then 1. else 0 end)*(case when PaymentType in(1,2,3) then TotalAfterDiscount when PaymentType=5 then CashValue end) Db,
(Case when ToId=@SubAccNo and @LinkFile=1 then 1. else 0 end)*(case when PaymentType in(1,2,3) then TotalAfterDiscount when PaymentType=5 then CashValue end) Cr
from SalesMaster
where DayDate <=@FromDate 
and ((ToId=@SubAccNo and @LinkFile=1) or (SaveId=@SubAccNo and @LinkFile=5))
and Flag in(11,13,15)
and PaymentType in(1,2,3,5)

union all

select 
(Case when ToId=@SubAccNo and @LinkFile=1 then 1. else 0 end)*(case when PaymentType in(1,2,3) then TotalAfterDiscount when PaymentType=5 then CashValue end) Db,
(Case when SaveId=@SubAccNo and @LinkFile=5 then 1. else 0 end)*(case when PaymentType in(1,2,3) then TotalAfterDiscount when PaymentType=5 then CashValue end) Cr
from SalesMaster
where DayDate <=@FromDate 
and ((ToId=@SubAccNo and @LinkFile=1) or (SaveId=@SubAccNo and @LinkFile=5))
and Flag in(12,14,16)
and PaymentType in(1,2,3,5)

union all

select 
(Case when ToId=@SubAccNo and @LinkFile=1 then 1. else 0 end)*(case when PaymentType in(1,2,3) then TotalAfterDiscount when PaymentType=5 then CashValue end) Db,
(Case when SaveId=@SubAccNo and @LinkFile=5 then 1. else 0 end)*(case when PaymentType in(1,2,3) then TotalAfterDiscount when PaymentType=5 then CashValue end) Cr
from SalesMaster
where DayDate <=@FromDate 
and ((ToId=@SubAccNo and @LinkFile=1) or (SaveId=@SubAccNo and @LinkFile=5))
and Flag in(17)
and PaymentType in(1,2,3,5)

union all

select 
(Case when ToId=@SubAccNo and @LinkFile=2 then 1. else 0 end)*(case when PaymentType in(1,2,3) then TotalAfterDiscount when PaymentType=5 then CashValue end) Db,
(Case when SaveId=@SubAccNo and @LinkFile=5 then 1. else 0 end)*(case when PaymentType in(1,2,3) then TotalAfterDiscount when PaymentType=5 then CashValue end) Cr
from SalesMaster
where DayDate <=@FromDate 
and ((ToId=@SubAccNo and @LinkFile=2) or (SaveId=@SubAccNo and @LinkFile=5))
and Flag =9
and PaymentType in(1,2,3,5)

union all

select 
(Case when SaveId=@SubAccNo and @LinkFile=5 then 1. else 0 end)*(case when PaymentType in(1,2,3) then TotalAfterDiscount when PaymentType=5 then CashValue end) Db,
(Case when ToId=@SubAccNo and @LinkFile=2 then 1. else 0 end)*(case when PaymentType in(1,2,3) then TotalAfterDiscount when PaymentType=5 then CashValue end) Cr
from SalesMaster
where DayDate <=@FromDate 
and ((ToId=@SubAccNo and @LinkFile=2) or (SaveId=@SubAccNo and @LinkFile=5))
and Flag =10
and PaymentType in(1,2,3,5)

union all

select 
(Case when SaveId=@SubAccNo and @LinkFile=5 then 1. else 0 end)*(case when PaymentType in(1,2,3) then TotalAfterDiscount when PaymentType=5 then CashValue end) Db,
(Case when ToId=@SubAccNo and @LinkFile=2 then 1. else 0 end)*(case when PaymentType in(1,2,3) then TotalAfterDiscount when PaymentType=5 then CashValue end) Cr
from SalesMaster
where DayDate <=@FromDate 
and ((ToId=@SubAccNo and @LinkFile=2) or (SaveId=@SubAccNo and @LinkFile=5))
and Flag =18
and PaymentType in(1,2,3,5)

--===========================================================================إكرامية
union all

select 
0 Db,
Tips Cr
from SalesMaster
where DayDate <=@FromDate 
and (SaveId=@SubAccNo and @LinkFile=5)
and Flag in(11,13,15)
and Tips<>0
--===========================================================================حساب المبيعات والمشتريات

union all

select 
0 Db,
Total Cr
from SalesMaster
where DayDate <=@FromDate 
and Flag in(11,13,15)
and @S_AccNo=@MainAccNo
and @SubAccNo=0

union all

select 
Total Db,
0 Cr
from SalesMaster
where DayDate <=@FromDate 
and Flag in(12,14,16)
and @R_S_AccNo=@MainAccNo
and @SubAccNo=0

union all

select 
Total Db,
0 Cr
from SalesMaster
where DayDate <=@FromDate 
and Flag in(17)
and @R_S_AccNo=@MainAccNo
and @SubAccNo=0

union all

select 
Total Db,
0 Cr
from SalesMaster
where DayDate <=@FromDate 
and Flag =9
and @P_AccNo=@MainAccNo
and @SubAccNo=0

union all

select 
0 Db,
Total Cr
from SalesMaster
where DayDate <=@FromDate 
and Flag =10
and @R_P_AccNo=@MainAccNo
and @SubAccNo=0

union all

select 
0 Db,
Total Cr
from SalesMaster
where DayDate <=@FromDate 
and Flag =18
and @R_P_AccNo=@MainAccNo
and @SubAccNo=0



--===========================================================================حسابات الخصم والإضافة

union all

select 
((case when @MainAccNo=AccNo1 and AccType1=1 then Val1 else 0 end)+(case when @MainAccNo=AccNo2 and AccType2=1 then Val2 else 0 end)+(case when @MainAccNo=AccNo3 and AccType3=1 then Val3 else 0 end)+(case when @MainAccNo=AccNo4 and AccType4=1 then Val4 else 0 end)) Db,
((case when @MainAccNo=AccNo1 and AccType1=2 then Val1 else 0 end)+(case when @MainAccNo=AccNo2 and AccType2=2 then Val2 else 0 end)+(case when @MainAccNo=AccNo3 and AccType3=2 then Val3 else 0 end)+(case when @MainAccNo=AccNo4 and AccType4=2 then Val4 else 0 end)) Cr
from SalesMaster
where DayDate <=@FromDate 
and Flag in(11,13,15)
and @MainAccNo in(AccNo1,AccNo2,AccNo3,AccNo4)
and @SubAccNo=0

union all

select 
((case when @MainAccNo=AccNo1 and AccType1=2 then Val1 else 0 end)+(case when @MainAccNo=AccNo2 and AccType2=2 then Val2 else 0 end)+(case when @MainAccNo=AccNo3 and AccType3=2 then Val3 else 0 end)+(case when @MainAccNo=AccNo4 and AccType4=2 then Val4 else 0 end)) Db,
((case when @MainAccNo=AccNo1 and AccType1=1 then Val1 else 0 end)+(case when @MainAccNo=AccNo2 and AccType2=1 then Val2 else 0 end)+(case when @MainAccNo=AccNo3 and AccType3=1 then Val3 else 0 end)+(case when @MainAccNo=AccNo4 and AccType4=1 then Val4 else 0 end)) Cr
from SalesMaster
where DayDate <=@FromDate 
and Flag in(12,14,16)
and @MainAccNo in(AccNo1,AccNo2,AccNo3,AccNo4)
and @SubAccNo=0

union all

select 
((case when @MainAccNo=AccNo1 and AccType1=2 then Val1 else 0 end)+(case when @MainAccNo=AccNo2 and AccType2=2 then Val2 else 0 end)+(case when @MainAccNo=AccNo3 and AccType3=2 then Val3 else 0 end)+(case when @MainAccNo=AccNo4 and AccType4=2 then Val4 else 0 end)) Db,
((case when @MainAccNo=AccNo1 and AccType1=1 then Val1 else 0 end)+(case when @MainAccNo=AccNo2 and AccType2=1 then Val2 else 0 end)+(case when @MainAccNo=AccNo3 and AccType3=1 then Val3 else 0 end)+(case when @MainAccNo=AccNo4 and AccType4=1 then Val4 else 0 end)) Cr
from SalesMaster
where DayDate <=@FromDate 
and Flag in(17)
and @MainAccNo in(AccNo1,AccNo2,AccNo3,AccNo4)
and @SubAccNo=0

union all

select 
((case when @MainAccNo=AccNo1 and AccType1=2 then Val1 else 0 end)+(case when @MainAccNo=AccNo2 and AccType2=2 then Val2 else 0 end)+(case when @MainAccNo=AccNo3 and AccType3=2 then Val3 else 0 end)+(case when @MainAccNo=AccNo4 and AccType4=2 then Val4 else 0 end)) Db,
((case when @MainAccNo=AccNo1 and AccType1=1 then Val1 else 0 end)+(case when @MainAccNo=AccNo2 and AccType2=1 then Val2 else 0 end)+(case when @MainAccNo=AccNo3 and AccType3=1 then Val3 else 0 end)+(case when @MainAccNo=AccNo4 and AccType4=1 then Val4 else 0 end)) Cr
from SalesMaster
where DayDate <=@FromDate 
and Flag =9
and @MainAccNo in(AccNo1,AccNo2,AccNo3,AccNo4)
and @SubAccNo=0

union all

select 
((case when @MainAccNo=AccNo1 and AccType1=1 then Val1 else 0 end)+(case when @MainAccNo=AccNo2 and AccType2=1 then Val2 else 0 end)+(case when @MainAccNo=AccNo3 and AccType3=1 then Val3 else 0 end)+(case when @MainAccNo=AccNo4 and AccType4=1 then Val4 else 0 end)) Db,
((case when @MainAccNo=AccNo1 and AccType1=2 then Val1 else 0 end)+(case when @MainAccNo=AccNo2 and AccType2=2 then Val2 else 0 end)+(case when @MainAccNo=AccNo3 and AccType3=2 then Val3 else 0 end)+(case when @MainAccNo=AccNo4 and AccType4=2 then Val4 else 0 end)) Cr
from SalesMaster
where DayDate <=@FromDate 
and Flag =10
and @MainAccNo in(AccNo1,AccNo2,AccNo3,AccNo4)
and @SubAccNo=0

union all

select 
((case when @MainAccNo=AccNo1 and AccType1=1 then Val1 else 0 end)+(case when @MainAccNo=AccNo2 and AccType2=1 then Val2 else 0 end)+(case when @MainAccNo=AccNo3 and AccType3=1 then Val3 else 0 end)+(case when @MainAccNo=AccNo4 and AccType4=1 then Val4 else 0 end)) Db,
((case when @MainAccNo=AccNo1 and AccType1=2 then Val1 else 0 end)+(case when @MainAccNo=AccNo2 and AccType2=2 then Val2 else 0 end)+(case when @MainAccNo=AccNo3 and AccType3=2 then Val3 else 0 end)+(case when @MainAccNo=AccNo4 and AccType4=2 then Val4 else 0 end)) Cr
from SalesMaster
where DayDate <=@FromDate 
and Flag =18
and @MainAccNo in(AccNo1,AccNo2,AccNo3,AccNo4)
and @SubAccNo=0



return 
(
case when @Flag=0 then (select isnull(SUM(Db),0)-isnull(SUM(Cr),0) from @tbl)*@MotionValue
when @Flag=1 then (select isnull(SUM(Db),0) from @tbl)
when @Flag=2 then (select isnull(SUM(Cr),0) from @tbl)
else 0 end
)
end

' 
END
GO
/****** Object:  UserDefinedFunction [dbo].[GetEmpDirectCut]    Script Date: 04/27/2014 08:57:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetEmpDirectCut]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'CREATE FUNCTION [dbo].[GetEmpDirectCut]
(@Month int ,@Year int,@EmpId int) returns float
as
begin
declare @val float

select @val=sum(case IsVal 
			when 0 then dbo.GetEmpHourValue(EmpId) 
			when 1 then dbo.GetEmpDayValue(EmpId)  
			when 2 then value 
			else 0 end)
from DirectCut
where EmpId=@EmpId
and Month(DayDate)=@Month
and Year(DayDate)=@Year

select @val=0 where @val is null

return @val

end
' 
END
GO
/****** Object:  UserDefinedFunction [dbo].[GetEmpDirectBonus]    Script Date: 04/27/2014 08:57:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetEmpDirectBonus]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'CREATE FUNCTION [dbo].[GetEmpDirectBonus]
(@Month int ,@Year int,@EmpId int) returns float
as
begin
declare @val float

select @val=sum(case IsVal 
			when 0 then dbo.GetEmpHourValue(EmpId)*(hh+mm/60.)
			when 1 then dbo.GetEmpDayValue(EmpId)*value
			when 2 then value 
			else 0 end)
from DirectBonus 
where EmpId=@EmpId
and Month(DayDate)=@Month
and Year(DayDate)=@Year

select @val=0 where @val is null

return @val

end
' 
END
GO
/****** Object:  UserDefinedFunction [dbo].[GetCostPrice]    Script Date: 04/27/2014 08:57:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetCostPrice]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'CREATE FUNCTION [dbo].[GetCostPrice](@MainItemId int)
returns float
--with encryption
as
begin
return(
isnull(
(select sum(dbo.GetItemPurchasePrice(ItemId)*Qty) from ItemComponants where MainItemId=@MainItemId)
,
(select dbo.GetItemPurchasePrice(@MainItemId))
)
)
end
' 
END
GO
/****** Object:  StoredProcedure [dbo].[GetDeletedSales]    Script Date: 04/27/2014 08:57:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetDeletedSales]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE proc [dbo].[GetDeletedSales]
(
@FromDate datetime,
@ToDate datetime,
@Shift int,
@Flag int,
@StoreId int,
@FromInvoiceNo int,
@ToInvoiceNo int,
@NewItemsOnly int=0,
@RPTFlag1 int=0,
@RPTFlag2 int=0,
@ToId int=0
)
--with encryption
as

select M.DayDate InvDate,M.Shift InvShift,S.Logo,SF.Name ShiftName,St.Name StoreName,W.EnName WaiterName
,U.EnName UserFullName,UD.EnName UserDeletedFullName,C.EnName CashierName,
(case 
when M.Flag IN(8) then ToSt.Name
when M.Flag IN(9,10,18) then ToSp.Name
when M.Flag IN(15,16,17) then ToCs.Name end) ToName,'''' TableName,
M.*,D.*,dbo.GetItemUnitName(D.ItemId,D.UnitId)UnitName,
dbo.GetAccName(AccNo1)AccName1,
dbo.GetAccName(AccNo2)AccName2,
dbo.GetAccName(AccNo3)AccName3,
dbo.GetAccName(AccNo4)AccName4,
dbo.GetAccTypeName(AccType1)AccTypeName1,
dbo.GetAccTypeName(AccType2)AccTypeName2,
dbo.GetAccTypeName(AccType3)AccTypeName3,
dbo.GetAccTypeName(AccType4)AccTypeName4
from DeletedSalesMaster M
left join DeletedSalesDetails D on(M.Flag=D.Flag and M.StoreId=D.StoreId and M.InvoiceNo=D.InvoiceNo and M.LastLine=D.LastLine)
left join Statics S on(1=1)
left join Shifts SF on(M.Shift=SF.Id)
left join Stores St on(M.StoreId=St.Id)
left join Employees U on(M.UserName=U.Id)
left join Employees UD on(M.UserDelete=UD.Id)
left join Employees C on(M.Cashier=C.Id)
left join Employees W on(M.WaiterId=W.Id)
left join Stores ToSt on(M.ToId=ToSt.Id)
left join Suppliers ToSp on(M.ToId=ToSp.Id)
left join Customers ToCs on(M.ToId=ToCs.Id)

where 
M.DayDate between @FromDate and @ToDate
and (M.Shift=@Shift or @Shift=0)

and (M.Flag=@Flag or @Flag=0)
and (M.StoreId=@StoreId or @StoreId=0)
and (M.InvoiceNo>=@FromInvoiceNo or @FromInvoiceNo=0)
and (M.InvoiceNo<=@ToInvoiceNo or @ToInvoiceNo=0)
and (M.ToId=@ToId or @ToId=0)

and (D.IsPrinted=0 or @NewItemsOnly=0)

and (
	@RPTFlag1=0 or
	((@RPTFlag1=1 and M.Flag between 1  and 8  and @RPTFlag2=0) or (M.Flag=@RPTFlag2) ) or
	((@RPTFlag1=2 and M.Flag in(9,10,18) and @RPTFlag2=0) or (M.Flag=@RPTFlag2) ) or
	((@RPTFlag1=3 and M.Flag between 11 and 17 and @RPTFlag2=0) or (M.Flag=@RPTFlag2) )
	)
' 
END
GO
/****** Object:  StoredProcedure [dbo].[GetBankCash2]    Script Date: 04/27/2014 08:57:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetBankCash2]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE proc [dbo].[GetBankCash2]
@CostCenterId int,
@OutComeTypeId int,
@FromDate datetime,
@ToDate datetime

--with encryption
as
declare @MotionType int=0

select InvoiceNo,DayDate,Value,''* ''+Notes Notes,
OutComeTypeId,dbo.GetOutComeTypeName(OutComeTypeId)OutComeTypeName
from BankCash2
where DayDate between @FromDate and @ToDate 
and (CostCenterId=@CostCenterId or @CostCenterId=0)
and (OutComeTypeId=@OutComeTypeId or @OutComeTypeId=0)
and Canceled=0
' 
END
GO
/****** Object:  StoredProcedure [dbo].[CalcSalary]    Script Date: 04/27/2014 08:57:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CalcSalary]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE proc [dbo].[CalcSalary](@Month int,@Year int)
--with encryption
as
exec CloseAttendance @Month,@Year

delete from SalaryHistory where MONTH=@Month and Year=@Year
insert into SalaryHistory(EmpId,Month,Year,Doctor,MainJobId,SubJobId,Salary,Tax,SalaryOnly,ShiftsOnly,SalaryOrShifts,ShiftCount,ShiftValue,IsFreelancer,IsSalary,Bonus,Allowance,SpAllowance,Insurance)
select            Distinct Id,@Month,@Year,Doctor,MainJobId,SubJobId,Salary,Tax,SalaryOnly,ShiftsOnly,SalaryOrShifts,ShiftCount,ShiftValue,IsFreelancer,IsSalary,Bonus,Allowance,SpAllowance,Insurance from Employees where Stopped=0 
and HiringDate<dateadd(month,1,CAST(CAST(@Year as varchar(4))+''-''+CAST(@Month as varchar(2))+''-01'' As datetime))


--=========================================================================================
--=========================================  Doctors  =====================================
--=========================================================================================

update SalaryHistory set 
Income=dbo.GetEmpIncome(EmpId,@Month,@Year,2),
IncomeOnly=dbo.GetEmpIncome(EmpId,@Month,@Year,0),
OutcomeOnly=-dbo.GetEmpIncome(EmpId,@Month,@Year,1)
where Month=@Month and Year=@Year

--=========================================================================================
--=========================================    CS     =====================================
--=========================================================================================
declare @LoanDeduction int=dbo.GetLoanDeduction()

update SalaryHistory set 
Name1=''المرتب الأساسى''/*''Salary''*/,Type1=''P'',Value1=Salary,
Name2=''علاوة خاصة''/*''SpAllowance''*/,Type2=''P'',Value2=SpAllowance,
Name3=''الحوافز''/*''Bonus''*/,Type3=''P'',Value3=Bonus,
Name4=''البدلات''/*''Allowance''*/,Type4=''P'',Value4=Allowance,
Name5=''إضافى العمل''/*''OverTime''*/,Type5=''P'',Value5=dbo.GetEmpOverTime(EmpId,@Month,@Year),
Name6=''الزيارات المنزلية''/*''Income''*/,Type6=''P'',Value6=Income,
Name7=''المكافآت'',Type7=''P'',Value7=dbo.GetEmpDirectBonus(@Month,@Year,EmpId),
Name8='''',Type8='''',Value8=0,
Name9='''',Type9='''',Value9=0,
Name10='''',Type10='''',Value10=0,

Name11=''الغياب''/*''Absence''*/,Type11=''N'',Value11=dbo.GetEmpAbsence(EmpId,@Month,@Year),
Name12=''التأخير''/*''Late''*/,Type12=''N'',Value12=dbo.GetEmpLate(EmpId,@Month,@Year),
Name13=''التأمينات''/*''Insurance''*/,Type13=''N'',Value13=Insurance,
Name14=''الضرائب''/*''Tax''*/,Type14=''N'',Value14=Tax,
Name15=''سلفة''/*''Loans''*/,Type15=''N'',Value15=(Case when @LoanDeduction=1 then dbo.GetEmpLoans(@Month,@Year,EmpId) else 0 end),
Name16=''الجزاءات'',Type16=''N'',Value16=dbo.GetEmpDirectCut(@Month,@Year,EmpId),
Name17='''',Type17='''',Value17=0,
Name18='''',Type18='''',Value18=0,
Name19='''',Type19='''',Value19=0,
Name20='''',Type20='''',Value20=0,

DaysInMonth=dbo.DaysInMonth(@MONTH,@YEAR)
where Month=@Month and Year=@Year


--=========================================================================================
--=======================================----------========================================
update SalaryHistory set Name20='''',Type20='''',Value20=0
where Month=@Month and Year=@Year

--=========================================================================================
--=======================================Total========================================
update SalaryHistory set Total=

((case when Type1 is null then 0. when Type1=''N'' then -1. else 1. end)*(case when Value1 is null then 0 else Value1 end))+
((case when Type2 is null then 0. when Type2=''N'' then -1. else 1. end)*(case when Value2 is null then 0 else Value2 end))+
((case when Type3 is null then 0. when Type3=''N'' then -1. else 1. end)*(case when Value3 is null then 0 else Value3 end))+
((case when Type4 is null then 0. when Type4=''N'' then -1. else 1. end)*(case when Value4 is null then 0 else Value4 end))+
((case when Type5 is null then 0. when Type5=''N'' then -1. else 1. end)*(case when Value5 is null then 0 else Value5 end))+
((case when Type6 is null then 0. when Type6=''N'' then -1. else 1. end)*(case when Value6 is null then 0 else Value6 end))+
((case when Type7 is null then 0. when Type7=''N'' then -1. else 1. end)*(case when Value7 is null then 0 else Value7 end))+
((case when Type8 is null then 0. when Type8=''N'' then -1. else 1. end)*(case when Value8 is null then 0 else Value8 end))+
((case when Type9 is null then 0. when Type9=''N'' then -1. else 1. end)*(case when Value9 is null then 0 else Value9 end))+
((case when Type10 is null then 0. when Type10=''N'' then -1. else 1. end)*(case when Value10 is null then 0 else Value10 end))+
((case when Type11 is null then 0. when Type11=''N'' then -1. else 1. end)*(case when Value11 is null then 0 else Value11 end))+
((case when Type12 is null then 0. when Type12=''N'' then -1. else 1. end)*(case when Value12 is null then 0 else Value12 end))+
((case when Type13 is null then 0. when Type13=''N'' then -1. else 1. end)*(case when Value13 is null then 0 else Value13 end))+
((case when Type14 is null then 0. when Type14=''N'' then -1. else 1. end)*(case when Value14 is null then 0 else Value14 end))+
((case when Type15 is null then 0. when Type15=''N'' then -1. else 1. end)*(case when Value15 is null then 0 else Value15 end))+
((case when Type16 is null then 0. when Type16=''N'' then -1. else 1. end)*(case when Value16 is null then 0 else Value16 end))+
((case when Type17 is null then 0. when Type17=''N'' then -1. else 1. end)*(case when Value17 is null then 0 else Value17 end))+
((case when Type18 is null then 0. when Type18=''N'' then -1. else 1. end)*(case when Value18 is null then 0 else Value18 end))+
((case when Type19 is null then 0. when Type19=''N'' then -1. else 1. end)*(case when Value19 is null then 0 else Value19 end))+
((case when Type20 is null then 0. when Type20=''N'' then -1. else 1. end)*(case when Value20 is null then 0 else Value20 end))
,
TotalBonus=
((case when Type1 is null then 0. when Type1=''N'' then 0 else 1. end)*(case when Value1 is null then 0 else Value1 end))+
((case when Type2 is null then 0. when Type2=''N'' then 0 else 1. end)*(case when Value2 is null then 0 else Value2 end))+
((case when Type3 is null then 0. when Type3=''N'' then 0 else 1. end)*(case when Value3 is null then 0 else Value3 end))+
((case when Type4 is null then 0. when Type4=''N'' then 0 else 1. end)*(case when Value4 is null then 0 else Value4 end))+
((case when Type5 is null then 0. when Type5=''N'' then 0 else 1. end)*(case when Value5 is null then 0 else Value5 end))+
((case when Type6 is null then 0. when Type6=''N'' then 0 else 1. end)*(case when Value6 is null then 0 else Value6 end))+
((case when Type7 is null then 0. when Type7=''N'' then 0 else 1. end)*(case when Value7 is null then 0 else Value7 end))+
((case when Type8 is null then 0. when Type8=''N'' then 0 else 1. end)*(case when Value8 is null then 0 else Value8 end))+
((case when Type9 is null then 0. when Type9=''N'' then 0 else 1. end)*(case when Value9 is null then 0 else Value9 end))+
((case when Type10 is null then 0. when Type10=''N'' then 0 else 1. end)*(case when Value10 is null then 0 else Value10 end))+
((case when Type11 is null then 0. when Type11=''N'' then 0 else 1. end)*(case when Value11 is null then 0 else Value11 end))+
((case when Type12 is null then 0. when Type12=''N'' then 0 else 1. end)*(case when Value12 is null then 0 else Value12 end))+
((case when Type13 is null then 0. when Type13=''N'' then 0 else 1. end)*(case when Value13 is null then 0 else Value13 end))+
((case when Type14 is null then 0. when Type14=''N'' then 0 else 1. end)*(case when Value14 is null then 0 else Value14 end))+
((case when Type15 is null then 0. when Type15=''N'' then 0 else 1. end)*(case when Value15 is null then 0 else Value15 end))+
((case when Type16 is null then 0. when Type16=''N'' then 0 else 1. end)*(case when Value16 is null then 0 else Value16 end))+
((case when Type17 is null then 0. when Type17=''N'' then 0 else 1. end)*(case when Value17 is null then 0 else Value17 end))+
((case when Type18 is null then 0. when Type18=''N'' then 0 else 1. end)*(case when Value18 is null then 0 else Value18 end))+
((case when Type19 is null then 0. when Type19=''N'' then 0 else 1. end)*(case when Value19 is null then 0 else Value19 end))+
((case when Type20 is null then 0. when Type20=''N'' then 0 else 1. end)*(case when Value20 is null then 0 else Value20 end))

,
TotalCut=
((case when Type1 is null then 0. when Type1=''N'' then 1. else 0 end)*(case when Value1 is null then 0 else Value1 end))+
((case when Type2 is null then 0. when Type2=''N'' then 1. else 0 end)*(case when Value2 is null then 0 else Value2 end))+
((case when Type3 is null then 0. when Type3=''N'' then 1. else 0 end)*(case when Value3 is null then 0 else Value3 end))+
((case when Type4 is null then 0. when Type4=''N'' then 1. else 0 end)*(case when Value4 is null then 0 else Value4 end))+
((case when Type5 is null then 0. when Type5=''N'' then 1. else 0 end)*(case when Value5 is null then 0 else Value5 end))+
((case when Type6 is null then 0. when Type6=''N'' then 1. else 0 end)*(case when Value6 is null then 0 else Value6 end))+
((case when Type7 is null then 0. when Type7=''N'' then 1. else 0 end)*(case when Value7 is null then 0 else Value7 end))+
((case when Type8 is null then 0. when Type8=''N'' then 1. else 0 end)*(case when Value8 is null then 0 else Value8 end))+
((case when Type9 is null then 0. when Type9=''N'' then 1. else 0 end)*(case when Value9 is null then 0 else Value9 end))+
((case when Type10 is null then 0. when Type10=''N'' then 1. else 0 end)*(case when Value10 is null then 0 else Value10 end))+
((case when Type11 is null then 0. when Type11=''N'' then 1. else 0 end)*(case when Value11 is null then 0 else Value11 end))+
((case when Type12 is null then 0. when Type12=''N'' then 1. else 0 end)*(case when Value12 is null then 0 else Value12 end))+
((case when Type13 is null then 0. when Type13=''N'' then 1. else 0 end)*(case when Value13 is null then 0 else Value13 end))+
((case when Type14 is null then 0. when Type14=''N'' then 1. else 0 end)*(case when Value14 is null then 0 else Value14 end))+
((case when Type15 is null then 0. when Type15=''N'' then 1. else 0 end)*(case when Value15 is null then 0 else Value15 end))+
((case when Type16 is null then 0. when Type16=''N'' then 1. else 0 end)*(case when Value16 is null then 0 else Value16 end))+
((case when Type17 is null then 0. when Type17=''N'' then 1. else 0 end)*(case when Value17 is null then 0 else Value17 end))+
((case when Type18 is null then 0. when Type18=''N'' then 1. else 0 end)*(case when Value18 is null then 0 else Value18 end))+
((case when Type19 is null then 0. when Type19=''N'' then 1. else 0 end)*(case when Value19 is null then 0 else Value19 end))+
((case when Type20 is null then 0. when Type20=''N'' then 1. else 0 end)*(case when Value20 is null then 0 else Value20 end))

where Month=@Month and Year=@Year



--=========================================================================================




exec Shrink
' 
END
GO
/****** Object:  StoredProcedure [dbo].[AccontMotion]    Script Date: 04/27/2014 08:57:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AccontMotion]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE proc [dbo].[AccontMotion]
(
@MainAccNo int,
@SubAccNo int,
@FromDate datetime,
@ToDate datetime,
@Detailed int
)
--with encryption
as

declare @S_AccNo int,@R_S_AccNo int,@P_AccNo int,@R_P_AccNo int
select top 1 @S_AccNo=S_AccNo,@R_S_AccNo=R_S_AccNo,@P_AccNo=P_AccNo,@R_P_AccNo=R_P_AccNo from Statics

declare @LinkFile int,@MotionType int
select @LinkFile=LinkFile,@MotionType=MotionType from Chart where Id=@MainAccNo
select @LinkFile=ISNULL(@LinkFile,0)

declare @TableName varchar(100)
select @TableName=TableName from LinkFile where Id=@LinkFile
select @TableName=ISNULL(@TableName,'''')

declare @Db float=0,@Cr float=0
if @MotionType=0 select @Db=1. 
if @MotionType=1 select @Cr=1.

declare @Bal0 float=dbo.Bal0(@MainAccNo,@SubAccNo,@FromDate-1,0)

select 0 MyFlag,@MotionType MotionType,0 InvoiceNo,@FromDate-1 DayDate,
@Bal0*(case when @Bal0>0 then @Db else @Cr*-1. end) Db,
@Bal0*(case when @Bal0>0 then @Cr else @Db*-1. end) Cr,
0 Cash,'''' SheekNo,'''' SheekPerson,null SheekDate,''* '' Notes,''رصيد أول المدة'' ''Rem'',
''-'' MainAccNo,''-'' MainAccName,''-'' SubAccNo,''-'' SubAccName,
'''' SalesItems

union all

select 1 MyFlag,@MotionType MotionType,ED.InvoiceNo,E.DayDate,
ED.Debit Db,
ED.Credit Cr,
'''','''','''','''',''* ''+ED.Notes Notes,
''القيود'' ''Rem'',
MainAccNo,dbo.GetMainAccName(MainAccNo)MainAccName,SubAccNo,dbo.GetSubAccName(MainAccNo,SubAccNo) SubAccName,
'''' SalesItems
from EntryDt ED
left join Entry E on(ED.InvoiceNo=E.InvoiceNo)
where E.DayDate between @FromDate and @ToDate 
and MainAccNo=@MainAccNo 
and (SubAccNo=@SubAccNo or @SubAccNo=0 or SubAccNo=0)

union all

select Flag MyFlag,@MotionType MotionType,InvoiceNo,DayDate,
(Case when Flag in(1,3) then 0 else 1. end)*Value Db,
(Case when Flag in(1,3) then 1. else 0 end)*Value Cr,
Cash,SheekNo,SheekPerson,SheekDate,''* ''+Notes Notes,
(Case Flag when 1 then ''إيرادات خزنة'' when 2 then ''مصروفات خزنة'' when 3 then ''إيرادات بنك'' when 4 then ''مصروفات بنك'' end) ''Rem'',
MainAccNo,dbo.GetMainAccName(MainAccNo)MainAccName,SubAccNo,dbo.GetSubAccName(MainAccNo,SubAccNo) SubAccName,
'''' SalesItems
from BankCash
where DayDate between @FromDate and @ToDate 
and MainAccNo=@MainAccNo 
and (SubAccNo=@SubAccNo or @SubAccNo=0 or SubAccNo=0)
and Canceled=0

union all

select Flag MyFlag,@MotionType MotionType,InvoiceNo,DayDate,
(Case when Flag in(1,3) then 1. else 0 end)*Value Db,
(Case when Flag in(1,3) then 0 else 1. end)*Value Cr,
Cash,SheekNo,SheekPerson,SheekDate,''* ''+Notes Notes,
(Case Flag when 1 then ''إيرادات خزنة'' when 2 then ''مصروفات خزنة'' when 3 then ''إيرادات بنك'' when 4 then ''مصروفات بنك'' end) ''Rem'',
MainAccNo,dbo.GetMainAccName(MainAccNo)MainAccName,SubAccNo,dbo.GetSubAccName(MainAccNo,SubAccNo) SubAccName,
'''' SalesItems
from BankCash
where DayDate between @FromDate and @ToDate 
and (
	(dbo.GetSafeAccNo(BankId)=@MainAccNo and Flag in(1,2) and @LinkFile=5) or
	(dbo.GetBankAccNo(BankId)=@MainAccNo and Flag in(3,4) and @LinkFile=6)
	)
and BankId=@SubAccNo
and Canceled=0

union all

select Flag MyFlag,@MotionType MotionType,InvoiceNo,DayDate,
(Case when Flag in(1,3) then 1. else 0 end)*Value Db,
(Case when Flag in(1,3) then 0 else 1. end)*Value Cr,
'''','''','''',null,''* ''+Notes Notes,
(Case Flag when 1 then ''إيرادات خزنة'' when 2 then ''مصروفات خزنة'' when 3 then ''إيرادات بنك'' when 4 then ''مصروفات بنك'' end) ''Rem'',
OutComeTypeId,dbo.GetOutComeTypeName(OutComeTypeId)MainAccName,'''','''',
'''' SalesItems
from BankCash2
where DayDate between @FromDate and @ToDate 
and (
	(dbo.GetSafeAccNo(BankId)=@MainAccNo and Flag in(1,2) and @LinkFile=5) or
	(dbo.GetBankAccNo(BankId)=@MainAccNo and Flag in(3,4) and @LinkFile=6)
	)
and BankId=@SubAccNo
and Canceled=0

union all

--===========================================================================
--===========================================================================








select 0 MyFlag,@MotionType MotionType,InvoiceNo,DayDate,
(case when Flag in(11,13,15,10,18) then TotalAfterDiscount else 0 end) Db,
(case when Flag in(12,14,16,9,17) then TotalAfterDiscount else 0 end) Cr,
1 Cash,'''' SheekNo,'''' SheekPerson,null SheekDate,''* ''+Notes Notes,
(case when Flag in(11,13,15) then ''مبيعات'' 
when Flag in(12,14,16) then ''مردودات مبيعات'' 
when Flag =9 then ''مشتريات'' 
when Flag=10 then ''مردودات مشتريات'' 
when Flag =17 then ''مشتريات من عملاء'' 
when Flag =18 then ''مبيعات لموردين'' 
else '''' end) ''Rem'',
''-'' MainAccNo,''-'' MainAccName,''-'' SubAccNo,''-'' SubAccName,
'''' SalesItems
from SalesMaster
where DayDate between @FromDate and @ToDate 
and ToId=@SubAccNo
and (
	(@LinkFile=1 and Flag in(11,13,15,12,14,16,17)) or
	(@LinkFile=2 and Flag in(9,10,18)) 
	)
and @Detailed=0
--===========================================================================
union all

select 0 MyFlag,@MotionType MotionType,D.InvoiceNo,D.DayDate,
(case when D.Flag in(11,13,15,10,18) then Dt.Value else 0 end) Db,
(case when D.Flag in(12,14,16,9,17) then Dt.Value else 0 end) Cr,
1 Cash,'''' SheekNo,'''' SheekPerson,null SheekDate,''* ''+Notes Notes,
dt.ItemName ''Rem'',
''-'' MainAccNo,''-'' MainAccName,''-'' SubAccNo,''-'' SubAccName,
'''' SalesItems
from SalesMaster D
left join SalesDetails Dt on(D.StoreId=dt.StoreId and D.Flag=dt.Flag and D.InvoiceNo=Dt.InvoiceNo )
where D.DayDate between @FromDate and @ToDate 
and ToId=@SubAccNo
and (
	(@LinkFile=1 and D.Flag in(11,13,15,12,14,16,17)) or
	(@LinkFile=2 and D.Flag in(9,10,18)) 
	)
and Dt.Value<>0
and @Detailed=1
--===========================================================================
union all

select 0 MyFlag,@MotionType MotionType,InvoiceNo,DayDate,
(case when (Flag in(11,13,15,10,18) and AccType1=2) or (Flag in(12,14,16,9,17) and AccType1=1) then Val1 else 0 end) Db,
(case when (Flag in(11,13,15,10,18) and AccType1=1) or (Flag in(12,14,16,9,17) and AccType1=2) then Val1 else 0 end) Cr,
1 Cash,'''' SheekNo,'''' SheekPerson,null SheekDate,''* ''+Notes Notes,
dbo.GetAccName(AccNo1) ''Rem'',
''-'' MainAccNo,''-'' MainAccName,''-'' SubAccNo,''-'' SubAccName,
'''' SalesItems
from SalesMaster
where DayDate between @FromDate and @ToDate 
and ToId=@SubAccNo
and (
	(@LinkFile=1 and Flag in(11,13,15,12,14,16,17)) or
	(@LinkFile=2 and Flag in(9,10,18)) 
	)
and Val1<>0
and @Detailed=1
--===========================================================================
union all

select 0 MyFlag,@MotionType MotionType,InvoiceNo,DayDate,
(case when (Flag in(11,13,15,10,18) and AccType2=2) or (Flag in(12,14,16,9,17) and AccType2=1) then Val2 else 0 end) Db,
(case when (Flag in(11,13,15,10,18) and AccType2=1) or (Flag in(12,14,16,9,17) and AccType2=2) then Val2 else 0 end) Cr,
1 Cash,'''' SheekNo,'''' SheekPerson,null SheekDate,''* ''+Notes Notes,
dbo.GetAccName(AccNo2) ''Rem'',
''-'' MainAccNo,''-'' MainAccName,''-'' SubAccNo,''-'' SubAccName,
'''' SalesItems
from SalesMaster
where DayDate between @FromDate and @ToDate 
and ToId=@SubAccNo
and (
	(@LinkFile=1 and Flag in(11,13,15,12,14,16,17)) or
	(@LinkFile=2 and Flag in(9,10,18)) 
	)
and Val2<>0
and @Detailed=1
--===========================================================================
union all

select 0 MyFlag,@MotionType MotionType,InvoiceNo,DayDate,
(case when (Flag in(11,13,15,10,18) and AccType3=2) or (Flag in(12,14,16,9,17) and AccType3=1) then Val3 else 0 end) Db,
(case when (Flag in(11,13,15,10,18) and AccType3=1) or (Flag in(12,14,16,9,17) and AccType3=2) then Val3 else 0 end) Cr,
1 Cash,'''' SheekNo,'''' SheekPerson,null SheekDate,''* ''+Notes Notes,
dbo.GetAccName(AccNo3) ''Rem'',
''-'' MainAccNo,''-'' MainAccName,''-'' SubAccNo,''-'' SubAccName,
'''' SalesItems
from SalesMaster
where DayDate between @FromDate and @ToDate 
and ToId=@SubAccNo
and (
	(@LinkFile=1 and Flag in(11,13,15,12,14,16,17)) or
	(@LinkFile=2 and Flag in(9,10,18)) 
	)
and Val3<>0
and @Detailed=1
--===========================================================================
union all

select 0 MyFlag,@MotionType MotionType,InvoiceNo,DayDate,
(case when (Flag in(11,13,15,10,18) and AccType4=2) or (Flag in(12,14,16,9,17) and AccType4=1) then Val4 else 0 end) Db,
(case when (Flag in(11,13,15,10,18) and AccType4=1) or (Flag in(12,14,16,9,17) and AccType4=2) then Val4 else 0 end) Cr,
1 Cash,'''' SheekNo,'''' SheekPerson,null SheekDate,''* ''+Notes Notes,
dbo.GetAccName(AccNo4) ''Rem'',
''-'' MainAccNo,''-'' MainAccName,''-'' SubAccNo,''-'' SubAccName,
'''' SalesItems
from SalesMaster
where DayDate between @FromDate and @ToDate 
and ToId=@SubAccNo
and (
	(@LinkFile=1 and Flag in(11,13,15,12,14,16,17)) or
	(@LinkFile=2 and Flag in(9,10,18)) 
	)
and Val4<>0
and @Detailed=1
--===========================================================================


--===========================================================================النقدى والفيزا

union all


select 0 MyFlag,@MotionType MotionType,InvoiceNo,DayDate,
(Case when SaveId=@SubAccNo and @LinkFile=5 then 1. else 0 end)*(case when PaymentType in(1,2,3) then TotalAfterDiscount when PaymentType=5 then CashValue end) Db,
(Case when ToId=@SubAccNo and @LinkFile=1 then 1. else 0 end)*(case when PaymentType in(1,2,3) then TotalAfterDiscount when PaymentType=5 then CashValue end) Cr,
1 Cash,'''' SheekNo,'''' SheekPerson,null SheekDate,''* ''+Notes Notes,
''نقدى - مبيعات'' ''Rem'',
dbo.GetMainAccNoLink(1,ToId),dbo.GetMainAccName(dbo.GetMainAccNoLink(1,ToId))MainAccName,ToId,dbo.GetSubAccNameLink(1,ToId) SubAccName,
dbo.GetSalesItems(Flag,StoreId,InvoiceNo)
from SalesMaster
where DayDate between @FromDate and @ToDate 
and ((ToId=@SubAccNo and @LinkFile=1) or (SaveId=@SubAccNo and @LinkFile=5))
and Flag in(11,13,15)
and PaymentType in(1,2,3,5)

union all

select 0 MyFlag,@MotionType MotionType,InvoiceNo,DayDate,
(Case when ToId=@SubAccNo and @LinkFile=1 then 1. else 0 end)*(case when PaymentType in(1,2,3) then TotalAfterDiscount when PaymentType=5 then CashValue end) Db,
(Case when SaveId=@SubAccNo and @LinkFile=5 then 1. else 0 end)*(case when PaymentType in(1,2,3) then TotalAfterDiscount when PaymentType=5 then CashValue end) Cr,
1 Cash,'''' SheekNo,'''' SheekPerson,null SheekDate,''* ''+Notes Notes,
''نقدى - مردودات مبيعات'' ''Rem'',
dbo.GetMainAccNoLink(1,ToId),dbo.GetMainAccName(dbo.GetMainAccNoLink(1,ToId))MainAccName,ToId,dbo.GetSubAccNameLink(1,ToId) SubAccName,
dbo.GetSalesItems(Flag,StoreId,InvoiceNo)
from SalesMaster
where DayDate between @FromDate and @ToDate 
and ((ToId=@SubAccNo and @LinkFile=1) or (SaveId=@SubAccNo and @LinkFile=5))
and Flag in(12,14,16)
and PaymentType in(1,2,3,5)

union all

select 0 MyFlag,@MotionType MotionType,InvoiceNo,DayDate,
(Case when ToId=@SubAccNo and @LinkFile=1 then 1. else 0 end)*(case when PaymentType in(1,2,3) then TotalAfterDiscount when PaymentType=5 then CashValue end) Db,
(Case when SaveId=@SubAccNo and @LinkFile=5 then 1. else 0 end)*(case when PaymentType in(1,2,3) then TotalAfterDiscount when PaymentType=5 then CashValue end) Cr,
1 Cash,'''' SheekNo,'''' SheekPerson,null SheekDate,''* ''+Notes Notes,
''نقدى - مشتريات من عميل'' ''Rem'',
dbo.GetMainAccNoLink(1,ToId),dbo.GetMainAccName(dbo.GetMainAccNoLink(1,ToId))MainAccName,ToId,dbo.GetSubAccNameLink(1,ToId) SubAccName,
dbo.GetSalesItems(Flag,StoreId,InvoiceNo)
from SalesMaster
where DayDate between @FromDate and @ToDate 
and ((ToId=@SubAccNo and @LinkFile=1) or (SaveId=@SubAccNo and @LinkFile=5))
and Flag in(17)
and PaymentType in(1,2,3,5)

union all

select 0 MyFlag,@MotionType MotionType,InvoiceNo,DayDate,
(Case when ToId=@SubAccNo and @LinkFile=2 then 1. else 0 end)*(case when PaymentType in(1,2,3) then TotalAfterDiscount when PaymentType=5 then CashValue end) Db,
(Case when SaveId=@SubAccNo and @LinkFile=5 then 1. else 0 end)*(case when PaymentType in(1,2,3) then TotalAfterDiscount when PaymentType=5 then CashValue end) Cr,
1 Cash,'''' SheekNo,'''' SheekPerson,null SheekDate,''* ''+Notes Notes,
''نقدى - مشتريات'' ''Rem'',
dbo.GetMainAccNoLink(2,ToId),dbo.GetMainAccName(dbo.GetMainAccNoLink(2,ToId))MainAccName,ToId,dbo.GetSubAccNameLink(2,ToId) SubAccName,
dbo.GetSalesItems(Flag,StoreId,InvoiceNo)
from SalesMaster
where DayDate between @FromDate and @ToDate 
and ((ToId=@SubAccNo and @LinkFile=2) or (SaveId=@SubAccNo and @LinkFile=5))
and Flag =9
and PaymentType in(1,2,3,5)

union all

select 0 MyFlag,@MotionType MotionType,InvoiceNo,DayDate,
(Case when SaveId=@SubAccNo and @LinkFile=5 then 1. else 0 end)*(case when PaymentType in(1,2,3) then TotalAfterDiscount when PaymentType=5 then CashValue end) Db,
(Case when ToId=@SubAccNo and @LinkFile=2 then 1. else 0 end)*(case when PaymentType in(1,2,3) then TotalAfterDiscount when PaymentType=5 then CashValue end) Cr,
1 Cash,'''' SheekNo,'''' SheekPerson,null SheekDate,''* ''+Notes Notes,
''نقدى - مردودات مشتريات'' ''Rem'',
dbo.GetMainAccNoLink(2,ToId),dbo.GetMainAccName(dbo.GetMainAccNoLink(2,ToId))MainAccName,ToId,dbo.GetSubAccNameLink(2,ToId) SubAccName,
dbo.GetSalesItems(Flag,StoreId,InvoiceNo)
from SalesMaster
where DayDate between @FromDate and @ToDate 
and ((ToId=@SubAccNo and @LinkFile=2) or (SaveId=@SubAccNo and @LinkFile=5))
and Flag =10
and PaymentType in(1,2,3,5)

union all

select 0 MyFlag,@MotionType MotionType,InvoiceNo,DayDate,
(Case when SaveId=@SubAccNo and @LinkFile=5 then 1. else 0 end)*(case when PaymentType in(1,2,3) then TotalAfterDiscount when PaymentType=5 then CashValue end) Db,
(Case when ToId=@SubAccNo and @LinkFile=2 then 1. else 0 end)*(case when PaymentType in(1,2,3) then TotalAfterDiscount when PaymentType=5 then CashValue end) Cr,
1 Cash,'''' SheekNo,'''' SheekPerson,null SheekDate,''* ''+Notes Notes,
''نقدى - مبيعات لموردين'' ''Rem'',
dbo.GetMainAccNoLink(2,ToId),dbo.GetMainAccName(dbo.GetMainAccNoLink(2,ToId))MainAccName,ToId,dbo.GetSubAccNameLink(2,ToId) SubAccName,
dbo.GetSalesItems(Flag,StoreId,InvoiceNo)
from SalesMaster
where DayDate between @FromDate and @ToDate 
and ((ToId=@SubAccNo and @LinkFile=2) or (SaveId=@SubAccNo and @LinkFile=5))
and Flag =18
and PaymentType in(1,2,3,5)

--===========================================================================إكرامية
union all

select 0 MyFlag,@MotionType MotionType,InvoiceNo,DayDate,
0 Db,
Tips Cr,
1 Cash,'''' SheekNo,'''' SheekPerson,null SheekDate,''* ''+Notes Notes,
''إكرامية - مبيعات'' ''Rem'',
dbo.GetMainAccNoLink(1,ToId),dbo.GetMainAccName(dbo.GetMainAccNoLink(1,ToId))MainAccName,ToId,dbo.GetSubAccNameLink(1,ToId) SubAccName,
dbo.GetSalesItems(Flag,StoreId,InvoiceNo)
from SalesMaster
where DayDate between @FromDate and @ToDate 
and (SaveId=@SubAccNo and @LinkFile=5)
and Flag in(11,13,15)
and Tips<>0
--===========================================================================حساب المبيعات والمشتريات

union all

select 0 MyFlag,@MotionType MotionType,InvoiceNo,DayDate,
0 Db,
Total Cr,
1 Cash,'''' SheekNo,'''' SheekPerson,null SheekDate,''* ''+Notes Notes,
''مبيعات'' ''Rem'',
''-'' MainAccNo,''-'' MainAccName,''-'' SubAccNo,''-'' SubAccName,
'''' SalesItems
from SalesMaster
where DayDate between @FromDate and @ToDate 
and Flag in(11,13,15)
and @S_AccNo=@MainAccNo
and @SubAccNo=0

union all

select 0 MyFlag,@MotionType MotionType,InvoiceNo,DayDate,
Total Db,
0 Cr,
1 Cash,'''' SheekNo,'''' SheekPerson,null SheekDate,''* ''+Notes Notes,
''مردودات مبيعات'' ''Rem'',
''-'' MainAccNo,''-'' MainAccName,''-'' SubAccNo,''-'' SubAccName,
'''' SalesItems
from SalesMaster
where DayDate between @FromDate and @ToDate 
and Flag in(12,14,16)
and @R_S_AccNo=@MainAccNo
and @SubAccNo=0

union all

select 0 MyFlag,@MotionType MotionType,InvoiceNo,DayDate,
Total Db,
0 Cr,
1 Cash,'''' SheekNo,'''' SheekPerson,null SheekDate,''* ''+Notes Notes,
''مشتريات من عميل'' ''Rem'',
''-'' MainAccNo,''-'' MainAccName,''-'' SubAccNo,''-'' SubAccName,
'''' SalesItems
from SalesMaster
where DayDate between @FromDate and @ToDate 
and Flag in(17)
and @R_S_AccNo=@MainAccNo
and @SubAccNo=0

union all

select 0 MyFlag,@MotionType MotionType,InvoiceNo,DayDate,
Total Db,
0 Cr,
1 Cash,'''' SheekNo,'''' SheekPerson,null SheekDate,''* ''+Notes Notes,
''مشتريات'' ''Rem'',
''-'' MainAccNo,''-'' MainAccName,''-'' SubAccNo,''-'' SubAccName,
'''' SalesItems
from SalesMaster
where DayDate between @FromDate and @ToDate 
and Flag =9
and @P_AccNo=@MainAccNo
and @SubAccNo=0

union all

select 0 MyFlag,@MotionType MotionType,InvoiceNo,DayDate,
0 Db,
Total Cr,
1 Cash,'''' SheekNo,'''' SheekPerson,null SheekDate,''* ''+Notes Notes,
''مردودات مشتريات'' ''Rem'',
''-'' MainAccNo,''-'' MainAccName,''-'' SubAccNo,''-'' SubAccName,
'''' SalesItems
from SalesMaster
where DayDate between @FromDate and @ToDate 
and Flag =10
and @R_P_AccNo=@MainAccNo
and @SubAccNo=0

union all

select 0 MyFlag,@MotionType MotionType,InvoiceNo,DayDate,
0 Db,
Total Cr,
1 Cash,'''' SheekNo,'''' SheekPerson,null SheekDate,''* ''+Notes Notes,
''مبيعات لموردين'' ''Rem'',
''-'' MainAccNo,''-'' MainAccName,''-'' SubAccNo,''-'' SubAccName,
'''' SalesItems
from SalesMaster
where DayDate between @FromDate and @ToDate 
and Flag =18
and @R_P_AccNo=@MainAccNo
and @SubAccNo=0



--===========================================================================حسابات الخصم والإضافة

union all

select 0 MyFlag,@MotionType MotionType,InvoiceNo,DayDate,
((case when @MainAccNo=AccNo1 and AccType1=1 then Val1 else 0 end)+(case when @MainAccNo=AccNo2 and AccType2=1 then Val2 else 0 end)+(case when @MainAccNo=AccNo3 and AccType3=1 then Val3 else 0 end)+(case when @MainAccNo=AccNo4 and AccType4=1 then Val4 else 0 end)) Db,
((case when @MainAccNo=AccNo1 and AccType1=2 then Val1 else 0 end)+(case when @MainAccNo=AccNo2 and AccType2=2 then Val2 else 0 end)+(case when @MainAccNo=AccNo3 and AccType3=2 then Val3 else 0 end)+(case when @MainAccNo=AccNo4 and AccType4=2 then Val4 else 0 end)) Cr,
1 Cash,'''' SheekNo,'''' SheekPerson,null SheekDate,''* ''+Notes Notes,
''مبيعات'' ''Rem'',
''-'' MainAccNo,''-'' MainAccName,''-'' SubAccNo,''-'' SubAccName,
'''' SalesItems
from SalesMaster
where DayDate between @FromDate and @ToDate 
and Flag in(11,13,15)
and @MainAccNo in(AccNo1,AccNo2,AccNo3,AccNo4)
and @SubAccNo=0

union all

select 0 MyFlag,@MotionType MotionType,InvoiceNo,DayDate,
((case when @MainAccNo=AccNo1 and AccType1=2 then Val1 else 0 end)+(case when @MainAccNo=AccNo2 and AccType2=2 then Val2 else 0 end)+(case when @MainAccNo=AccNo3 and AccType3=2 then Val3 else 0 end)+(case when @MainAccNo=AccNo4 and AccType4=2 then Val4 else 0 end)) Db,
((case when @MainAccNo=AccNo1 and AccType1=1 then Val1 else 0 end)+(case when @MainAccNo=AccNo2 and AccType2=1 then Val2 else 0 end)+(case when @MainAccNo=AccNo3 and AccType3=1 then Val3 else 0 end)+(case when @MainAccNo=AccNo4 and AccType4=1 then Val4 else 0 end)) Cr,
1 Cash,'''' SheekNo,'''' SheekPerson,null SheekDate,''* ''+Notes Notes,
''مردودات مبيعات'' ''Rem'',
''-'' MainAccNo,''-'' MainAccName,''-'' SubAccNo,''-'' SubAccName,
'''' SalesItems
from SalesMaster
where DayDate between @FromDate and @ToDate 
and Flag in(12,14,16)
and @MainAccNo in(AccNo1,AccNo2,AccNo3,AccNo4)
and @SubAccNo=0

union all

select 0 MyFlag,@MotionType MotionType,InvoiceNo,DayDate,
((case when @MainAccNo=AccNo1 and AccType1=2 then Val1 else 0 end)+(case when @MainAccNo=AccNo2 and AccType2=2 then Val2 else 0 end)+(case when @MainAccNo=AccNo3 and AccType3=2 then Val3 else 0 end)+(case when @MainAccNo=AccNo4 and AccType4=2 then Val4 else 0 end)) Db,
((case when @MainAccNo=AccNo1 and AccType1=1 then Val1 else 0 end)+(case when @MainAccNo=AccNo2 and AccType2=1 then Val2 else 0 end)+(case when @MainAccNo=AccNo3 and AccType3=1 then Val3 else 0 end)+(case when @MainAccNo=AccNo4 and AccType4=1 then Val4 else 0 end)) Cr,
1 Cash,'''' SheekNo,'''' SheekPerson,null SheekDate,''* ''+Notes Notes,
''مشتريات من عميل'' ''Rem'',
''-'' MainAccNo,''-'' MainAccName,''-'' SubAccNo,''-'' SubAccName,
'''' SalesItems
from SalesMaster
where DayDate between @FromDate and @ToDate 
and Flag in(17)
and @MainAccNo in(AccNo1,AccNo2,AccNo3,AccNo4)
and @SubAccNo=0

union all

select 0 MyFlag,@MotionType MotionType,InvoiceNo,DayDate,
((case when @MainAccNo=AccNo1 and AccType1=2 then Val1 else 0 end)+(case when @MainAccNo=AccNo2 and AccType2=2 then Val2 else 0 end)+(case when @MainAccNo=AccNo3 and AccType3=2 then Val3 else 0 end)+(case when @MainAccNo=AccNo4 and AccType4=2 then Val4 else 0 end)) Db,
((case when @MainAccNo=AccNo1 and AccType1=1 then Val1 else 0 end)+(case when @MainAccNo=AccNo2 and AccType2=1 then Val2 else 0 end)+(case when @MainAccNo=AccNo3 and AccType3=1 then Val3 else 0 end)+(case when @MainAccNo=AccNo4 and AccType4=1 then Val4 else 0 end)) Cr,
1 Cash,'''' SheekNo,'''' SheekPerson,null SheekDate,''* ''+Notes Notes,
''مشتريات'' ''Rem'',
''-'' MainAccNo,''-'' MainAccName,''-'' SubAccNo,''-'' SubAccName,
'''' SalesItems
from SalesMaster
where DayDate between @FromDate and @ToDate 
and Flag =9
and @MainAccNo in(AccNo1,AccNo2,AccNo3,AccNo4)
and @SubAccNo=0

union all

select 0 MyFlag,@MotionType MotionType,InvoiceNo,DayDate,
((case when @MainAccNo=AccNo1 and AccType1=1 then Val1 else 0 end)+(case when @MainAccNo=AccNo2 and AccType2=1 then Val2 else 0 end)+(case when @MainAccNo=AccNo3 and AccType3=1 then Val3 else 0 end)+(case when @MainAccNo=AccNo4 and AccType4=1 then Val4 else 0 end)) Db,
((case when @MainAccNo=AccNo1 and AccType1=2 then Val1 else 0 end)+(case when @MainAccNo=AccNo2 and AccType2=2 then Val2 else 0 end)+(case when @MainAccNo=AccNo3 and AccType3=2 then Val3 else 0 end)+(case when @MainAccNo=AccNo4 and AccType4=2 then Val4 else 0 end)) Cr,
1 Cash,'''' SheekNo,'''' SheekPerson,null SheekDate,''* ''+Notes Notes,
''مردودات مشتريات'' ''Rem'',
''-'' MainAccNo,''-'' MainAccName,''-'' SubAccNo,''-'' SubAccName,
'''' SalesItems
from SalesMaster
where DayDate between @FromDate and @ToDate 
and Flag =10
and @MainAccNo in(AccNo1,AccNo2,AccNo3,AccNo4)
and @SubAccNo=0

union all

select 0 MyFlag,@MotionType MotionType,InvoiceNo,DayDate,
((case when @MainAccNo=AccNo1 and AccType1=1 then Val1 else 0 end)+(case when @MainAccNo=AccNo2 and AccType2=1 then Val2 else 0 end)+(case when @MainAccNo=AccNo3 and AccType3=1 then Val3 else 0 end)+(case when @MainAccNo=AccNo4 and AccType4=1 then Val4 else 0 end)) Db,
((case when @MainAccNo=AccNo1 and AccType1=2 then Val1 else 0 end)+(case when @MainAccNo=AccNo2 and AccType2=2 then Val2 else 0 end)+(case when @MainAccNo=AccNo3 and AccType3=2 then Val3 else 0 end)+(case when @MainAccNo=AccNo4 and AccType4=2 then Val4 else 0 end)) Cr,
1 Cash,'''' SheekNo,'''' SheekPerson,null SheekDate,''* ''+Notes Notes,
''مبيعات لموردين'' ''Rem'',
''-'' MainAccNo,''-'' MainAccName,''-'' SubAccNo,''-'' SubAccName,
'''' SalesItems
from SalesMaster
where DayDate between @FromDate and @ToDate 
and Flag =18
and @MainAccNo in(AccNo1,AccNo2,AccNo3,AccNo4)
and @SubAccNo=0
' 
END
GO
