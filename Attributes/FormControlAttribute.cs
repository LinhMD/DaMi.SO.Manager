namespace DaMi.SO.Manager.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class FormControlAttribute : Attribute
    {
        public FormControlAttribute(FormControlType type)
        {
            Type = type;
        }

        public FormControlType Type { get; private set; }
    }
    public enum FormControlType
    {
        Text,
        Textarea
    }
}
