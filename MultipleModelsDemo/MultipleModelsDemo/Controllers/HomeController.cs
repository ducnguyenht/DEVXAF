using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using MultipleModelsDemo.ViewModels;

namespace MultipleModelsDemo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = new IndexViewModel();
            model.HeaderText = "Strongly typed model used here, no view bag";
            return View(model);
        }

        public ActionResult MyEditActionOne(IndexViewModel model)
        {
            if (ModelState.IsValid)
            {
                //var config = new MapperConfiguration(
                //    cfg => {
                //        cfg.CreateMap<TestOneModel, TestTwoModel>()
                //            .ForMember(dst => dst.PropertyFour, opt => opt.MapFrom(src => src.PropertyTwo))
                //            .ForMember(dst => dst.PropertyThree, opt => opt.MapFrom(src => src.PropertyOne)).ReverseMap();
                //    });
                //config.CreateMapper();
                //var mapper = new Mapper(config);
                //var dto = mapper.Map<OrderDto>(order);
                // or
                //MapperConfiguration MapperConfiguration = new MapperConfiguration(cfg => {
                //    cfg.CreateMap<TestOneModel, TestTwoModel>()
                //        .ForMember(dst => dst.PropertyFour, opt => opt.MapFrom(src => src.PropertyTwo))
                //        .ForMember(dst => dst.PropertyThree, opt => opt.MapFrom(src => src.PropertyOne)).ReverseMap();
                //});

                //AutoMapper.Mapper.Initialize(config =>
                //{
                //    config.CreateMap<TestOneModel, TestTwoModel>()
                //        .ForMember(dst => dst.PropertyFour, opt => opt.MapFrom(src => src.PropertyTwo))
                //        .ForMember(dst => dst.PropertyThree, opt => opt.MapFrom(src => src.PropertyOne)).ReverseMap();
                //    config.CreateMap<TestTwoModel, TestOneModel>()
                //        .ForMember(src => src.PropertyTwo, opt => opt.MapFrom(dst => dst.PropertyFour))
                //        .ForMember(src => src.PropertyOne, opt => opt.MapFrom(dst => dst.PropertyThree)).ReverseMap();
                //});

                // Mapper.CreateMap<TestOneModel, TestTwoModel>()
                //.ForMember(dst => dst.PropertyFour, opt => opt.MapFrom(src => src.PropertyTwo))
                //.ForMember(dst => dst.PropertyThree, opt => opt.MapFrom(src => src.PropertyOne))
                //.ReverseMapWithForMemberPreserved41();
                //if source+dest types are not both reference or both value need to map it explicity
                //.ForMember(dst => dst.Age, opt => opt.MapFrom(src => src.YearsOld));

                //var Mapper = MapperConfiguration.CreateMapper());

                #region 4.2 and above
                //4.2 approach
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<TestOneModel, TestTwoModel>()
                    .ForMember(dst => dst.PropertyFour, opt => opt.MapFrom(src => src.PropertyTwo))
                    .ForMember(dst => dst.PropertyThree, opt => opt.MapFrom(src => src.PropertyOne))
                    .ReverseMapWithForMemberPreserved(cfg);
                    //if source+dest types are not both reference or both value need to map it
                    //.ForMember(dst => dst.Age, opt => opt.MapFrom(src => src.YearsOld));

                    //cfg.CreateMap<TeamViewModel, TeamDTO>()
                    //.ForMember(dst => dst.TeamName, opt => opt.MapFrom(src => src.Name))
                    //.ForMember(dst => dst.CoachFullName, opt => opt.MapFrom(src => src.ManagerFullName))
                    //.ForMember(dst => dst.RegisteredPlayers, opt => opt.MapFrom(src => src.Players)) //must explicity name on reverse
                    //.ForMember(dst => dst.PlayingInEuropeThisSeason, opt => opt.MapFrom(src => src.InEuropeThisSeason))
                    //.ReverseMapWithForMemberPreserved(cfg)
                    //    //if your collection names differ and if you don't explicitly map in reverse AssertConfigurationIsValid() will fail
                    //    .ForMember(rdst => rdst.Players, opt => opt.MapFrom(rsrc => rsrc.RegisteredPlayers));
                });

                config.AssertConfigurationIsValid();

                var mapper = config.CreateMapper();
                var dto = mapper.Map<TestTwoModel>(model.TestOne);
                var dt01 = mapper.Map<TestOneModel>(dto);
                #endregion


                //var dto = Mapper.Map<TestTwoModel>(model.TestOne);
                //var dt01 = Mapper.Map<TestOneModel>(dto);
                return View("Index", model);
            }

            throw new Exception("My Model state is not valid");
        }
    }
}
