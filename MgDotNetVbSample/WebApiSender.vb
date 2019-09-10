Imports System.Net
Imports System.Net.Http
Imports System.Net.Http.Headers

Public Class WebApiSender

    Public Const JWT_BEARER_SCHEME As String = "Bearer"
    Private ReadOnly client As HttpClient

    Public Sub New()
        client = New HttpClient()
        client.DefaultRequestHeaders.Accept.Clear()
        client.DefaultRequestHeaders.Accept.Add(New MediaTypeWithQualityHeaderValue("application/json"))
    End Sub

    Public Async Function SendPostRequestAsync(ByVal mt As MtRequest, ByVal baseUrl As String) As Task(Of HttpResponseMessage)
        Try
            Dim resp = Await client.PostAsJsonAsync(baseUrl, mt)
            Return resp
        Catch ex As Exception
            Return New HttpResponseMessage(HttpStatusCode.InternalServerError)
        End Try
    End Function

    Public Async Function SendGetRequestAsync(ByVal url As String) As Task(Of HttpResponseMessage)
        Try
            Dim resp = Await client.GetAsync(url)
            Return resp
        Catch ex As Exception
            Return New HttpResponseMessage(HttpStatusCode.InternalServerError)
        End Try
    End Function

End Class
