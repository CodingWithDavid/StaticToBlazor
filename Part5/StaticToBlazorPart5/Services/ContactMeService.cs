
using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

//locals
using StaticToBlazorPart5.Models;

namespace StaticToBlazorPart5.Services
{
    public class ContactMeService
    {
        public async Task<string> SendContactMessage(ContactMeModel person)
        {
            string result = "";
            //put code here to handle the submit.  For this example, we are just witting it out to a folder
            if (!string.IsNullOrEmpty(person.Name))
            {
                try
                {
                    string fileName = $"{Environment.CurrentDirectory}/wwwroot/ContactMes/{person.Name}.contactMe";
                    TextWriter tw = new StreamWriter(fileName);
                    await tw.WriteLineAsync(JsonSerializer.Serialize(person));
                    tw.Close();
                }
                catch(Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    result = "Unable to save contact to data store";
                }
            }
            return result;
        }
    }
}
