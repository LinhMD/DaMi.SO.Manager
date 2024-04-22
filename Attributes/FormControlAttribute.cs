namespace DaMi.SO.Manager.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class FormControlAttribute(FormControlType type) : Attribute
    {
        public FormControlType Type { get; private set; } = type;
    }
    public enum FormControlType
    {
        Text,
        Textarea
    }
}
