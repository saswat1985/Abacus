using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataObject
{
    public partial class ClsVALBase
    {
        public string Type { get; set; }
    }

    public partial class MstPinPlanType
    {
        public const string SPName = "USP_MstPinPlanType";
        public string Type { get; set; }
    }

    public partial class tblMstUserMaster
    {
        public const string SPName = "chkLogin";
        public const string SPName1 = "USP_MemberMaster";
        public string Type { get; set; }                
        public int RoleId { get; set; }
        public int OutRes { get; set; }
        public string UserCulture { get; set; }
    }

    public partial class MstMenuMaster
    {
        public const string SPName = "uspMenuMaster";
        public string Type { get; set; }
    }

    public partial class MstPinGenerateMaster
    {
        public const string SPName = "USP_GeneratePins";
        public const string SPName1 = "USP_GeneratePinForPlan";
        public const string SPReport = "USP_PINGenerateReport";
        public int RequestedMemberId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string Type { get; set; }
        public int ResponseId { get; set; }
    }

    public partial class MstMember
    {
        public const string SPName = "USP_MemberMaster";
        public const string SPMemberDetail = "USP_GetMemberDetail";
        public const string SPNameSearch = "USP_UserSearch";
        public string Type { get; set; }
        public string UserCode { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string Email { get; set; }
    }

    public partial class tblUserTreeStructure
    {
        public const string SPName = "USP_CreateUserTree";
        public const string SPFindMember = "USP_UserInTree";
        public string Type { get; set; }
        public string LUser { get; set; }
        public string RUser { get; set; }
    }

    public partial class tblPayoutMaster
    {
        public const string SPName = "USP_GeneratePayOut";
        public const string SPNameHistory = "USP_GeneratePayoutHistory";
    }

    public partial class tblPinRequest
    {
        public const string SPName = "USP_PINRequestResponse";
        public string Type { get; set; }
    }

    public partial class tblPinResponse
    {
        public const string SPName = "USP_PINRequestResponse";
        public string Type { get; set; }
    }

    public partial class tblRoyaltyClub
    {
        public const string SPName = "USP_RoyaltyClub";
        public const string SPNameUserRoyalty = "USP_UserRoyaltyClub";
        public int CompanyLevel { get; set; }
        public int UserJoiningLevel { get; set; }
        public int ParentId { get; set; }

        public string Type { get; set; }
    }

    public partial class DashBoardProperty
    {
        public const string SP_Name = "USP_DashboardData";

        public int UserId { get; set; }

        public string UserCode { get; set; }

        public string UserName { get; set; }

        public DateTime? UserEntryDate { get; set; }

        public string Email { get; set; }

        public string PhoneNo { get; set; }

        public string SponcerCode { get; set; }

        public string ParentCode { get; set; }

        public int LJoining { get; set; }

        public int RJoining { get; set; }

        public int TotalRefral { get; set; }

        public decimal? PayAmt { get; set; }

        public int TotalPin { get; set; }

        public int UsedPin { get; set; }

        public int UnusedPin { get; set; }

        public decimal WalletBalance { get; set; }

    }

    public partial class tblPinTransfer
    {
        public const string SP_Name = "USP_UserPinTransfer";

        public string Type { get; set; }

    }

    public partial class SMSPinProperty
    {
        public string TransferAccount { get; set; }

        public int PinCount { get; set; }

        public DateTime TransectionDate { get; set; }

        public string TransectionCode { get; set; }

        public string TransfreeAccount { get; set; }

        public string TransferAccountMobNo { get; set; }

    }

    public partial class tblTransCode
    {
        public const string SP_Name = "USP_GenerateTransCode";
    }

    public partial class tblUserWalletCreditAmt
    {
        public string Type { get; set; }
    }

    public partial class tblJournalLedger
    {
        public const string SP_Name = "USP_JournalLedgerEntry";
        public string Type { get; set; }
        public int? UserId { get; set; }
    }

    public partial class tblUserWalletCreditAmt
    {
        public decimal WalletBalance { get; set; }
    }
}
