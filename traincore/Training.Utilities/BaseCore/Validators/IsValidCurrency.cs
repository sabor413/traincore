using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sitecore.Data.Validators;
using System.Runtime.Serialization;
using Generic.SitecoreUtilities.Configuration;
using Generic.SitecoreUtilities.Fields;
using Training.Utilities.BaseCore.References;
using Sitecore.Data;
using Sitecore.Data.Items;

namespace Training.Utilities.BaseCore.Validators
{
    /// <summary>
    /// This is a custom validator to check that the string entered is a currency with two
    /// decimal places.
    /// 
    /// Based on: http://roadha.us/2010/10/currency-validator-for-sitecore-cms/
    /// Another example of a custom validator: https://briancaos.wordpress.com/2011/05/16/sitecore-validators-validating-image-width-height-and-aspect-ratio/
    /// Suppressing validation rules with base template: http://blog.velir.com/index.php/2012/11/12/suppress-validation-rules-with-base-templates/
    /// </summary>
    [Serializable]
    public class IsValidCurrency : StandardValidator
    {
        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        public IsValidCurrency(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public IsValidCurrency() { }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        public override string Name
        {
            get { return "Is Valid Currency"; }
        }

        /// <summary>
        /// Determines whether the output is valid.
        /// </summary>
        /// <returns></returns>
        protected override ValidatorResult Evaluate()
        {
            string controlValidationValue = base.ControlValidationValue;

            decimal decimalValue;

            if (decimal.TryParse(controlValidationValue, out decimalValue))
            {
                if (decimalValue >= 0)
                {
                    if (decimalValue.Equals(Math.Round(decimalValue, 2)))
                    {
                        return ValidatorResult.Valid;
                    }
                }
            }

            Database master = Sitecore.Configuration.Factory.GetDatabase("master");

            Item messageItem = master.GetItem(MessageReferences.MessageInvalidCurrencyItem);

            base.Text = FieldUtils.GetFieldValue(messageItem, References.Keys.SimpleTextFieldName);

            return GetMaxValidatorResult();
        }

        /// <summary>
        /// The most severe validation result this validator can return.
        /// </summary>
        /// <returns></returns>
        protected override ValidatorResult GetMaxValidatorResult()
        {
            return base.GetFailedResult(ValidatorResult.CriticalError);
        }
    }
}
