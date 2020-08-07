using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PragimTech.Components
{
    public class CustomInputSelect<TValue> : InputSelect<TValue> //If our custom input select component is bound
    {
        protected override bool TryParseValueFromString(string value, out TValue result, out string validationErrorMessage)
        {
            if (typeof(TValue) == typeof(int))//to an integer datatype we want to try and parse the incoming value to integer 
            {
                if(int.TryParse(value, out var resultInt))// We are using  int dot tryparse and if the parsing is successful we are setting validation error massage to null
                {
                    result = (TValue)(object)resultInt;
                    validationErrorMessage = null;
                    return true;// and return true 
                }
                else
                {
                    result = default;
                    validationErrorMessage = $"The selected value {value} in not a valid number.";
                    return false;
                }
            }
            else
            {
                return base.TryParseValueFromString(value, out result, out validationErrorMessage);
            }
           
        }
    }
}
