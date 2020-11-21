using FriendOrganizer.Model;
using System;
using System.Collections.Generic;

namespace FriendOrganizer.UI.Wrapper
{
    //Class that wraps around the Friend model class and has same properties for error handling
    public class FriendWrapper : ModelWrapper<Friend>
    {
        public FriendWrapper(Friend model) : base(model)
        {

        }

        public int Id { get { return Model.Id; } }

        public string FirstName
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        public string LastName
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        public string Email
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        public int? FavoriteLanguageId
        {
            get { return GetValue<int?>(); }
            set { SetValue(value); }
        }

        //changes firstname textbox red if name is "Robot"
        protected override IEnumerable<string> ValidateProperty(string propertyName)
        {
            switch (propertyName)
            {
                case nameof(FirstName):
                    if (string.Equals(FirstName, "Robot", StringComparison.OrdinalIgnoreCase))
                    {
                        yield return "Robots are not vaild friends";
                    }
                    break;
            }
        }
        }
}
