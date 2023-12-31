﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL_Service.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class RELServiceEntities : DbContext
    {
        public RELServiceEntities()
            : base("name=RELServiceEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Branch> Branches { get; set; }
        public virtual DbSet<BrandModel> BrandModels { get; set; }
        public virtual DbSet<CashSale> CashSales { get; set; }
        public virtual DbSet<cFlagDetail> cFlagDetails { get; set; }
        public virtual DbSet<ClaimList> ClaimLists { get; set; }
        public virtual DbSet<cType> cTypes { get; set; }
        public virtual DbSet<CustomerClaimOther> CustomerClaimOthers { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<dtproperty> dtproperties { get; set; }
        public virtual DbSet<EstimateRefused> EstimateRefuseds { get; set; }
        public virtual DbSet<LogUser> LogUsers { get; set; }
        public virtual DbSet<NRDetail> NRDetails { get; set; }
        public virtual DbSet<NROther> NROthers { get; set; }
        public virtual DbSet<Pending> Pendings { get; set; }
        public virtual DbSet<PendingOther> PendingOthers { get; set; }
        public virtual DbSet<Personal> Personals { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<RPTHowTimeBillPrint> RPTHowTimeBillPrints { get; set; }
        public virtual DbSet<SecurityProfile> SecurityProfiles { get; set; }
        public virtual DbSet<SoftUser> SoftUsers { get; set; }
        public virtual DbSet<tbBill> tbBills { get; set; }
        public virtual DbSet<tbBill_FFC> tbBill_FFC { get; set; }
        public virtual DbSet<tbGrade> tbGrades { get; set; }
        public virtual DbSet<tbl_RptTechnicianPerformance> tbl_RptTechnicianPerformance { get; set; }
        public virtual DbSet<tblDailyInOut> tblDailyInOuts { get; set; }
        public virtual DbSet<tblItemCap> tblItemCaps { get; set; }
        public virtual DbSet<tblServiceCharge> tblServiceCharges { get; set; }
        public virtual DbSet<tbReminder> tbReminders { get; set; }
        public virtual DbSet<tbSM> tbSMS { get; set; }
        public virtual DbSet<tbSMSReceipentList> tbSMSReceipentLists { get; set; }
        public virtual DbSet<tbStoregeSET> tbStoregeSETs { get; set; }
        public virtual DbSet<tbTechPerformancSummary> tbTechPerformancSummaries { get; set; }
        public virtual DbSet<tbVATSetting> tbVATSettings { get; set; }
        public virtual DbSet<TempMIS_Report> TempMIS_Report { get; set; }
        public virtual DbSet<TempService> TempServices { get; set; }
        public virtual DbSet<TransferJob> TransferJobs { get; set; }
        public virtual DbSet<CustomerClaim> CustomerClaims { get; set; }
        public virtual DbSet<Designation> Designations { get; set; }
        public virtual DbSet<Replace> Replaces { get; set; }
        public virtual DbSet<SecurityProfile2> SecurityProfile2 { get; set; }
        public virtual DbSet<ServiceDetail> ServiceDetails { get; set; }
        public virtual DbSet<qryFind> qryFinds { get; set; }
        public virtual DbSet<qryFind1> qryFind1 { get; set; }
        public virtual DbSet<qryFindProduct> qryFindProducts { get; set; }
        public virtual DbSet<qryFindProduct1> qryFindProduct1 { get; set; }
        public virtual DbSet<qryGrade> qryGrades { get; set; }
        public virtual DbSet<qryKPII> qryKPIIs { get; set; }
        public virtual DbSet<qryRptClaimInfo> qryRptClaimInfoes { get; set; }
        public virtual DbSet<Query4> Query4 { get; set; }
        public virtual DbSet<RTPBrandMaster> RTPBrandMasters { get; set; }
        public virtual DbSet<VIEW1> VIEW1 { get; set; }
        public virtual DbSet<VW_Advance_Info> VW_Advance_Info { get; set; }
        public virtual DbSet<vw_BrandModel> vw_BrandModel { get; set; }
        public virtual DbSet<VW_CashSales> VW_CashSales { get; set; }
        public virtual DbSet<vw_TransferJob> vw_TransferJob { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<ClaimInfo> ClaimInfoes { get; set; }
        public virtual DbSet<ServiceItem> ServiceItems { get; set; }
    
        public virtual ObjectResult<aabc_Result> aabc()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<aabc_Result>("aabc");
        }
    
        public virtual ObjectResult<Nullable<double>> dd()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<double>>("dd");
        }
    
        public virtual int dt_addtosourcecontrol(string vchSourceSafeINI, string vchProjectName, string vchComment, string vchLoginName, string vchPassword)
        {
            var vchSourceSafeINIParameter = vchSourceSafeINI != null ?
                new ObjectParameter("vchSourceSafeINI", vchSourceSafeINI) :
                new ObjectParameter("vchSourceSafeINI", typeof(string));
    
            var vchProjectNameParameter = vchProjectName != null ?
                new ObjectParameter("vchProjectName", vchProjectName) :
                new ObjectParameter("vchProjectName", typeof(string));
    
            var vchCommentParameter = vchComment != null ?
                new ObjectParameter("vchComment", vchComment) :
                new ObjectParameter("vchComment", typeof(string));
    
            var vchLoginNameParameter = vchLoginName != null ?
                new ObjectParameter("vchLoginName", vchLoginName) :
                new ObjectParameter("vchLoginName", typeof(string));
    
            var vchPasswordParameter = vchPassword != null ?
                new ObjectParameter("vchPassword", vchPassword) :
                new ObjectParameter("vchPassword", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("dt_addtosourcecontrol", vchSourceSafeINIParameter, vchProjectNameParameter, vchCommentParameter, vchLoginNameParameter, vchPasswordParameter);
        }
    
        public virtual int dt_addtosourcecontrol_u(string vchSourceSafeINI, string vchProjectName, string vchComment, string vchLoginName, string vchPassword)
        {
            var vchSourceSafeINIParameter = vchSourceSafeINI != null ?
                new ObjectParameter("vchSourceSafeINI", vchSourceSafeINI) :
                new ObjectParameter("vchSourceSafeINI", typeof(string));
    
            var vchProjectNameParameter = vchProjectName != null ?
                new ObjectParameter("vchProjectName", vchProjectName) :
                new ObjectParameter("vchProjectName", typeof(string));
    
            var vchCommentParameter = vchComment != null ?
                new ObjectParameter("vchComment", vchComment) :
                new ObjectParameter("vchComment", typeof(string));
    
            var vchLoginNameParameter = vchLoginName != null ?
                new ObjectParameter("vchLoginName", vchLoginName) :
                new ObjectParameter("vchLoginName", typeof(string));
    
            var vchPasswordParameter = vchPassword != null ?
                new ObjectParameter("vchPassword", vchPassword) :
                new ObjectParameter("vchPassword", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("dt_addtosourcecontrol_u", vchSourceSafeINIParameter, vchProjectNameParameter, vchCommentParameter, vchLoginNameParameter, vchPasswordParameter);
        }
    
        public virtual int dt_adduserobject()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("dt_adduserobject");
        }
    
        public virtual int dt_adduserobject_vcs(string vchProperty)
        {
            var vchPropertyParameter = vchProperty != null ?
                new ObjectParameter("vchProperty", vchProperty) :
                new ObjectParameter("vchProperty", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("dt_adduserobject_vcs", vchPropertyParameter);
        }
    
        public virtual int dt_checkinobject(string chObjectType, string vchObjectName, string vchComment, string vchLoginName, string vchPassword, Nullable<int> iVCSFlags, Nullable<int> iActionFlag, string txStream1, string txStream2, string txStream3)
        {
            var chObjectTypeParameter = chObjectType != null ?
                new ObjectParameter("chObjectType", chObjectType) :
                new ObjectParameter("chObjectType", typeof(string));
    
            var vchObjectNameParameter = vchObjectName != null ?
                new ObjectParameter("vchObjectName", vchObjectName) :
                new ObjectParameter("vchObjectName", typeof(string));
    
            var vchCommentParameter = vchComment != null ?
                new ObjectParameter("vchComment", vchComment) :
                new ObjectParameter("vchComment", typeof(string));
    
            var vchLoginNameParameter = vchLoginName != null ?
                new ObjectParameter("vchLoginName", vchLoginName) :
                new ObjectParameter("vchLoginName", typeof(string));
    
            var vchPasswordParameter = vchPassword != null ?
                new ObjectParameter("vchPassword", vchPassword) :
                new ObjectParameter("vchPassword", typeof(string));
    
            var iVCSFlagsParameter = iVCSFlags.HasValue ?
                new ObjectParameter("iVCSFlags", iVCSFlags) :
                new ObjectParameter("iVCSFlags", typeof(int));
    
            var iActionFlagParameter = iActionFlag.HasValue ?
                new ObjectParameter("iActionFlag", iActionFlag) :
                new ObjectParameter("iActionFlag", typeof(int));
    
            var txStream1Parameter = txStream1 != null ?
                new ObjectParameter("txStream1", txStream1) :
                new ObjectParameter("txStream1", typeof(string));
    
            var txStream2Parameter = txStream2 != null ?
                new ObjectParameter("txStream2", txStream2) :
                new ObjectParameter("txStream2", typeof(string));
    
            var txStream3Parameter = txStream3 != null ?
                new ObjectParameter("txStream3", txStream3) :
                new ObjectParameter("txStream3", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("dt_checkinobject", chObjectTypeParameter, vchObjectNameParameter, vchCommentParameter, vchLoginNameParameter, vchPasswordParameter, iVCSFlagsParameter, iActionFlagParameter, txStream1Parameter, txStream2Parameter, txStream3Parameter);
        }
    
        public virtual int dt_checkinobject_u(string chObjectType, string vchObjectName, string vchComment, string vchLoginName, string vchPassword, Nullable<int> iVCSFlags, Nullable<int> iActionFlag, string txStream1, string txStream2, string txStream3)
        {
            var chObjectTypeParameter = chObjectType != null ?
                new ObjectParameter("chObjectType", chObjectType) :
                new ObjectParameter("chObjectType", typeof(string));
    
            var vchObjectNameParameter = vchObjectName != null ?
                new ObjectParameter("vchObjectName", vchObjectName) :
                new ObjectParameter("vchObjectName", typeof(string));
    
            var vchCommentParameter = vchComment != null ?
                new ObjectParameter("vchComment", vchComment) :
                new ObjectParameter("vchComment", typeof(string));
    
            var vchLoginNameParameter = vchLoginName != null ?
                new ObjectParameter("vchLoginName", vchLoginName) :
                new ObjectParameter("vchLoginName", typeof(string));
    
            var vchPasswordParameter = vchPassword != null ?
                new ObjectParameter("vchPassword", vchPassword) :
                new ObjectParameter("vchPassword", typeof(string));
    
            var iVCSFlagsParameter = iVCSFlags.HasValue ?
                new ObjectParameter("iVCSFlags", iVCSFlags) :
                new ObjectParameter("iVCSFlags", typeof(int));
    
            var iActionFlagParameter = iActionFlag.HasValue ?
                new ObjectParameter("iActionFlag", iActionFlag) :
                new ObjectParameter("iActionFlag", typeof(int));
    
            var txStream1Parameter = txStream1 != null ?
                new ObjectParameter("txStream1", txStream1) :
                new ObjectParameter("txStream1", typeof(string));
    
            var txStream2Parameter = txStream2 != null ?
                new ObjectParameter("txStream2", txStream2) :
                new ObjectParameter("txStream2", typeof(string));
    
            var txStream3Parameter = txStream3 != null ?
                new ObjectParameter("txStream3", txStream3) :
                new ObjectParameter("txStream3", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("dt_checkinobject_u", chObjectTypeParameter, vchObjectNameParameter, vchCommentParameter, vchLoginNameParameter, vchPasswordParameter, iVCSFlagsParameter, iActionFlagParameter, txStream1Parameter, txStream2Parameter, txStream3Parameter);
        }
    
        public virtual int dt_checkoutobject(string chObjectType, string vchObjectName, string vchComment, string vchLoginName, string vchPassword, Nullable<int> iVCSFlags, Nullable<int> iActionFlag)
        {
            var chObjectTypeParameter = chObjectType != null ?
                new ObjectParameter("chObjectType", chObjectType) :
                new ObjectParameter("chObjectType", typeof(string));
    
            var vchObjectNameParameter = vchObjectName != null ?
                new ObjectParameter("vchObjectName", vchObjectName) :
                new ObjectParameter("vchObjectName", typeof(string));
    
            var vchCommentParameter = vchComment != null ?
                new ObjectParameter("vchComment", vchComment) :
                new ObjectParameter("vchComment", typeof(string));
    
            var vchLoginNameParameter = vchLoginName != null ?
                new ObjectParameter("vchLoginName", vchLoginName) :
                new ObjectParameter("vchLoginName", typeof(string));
    
            var vchPasswordParameter = vchPassword != null ?
                new ObjectParameter("vchPassword", vchPassword) :
                new ObjectParameter("vchPassword", typeof(string));
    
            var iVCSFlagsParameter = iVCSFlags.HasValue ?
                new ObjectParameter("iVCSFlags", iVCSFlags) :
                new ObjectParameter("iVCSFlags", typeof(int));
    
            var iActionFlagParameter = iActionFlag.HasValue ?
                new ObjectParameter("iActionFlag", iActionFlag) :
                new ObjectParameter("iActionFlag", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("dt_checkoutobject", chObjectTypeParameter, vchObjectNameParameter, vchCommentParameter, vchLoginNameParameter, vchPasswordParameter, iVCSFlagsParameter, iActionFlagParameter);
        }
    
        public virtual int dt_checkoutobject_u(string chObjectType, string vchObjectName, string vchComment, string vchLoginName, string vchPassword, Nullable<int> iVCSFlags, Nullable<int> iActionFlag)
        {
            var chObjectTypeParameter = chObjectType != null ?
                new ObjectParameter("chObjectType", chObjectType) :
                new ObjectParameter("chObjectType", typeof(string));
    
            var vchObjectNameParameter = vchObjectName != null ?
                new ObjectParameter("vchObjectName", vchObjectName) :
                new ObjectParameter("vchObjectName", typeof(string));
    
            var vchCommentParameter = vchComment != null ?
                new ObjectParameter("vchComment", vchComment) :
                new ObjectParameter("vchComment", typeof(string));
    
            var vchLoginNameParameter = vchLoginName != null ?
                new ObjectParameter("vchLoginName", vchLoginName) :
                new ObjectParameter("vchLoginName", typeof(string));
    
            var vchPasswordParameter = vchPassword != null ?
                new ObjectParameter("vchPassword", vchPassword) :
                new ObjectParameter("vchPassword", typeof(string));
    
            var iVCSFlagsParameter = iVCSFlags.HasValue ?
                new ObjectParameter("iVCSFlags", iVCSFlags) :
                new ObjectParameter("iVCSFlags", typeof(int));
    
            var iActionFlagParameter = iActionFlag.HasValue ?
                new ObjectParameter("iActionFlag", iActionFlag) :
                new ObjectParameter("iActionFlag", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("dt_checkoutobject_u", chObjectTypeParameter, vchObjectNameParameter, vchCommentParameter, vchLoginNameParameter, vchPasswordParameter, iVCSFlagsParameter, iActionFlagParameter);
        }
    
        public virtual int dt_displayoaerror(Nullable<int> iObject, Nullable<int> iresult)
        {
            var iObjectParameter = iObject.HasValue ?
                new ObjectParameter("iObject", iObject) :
                new ObjectParameter("iObject", typeof(int));
    
            var iresultParameter = iresult.HasValue ?
                new ObjectParameter("iresult", iresult) :
                new ObjectParameter("iresult", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("dt_displayoaerror", iObjectParameter, iresultParameter);
        }
    
        public virtual int dt_displayoaerror_u(Nullable<int> iObject, Nullable<int> iresult)
        {
            var iObjectParameter = iObject.HasValue ?
                new ObjectParameter("iObject", iObject) :
                new ObjectParameter("iObject", typeof(int));
    
            var iresultParameter = iresult.HasValue ?
                new ObjectParameter("iresult", iresult) :
                new ObjectParameter("iresult", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("dt_displayoaerror_u", iObjectParameter, iresultParameter);
        }
    
        public virtual int dt_droppropertiesbyid(Nullable<int> id, string property)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            var propertyParameter = property != null ?
                new ObjectParameter("property", property) :
                new ObjectParameter("property", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("dt_droppropertiesbyid", idParameter, propertyParameter);
        }
    
        public virtual int dt_dropuserobjectbyid(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("dt_dropuserobjectbyid", idParameter);
        }
    
        public virtual int dt_generateansiname(ObjectParameter name)
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("dt_generateansiname", name);
        }
    
        public virtual ObjectResult<Nullable<int>> dt_getobjwithprop(string property, string value)
        {
            var propertyParameter = property != null ?
                new ObjectParameter("property", property) :
                new ObjectParameter("property", typeof(string));
    
            var valueParameter = value != null ?
                new ObjectParameter("value", value) :
                new ObjectParameter("value", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("dt_getobjwithprop", propertyParameter, valueParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> dt_getobjwithprop_u(string property, string uvalue)
        {
            var propertyParameter = property != null ?
                new ObjectParameter("property", property) :
                new ObjectParameter("property", typeof(string));
    
            var uvalueParameter = uvalue != null ?
                new ObjectParameter("uvalue", uvalue) :
                new ObjectParameter("uvalue", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("dt_getobjwithprop_u", propertyParameter, uvalueParameter);
        }
    
        public virtual ObjectResult<dt_getpropertiesbyid_Result> dt_getpropertiesbyid(Nullable<int> id, string property)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            var propertyParameter = property != null ?
                new ObjectParameter("property", property) :
                new ObjectParameter("property", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<dt_getpropertiesbyid_Result>("dt_getpropertiesbyid", idParameter, propertyParameter);
        }
    
        public virtual ObjectResult<dt_getpropertiesbyid_u_Result> dt_getpropertiesbyid_u(Nullable<int> id, string property)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            var propertyParameter = property != null ?
                new ObjectParameter("property", property) :
                new ObjectParameter("property", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<dt_getpropertiesbyid_u_Result>("dt_getpropertiesbyid_u", idParameter, propertyParameter);
        }
    
        public virtual int dt_getpropertiesbyid_vcs(Nullable<int> id, string property, ObjectParameter value)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            var propertyParameter = property != null ?
                new ObjectParameter("property", property) :
                new ObjectParameter("property", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("dt_getpropertiesbyid_vcs", idParameter, propertyParameter, value);
        }
    
        public virtual int dt_getpropertiesbyid_vcs_u(Nullable<int> id, string property, ObjectParameter value)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            var propertyParameter = property != null ?
                new ObjectParameter("property", property) :
                new ObjectParameter("property", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("dt_getpropertiesbyid_vcs_u", idParameter, propertyParameter, value);
        }
    
        public virtual int dt_isundersourcecontrol(string vchLoginName, string vchPassword, Nullable<int> iWhoToo)
        {
            var vchLoginNameParameter = vchLoginName != null ?
                new ObjectParameter("vchLoginName", vchLoginName) :
                new ObjectParameter("vchLoginName", typeof(string));
    
            var vchPasswordParameter = vchPassword != null ?
                new ObjectParameter("vchPassword", vchPassword) :
                new ObjectParameter("vchPassword", typeof(string));
    
            var iWhoTooParameter = iWhoToo.HasValue ?
                new ObjectParameter("iWhoToo", iWhoToo) :
                new ObjectParameter("iWhoToo", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("dt_isundersourcecontrol", vchLoginNameParameter, vchPasswordParameter, iWhoTooParameter);
        }
    
        public virtual int dt_isundersourcecontrol_u(string vchLoginName, string vchPassword, Nullable<int> iWhoToo)
        {
            var vchLoginNameParameter = vchLoginName != null ?
                new ObjectParameter("vchLoginName", vchLoginName) :
                new ObjectParameter("vchLoginName", typeof(string));
    
            var vchPasswordParameter = vchPassword != null ?
                new ObjectParameter("vchPassword", vchPassword) :
                new ObjectParameter("vchPassword", typeof(string));
    
            var iWhoTooParameter = iWhoToo.HasValue ?
                new ObjectParameter("iWhoToo", iWhoToo) :
                new ObjectParameter("iWhoToo", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("dt_isundersourcecontrol_u", vchLoginNameParameter, vchPasswordParameter, iWhoTooParameter);
        }
    
        public virtual int dt_removefromsourcecontrol()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("dt_removefromsourcecontrol");
        }
    
        public virtual int dt_setpropertybyid(Nullable<int> id, string property, string value, byte[] lvalue)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            var propertyParameter = property != null ?
                new ObjectParameter("property", property) :
                new ObjectParameter("property", typeof(string));
    
            var valueParameter = value != null ?
                new ObjectParameter("value", value) :
                new ObjectParameter("value", typeof(string));
    
            var lvalueParameter = lvalue != null ?
                new ObjectParameter("lvalue", lvalue) :
                new ObjectParameter("lvalue", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("dt_setpropertybyid", idParameter, propertyParameter, valueParameter, lvalueParameter);
        }
    
        public virtual int dt_setpropertybyid_u(Nullable<int> id, string property, string uvalue, byte[] lvalue)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            var propertyParameter = property != null ?
                new ObjectParameter("property", property) :
                new ObjectParameter("property", typeof(string));
    
            var uvalueParameter = uvalue != null ?
                new ObjectParameter("uvalue", uvalue) :
                new ObjectParameter("uvalue", typeof(string));
    
            var lvalueParameter = lvalue != null ?
                new ObjectParameter("lvalue", lvalue) :
                new ObjectParameter("lvalue", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("dt_setpropertybyid_u", idParameter, propertyParameter, uvalueParameter, lvalueParameter);
        }
    
        public virtual int dt_validateloginparams(string vchLoginName, string vchPassword)
        {
            var vchLoginNameParameter = vchLoginName != null ?
                new ObjectParameter("vchLoginName", vchLoginName) :
                new ObjectParameter("vchLoginName", typeof(string));
    
            var vchPasswordParameter = vchPassword != null ?
                new ObjectParameter("vchPassword", vchPassword) :
                new ObjectParameter("vchPassword", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("dt_validateloginparams", vchLoginNameParameter, vchPasswordParameter);
        }
    
        public virtual int dt_validateloginparams_u(string vchLoginName, string vchPassword)
        {
            var vchLoginNameParameter = vchLoginName != null ?
                new ObjectParameter("vchLoginName", vchLoginName) :
                new ObjectParameter("vchLoginName", typeof(string));
    
            var vchPasswordParameter = vchPassword != null ?
                new ObjectParameter("vchPassword", vchPassword) :
                new ObjectParameter("vchPassword", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("dt_validateloginparams_u", vchLoginNameParameter, vchPasswordParameter);
        }
    
        public virtual int dt_vcsenabled()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("dt_vcsenabled");
        }
    
        public virtual ObjectResult<Nullable<int>> dt_verstamp006()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("dt_verstamp006");
        }
    
        public virtual int dt_whocheckedout(string chObjectType, string vchObjectName, string vchLoginName, string vchPassword)
        {
            var chObjectTypeParameter = chObjectType != null ?
                new ObjectParameter("chObjectType", chObjectType) :
                new ObjectParameter("chObjectType", typeof(string));
    
            var vchObjectNameParameter = vchObjectName != null ?
                new ObjectParameter("vchObjectName", vchObjectName) :
                new ObjectParameter("vchObjectName", typeof(string));
    
            var vchLoginNameParameter = vchLoginName != null ?
                new ObjectParameter("vchLoginName", vchLoginName) :
                new ObjectParameter("vchLoginName", typeof(string));
    
            var vchPasswordParameter = vchPassword != null ?
                new ObjectParameter("vchPassword", vchPassword) :
                new ObjectParameter("vchPassword", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("dt_whocheckedout", chObjectTypeParameter, vchObjectNameParameter, vchLoginNameParameter, vchPasswordParameter);
        }
    
        public virtual int dt_whocheckedout_u(string chObjectType, string vchObjectName, string vchLoginName, string vchPassword)
        {
            var chObjectTypeParameter = chObjectType != null ?
                new ObjectParameter("chObjectType", chObjectType) :
                new ObjectParameter("chObjectType", typeof(string));
    
            var vchObjectNameParameter = vchObjectName != null ?
                new ObjectParameter("vchObjectName", vchObjectName) :
                new ObjectParameter("vchObjectName", typeof(string));
    
            var vchLoginNameParameter = vchLoginName != null ?
                new ObjectParameter("vchLoginName", vchLoginName) :
                new ObjectParameter("vchLoginName", typeof(string));
    
            var vchPasswordParameter = vchPassword != null ?
                new ObjectParameter("vchPassword", vchPassword) :
                new ObjectParameter("vchPassword", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("dt_whocheckedout_u", chObjectTypeParameter, vchObjectNameParameter, vchLoginNameParameter, vchPasswordParameter);
        }
    
        public virtual ObjectResult<spJobCount_Result> spJobCount()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spJobCount_Result>("spJobCount");
        }
    
        public virtual ObjectResult<spKPII_Result> spKPII()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spKPII_Result>("spKPII");
        }
    
        public virtual ObjectResult<Nullable<int>> spGetIncrementValue(string branchName, ObjectParameter value)
        {
            var branchNameParameter = branchName != null ?
                new ObjectParameter("BranchName", branchName) :
                new ObjectParameter("BranchName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("spGetIncrementValue", branchNameParameter, value);
        }
    }
}
