namespace jcxyis_website_v4.Features.SvgHelper
{
    public class Svg
    {
        protected float _width = 600;
        protected float _height = 400;
        protected string _id = "jc_cool_svg";
        public List<SvgContentBase> elements = new List<SvgContentBase>();
        
        public Svg()
        {

        }
        public Svg(float w, float h)
        {
            _width = w;
            _height = h;
        }
        public Svg(float w, float h, string id)
        {
            _width = w;
            _height = h;
            _id = id;
        }


        public override string ToString()
        {
            string result = $"<svg xmlns=\"http://www.w3.org/2000/svg\" xmlns:xlink=\"http://www.w3.org/1999/xlink\" id=\"{_id}\" width=\"{_width}\" height=\"{_height}\" viewBox=\"0 0 {_width} {_height}\">\n";
            elements.ForEach(c => result += $"{c}\n");
            result += "</svg>";
            return result;
        }
    }
}
