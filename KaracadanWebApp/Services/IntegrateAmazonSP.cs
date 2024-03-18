namespace KaracadanWebApp.Services
{
    public class IntegrateAmazonSP:IIntegrateAmazonSP
    {

        
        async public Task CheckOrder()
        {
            Console.WriteLine("CheckingOrder");

            using HttpClient client = new HttpClient();

            // URL to send the request to
            string url = "https://sandbox.sellingpatnerapi-na.amazon.com";

            try
            {
                // Send GET request
                HttpResponseMessage response = await client.GetAsync(url);

                // Check if the response is successful
                if (response.IsSuccessStatusCode)
                {
                    // Read the response content as string
                    string responseBody = await response.Content.ReadAsStringAsync();

                    // Output the response body
                    Console.WriteLine("Response:");
                    Console.WriteLine(responseBody);
                }
                else
                {
                    Console.WriteLine($"Failed to fetch data. Status code: {response.StatusCode}");
                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Request error: {e.Message}");
            }
        }
    }
}
