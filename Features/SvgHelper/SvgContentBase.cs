namespace jcxyis_website_v4.Features.SvgHelper
{
    public class SvgContentBase
    {
        public float x = 0;
        public float y = 0;
        public float? width = null;
        public float? height = null;

        /// <summary>
        /// CSS styles
        /// </summary>
        public string? style = null;

        
        protected string baseAttribute
        {
            get
            {
                string result = $" x=\"{x}\" y=\"{y}\" ";
                if (width != null)
                {
                    result += $" width=\"{width}\" ";
                }
                if (height != null)
                {
                    result += $" height=\"{height}\" ";
                }
                if (style != null)
                {
                    result += $" style=\"{style}\"";
                }
                return result;
            }
        }
    }
}
