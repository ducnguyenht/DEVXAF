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
}
