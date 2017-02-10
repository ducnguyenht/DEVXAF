using System;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections.Generic;
using AutoMapper;

namespace NamolyNomenclature.Domain
{
    // Generated 02/09/2017 20:08:37

    // Add custom code inside partial class

    public partial class Hotels : BusinessEntities
    {
        public Hotels()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<BusinessEntity, Hotel>();
            });
        }
        #region Filter SQL
        private const string IsHotelFilter = "IsHotel = 'true'";

        #endregion Filter SQL

        #region Overrides
        public new Hotel Single(int? id)
        {
            var businessEntity_FDB = base.Single(id);
            if (businessEntity_FDB != null)
            {
                var mapper = Mapper.Map<Hotel>(businessEntity_FDB);
                mapper.ReadFromDB();
                return mapper;
            }
            return null;
        }
        public new Hotel Single(string where = null, params object[] parms)
        {
            if (where != null)
            {
                where += " and " + IsHotelFilter;
            }
            else
            {
                where += IsHotelFilter;
            }
            var businessEntity_FDB = base.Single(where, parms);
            if (businessEntity_FDB != null)
            {
                var hotelMapper = Mapper.Map<Hotel>(businessEntity_FDB);
                hotelMapper.ReadFromDB();
                return hotelMapper;
            }
            return null;
        }
        public new IEnumerable<Hotel> All(string where = null, string orderBy = null, int top = 0, params object[] parms)
        {

            if (where != null)
            {
                where += " and " + IsHotelFilter;
            }
            else
            {
                where += IsHotelFilter;
            }
            var lstHotelFDB = base.All(where, orderBy, top, parms);
            var lstHotel = new List<Hotel>();
            foreach (var hFDB in lstHotelFDB)
            {
                var h = Mapper.Map<Hotel>(hFDB);
                h.ReadFromDB();
                lstHotel.Add(h);
            }
            return lstHotel;
        }
        #endregion Overrides
    }
}
