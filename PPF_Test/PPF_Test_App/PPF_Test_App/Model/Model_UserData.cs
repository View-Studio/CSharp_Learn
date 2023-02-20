using System.Net.NetworkInformation;

namespace PPF_Test_App.Model;

struct Credit
{ 
    public float V_Area { get; set; } // 필름 면적
    public int V_Times { get; set; } // 필름 사용 가능 횟수
    public Credit() // 구조체 생성자
    {
        V_Area= 0;
        V_Times= 0;
    }
}

internal class Model_UserData
{
    public string V_Name;
    public string V_MacAddress;
    public Credit V_Credit;
    public int V_Remainingdays; 

    public Model_UserData() // 생성자
    {
        V_Name = string.Empty;
        V_MacAddress = string.Empty;
        V_Credit = new Credit();
        V_Remainingdays = 0;
    }

    public string F_GetMacAddress()
    {
        string _macAddress =
            NetworkInterface.GetAllNetworkInterfaces()
            .Where(nic => nic.OperationalStatus == OperationalStatus.Up && nic.NetworkInterfaceType !=
             NetworkInterfaceType.Loopback)
            .Select(nic => nic.GetPhysicalAddress().ToString()).FirstOrDefault();

        return _macAddress;
    }
}
