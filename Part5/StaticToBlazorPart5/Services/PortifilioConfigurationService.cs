
using System.Threading.Tasks;

//locals
using StaticToBlazorPart5.Models;

namespace StaticToBlazorPart5.Services
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

        public async Task<AboutModel> GetAbout()
        {
            AboutModel result = new AboutModel()
            {
                RightSectionMessage = "I have been building solutions for a long time and I am working on giving back to my profession, that I have enjoyed for so many years",
                LeftSectionMessage = "My goal is to provide knowledge and skills to the engineers that follow me so they can learn how to be become Software Craftsman",
                LinkToOtherResources = "http://manifesto.softwarecraftsmanship.org/",
                LinkName = "Software Craftsmanship"
            };
            await Task.CompletedTask;
            return result;
        }

    }
}
