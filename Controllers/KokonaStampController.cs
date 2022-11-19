using jcxyis_website_v4.Features.SvgHelper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KokonaStamp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KokonaStampController : ControllerBase
    {
        private readonly IWebHostEnvironment _hostEnv;

        public KokonaStampController( IWebHostEnvironment hostEnv)
        {
            _hostEnv = hostEnv;
        }

        private string WwwrootImgToBase64(string fileNameInWwwroot)
        {
            return Convert.ToBase64String(System.IO.File.ReadAllBytes(Path.Combine(_hostEnv.WebRootPath, fileNameInWwwroot)));
        }


        [HttpGet]
        public IActionResult GetKokonaStamp(int score = -1, int face = -1)
        {
            if (score < 0)
                score = new Random().Next(0, 100 + 1);
            if (face < 0)
                face = new Random().Next(0, 2 + 1);

            // my svg wrapper
            Svg svg = new Svg(512, 512);
            //svg.elements.Add(new SvgStyle());

            // base
            svg.elements.Add(new SvgImage { base64 = WwwrootImgToBase64($"ココナ的印章/OUTLINE.png"), y = 0, width = 512 });
            svg.elements.Add(new SvgImage { base64 = WwwrootImgToBase64($"ココナ的印章/FLOWER_TR.png"), y = 0, width = 512 });
            svg.elements.Add(new SvgImage { base64 = WwwrootImgToBase64($"ココナ的印章/FLOWER_BL.png"), y = 0, width = 512 });

            // score
            try
            {
                int x = 85, y = 65, xgap = 77, ygap = -17;  // position param
                string s = score.ToString();
                for (int i = 0; i < s.Length; i++)
                {
                    if (s.Length == 1)
                        svg.elements.Add(new SvgImage { base64 = WwwrootImgToBase64($"ココナ的印章/{s[i]}.png"), x = x + xgap / 2f, y = y + ygap / 2f, width = 100 });
                    else
                        svg.elements.Add(new SvgImage { base64 = WwwrootImgToBase64($"ココナ的印章/{s[i]}.png"), x = x + i * xgap, y = y + i * ygap, width = 100 });
                    svg.elements.Add(new SvgImage { base64 = WwwrootImgToBase64($"ココナ的印章/SCORE_UNDERLINE.png"), x = 0, y = 5 });
                }
            }
            catch
            {
                return BadRequest("Invalid score!");
            }

            // face
            try
            {
                svg.elements.Add(new SvgImage { base64 = WwwrootImgToBase64($"ココナ的印章/Face{face}.png"), y = 0, width = 512 });
            }
            catch
            {
                return BadRequest("Invalid face index!");
            }

            return Content(svg.ToString(), "image/svg+xml; charset=utf-8");
        }
    }
}
