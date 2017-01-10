using System.ComponentModel.DataAnnotations;

namespace MultipleModelsDemo.ViewModels
{
    public class IndexViewModel
    {
        public string HeaderText { get; set; }

        public TestOneModel TestOne { get; set; }

        public TestTwoModel TestTwo { get; set; }
    }

    public class TestOneModel {
        public string Test {
            get;
            set;
        }    
        [Required]
        public string PropertyOne {
            get;
            set;
        }

        [Required]
        public string PropertyTwo {
            get;
            set;
        }
    }
    public class TestTwoModel {
        public string Test {
            get;
            set;
        }
        [Required]
        public string PropertyThree {
            get;
            set;
        }

        [Required]
        public string PropertyFour {
            get;
            set;
        }
    }
}