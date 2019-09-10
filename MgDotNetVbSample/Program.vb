Imports System
Imports System.Web
Imports Newtonsoft.Json

Module Program

    Private ReadOnly baseUrl As String = "http://162.253.16.28:5010/api/send"
    Private api As WebApiSender

    Sub Main()

        api = New WebApiSender()
        Console.WriteLine("===============================")
        Console.WriteLine("  .NETCore MiniGateway Sample")
        Console.WriteLine("===============================")
        Console.WriteLine("To initiate, press ENTER key")
        Console.WriteLine()
        Dim request As MtRequest = New MtRequest With {
            .Username = "httpprepaid",
            .Password = "123456",
            .From = ".NET Sample",
            .[To] = "60137033242",
            .Text = ".NETCore (VBNET) sample using HTTP POST",
            .Coding = "1",
            .DlrMask = "1",
            .DlrUrl = "http://127.0.0.1:5002/api/dlr/save-json",
            .ResponseType = "json"
        }

        Do
            If Console.ReadKey(True).Key = ConsoleKey.Enter Then
                'TODO: open one method call

                SendSmsUsingPostAsync(request)
                ' SendSmsUsingGetAsync(request)
            End If
        Loop While Console.ReadKey(True).Key <> ConsoleKey.Escape

    End Sub

    Private Async Function SendSmsUsingPostAsync(ByVal request As MtRequest) As Task
        Dim stopwatch As Stopwatch = Stopwatch.StartNew()
        Console.WriteLine("Executing POST request..")
        Dim response = Await api.SendPostRequestAsync(request, baseUrl)
        Dim contentStr = Await response.Content.ReadAsStringAsync()

        If request.ResponseType = "json" Then
            Dim obj = JsonConvert.DeserializeObject(Of MtResponse)(contentStr)
        End If

        stopwatch.[Stop]()
        Console.WriteLine($"Finished. Time taken: {stopwatch.Elapsed}")
        Console.WriteLine($"Response = StatusCode: {response.StatusCode}, Content: {contentStr}")
        Console.WriteLine()
        Console.WriteLine("To resend, press ENTER key 2x")
        Console.WriteLine("To exit, press ESC key")
        Console.WriteLine()
    End Function

    Private Async Function SendSmsUsingGetAsync(ByVal request As MtRequest) As Task
        Dim stopwatch As Stopwatch = Stopwatch.StartNew()
        Console.WriteLine("Executing GET request..")
        Dim url = $"{baseUrl}?" & $"{MtRequest.GW_USERNAME}={request.Username}&" & $"{MtRequest.GW_PASSWORD}={request.Password}&" & $"{MtRequest.GW_FROM}={HttpUtility.UrlEncode(request.From)}&" & $"{MtRequest.GW_TO}={HttpUtility.UrlEncode(request.[To])}&" & $"{MtRequest.GW_TEXT}={HttpUtility.UrlEncode(request.Text)}&" & $"{MtRequest.GW_CODING}={request.Coding}&" & $"{MtRequest.GW_DLR_MASK}={request.DlrMask}&" & $"{MtRequest.GW_DLR_URL}={request.DlrUrl}&" & $"{MtRequest.GW_RESP_TYPE}={request.ResponseType}"
        Dim response = Await api.SendGetRequestAsync(url)
        Dim contentStr As String = Await response.Content.ReadAsStringAsync()

        If request.ResponseType = "json" Then
            Dim obj = JsonConvert.DeserializeObject(Of MtResponse)(contentStr)
        End If

        stopwatch.[Stop]()
        Console.WriteLine($"Finished. Time taken: {stopwatch.Elapsed}")
        Console.WriteLine($"Response = StatusCode: {response.StatusCode}, Content: {contentStr}")
        Console.WriteLine()
        Console.WriteLine("To resend, press ENTER key 2x")
        Console.WriteLine("To exit, press ESC key")
        Console.WriteLine()
    End Function

End Module


