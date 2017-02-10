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

    public partial class Restaurants : BusinessEntities
    {
        public Restaurants()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<BusinessEntity, Restaurant>();
            });
        }
        #region Filter SQL
        private const string IsRestaurantFilter = "IsRestaurant = 'true'";

        #endregion Filter SQL


        public new Restaurant Single(string where = null, params object[] parms)
        {
            if (where != null)
            {
                where += " and " + IsRestaurantFilter;
            }
            else
            {
                where += IsRestaurantFilter;
            }
            var businessEntity_FDB = base.Single(where, parms);
            if (businessEntity_FDB != null)
            {
                var mapper = Mapper.Map<Restaurant>(businessEntity_FDB);
                mapper.ReadFromDB();
                return mapper;
            }
            return null;
        }
        public new IEnumerable<Restaurant> All(string where = null, string orderBy = null, int top = 0, params object[] parms)
        {

            if (where != null)
            {
                where += " and " + IsRestaurantFilter;
            }
            else
            {
                where += IsRestaurantFilter;
            }
            var lstRestaurantFDB = base.All(where, orderBy, top, parms);
            var lstRestaurant = new List<Restaurant>();
            foreach (var item in lstRestaurantFDB)
            {
                var obj = Mapper.Map<Restaurant>(item);
                obj.ReadFromDB();
                lstRestaurant.Add(obj);
            }
            return lstRestaurant;
        }

    }
}
