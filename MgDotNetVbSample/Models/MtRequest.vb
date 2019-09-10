Imports Newtonsoft.Json

Public Class MtRequest

    Public Const GW_USERNAME As String = "gw-username"
    Public Const GW_PASSWORD As String = "gw-password"
    Public Const GW_FROM As String = "gw-from"
    Public Const GW_TO As String = "gw-to"
    Public Const GW_TEXT As String = "gw-text"
    Public Const GW_CODING As String = "gw-coding"
    Public Const GW_DLR_MASK As String = "gw-dlr-mask"
    Public Const GW_DLR_URL As String = "gw-dlr-url"
    Public Const GW_RESP_TYPE As String = "gw-resp-type"

    <JsonProperty(PropertyName:=GW_USERNAME)>
    Public Property Username As String
    <JsonProperty(PropertyName:=GW_PASSWORD)>
    Public Property Password As String
    <JsonProperty(PropertyName:=GW_FROM)>
    Public Property From As String
    <JsonProperty(PropertyName:=GW_TO)>
    Public Property [To] As String
    <JsonProperty(PropertyName:=GW_TEXT)>
    Public Property Text As String
    <JsonProperty(PropertyName:=GW_CODING)>
    Public Property Coding As String
    <JsonProperty(PropertyName:=GW_DLR_MASK)>
    Public Property DlrMask As String
    <JsonProperty(PropertyName:=GW_DLR_URL)>
    Public Property DlrUrl As String
    <JsonProperty(PropertyName:=GW_RESP_TYPE)>
    Public Property ResponseType As String

End Class
