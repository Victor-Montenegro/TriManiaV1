using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Validations
{
    public class DateTimeValidation : DataTypeAttribute
    {
        public DateTimeValidation(DataType dataType) : base(dataType)
        {
        }

        public override bool IsValid(object value)
        {
            DateTime outDate;

            if (value != null && DateTime.TryParse(value.ToString(), out outDate) && DateTime.Parse(value.ToString()).Year >= 1900)
                return true;
            else
                return false;
        }
    }
}
