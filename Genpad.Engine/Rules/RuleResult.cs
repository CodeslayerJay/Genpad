using Genpad.Engine.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Genpad.Engine.Rules
{
    public class RuleResult : CommandResult
    {

               
        public void AddError(string propertyName, string errorMsg)
        {
            if (String.IsNullOrEmpty(propertyName)) throw new ArgumentNullException(nameof(propertyName));
            if (String.IsNullOrEmpty(errorMsg)) throw new ArgumentNullException(nameof(errorMsg));

            base.AddError(new RuleResultErrorModel { PropertyName = propertyName, ErrorMsg = errorMsg });
        }

    }

    public class RuleResultErrorModel : CommandResultErrorModel
    {
        public string PropertyName { get; set; }
    }
}
