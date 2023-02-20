using PPF_Test_App.Model;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using static System.Net.Mime.MediaTypeNames;
using System.IO;

namespace PPF_Test_App.ViewModel;
internal class ViewModel_MainPage : ObservableObject
{
    private Model_UserData V_UserData;
    public string V_name 
    {
        get => V_UserData.V_Name; 
        set {
            V_UserData.V_Name = value;
            OnPropertyChanged();
        }
    }
    public int V_remainingDays
    {
        get => V_UserData.V_Remainingdays;
        set {
            V_UserData.V_Remainingdays = value;
            OnPropertyChanged();
        }
    }
    public string V_macAddress
    {
        get => V_UserData.V_MacAddress;
        set {
            V_UserData.V_MacAddress = value;
            OnPropertyChanged();
        }
    }
    public float V_area
    {
        get => V_UserData.V_Credit.V_Area;
        set { 
            V_UserData.V_Credit.V_Area = value; 
            OnPropertyChanged();
        }
    }
    public int V_times
    {
        get => V_UserData.V_Credit.V_Times;
        set
        {
            V_UserData.V_Credit.V_Times = value;
        }
    }
    public ICommand C_LoginCheckCommand { get; private set; }



    // ========================================================================



    public ViewModel_MainPage() // 생성자
    {
        V_UserData = new Model_UserData();
        C_LoginCheckCommand = new AsyncRelayCommand(F_IsLogin);
    }



    // ========================================================================



    public bool F_CreditCheck(Credit credit)
    {
        if (credit.V_Times > 0)
            return true;
        else
            return false;
    }

    public Credit F_GetCredit()
    {
        return V_UserData.V_Credit;
    }

    public bool F_RemainDaysCheck(int remainDays)
    {
        if (remainDays > 0)
            return true;
        else
            return false;
    }

    public int GetRemaingdays()
    {
        return V_UserData.V_Remainingdays;
    }

    private async Task F_IsLogin()
    {
        if ("KDSALFJ612IUG36lkn3IBloi" == F_GetAuthToken())
        {
            V_name = "경민";
            V_remainingDays = 213;
            V_area = 64.53f;
            V_times = 10;
            V_macAddress = V_UserData.F_GetMacAddress();

            await Shell.Current.GoToAsync(nameof(View.CanvasPage));
        }
            
    }

    public string F_GetAuthToken()
    {
        string filename = System.IO.Path.Combine(@"C:\Users\SoulX\Desktop", "AuthToken.txt");
        string Text = File.ReadAllText(filename);

        return Text;
    }
}
