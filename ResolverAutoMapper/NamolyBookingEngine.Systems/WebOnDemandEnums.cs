using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NamolyBookingEngine.Systems
{
    public enum Website
    {
        NA = 0,
        /// <summary>
        /// Website GalinaHotel.com
        /// </summary>
        GALINAHOTELCOM = 1
    }
    public enum WebpageComponent
    {
        NA = 0,
        #region GALINAHOTELCOM Homepage 
        /// <summary>
        /// From 100..200
        /// </summary>
        HOME_BANNER = 100,
        /// <summary>
        /// Tiện nghi-Sang trọng - Thư giãn - Âm áp
        /// </summary>
        HOME_ACCOMODATION_ADVERTISEMENT = 101
        #endregion GALINAHOTELCOM Homepage 

    }

}
