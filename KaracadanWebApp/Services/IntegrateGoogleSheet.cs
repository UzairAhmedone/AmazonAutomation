using Google.Apis.Auth.OAuth2;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Microsoft.Build.Framework;

namespace KaracadanWebApp.Services
{
    public class IntegrateGoogleSheet : IIntegrateGoogleSheet
    {
        private readonly string source = "https://docs.google.com/spreadsheets/d/1ykv9Q8eR78jQyXijTlSlQf17yr13cDPnQXmaYd1c6ow/edit#gid=0";
        private readonly string spreadSheetId = "1ykv9Q8eR78jQyXijTlSlQf17yr13cDPnQXmaYd1c6ow";
        private readonly string ApplicationName = "testingintegration";
        private readonly string sheet = "sheet1";
        private readonly string[] scopes = { SheetsService.Scope.Spreadsheets };
        private SheetsService service;
        private readonly IWebHostEnvironment _env;

        public IntegrateGoogleSheet(IWebHostEnvironment env)
        {
            _env = env;
            GoogleCredential credentials;
            string filePath = Path.Combine(_env.WebRootPath, "testingintegration-417211-8358b0af2cd4.json");

            using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                // Use appropriate credentials based on your setup (e.g., service account)
                credentials = GoogleCredential.FromStream(stream).CreateScoped(scopes);
                service = new SheetsService(new Google.Apis.Services.BaseClientService.Initializer()
                {
                    HttpClientInitializer = credentials,
                    ApplicationName = ApplicationName,
                });


            }
        }
        public void ReadData()
        {
            var range = $"{sheet}!A1:F10";
            var request = service.Spreadsheets.Values.Get(spreadSheetId, range);
            var response = request.Execute();
            var value = response.Values;
            if (value != null && value.Count > 0)
            {
                foreach (var row in value)
                {
                    Console.WriteLine("dd");
                }
            }

        }

        public void InsertData()
        {
            var range = $"{sheet}!A1:F10";
            var valueRange = new ValueRange();

            var objectList = new List<object>() { "jean chapman", "the", "integration", "with", "googleApi" };

            valueRange.Values =new List<IList<object>> { objectList };
            var appendRequest=service.Spreadsheets.Values.Append(valueRange,spreadSheetId,range);
            appendRequest.ValueInputOption = SpreadsheetsResource.ValuesResource.AppendRequest.ValueInputOptionEnum.USERENTERED;
            var apppendResponse = appendRequest.Execute();
        }
    }
}
