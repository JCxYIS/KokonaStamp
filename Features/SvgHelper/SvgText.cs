namespace jcxyis_website_v4.Features.SvgHelper
{
    public class SvgText : SvgContentBase
    {
        public string text = "Hello World";

        public override string ToString()
        {
            return $"<text {baseAttribute}><tspan>{text}</tspan></text>";
        }
    }
}
