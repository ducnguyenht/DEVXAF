using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NASDMS.Systems
{
    /// <summary>
    /// Dựa vào mã lỗi của winerror.h
    /// Tham khảo:
    /// https://msdn.microsoft.com/en-us/library/windows/desktop/ms681381(v=vs.85).aspx
    /// https://www.rpi.edu/dept/cis/software/g77-mingw32/include/winerror.h
    /// http://www.pinvoke.net/default.aspx/Constants/WINERROR.html
    /// 
    /// Đối với HTTP thì sử dụng https://msdn.microsoft.com/en-us/library/system.net.httpstatuscode(v=vs.110).aspx
    /// Đối với Web.Security thì sử dụng https://msdn.microsoft.com/en-us/library/system.web.security.membershipcreatestatus(v=vs.110).aspx
    /// </summary>
    public enum ErrorCode
    {
        ERROR_SUCCESS = 0,
        ERROR_ALREADY_EXISTS = 183,
        ERROR_NOT_FOUND = 1168
    }
    #region AuditTrail
    public enum CategoryAudit
    {
        NA = 0,
        #region Tài chính kế toán
        /// <summary>
        ///  Nhập kho mua hàng,
        /// </summary>
        StockInFromFactory = 1,

        /// <summary>
        /// Mua hàng không qua kho 
        /// </summary>
        OperationalServicePurchaseOrder = 2,

        /// <summary>
        /// Đơn hàng tổng hợp
        /// </summary>
        SalesOrderAllChannel = 3,

        /// <summary>
        /// Điều chỉnh kho
        /// </summary>
        OperationalInventoryAdjustment = 4,

        /// <summary>
        /// Chuyển kho nội bộ
        /// </summary>
        OperationalMovement = 5,

        /// <summary>
        /// Xuất kho bán hàng
        /// </summary>
        OperationalShipment,

        /// <summary>
        /// Nhập kho hàng trả hàng
        /// </summary>
        OperationalReturnFromCustomer,

        //Nhập kho FMCG từ nhà máy

        /// <summary>
        /// Xuất kho trả hàng nhà máy
        /// </summary>
        ReturnToFactory,

        /// <summary>
        /// Yêu cầu đặt hàng nhà máy
        /// </summary>
        OperationalPOReceiptRequest,
        /// <summary>
        /// Điều chỉnh kho NPP
        /// </summary>
        OperationalDistributorInventoryAdjustment,

        /// <summary>
        /// Hạch toán tổng hợp
        /// </summary>
        ManagementGeneralEntry,
        /// <summary>
        /// Thẻ phân bổ CCDC
        /// </summary>
        ExpensesAllocationCard,
        /// <summary>
        /// Chứng từ phân bổ
        /// </summary>
        ManagementToolsAndSuppliesExpensesAllocationVoucher,
        /// <summary>
        /// Chi phí trả trước
        /// </summary>
        ManagementPrepaidExpensesAllocationCard,
        /// <summary>
        /// Chứng từ phân bổ chi phí trả trước
        /// </summary>
        ManagementPrepaidExpensesAllocationVoucher,

        /// <summary>
        /// Tài sản cố định(Tài sản cố định)
        /// </summary>
        FixedAssetItem,

        /// <summary>
        /// Mẫu chứng từ ghi giảm(Tài sản cố định)
        /// </summary>
        ManagementFixedAssetsDecreaseVoucherTemplate,

        /// <summary>
        /// Chứng từ khấu hao(Tài sản cố định)
        /// </summary>
        DepreciationVoucher,

        /// <summary>
        /// Mẫu kết chuyển(Kết chuyển)
        /// </summary>
        ClosingEntryTemplate,
        /// <summary>
        /// Công cụ kết chuyển(Kết chuyển)
        /// </summary>
        ManagementClosingEntryExecute,

        /// <summary>
        /// Bút toán kết chuyển(Kết chuyển)
        /// </summary>
        ManagementClosingEntry,

        /// <summary>
        /// Ủy nhiệm thu
        /// </summary>
        ReceiptByBank,

        /// <summary>
        /// Ủy nhiệm
        /// </summary>
        ReceiptByCash,

        /// <summary>
        /// Ủy nhiệm
        /// </summary>
        PaymentByCash,

        /// <summary>
        /// Ủy nhiệm
        /// </summary>
        PaymentByBank,

        /// <summary>
        /// Đề nghị
        /// </summary>
        CashAdvanceRequest,



        /// <summary>
        /// Định khoản
        /// </summary>
        ReceiptByBankBookingEntry,

        /// <summary>
        /// Định khoản
        /// </summary>
        PaymentByBankBookingEntry,

        /// <summary>
        /// Định khoản
        /// </summary>
        ReceiptByCashBookingEntry,

        /// <summary>
        /// Hóa đơn GTGT dau ra
        /// </summary>
        OutputVATInvoice,
        /// <summary>
        /// Hóa đơn GTGT dau vao
        /// </summary>
        InputVATInvoice,
        /// <summary>
        /// The account period:chu ky ke toan
        /// </summary>
        AccountPeriod,
        DomainObject1,
        #endregion Tài chính kế toán

    }
    public enum ActionAudit
    {
        NA = 0,
        /// <summary>
        /// The created
        /// </summary>
        Created = 1,
        /// <summary>
        /// The updated
        /// </summary>
        Updated = 2,
        /// <summary>
        /// The deleted
        /// </summary>
        Deleted = 3,
        /// <summary>
        /// The login sucess
        /// </summary>
        LoginSucess = 4,
        /// <summary>
        /// The login false
        /// </summary>
        LoginFalse = 5
    }
    #endregion
}
