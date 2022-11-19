namespace jcxyis_website_v4.Features.SvgHelper
{
    public class SvgStyle : SvgContentBase
    {
        public string css = "text { "+
            "font-family: monospace; font-size: 30px; /*text-anchor: middle;*/ " +
            "fill: #ffffff; stroke: #000000; stroke-width: 5px; paint-order: stroke; cursor: default;" + 
            "}";
        
        public override string ToString()
        {
            return $"<style>{css}</style>";
        }
    }
}
