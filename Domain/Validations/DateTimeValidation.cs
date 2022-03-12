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

            if (value != null && DateTime.TryParse(value.ToString(), out outDate))
                return true;
            else
                return false;
        }
    }
}
