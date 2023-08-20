using Google.Apis.Auth.OAuth2;
using Google.Apis.Keep.v1;
using Google.Apis.Keep.v1.Data;
using Google.Apis.Services;
using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace KeepApiExample
{
    public class KeepApiExample
    {
        public static async Task Main(string[] args)
        {
            // Authenticate with Google using a service account
            var credential = GoogleCredential.FromFile("infinite-bruin-394010-c8859a111069.json")
                .CreateScoped(KeepService.Scope.Keep, KeepService.Scope.KeepReadonly);

            // Create the Keep API service
            var service = new KeepService(new BaseClientService.Initializer
            {
                HttpClientInitializer = credential,
                ApplicationName = "Keep API Example"
            });

            // Create a new note
            Note body = new Note
            {
                Title = "TitleX",
                Body = new Section { }
              
            };

            //var createdNote = await service.Notes.Create(body).ExecuteAsync();
            //Console.WriteLine($"Created note with ID: {createdNote.Name}");

            //var response1 = await service.Notes.Get("stsdsdfsdf").ExecuteAsync();
          //  var notesa = await service.Notes.Get("tggg").ExecuteAsync();
            var response = await service.Notes.List().ExecuteAsync();
           // var del = await service.Notes.Delete("stddd").ExecuteAsync();
            Console.WriteLine(response.Notes);
            if (response.Notes != null)
            {
                var notes = response.Notes;
                foreach (var note in notes)
                {
                    Console.WriteLine($"Title: {note.Title}");
                    Console.WriteLine($"Content: {note.Body}");
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("No notes found.");
            }

        }
    }
}
