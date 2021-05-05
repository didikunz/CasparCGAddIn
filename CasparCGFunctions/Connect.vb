Imports System
Imports Extensibility
Imports System.Runtime.InteropServices
Imports Microsoft.Win32
Imports Microsoft.Office.Interop.Excel
Imports System.Windows.Forms
Imports System.Reflection
Imports System.Threading

<GuidAttribute("c4aa97b7-8988-42cb-9054-a0dbae1c373e")>
Interface IFunctions
   Function ADDINNAME() As String
   Function RANDOMTABLE(ByVal r As Integer, ByVal c As Integer) As String
End Interface


<GuidAttribute("fb57f01f-0610-4937-86bd-2fcd684530c0"), ProgId("ExcelFunctions.Connect"), ClassInterface(ClassInterfaceType.AutoDual), ComDefaultInterface(GetType(IFunctions))>
   Public Class Connect
      Inherits Object
      Implements Extensibility.IDTExtensibility2, IFunctions

      Public Function ADDINNAME() As String Implements IFunctions.ADDINNAME
         Return "TEST"
      End Function

      Public Class ObjectParameter
         Public Property rng As Range
         Public Property r As Integer
         Public Property c As Integer
         Public Sub New(rng As Range, r As Integer, c As Integer)
            Me.rng = rng
            Me.r = r
            Me.c = c
         End Sub
      End Class

      Public Shared Sub RandHelper(parameter As Object)

         Dim op As ObjectParameter = TryCast(parameter, ObjectParameter)
         If op IsNot Nothing Then

            For rowCnt As Integer = op.rng.Row + 1 To (op.rng.Row + op.r)

               For colCnt As Integer = op.rng.Column To (op.rng.Column + op.c) - 1
                  Dim ws As Worksheet = CType(op.rng.Parent, Worksheet)
                  Dim nextCell As Range = ws.Cells(rowCnt, colCnt)
                  'nextCell.Value2 = New Random().[Next](999).ToString()
                  nextCell.Value2 = "TEST"
                  Marshal.ReleaseComObject(nextCell)
               Next
            Next

            Marshal.FinalReleaseComObject(op.rng)

         End If

      End Sub

      ''' <summary>
      ''' Generates a random able in the row and cell just
      ''' below the current cell - regardless of current
      ''' contents
      ''' </summary>
      ''' <param name="r"></param>
      ''' <param name="c"></param>
      ''' <returns></returns>
      Public Function RANDOMTABLE(ByVal r As Integer, ByVal c As Integer) As String Implements IFunctions.RANDOMTABLE
         Dim rng As Range = CType(application.get_Caller(1), Range)
         Dim trd As Thread = New Thread(AddressOf RandHelper)
         Dim op As ObjectParameter = New ObjectParameter(rng, r, c)
         trd.Start(op)
         Return "RANDOM TABLE"
      End Function

