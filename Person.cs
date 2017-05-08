using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpTipsAndTricksLunchLearn
{ 
    public class Person
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool IsActive { get; set; } = true;

        public string FullName
        {
            get
            {
                return $"{this.FirstName} {this.LastName}";
            }
        }

        public DateTimeOffset CreateDateTime { get; set; } = DateTimeOffset.Now;

        public ICollection<string> Nicknames
        {
            get
            {
                return _nickNames ?? (_nickNames = new List<string>());
                //if (_nickNames == null)
                //{
                //    _nickNames = new List<string>();
                //}

                //return _nickNames;

                
            }
        }
        private ICollection<string> _nickNames;
    }

}
