using System.Net;
using System.Text;
using System.Threading;

namespace HttpTest
{
    internal class Program
    {
        static CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

        static void Main(string[] args)
        {
            string prefix = "http://localhost:53256/";

            var listener = new HttpListener();
            listener.Prefixes.Add(prefix);
            listener.Start();
            Console.WriteLine($"Started listening on {prefix}");

            var listeningTask = Task.Run(async () =>
            {
                try
                {
                    while (!cancellationTokenSource.IsCancellationRequested)
                    {
                        var getContextTask = listener.GetContextAsync();
                    
                        HttpListenerContext context = await getContextTask;
                        _ = Task.Run(() => ProcessRequest(context, listener));
                    }                
                }
                catch (HttpListenerException ex)
                {
                    if (cancellationTokenSource.IsCancellationRequested)
                        Console.WriteLine("Listener is stopped");
                    else
                        Console.WriteLine($"HttpListenerException: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception raised in the listening loop {ex.Message}, {ex.StackTrace}");
                }
                finally
                {
                    Console.WriteLine($"Listening loop exit. Cancellation token state: {cancellationTokenSource.IsCancellationRequested}");
                }

            });

            listeningTask.Wait();
        }

        static void ProcessRequest(HttpListenerContext context, HttpListener listener)
        {
            try
            {
                var request = context.Request;
                var response = context.Response;

                var path = request.Url?.AbsolutePath ?? "";



                Console.WriteLine($"Request processed: {request.Url}");

                if(path == "/close")
                {
                    string closeResponse = "Shutting down";
                    var closeResponseBytes = Encoding.UTF8.GetBytes(closeResponse);
                    response.ContentLength64 = closeResponseBytes.Length;

                    using (var stream = response.OutputStream)
                    {
                        stream.Write(closeResponseBytes, 0, closeResponseBytes.Length);
                    }

                    Console.WriteLine("Canceling the listening");
                    cancellationTokenSource.Cancel();
                    listener.Stop();
                    return;
                }
                else
                {
                    string basicText = "Test answer";
                    var basicTextBytes = Encoding.UTF8.GetBytes(basicText);

                    using (var stream = response.OutputStream)
                    {
                        stream.Write(basicTextBytes, 0, basicTextBytes.Length);
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception raised while processing request {ex.Message}, {ex.StackTrace}");
            }
            finally
            {
                context.Response.Close();
            }
            
        }
    }
}
