
using System.Threading.Tasks;

//locals
using StaticToBlazorPart3.Models;

namespace StaticToBlazorPart3.Services
{
    public class PortifilioConfigurationService
    {
        public async Task<HeaderModel> GetHeader()
        {
            HeaderModel result = new HeaderModel()
            {
                AvatarURL = "/img/MyAvator.png",
                AvatarAltText = "Coding with David",
                Name = "CodingWithDavid",
                Summary = "One engineers path to learn new and exciting things."
            };
            await Task.CompletedTask;
            return result;
        }
        public async Task<FooterModel> GetFooter()
        {
            SocialLinks sl = new SocialLinks()
            {
                TwitterLink = "https://twitter.com/CodingwithDavid",
                GitHub = "https://github.com/CodingWithDavid",
                LinkedInLink = "https://www.linkedin.com/in/davidgallivan/"
            };

            FooterModel result = new FooterModel()
            {
                About = "CodingWithDavid",
                Message = "Coding with David tries to provide free coding tips, MIT licensed",
                SocialLinks = sl
                
            };
            await Task.CompletedTask;
            return result;
        }

    }
}
