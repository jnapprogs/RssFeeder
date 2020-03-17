namespace RssFeeder.Models
{
    public class ModelValidationError
    {
        public string Key { get; set; }
        public string Value { get; set; }

        public ModelValidationError(string key, string value)
        {
            Key = key;
            Value = value;
        }
    }
}
