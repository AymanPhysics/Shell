Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Common
Imports System.Drawing

Module Md
    Public LastVersion As Integer = 64
    Public MyProject As Client = Client.El7ariry

    Public StopProfiler As Boolean = False
    Public AllowCashierToEditPrice As Boolean = False
    Public SaleQtySub As Boolean = True
    Public ShowCostCenter As Boolean = True
    Public ShowShiftForEveryStore As Boolean = False

    Public cmd As New SqlCommand
    Public con As New SqlConnection
    Public s As New SqlClient.SqlConnectionStringBuilder
    Public FourceExit As Boolean = False
    Public HasLeft As Boolean = False

    Public UserName, ArName, LevelId, Password, CompanyName, CompanyTel, Nurse, Receptionist, ShopItemsOnly, CustAccNo As String
    Public Manager As Boolean
    Public DefaultStore, DefaultSave, DefaultBank, IsCustTel As Integer
    Public EnName As String = "Please, Login", Currentpage As String = ""

    Public CurrentDate As DateTime
    Public CurrentShiftId As Integer = 0
    Public CurrentShiftName As String = ""
    Public Cashier As String = "0"
    Public UdlName As String = "Connect"
    Public IsLogedIn As Boolean = False

    Public BarcodePrinter As String = ""
    Public PonePrinter As String = ""

    Public DictionaryCurrent As New ResourceDictionary()
    Public DictionaryAr As New ResourceDictionary()
    Public DictionaryEn As New ResourceDictionary()

    Enum Client
        PCs
        El7ariry
        Shady
        AutoMarket
        MisrPetrol 'not working
    End Enum



End Module
