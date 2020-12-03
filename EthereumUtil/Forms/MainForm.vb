
Imports Nethereum.Web3
Imports Nethereum.Util
Imports Nethereum.RPC

Public Class MainForm

    Private Sub btnExec_Click(sender As Object, e As EventArgs) Handles btnExec.Click
        Call GetBalance()
    End Sub

    Private Async Sub GetBalance()
        ' from account - account we are transferring from
        Dim privateKey As New Nethereum.Signer.EthECKey("0000000000000000000000000000000000000000000000000000000000000001")
        Dim account = New Nethereum.Web3.Accounts.Account(privateKey)
        Dim stopMe As Boolean = False

        While stopMe <> True
            Label1.Text = "Checking to see if it is happening..."
            Label1.Refresh()

            Dim iweb3 = New Web3(account, "https://cloudflare-eth.com")

            Dim contractAddress = "0x00000000219ab540356cBB839Cbe05303d7705Fa"
            Dim balance = Await iweb3.Eth.GetBalance.SendRequestAsync("0x00000000219ab540356cBB839Cbe05303d7705Fa")

            If balance.Value >= Web3.Convert.ToWei(1000000, UnitConversion.EthUnit.Ether) Then
                MsgBox("IT HAPPENED!")
                stopMe = True
            Else
                Label1.Text = "Checking to see if it is happening.... Nope. Not yet. Sleep for 5 secs first."
                Label1.Refresh()
                System.Threading.Thread.Sleep(5000)
            End If
        End While
    End Sub

End Class
