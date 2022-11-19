namespace jcxyis_website_v4.Features.SvgHelper
{
    public class SvgImage : SvgContentBase
    {
        /// <summary>
        /// 
        /// </summary>
        public string base64 = ""; // Convert.ToBase64String(System.IO.File.ReadAllBytes(Path.Combine(_hostEnv.WebRootPath, "polaris.png")));

        /// <summary>
        /// 
        /// </summary>
        public string href = "";  // https://i.imgur.com/FVM77ZR.png

        public override string ToString()
        {
            if(!string.IsNullOrEmpty(base64))
                return $"<image href=\"data:image/png;base64,{base64}\" {baseAttribute} />";
            else
                return $"<image href=\"{href}\" {baseAttribute} />";
        }
    }
}