#Region "IDTExtensibility2"

      Private Shared Application As Microsoft.Office.Interop.Excel.Application
      Private Shared ThisAddIn As Object
      Private Shared fVstoRegister As Boolean = False

      Public Sub New()
      End Sub

      Public Sub Register()
         fVstoRegister = True
         RegisterFunction(GetType(Connect))
      End Sub

      Public Sub Unregister()
         UnregisterFunction(GetType(Connect))
      End Sub

      Public Sub OnConnection(ByVal application As Object, ByVal connectMode As Extensibility.ext_ConnectMode, ByVal addInInst As Object, ByRef custom As System.Array) Implements IDTExtensibility2.OnConnection
         application = TryCast(application, Microsoft.Office.Interop.Excel.Application)
         ThisAddIn = addInInst
      End Sub

      Public Sub OnDisconnection(ByVal disconnectMode As Extensibility.ext_DisconnectMode, ByRef custom As System.Array) Implements IDTExtensibility2.OnDisconnection
         Marshal.ReleaseComObject(Application)
         Application = Nothing
         ThisAddIn = Nothing
         GC.Collect()
         GC.Collect()
         GC.WaitForPendingFinalizers()
      End Sub

      Public Sub OnAddInsUpdate(ByRef custom As System.Array) Implements IDTExtensibility2.OnAddInsUpdate
      End Sub

      Public Sub OnStartupComplete(ByRef custom As System.Array) Implements IDTExtensibility2.OnStartupComplete
      End Sub

      Public Sub OnBeginShutdown(ByRef custom As System.Array) Implements IDTExtensibility2.OnBeginShutdown
      End Sub

      <ComRegisterFunctionAttribute>
      Public Shared Sub RegisterFunction(ByVal type As Type)
         Dim PATH As String = System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase.Replace("\", "/")
         Dim ASSM As String = Assembly.GetExecutingAssembly().FullName
         Dim startPos As Integer = ASSM.ToLower().IndexOf("version=") + "version=".Length
         Dim len As Integer = ASSM.ToLower().IndexOf(",", startPos) - startPos
         Dim VER As String = ASSM.Substring(startPos, len)
         Dim GUID As String = "{" + type.GUID.ToString().ToUpper() + "}"
         Dim NAME As String = type.[Namespace] + "." + type.Name
         Dim BASE As String = "Classes\" + NAME
         Dim CLSID As String = "Classes\CLSID\" + GUID

         'open the key
         Dim CU As RegistryKey = Registry.CurrentUser.OpenSubKey("Software", True)

         'is this version registered?
         Dim key As RegistryKey = CU.OpenSubKey(CLSID + "\InprocServer32\" + VER)
         If key Is Nothing Then
            'The version of this class currently being registered DOES NOT
            'exist in the registry - so we will now register it

            'BASE KEY
            'HKEY_CURRENT_USER\CLASSES\{NAME}
            key = CU.CreateSubKey(BASE)
            key.SetValue("", NAME)

            'HKEY_CURRENT_USER\CLASSES\{NAME}\CLSID}
            key = CU.CreateSubKey(BASE + "\CLSID")
            key.SetValue("", GUID)

            'CLSID
            'HKEY_CURRENT_USER\CLASSES\CLSID\{GUID}
            key = CU.CreateSubKey(CLSID)
            key.SetValue("", NAME)

            'HKEY_CURRENT_USER\CLASSES\CLSID\{GUID}\Implemented Categories
            key = CU.CreateSubKey(CLSID + "\Implemented Categories").CreateSubKey("{62C8FE65-4EBB-45e7-B440-6E39B2CDBF29}")

            'HKEY_CURRENT_USER\CLASSES\CLSID\{GUID}\InProcServer32
            key = CU.CreateSubKey(CLSID + "\InprocServer32")
            key.SetValue("", "c:\Windows\SysWow64\mscoree.dll")
            key.SetValue("ThreadingModel", "Both")
            key.SetValue("Class", NAME)
            key.SetValue("CodeBase", PATH)
            key.SetValue("Assembly", ASSM)
            key.SetValue("RuntimeVersion", "v4.0.30319")

            'HKEY_CURRENT_USER\CLASSES\CLSID\{GUID}\InProcServer32\{VERSION}
            key = CU.CreateSubKey(CLSID + "\InprocServer32\" + VER)
            key.SetValue("Class", NAME)
            key.SetValue("CodeBase", PATH)
            key.SetValue("Assembly", ASSM)
            key.SetValue("RuntimeVersion", "v4.0.30319")

            'HKEY_CURRENT_USER\CLASSES\CLSID\{GUID}\ProgId
            key = CU.CreateSubKey(CLSID + "\ProgId")
            key.SetValue("", NAME)

            'HKEY_CURRENT_USER\CLASSES\CLSID\{GUID}\Progammable
            key = CU.CreateSubKey(CLSID + "\Programmable")

            'now register the addin in the addins sub keys for each version of Office
            For Each keyName As String In Registry.CurrentUser.OpenSubKey("Software\Microsoft\Office\").GetSubKeyNames()

               If IsVersionNum(keyName) Then

                  'if the addin is found in the Add-in Manager - remove it
                  key = Registry.CurrentUser.OpenSubKey("Software\Microsoft\Office\" + keyName + "\Excel\Add-in Manager", True)
                  If key IsNot Nothing Then
                     key.SetValue(NAME, "")
                  End If
               End If
            Next

            If Not fVstoRegister Then
               MessageBox.Show("Registered " + NAME + ".")
            End If
         End If
      End Sub

      <ComUnregisterFunctionAttribute>
      Public Shared Sub UnregisterFunction(ByVal type As Type)
         Dim GUID As String = "{" + type.GUID.ToString().ToUpper() + "}"
         Dim NAME As String = type.[Namespace] + "." + type.Name
         Dim BASE As String = "Classes\" + NAME
         Dim CLSID As String = "Classes\CLSID\" + GUID
         'open the key
         Dim CU As RegistryKey = Registry.CurrentUser.OpenSubKey("Software", True)
         'DELETE BASE KEY
         'HKEY_CURRENT_USER\CLASSES\{NAME}
         Try
            CU.DeleteSubKeyTree(BASE)
         Catch
         End Try
         'HKEY_CURRENT_USER\CLASSES\{NAME}\CLSID}
         Try
            CU.DeleteSubKeyTree(CLSID)
         Catch
         End Try

         'now un-register the addin in the addins sub keys for Office
         'here we just make sure to remove it from allversions of Office
         For Each keyName As String In Registry.CurrentUser.OpenSubKey("Software\Microsoft\Office\").GetSubKeyNames()

            If IsVersionNum(keyName) Then
               Dim key As RegistryKey = Registry.CurrentUser.OpenSubKey("Software\Microsoft\Office\" + keyName + "\Excel\Add-in Manager", True)
               If key IsNot Nothing Then
                  Try
                     key.DeleteValue(NAME)
                  Catch
                  End Try
               End If

               key = Registry.CurrentUser.OpenSubKey("Software\Microsoft\Office\" + keyName + "\Excel\Options", True)
               If key Is Nothing Then Continue For

               For Each valueName As String In key.GetValueNames()
                  If valueName.StartsWith("OPEN") Then
                     If key.GetValue(valueName).ToString().Contains(NAME) Then
                        Try
                           key.DeleteValue(valueName)
                        Catch
                        End Try
                     End If
                  End If
               Next
            End If
         Next

         MessageBox.Show("Unregistered " + NAME + "!")
      End Sub

      Public Shared Function IsVersionNum(ByVal s As String) As Boolean
         Dim idx As Integer = s.IndexOf(".")

         If idx >= 0 AndAlso s.EndsWith("0") AndAlso Integer.Parse(s.Substring(0, idx)) > 0 Then
            Return True
         Else
            Return False
         End If
      End Function

#End Region

   End Class
