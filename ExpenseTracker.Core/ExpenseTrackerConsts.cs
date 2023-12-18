namespace ExpenseTracker
{
    public class ExpenseTrackerConsts
    {
        public const string LocalizationSourceName = "ExpenseTracker";

        public const bool MultiTenancyEnabled = true;
        
        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public const string DefaultPassPhrase = "8a2cdd9c13744a85be7058ae53c212ae";
    }
}