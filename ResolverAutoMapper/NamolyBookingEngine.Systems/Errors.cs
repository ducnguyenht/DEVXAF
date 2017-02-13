using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NamolyBookingEngine.Systems
{
    public static class ErrorCodes
    {
        // simple error code lookup method

        public static string Find(ErrorCode errorCode, Language language)
        {
            // See http://go.microsoft.com/fwlink/?LinkID=177550 for
            // a full list of status codes.
            string errorMessage;
            switch (errorCode)
            {
                #region ERROR_SUCCESS
                case ErrorCode.ERROR_SUCCESS:
                    {
                        if (language == Language.VN)
                            errorMessage = @"Thành công";
                        else
                            errorMessage = @"Success";
                        break;
                    };
                #endregion ERROR_SUCCESS
                #region ERROR_ALREADY_EXISTS
                case ErrorCode.ERROR_ALREADY_EXISTS:
                    {
                        if (language == Language.VN)
                            errorMessage = @"Dữ liệu đã tồn tại trong hệ thống";
                        else
                            errorMessage = @"Cannot create a data when that data already exists";
                        break;
                    };
                #endregion ERROR_ALREADY_EXISTS
                #region ERROR_NOT_FOUND
                case ErrorCode.ERROR_NOT_FOUND:
                    {
                        if (language == Language.VN)
                            errorMessage = @"Không tìm thấy dữ liệu";
                        else
                            errorMessage = @"Element not found";
                        break;
                    };
                #endregion ERROR_NOT_FOUND

                default:
                    {
                        errorMessage = "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
                        break;
                    }
            }
            return errorMessage;
        }

    }
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
}
